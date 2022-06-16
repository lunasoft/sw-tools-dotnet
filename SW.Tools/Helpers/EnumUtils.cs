using SW.Tools.Catalogs;
using SW.Tools.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace SW.Tools.Helpers
{
    public static class EnumUtils
    {
        public static string GetXmlEnumAttributeValueFromEnum<TEnum>(this TEnum value) where TEnum : struct, IConvertible
        {
            var enumType = typeof(TEnum);
            if (!enumType.IsEnum) return null;//or string.Empty, or throw exception

            if (!value.ToString().Contains("Item"))
                return value.ToString();

            var member = enumType.GetMember(value.ToString()).FirstOrDefault();
            if (member == null) return null;//or string.Empty, or throw exception

            var attribute = member.GetCustomAttributes(false).OfType<XmlEnumAttribute>().FirstOrDefault();
            if (attribute == null) return null;//or string.Empty, or throw exception
            return attribute.Name;
        }

        public static string GetString(this c_FormaPago value)
        {
            return GetXmlEnumAttributeValueFromEnum<c_FormaPago>(value);
        }
        public static string GetString(this c_Moneda value)
        {
            return GetXmlEnumAttributeValueFromEnum<c_Moneda>(value);
        }
        public static string GetString(this c_Pais value)
        {
            return GetXmlEnumAttributeValueFromEnum<c_Pais>(value);
        }
        public static string GetString(this c_MetodoPago value)
        {
            return GetXmlEnumAttributeValueFromEnum<c_MetodoPago>(value);
        }
        public static string GetString(this c_TipoDeComprobante value)
        {
            return GetXmlEnumAttributeValueFromEnum<c_TipoDeComprobante>(value);
        }
        public static string GetString(this c_ClaveProdServ value)
        {
            return GetXmlEnumAttributeValueFromEnum<c_ClaveProdServ>(value);
        }
        public static string GetString(this c_ClaveUnidad value)
        {
            return GetXmlEnumAttributeValueFromEnum<c_ClaveUnidad>(value);
        }
        public static TEnum GetEnumValue<TEnum>(string value)
        {
            try
            {
                var enumType = typeof(TEnum);
                if (!enumType.IsEnum) return default(TEnum);//or string.Empty, or throw exception
                if (enumType.GetEnumValues().GetValue(0).ToString().StartsWith("Item"))
                    return (TEnum)System.Enum.Parse(typeof(TEnum), "Item" + value);
                else
                    return (TEnum)System.Enum.Parse(typeof(TEnum), value);
            }
            catch (Exception)
            {
                return default(TEnum);
            }
        }
    }
}
