using System;
using System.Security.Cryptography;
using SystemX509 = System.Security.Cryptography.X509Certificates;
using Org.BouncyCastle.Asn1.X509;
using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Crypto.Parameters;
using Org.BouncyCastle.Math;
using Org.BouncyCastle.X509;
using Org.BouncyCastle.Asn1.Pkcs;

namespace SW.Tools
{
    /// <summary>
    /// A class containing methods to interface the BouncyCastle world to the .NET Crypto world.
    /// </summary>
    internal sealed class DotNetUtilitiesCustom
    {
        private DotNetUtilitiesCustom()
        {
        }

        /// <summary>
        /// Create an System.Security.Cryptography.X509Certificate from an X509Certificate Structure.
        /// </summary>
        /// <param name="x509Struct"></param>
        /// <returns>A System.Security.Cryptography.X509Certificate.</returns>
        internal static SystemX509.X509Certificate ToX509Certificate(
            X509CertificateStructure x509Struct)
        {
            return new SystemX509.X509Certificate(x509Struct.GetDerEncoded());
        }

        internal static SystemX509.X509Certificate ToX509Certificate(
            X509Certificate x509Cert)
        {
            return new SystemX509.X509Certificate(x509Cert.GetEncoded());
        }

        internal static X509Certificate FromX509Certificate(
            SystemX509.X509Certificate x509Cert)
        {
            return new X509CertificateParser().ReadCertificate(x509Cert.GetRawCertData());
        }

        internal static AsymmetricCipherKeyPair GetDsaKeyPair(
            DSA dsa)
        {
            return GetDsaKeyPair(dsa.ExportParameters(true));
        }

        internal static AsymmetricCipherKeyPair GetDsaKeyPair(
            DSAParameters dp)
        {
            DsaValidationParameters validationParameters = (dp.Seed != null)
                ? new DsaValidationParameters(dp.Seed, dp.Counter)
                : null;

            DsaParameters parameters = new DsaParameters(
                new BigInteger(1, dp.P),
                new BigInteger(1, dp.Q),
                new BigInteger(1, dp.G),
                validationParameters);

            DsaPublicKeyParameters pubKey = new DsaPublicKeyParameters(
                new BigInteger(1, dp.Y),
                parameters);

            DsaPrivateKeyParameters privKey = new DsaPrivateKeyParameters(
                new BigInteger(1, dp.X),
                parameters);

            return new AsymmetricCipherKeyPair(pubKey, privKey);
        }

        internal static DsaPublicKeyParameters GetDsaPublicKey(
            DSA dsa)
        {
            return GetDsaPublicKey(dsa.ExportParameters(false));
        }

        internal static DsaPublicKeyParameters GetDsaPublicKey(
            DSAParameters dp)
        {
            DsaValidationParameters validationParameters = (dp.Seed != null)
                ? new DsaValidationParameters(dp.Seed, dp.Counter)
                : null;

            DsaParameters parameters = new DsaParameters(
                new BigInteger(1, dp.P),
                new BigInteger(1, dp.Q),
                new BigInteger(1, dp.G),
                validationParameters);

            return new DsaPublicKeyParameters(
                new BigInteger(1, dp.Y),
                parameters);
        }

        internal static AsymmetricCipherKeyPair GetRsaKeyPair(
            RSA rsa)
        {
            return GetRsaKeyPair(rsa.ExportParameters(true));
        }

        internal static AsymmetricCipherKeyPair GetRsaKeyPair(
            RSAParameters rp)
        {
            BigInteger modulus = new BigInteger(1, rp.Modulus);
            BigInteger pubExp = new BigInteger(1, rp.Exponent);

            RsaKeyParameters pubKey = new RsaKeyParameters(
                false,
                modulus,
                pubExp);

            RsaPrivateCrtKeyParameters privKey = new RsaPrivateCrtKeyParameters(
                modulus,
                pubExp,
                new BigInteger(1, rp.D),
                new BigInteger(1, rp.P),
                new BigInteger(1, rp.Q),
                new BigInteger(1, rp.DP),
                new BigInteger(1, rp.DQ),
                new BigInteger(1, rp.InverseQ));

            return new AsymmetricCipherKeyPair(pubKey, privKey);
        }

        internal static RsaKeyParameters GetRsaPublicKey(
            RSA rsa)
        {
            return GetRsaPublicKey(rsa.ExportParameters(false));
        }

        internal static RsaKeyParameters GetRsaPublicKey(
            RSAParameters rp)
        {
            return new RsaKeyParameters(
                false,
                new BigInteger(1, rp.Modulus),
                new BigInteger(1, rp.Exponent));
        }

        internal static AsymmetricCipherKeyPair GetKeyPair(AsymmetricAlgorithm privateKey)
        {
            if (privateKey is DSA)
            {
                return GetDsaKeyPair((DSA)privateKey);
            }

            if (privateKey is RSA)
            {
                return GetRsaKeyPair((RSA)privateKey);
            }

            throw new ArgumentException("Unsupported algorithm specified", "privateKey");
        }

        internal static RSA ToRSA(RsaKeyParameters rsaKey)
        {
            // TODO This appears to not work for private keys (when no CRT info)
            return CreateRSAProvider(ToRSAParameters(rsaKey));
        }

        internal static RSA ToRSA(RsaPrivateCrtKeyParameters privKey)
        {
            return CreateRSAProvider(ToRSAParameters(privKey));
        }

        internal static RSA ToRSA(RsaPrivateKeyStructure privKey)
        {
            return CreateRSAProvider(ToRSAParameters(privKey));
        }

        internal static RSAParameters ToRSAParameters(RsaKeyParameters rsaKey)
        {
            RSAParameters rp = new RSAParameters();
            rp.Modulus = rsaKey.Modulus.ToByteArrayUnsigned();
            if (rsaKey.IsPrivate)
                rp.D = ConvertRSAParametersField(rsaKey.Exponent, rp.Modulus.Length);
            else
                rp.Exponent = rsaKey.Exponent.ToByteArrayUnsigned();
            return rp;
        }

        internal static RSAParameters ToRSAParameters(RsaPrivateCrtKeyParameters privKey)
        {
            RSAParameters rp = new RSAParameters();
            rp.Modulus = privKey.Modulus.ToByteArrayUnsigned();
            rp.Exponent = privKey.PublicExponent.ToByteArrayUnsigned();
            rp.P = privKey.P.ToByteArrayUnsigned();
            rp.Q = privKey.Q.ToByteArrayUnsigned();
            rp.D = ConvertRSAParametersField(privKey.Exponent, rp.Modulus.Length);
            rp.DP = ConvertRSAParametersField(privKey.DP, rp.P.Length);
            rp.DQ = ConvertRSAParametersField(privKey.DQ, rp.Q.Length);
            rp.InverseQ = ConvertRSAParametersField(privKey.QInv, rp.Q.Length);
            return rp;
        }

        internal static RSAParameters ToRSAParameters(RsaPrivateKeyStructure privKey)
        {
            RSAParameters rp = new RSAParameters();
            rp.Modulus = privKey.Modulus.ToByteArrayUnsigned();
            rp.Exponent = privKey.PublicExponent.ToByteArrayUnsigned();
            rp.P = privKey.Prime1.ToByteArrayUnsigned();
            rp.Q = privKey.Prime2.ToByteArrayUnsigned();
            rp.D = ConvertRSAParametersField(privKey.PrivateExponent, rp.Modulus.Length);
            rp.DP = ConvertRSAParametersField(privKey.Exponent1, rp.P.Length);
            rp.DQ = ConvertRSAParametersField(privKey.Exponent2, rp.Q.Length);
            rp.InverseQ = ConvertRSAParametersField(privKey.Coefficient, rp.Q.Length);
            return rp;
        }

        // TODO Move functionality to more general class
        private static byte[] ConvertRSAParametersField(BigInteger n, int size)
        {
            byte[] bs = n.ToByteArrayUnsigned();

            if (bs.Length == size)
                return bs;

            if (bs.Length > size)
                throw new ArgumentException("Specified size too small", "size");

            byte[] padded = new byte[size];
            Array.Copy(bs, 0, padded, size - bs.Length, bs.Length);
            return padded;
        }

        private static RSA CreateRSAProvider(RSAParameters rp)
        {
            CspParameters csp = new CspParameters();
            csp.KeyContainerName = string.Format("BouncyCastle-{0}", Guid.NewGuid());
            csp.Flags = CspProviderFlags.UseMachineKeyStore;
            RSACryptoServiceProvider rsaCsp = new RSACryptoServiceProvider(csp);
            rsaCsp.ImportParameters(rp);
            return rsaCsp;
        }
    }
}
