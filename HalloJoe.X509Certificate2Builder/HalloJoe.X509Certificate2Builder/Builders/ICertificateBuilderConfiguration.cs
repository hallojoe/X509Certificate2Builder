using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;

namespace HalloJoe.X509Certificate2Builder.Builders
{
    /// <summary>
    /// Configuration for generating X509Certificate2.
    /// </summary>
    public interface ICertificateBuilderConfiguration
    {
        /// <summary>
        /// The name of the certificate being issued.
        /// </summary>
        string CertificateName { get; }
        /// <summary>
        /// The password of the certificate being issued.
        /// </summary>
        string CertificatePassword { get; }
        /// <summary>
        /// The key size in bits of the certificate being issued.
        /// </summary>
        int KeySizeInBits { get; }
        /// <summary>
        /// The amount of days before certificate being issued expire.
        /// </summary>
        int ExpiresInDays { get; }
        /// <summary>
        /// Dns names to add to the certificate being issued.
        /// </summary>
        string[] DnsNames { get; }
        /// <summary>
        /// Issuer. If null then self-signed it is.
        /// </summary>
        X509Certificate2 Issuer { get; }
        /// <summary>
        /// Certificate type 
        /// </summary>
        CertificateTypes CertificateType { get; }
        /// <summary>
        /// Usage flags of the certificate being issued.
        /// </summary>
        X509KeyUsageFlags X509KeyUsageFlags { get; }
        /// <summary>
        /// Content type of the certificate being issued.
        /// </summary>
        X509ContentType X509ContentType { get; }
        /// <summary>
        /// Storage flags of the certificate being issued.
        /// </summary>
        X509KeyStorageFlags X509KeyStorageFlags { get; }
        /// <summary>
        /// The hash algorithm of the certificate being issued.
        /// </summary>
        HashAlgorithmName HashAlgorithmName { get; }
        /// <summary>
        /// The signature padding strategy of the certificate being issued.
        /// </summary>
        RSASignaturePadding RsaSignaturePadding { get; }
    }
}
