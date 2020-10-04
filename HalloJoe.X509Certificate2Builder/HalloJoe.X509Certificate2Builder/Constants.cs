using System.Collections.Generic;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;

namespace HalloJoe.X509Certificate2Builder
{
    public static class Constants
    {
        public const string X500DistinguishedNameFormat = "CN={0},O={1},OU={2},C={3}";
        public static readonly OidCollection ServerCertificate =  new OidCollection { new Oid("1.3.6.1.5.5.7.3.1") }; // id-kp-serverAuth(1)
        public static readonly OidCollection ClientCertificate =  new OidCollection { new Oid("1.3.6.1.5.5.7.3.2") }; // id-kp-clientAuth(2)
        public static readonly OidCollection SigningCertificate = new OidCollection { new Oid("1.3.6.1.5.5.7.3.3") }; // id-kp-codeSigning(3)
        public static readonly OidCollection EmailCertificate =   new OidCollection { new Oid("1.3.6.1.5.5.7.3.4") }; // id-kp-emailProtection(4)

        public static readonly Dictionary<X509ContentType, string> X509ContentTypeFileExtensions = new Dictionary<X509ContentType, string>()
        {
            { X509ContentType.Unknown, ".txt"},
            { X509ContentType.Cert, ".crt"},
            { X509ContentType.Authenticode, ".txt"},
            { X509ContentType.Pkcs12, ".pfx"},
            { X509ContentType.Pkcs7, ".pfx7"},
            { X509ContentType.SerializedCert, ".xml"},
            { X509ContentType.SerializedStore, ".xml"},
        };

    }
}
