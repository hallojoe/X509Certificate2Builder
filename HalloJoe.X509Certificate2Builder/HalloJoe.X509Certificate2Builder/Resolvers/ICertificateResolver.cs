using System.Security.Cryptography.X509Certificates;

namespace HalloJoe.X509Certificate2Builder.Resolvers
{
    public interface ICertificateResolver
    {
        X509Certificate2Collection Resolve();
    }
}
