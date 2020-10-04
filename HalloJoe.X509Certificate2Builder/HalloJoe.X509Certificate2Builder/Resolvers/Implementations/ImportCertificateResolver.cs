using System.Security.Cryptography.X509Certificates;
using HalloJoe.X509Certificate2Builder.Importers;

namespace HalloJoe.X509Certificate2Builder.Resolvers
{
    public class ImportCertificateResolver : ICertificateResolver
    {
        private readonly IImportCertificateConfiguration _importCertificateContext;

        public ImportCertificateResolver(IImportCertificateConfiguration importCertificateContext)
        {
            _importCertificateContext = importCertificateContext;
        }

        public X509Certificate2Collection Resolve()
        {
            var certificates = new X509Certificate2Collection();
            certificates.Import(
                _importCertificateContext   .FileName, 
                _importCertificateContext   .Password, 
                _importCertificateContext   .X509KeyStorageFlags);
            return certificates;
        }
    }
}