using System.Security.Cryptography.X509Certificates;

namespace HalloJoe.X509Certificate2Builder.Finders
{
    /// <summary>
    /// Configuration for finding a X509Certificate2Collection.
    /// </summary>
    public interface IFindCertificateConfiguration
    {
        StoreName StoreName { get; set; }
        StoreLocation StoreLocation { get; set; }
        X509FindType X509FindType { get; set; }
        object X509FindValue { get; set; }
    }
}