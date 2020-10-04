using System.Security.Cryptography.X509Certificates;

namespace HalloJoe.X509Certificate2Builder.Importers
{
    /// <summary>
    /// Configuration for importing a X509Certificate2Collection.
    /// </summary>
    public interface IImportCertificateConfiguration
    {
        string FileName { get; set; }
        string Password { get; set; }
        X509KeyStorageFlags X509KeyStorageFlags { get; set; }
    }
}