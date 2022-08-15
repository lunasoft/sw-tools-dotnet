![NET](http://resources.workable.com/wp-content/uploads/2015/08/Microsoft-dotNET-logo.jpg)
![NET](https://smarterwebci.visualstudio.com/_apis/public/build/definitions/402b9165-314f-4f5f-8073-9ae3a2e962ef/23/badge)


# Contenido #
- [Compatibilidad](#Compatibilidad)
- [Dependencias](#Dependencias)
- [Documentación](#Documentación)
- [Instalación](#Instalación)
- [Implementación](#Implementación)
- [Autores](#Autores)

# Compatibilidad #
* CFDI 3.3
* CFDI 4.0
* .Net Framework 4.5 o superior


# Dependencias #
* [QrCodeNet](https://codeplex.pagaloo.com/d/com/qrcodenet)
* [BouncyCastle](https://www.bouncycastle.org/)

# Documentación #
* [Inicio Rápido](https://developers.sw.com.mx/knowledge-base/)
* [Documentacion Oficial Servicios](http://developers.sw.com.mx)
 
----------------
# Instalaci&oacute;n #
Instalar la libreria a traves Package Manager Console [nuget.org](https://www.nuget.org/packages/SW.Tools/1.0.3.2-rc)
```cs
Install-Package SW-Tools
```
En caso de no utilizar Package Manager Console puedes descargar la libreria directamente a traves del siguiente [link](https://github.com/lunasoft/sw-tools-dotnet/releases) y agregarla como referencia local a tu proyecto. Asegurate de utilizar la ultima version publicada.

# Implementaci&oacute;n #


**Generar xml CFDI 3.3**

Puedes generar un xml en su versión 3.3 de tipo ingreso/egreso así como tambien realizar el sellado para ser timbrado. Puedes consultar más ejemplos en [UT Tools](https://github.com/lunasoft/sw-tools-dotnet/blob/master/SW.ToolsUT/UT_Tools_BuildInvoiceCFDI33.cs)
```cs
using SW.Tools.Services.Sign;
using System;

namespace ExampleSDK
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                //Se construye el xml añadiendo los valores de cada atributo mediante objetos
            Tools.Entities.Comprobante comprobante = new Tools.Entities.Comprobante();

            comprobante.SetComprobante("MXN", "I", "01", "PPD", "20000");
            comprobante.SetConcepto(1, "84131500", "ZZ", "Prima neta", "1", "NO APLICA", 3592.83m);
            comprobante.SetConceptoImpuestoTraslado(0.160000m, "Tasa", "002", 3592.83m);
            comprobante.SetConcepto(1, "84131500", "ZZ", "Recargo por pago fraccionado", "1", "NO APLICA", 258.68m);
            comprobante.SetConceptoImpuestoTraslado(0.160000m, "Tasa", "002", 258.68m);
            comprobante.SetConcepto(1, "84131500", "ZZ", "derecho de poliza", "1", "NO APLICA", 550.00m);
            comprobante.SetConceptoImpuestoTraslado(0.160000m, "Tasa", "002", 550.00m);
            comprobante.SetEmisor("EKU9003173C9", "ACCEM SERVICIOS EMPRESARIALES SC", "601");
            comprobante.SetReceptor("XAXX010101000", "MIGUEL LANGARKA GENESTA", "G03");

            var invoice = comprobante.GetComprobante();
            var xmlInvoice = Tools.Helpers.Serializer.SerializeDocument(invoice);
            xmlInvoice = SignInvoice(xmlInvoice);
            }
            catch (Exception e)
            {

            }

        }
    }
}

```
## Generar xml CFDI 4.0 ##
Puedes generar un xml en su versión 4.0 de tipo ingreso/egreso así como tambien realizar el sellado para ser timbrado. Puedes consultar más ejemplos en [UT Tools](https://github.com/lunasoft/sw-tools-dotnet/blob/master/SW.ToolsUT/UT_Tools_BuildInvoiceCFDI40.cs)
```cs
using SW.Tools.Services.Sign;
using System;

namespace ExampleSDK
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                //Se construye el xml añadiendo los valores de cada atributo mediante objetos 
            Comprobante comprobante = new Comprobante();

            comprobante.SetComprobante("MXN", "I", "99", "PPD", "20000", "01");
            comprobante.SetConcepto(1, "84131500", "ZZ", "Prima neta", "1", "NO APLICA", 3592.83m, "02", 3592.83m);
            comprobante.SetConceptoImpuestoTraslado( "Tasa", "002", 3592.83m, 0.160000m, 574.85m);
            comprobante.SetConcepto(1, "84131500", "ZZ", "Recargo por pago fraccionado", "1", "NO APLICA", 258.68m, "02", 258.68m);
            comprobante.SetConceptoImpuestoTraslado( "Tasa", "002",  258.68m, 0.160000m, 41.38m);
            comprobante.SetConcepto(1, "84131500", "ZZ", "derecho de poliza", "1", "NO APLICA", 550.00m, "02", 550.00m);
            comprobante.SetConceptoImpuestoTraslado( "Tasa", "002", 550.00m, 0.160000m, 88.00m);
            comprobante.SetEmisor("EKU9003173C9", "ESCUELA KEMPER URGATE", "601");
            comprobante.SetReceptor("URE180429TM6", "UNIVERSIDAD ROBOTICA ESPAÑOLA", "G01", "65000", "601");
            
            var invoice = comprobante.GetComprobante();
            var xmlInvoice = SerializerCfdi40.SerializeDocument(invoice);
            xmlInvoice = SignInvoice(xmlInvoice);;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
```

## Generar xml con complemento de pagos 2.0 ##
Puedes generar un xml en su versión 4.0 con su complementeo de pagos 2.0, así como tambien realizar el sellado para ser timbrado. Puedes consultar más ejemplos en [UT Tools](https://github.com/lunasoft/sw-tools-dotnet/blob/master/SW.ToolsUT/UT_Tools_BuildInvoicePagos20.cs)
```cs
using SW.Tools.Services.Sign;
using SW.Tools.Entities.Complementos;
using System;

namespace ExampleSDK
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                //Se construye el xml añadiendo los valores de cada atributo mediante objetos 
            SW.Tools.Cfdi.Complementos.Pagos20.Pagos pago = new SW.Tools.Cfdi.Complementos.Pagos20.Pagos();

            pago.SetPago("01", null, DateTime.Now, null, "MXN", 200.00m, null, null, null, null, 1m);
            pago.SetDoctoRelacionado(null, null, "bfc36522-4b8e-45c4-8f14-d11b289f9eb7",
                "MXN", "1", "01", 1m, 200.00m, 200.00m, 0.00m);
            pago.SetEmisor("EKU9003173C9", "ESCUELA KEMPER URGATE", "601");
            pago.SetReceptor("JUFA7608212V6", "ADRIANA JUAREZ FERNANDEZ", "29133", "606");
            pago.SetTotales("200.00");
            var invoice = pago.GetInvoice("99056", "01", "01", "A", "1");

            var xmlInvoice = SW.Tools.Helpers.SerializerCfdi40.SerializeDocument(invoice);
            xmlInvoice = SignInvoice(xmlInvoice);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
```
## Sellar xml 3.3 ##
Una vez construido el xml con todos sus nodos y atributos puedes realizar el sellado del mismo con la siguiente fucnión:
* xml 3.3
* [PFX](#Crear_PFX) en Base64
* Password del archivo key
```cs
using SW.Tools.Services.Sign;
using System.IO;
using System;
using System.Text;
using System.Xml;

namespace ExampleSDK
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                //Se construye el xml añadiendo los valores de cada atributo mediante objetos 
           byte[] bytesCer = File.ReadAllBytes(@"Resources\CSD_Pruebas_CFDI_EKU9003173C9.cer");
            byte[] bytesKey = File.ReadAllBytes(@"Resources\CSD_Pruebas_CFDI_EKU9003173C9.key");
            string password = "12345678a";
            var pfx = Sign.CrearPFX(bytesCer, bytesKey, password);
            var xml = Fiscal.RemoverCaracteresInvalidosXml(Encoding.UTF8.GetString(File.ReadAllBytes(@"Resources\cfdi33.xml")));
            var xmlResult = Sign.SellarCFDIv33(pfx, password, xml);
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(xmlResult);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
```
## Sellar xml 4.0 ##
Una vez construido el xml con todos sus nodos y atributos puedes realizar el sellado del mismo con la siguiente fucnión:
* xml 4.0
* [PFX](#Crear_PFX) en Base64
* Password del archivo key
```cs
using SW.Tools.Services.Sign;
using System.IO;
using System;
using System.Text;
using System.Xml;

namespace ExampleSDK
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                
            byte[] bytesCer = File.ReadAllBytes(@"Resources\CSD_Pruebas_CFDI_EKU9003173C9.cer");
            byte[] bytesKey = File.ReadAllBytes(@"Resources\CSD_Pruebas_CFDI_EKU9003173C9.key");
            string password = "12345678a";
            var pfx = Sign.CrearPFX(bytesCer, bytesKey, password);
            var xml = Fiscal.RemoverCaracteresInvalidosXml(Encoding.UTF8.GetString(File.ReadAllBytes(@"Resources\cfdi40.xml")));
            var xmlResult = Sign.SellarCFDIv40(pfx, password, xml);
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(xmlResult);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
```
## Sellar xml retención 2.0 ##
Una vez construido el xml con todos sus nodos y atributos puedes realizar el sellado del mismo con la siguiente fucnión:
* xml retenciones 2.0
* [PFX](#Crear_PFX) en Base64
* Password del archivo key
```cs
using SW.Tools.Services.Sign;
using System.IO;
using System;
using System.Text;
using System.Xml;

namespace ExampleSDK
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                
            byte[] bytesCer = File.ReadAllBytes(@"Resources\CSD_Pruebas_CFDI_EKU9003173C9.cer");
            byte[] bytesKey = File.ReadAllBytes(@"Resources\CSD_Pruebas_CFDI_EKU9003173C9.key");
            string password = "12345678a";
            var pfx = Sign.CrearPFX(bytesCer, bytesKey, password);
            var xml = Fiscal.RemoverCaracteresInvalidosXml(Encoding.UTF8.GetString(File.ReadAllBytes(@"Resources\retencion20.xml")));
            var xmlResult = Sign.SellarRetencionv20(pfx, password, xml);
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(xmlResult);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
```
## Generar y sellar xml cancelación ##
Puedes construir y sellar un xml de cancelación incluyendo el/los UUID a cancelar
* Folios (UUID, motivo, foliosustitucion)
* RFC emisor
* [PFX](#Crear_PFX) en Base64
* Password del archivo key
```cs
using SW.Tools.Services.Sign;
using System;
using System.Xml;

namespace ExampleSDK
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                //Puedes agregar hasta 1000 folios
            var pfx = Sign.CrearPFX(build.BytesCer, build.BytesKey, build.CerPassword);
            List<Cancelacion> folios = new List<Cancelacion>();
            folios.Add(new Cancelacion()
            {
                Folio = Guid.Parse("b6a15ce8-0fb8-401a-bfe7-8930983e182e"),
                Motivo = CancelacionMotivo.Motivo01,
                FolioSustitucion = Guid.Parse("63187375-3433-4ae8-ad5a-3323872026fc")
            });
            folios.Add(new Cancelacion()
            {
                Folio = Guid.Parse("63187375-3433-4ae8-ad5a-3323872026fc"),
                Motivo = CancelacionMotivo.Motivo02
            });
            var xml = Sign.SellarCancelacion(folios, build.RfcEmisor, pfx, build.CerPassword);
            Cancelation cancelation = new Cancelation(build.Url, build.Token);
            var cancelacion = cancelation.CancelarByXML(Encoding.UTF8.GetBytes(xml));
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
```
**Consultar Validez**

Mediante esta función pudes consultar si un RFC es válido o no, **esta función no es una consulta a la LCO ni retorna ningún dato e información del RFC a consultar**. La función recibe los siguientes paramétros:
* RFC emisor
```cs
using System;
using SW.Tools.Services.Fiscal;
namespace ExampleSDK
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                //Llamamos a la función indicandole como parámetro el RFC a validar
                 var result = Fiscal.ValidarRfc("COSE860610K59");
                 Console.WriteLine(result);
            }
            catch (Exception e)
            {
            }
        }
    }
}
```


 ## Antiguedad en semanas ##
Para calcular el número de semanas en que el empleado ha mantenido relación laboral con el empleador puedes utilizar la siguiente función. Los parametros que recibe son:

* Fecha de inicio laboral
* Fecha fin de pago

```cs
using System;
using SW.Tools.Services.Fiscal;

namespace ExampleSDK
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                //Definimos las variables de inicio y de fin 
            string dateFrom = "01/08/2008";
            DateTime dtFrom = Convert.ToDateTime(dateFrom);
            string dateTo = "01/08/2008";
            DateTime dtTo = Convert.ToDateTime(dateTo);
            var result = Fiscal.AntiguedadSemanas(dtFrom, dtTo);
            Console.WriteLine(result);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
```
## Antiguedad en semanas ##
Para calcular el el periodo de años, meses y días (año 
calendario) en que el empleado ha mantenido relación laboral con el empleador puedes utilizar la siguiente función. Los parametros que recibe son:

* Fecha de inicio laboral
* Fecha fin de pago

```cs
using System;
using SW.Tools.Services.Fiscal;

namespace ExampleSDK
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                //Definimos las variables de inicio y de fin 
            string dateFrom = "01/08/2008";
            DateTime dtFrom = Convert.ToDateTime(dateFrom);
            string dateTo = "01/08/2008";
            DateTime dtTo = Convert.ToDateTime(dateTo);
            var result = Fiscal.AntiguedadAnosMesesDias(dtFrom, dtTo);
            Console.WriteLine(result);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
```

## Crear PFX ##
Puedes generar un archivo PFX mediante tus CSD con la siguiente fución, Los parámetros a recibir son:
* Certificado (.cer) en Base64
* Key (.key) en Base64
* Password del archivo key

```cs
using System;
using System.IO;
using System.Text;
using SW.Tools.Services.Sign;

namespace ExampleSDK
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {

            byte[] bytesCer = File.ReadAllBytes(@"Resources\CSD_Pruebas_CFDI_EKU9003173C9.cer");
            byte[] bytesKey = File.ReadAllBytes(@"Resources\CSD_Pruebas_CFDI_EKU9003173C9.key");
            string password = "12345678a";
            var pfx = Sign.CrearPFX(bytesCer, bytesKey, password);
            Console.WriteLine(result);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
```
# Autores # 

* Aeyrton Villalobos Sánchez - [SwAeyrton](https://github.com/SwAeyrton).
* David Ernesto Reyes Ayala - [ReyesSW](https://github.com/ReyesSW).
* Martin Flores Navarrete - [martinfnsw](https://github.com/martinfnsw).


