using System.Security.Cryptography.X509Certificates;

namespace HalloJoe.X509Certificate2Builder.Importers
{
    public class ImportFileCertificateConfiguration : IImportCertificateConfiguration
    {
        public string FileName { get; set; }
        public string Password { get; set; }

        public X509KeyStorageFlags X509KeyStorageFlags { get; set; } =
            X509KeyStorageFlags.MachineKeySet | X509KeyStorageFlags.PersistKeySet;
    }
}
