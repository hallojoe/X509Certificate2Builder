using System;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;

namespace HalloJoe.X509Certificate2Builder.Builders
{
    public class CertificateBuilderConfiguration : ICertificateBuilderConfiguration
    {
        public CertificateTypes CertificateType { get; set; }

        public string CertificateName { get; set; } = "cert_" + DateTime.Now.Ticks;

        public string CertificatePassword { get; set; } = "password";

        public int KeySizeInBits { get; set; } = 2048;

        public int ExpiresInDays { get; set; } = 3650;

        public X509Certificate2 Issuer { get; set; } = null;

        // TODO: Will usage flags in the end translate to OID's? If so then CertificateType can be removed + some code. 
        public X509KeyUsageFlags X509KeyUsageFlags { get; set; }

        public X509ContentType X509ContentType { get; set; } = X509ContentType.Pfx;

        public X509KeyStorageFlags X509KeyStorageFlags { get; set; } = X509KeyStorageFlags.MachineKeySet;

        public HashAlgorithmName HashAlgorithmName { get; set; } = HashAlgorithmName.SHA256;

        public RSASignaturePadding RsaSignaturePadding { get; set; } = RSASignaturePadding.Pkcs1;

        public string[] DnsNames { get; set; } = { };
    }
}
