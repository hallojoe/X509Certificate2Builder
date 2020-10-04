using System;
using System.IO;
using System.Security.Cryptography.X509Certificates;
using HalloJoe.X509Certificate2Builder;
using HalloJoe.X509Certificate2Builder.Builders;

namespace HalloJoe.X509CertificateBuilder.TestApp
{
    class Program
    {
        static string _path;
        static string _name;
        const string DotPfx = ".pfx";
        const string DefaultName = "Test";
        const string RootCaPattern = " Root";
        const string ServerPattern = " Server";
        const string ClientPattern = " Client";

        static void Main(string[] args)
        {
            Console.WriteLine("Type the path to directory where certificate(s) should be saved to...");

            _path = Console.ReadLine();

            if (!Directory.Exists(_path)) Directory.CreateDirectory(_path);

            Console.WriteLine("Type certificate naming prefix...");

            _name = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(_name)) _name = DefaultName;

            var selfSignedRootCaContext = new CertificateBuilderConfiguration()
            {
                CertificateType = CertificateTypes.Signing,
                CertificateName = $"{_name} {RootCaPattern}",
                X509KeyUsageFlags = X509KeyUsageFlags.KeyCertSign, 
                X509ContentType = X509ContentType.Cert
            };

            var selfSignedRootCaBuilder = new X500Certificate2Builder(selfSignedRootCaContext);
            
            var selfSignedRootCaCertificateData = selfSignedRootCaBuilder.Export();

            var signedRootCaCertificatePath = Path.Join(_path, selfSignedRootCaContext.CertificateName + Constants.X509ContentTypeFileExtensions[selfSignedRootCaContext.X509ContentType]);

            File.WriteAllBytes(signedRootCaCertificatePath.Replace(" ", "-"), selfSignedRootCaCertificateData);

            // --------

            //var selfSignedRootCaCertificate = selfSignedRootCaBuilder.BuildFromExport(selfSignedRootCaCertificateData);

            //var signedServerConfiguration = new CertificateBuilderConfiguration()
            //{
            //    Issuer = selfSignedRootCaCertificate,
            //    CertificateType = CertificateTypes.Server,
            //    CertificateName = $"{_name} {ServerPattern}",
            //    X509ContentType = X509ContentType.Cert

            //};

            //var signedServerBuilder = new X500Certificate2Builder(signedServerConfiguration);

            //var signedServerCertificateData = signedServerBuilder.Export();

            //var signedServerCertificate = signedServerBuilder.BuildFromExport(signedServerCertificateData);


            //var signedClientContext = new CertificateBuilderConfiguration()
            //{
            //    Issuer = selfSignedRootCaCertificate,
            //    CertificateType = CertificateTypes.Client,
            //    CertificateName = $"{_name} {ClientPattern}",
            //    X509ContentType = X509ContentType.Cert
            //};

            //var signedClientCertificateData = new X500Certificate2Builder(signedClientContext).Export();


            //var signedServerCertificatePath = Path.Join(_path, signedServerConfiguration.CertificateName + Constants.X509ContentTypeFileExtensions[signedServerConfiguration.X509ContentType]);

            //var signedClientCertificatePath = Path.Join(_path, signedClientContext.CertificateName + Constants.X509ContentTypeFileExtensions[selfSignedRootCaContext.X509ContentType]);


            //File.WriteAllBytes(signedClientCertificatePath.Replace(" ", "-"), signedClientCertificateData);

            //File.WriteAllBytes(signedServerCertificatePath.Replace(" ", "-"), signedServerCertificateData);



        }
    }
}
