using System.Security.Cryptography.X509Certificates;
using HalloJoe.X509Certificate2Builder.Finders;

namespace HalloJoe.X509Certificate2Builder.Resolvers
{
    public class FindCertificateResolver : ICertificateResolver
    {
        private readonly IFindCertificateConfiguration _certificateContext;

        public FindCertificateResolver(IFindCertificateConfiguration certificateContext)
        {
            _certificateContext = certificateContext;
        }

        public X509Certificate2Collection Resolve()
        {
            var store = new X509Store(
                _certificateContext.StoreName, 
                _certificateContext.StoreLocation);
            store.Open(OpenFlags.ReadOnly);

            return store.Certificates.Find(
                _certificateContext.X509FindType, 
                _certificateContext.X509FindValue, true);
        }
    }
}