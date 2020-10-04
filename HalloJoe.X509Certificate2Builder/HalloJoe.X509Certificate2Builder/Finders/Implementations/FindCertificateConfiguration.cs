using System.Security.Cryptography.X509Certificates;

namespace HalloJoe.X509Certificate2Builder.Finders
{
    public class FindCertificateConfiguration : IFindCertificateConfiguration
    {
        public FindCertificateConfiguration(object x509FindValue)
        {
            X509FindValue = x509FindValue;
        }

        public StoreName StoreName { get; set; } = StoreName.My;
        public StoreLocation StoreLocation { get; set; } = StoreLocation.LocalMachine;
        public X509FindType X509FindType { get; set; } = X509FindType.FindBySubjectName;
        public object X509FindValue { get; set; }
    }
}