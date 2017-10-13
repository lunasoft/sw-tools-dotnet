using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SW.Tools.Helpers
{
    public static class Encodins
    {
        public static string EncodeTo64(string toEncode)
        {
            UTF8Encoding encoding = new System.Text.UTF8Encoding();
            byte[] toEncodeAsBytes = encoding.GetBytes(toEncode);
            string returnValue = Convert.ToBase64String(toEncodeAsBytes);
            return returnValue;
        }
        public static string DecodeFrom64(string m_enc)
        {
            byte[] encodedDataAsBytes = Convert.FromBase64String(m_enc);
            string returnValue = System.Text.Encoding.UTF8.GetString(encodedDataAsBytes);
            return returnValue;
        }
        public static string HeadecimalStringToASCII(string hexadecimalString)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i <= hexadecimalString.Length - 2; i += 2)
            {
                sb.Append(Convert.ToString(Convert.ToChar(Int32.Parse(hexadecimalString.Substring(i, 2), System.Globalization.NumberStyles.HexNumber))));
            }
            return sb.ToString();
        }
        public static string UTF8ByteArrayToString(byte[] characters)
        {
            UTF8Encoding encoding = new UTF8Encoding();
            string constructedString = encoding.GetString(characters);
            return (constructedString);
        }
        public static Byte[] StringToUTF8ByteArray(string pXmlString)
        {
            UTF8Encoding encoding = new UTF8Encoding();
            byte[] byteArray = encoding.GetBytes(pXmlString);
            return byteArray;
        }
        public static string FromB64ToStringUTF8(string str)
        {
            UTF8Encoding encodin = new UTF8Encoding();
            return encodin.GetString(Convert.FromBase64String(str));
        }
    }
}
