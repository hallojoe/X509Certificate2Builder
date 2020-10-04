using System;
using System.Net;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;

namespace HalloJoe.X509Certificate2Builder.Builders
{
    public abstract class BaseCertificateBuilder : ICertificateBuilder
    {
        private readonly ICertificateBuilderConfiguration _certificateBuilderConfiguration;

        protected BaseCertificateBuilder(ICertificateBuilderConfiguration certificateBuilderConfiguration)
        {
            _certificateBuilderConfiguration = certificateBuilderConfiguration;
        }

        protected X509Extension BuildSubjectAlternativeName()
        {
            var subjectAlternativeNameBuilder = new SubjectAlternativeNameBuilder();
            subjectAlternativeNameBuilder.AddIpAddress(IPAddress.Loopback);
            subjectAlternativeNameBuilder.AddIpAddress(IPAddress.IPv6Loopback);

            foreach (var dnsName in _certificateBuilderConfiguration.DnsNames) subjectAlternativeNameBuilder.AddDnsName(dnsName);
                
            subjectAlternativeNameBuilder.AddDnsName(Environment.MachineName);

            return subjectAlternativeNameBuilder.Build();
        }

        protected virtual X500DistinguishedName BuildX500DistinguishedName() =>
            new X500DistinguishedName(string.Format(Constants.X500DistinguishedNameFormat,
                _certificateBuilderConfiguration.CertificateName, "Test", "Development", "DK"));


        public X509Certificate2 Build() => BuildFromExport(Export());

        public X509Certificate2 BuildFromExport(byte[] exportedCertificateRawData)
        {
            return new X509Certificate2(
                exportedCertificateRawData,
                _certificateBuilderConfiguration.CertificatePassword,
                _certificateBuilderConfiguration.X509KeyStorageFlags);
        }

        public virtual byte[] Export()
        {
            using var ephemeralRsa = RSA.Create(_certificateBuilderConfiguration.KeySizeInBits);

            var request = new CertificateRequest(
                BuildX500DistinguishedName(),
                ephemeralRsa,
                _certificateBuilderConfiguration.HashAlgorithmName,
                _certificateBuilderConfiguration.RsaSignaturePadding);

            request.CertificateExtensions.Add(
                new X509KeyUsageExtension(_certificateBuilderConfiguration.X509KeyUsageFlags, false));
           
            if(_certificateBuilderConfiguration.Issuer == null)
                request.CertificateExtensions.Add(
                    new X509BasicConstraintsExtension(true, false, -1, false));

            switch (_certificateBuilderConfiguration.CertificateType)
            {
                case CertificateTypes.Server:
                    request.CertificateExtensions.Add(new X509EnhancedKeyUsageExtension(Constants.ServerCertificate, false));
                    break;
                case CertificateTypes.Client:
                    request.CertificateExtensions.Add(new X509EnhancedKeyUsageExtension(Constants.ClientCertificate, false));
                    break;
                case CertificateTypes.Signing:
                    request.CertificateExtensions.Add(new X509EnhancedKeyUsageExtension(Constants.SigningCertificate, false));
                    break;
                default:
                    throw new InvalidOperationException();
            }

            request.CertificateExtensions.Add(BuildSubjectAlternativeName());

            var notBefore = _certificateBuilderConfiguration.Issuer?.NotBefore ?? DateTime.UtcNow.AddDays(-1);
            var notAfter = _certificateBuilderConfiguration.Issuer?.NotAfter ?? DateTime.UtcNow.AddDays(_certificateBuilderConfiguration.ExpiresInDays);

            var certificate = _certificateBuilderConfiguration.Issuer == null
                ? request.CreateSelfSigned(notBefore, notAfter)
                : request.Create(_certificateBuilderConfiguration.Issuer, 
                    notBefore, 
                    notAfter,   
                    _certificateBuilderConfiguration.Issuer.GetSerialNumber());

            certificate.FriendlyName = _certificateBuilderConfiguration.CertificateName;

            var exportedCertificate = _certificateBuilderConfiguration.Issuer == null
                ? certificate.Export(
                    _certificateBuilderConfiguration.X509ContentType,
                    _certificateBuilderConfiguration.CertificatePassword)
                : certificate.CopyWithPrivateKey(ephemeralRsa).Export(
                    _certificateBuilderConfiguration.X509ContentType,
                    _certificateBuilderConfiguration.CertificatePassword);

            return exportedCertificate;
        }
    }
}
