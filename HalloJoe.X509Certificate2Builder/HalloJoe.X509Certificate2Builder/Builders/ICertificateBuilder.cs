using System.Security.Cryptography.X509Certificates;

namespace HalloJoe.X509Certificate2Builder.Builders
{
    public interface ICertificateBuilder
    {
        /// <summary>
        /// Build a X509Certificate2, including private key.
        /// </summary>
        /// <returns></returns>
        X509Certificate2 Build();
        /// <summary>
        /// Export X509Certificate2 as byte array, including private key.
        /// </summary>
        /// <returns></returns>
        byte[] Export();
    }
}
