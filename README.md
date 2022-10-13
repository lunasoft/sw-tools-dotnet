![NET](http://resources.workable.com/wp-content/uploads/2015/08/Microsoft-dotNET-logo.jpg)
![NET](https://smarterwebci.visualstudio.com/_apis/public/build/definitions/402b9165-314f-4f5f-8073-9ae3a2e962ef/23/badge)

# Contenido #

- [Compatibilidad](#Compatibilidad)
- [Dependencias](#Dependencias)
- [Documentación](#Documentación)
- [Instalación](#Instalación)
- [Implementación](#Implementación)
    - [Sign](#sign-service)
        - [Sellar CFDI 3.3](#generar-xml-cfdi-33)
        - [Sellar CFDI 4.0](#generar-xml-cfdi-40)
        - [Sellar Retenciones 2.0](#sellar-xml-retención-20)
        - [Sellar XML Cancelaciones](#generar-y-sellar-xml-de-cancelación)
        - [Sellar XML Aceptacion/Rechazo](#generar-y-sellar-xml-aceptaciónrechazo)
    - [Certificates](#certificados-service)
    - [Fiscal](#fiscal-service)
- [Autores](#Autores)

# Compatibilidad #

- CFDI 3.3
- CFDI 4.0
- .Net Framework 4.5 o superior

# Dependencias #

- [QrCodeNet](https://codeplex.pagaloo.com/d/com/qrcodenet)
- [BouncyCastle](https://www.bouncycastle.org/)

# Documentación #

- [Inicio Rápido](https://developers.sw.com.mx/knowledge-base/)
- [Documentacion Oficial Servicios](http://developers.sw.com.mx)

----------------

# Instalación #

Instalar la libreria a traves Package Manager Console [nuget.org](https://www.nuget.org/packages/SW.Tools/1.0.3.2-rc)

```cs
Install-Package SW-Tools
```

En caso de no utilizar Package Manager Console puedes descargar la libreria directamente a traves del siguiente [link](https://github.com/lunasoft/sw-tools-dotnet/releases) y agregarla como referencia local a tu proyecto. Asegurate de utilizar la ultima version publicada.

# Implementación #

## Comprobante Service #
Servicios para generar XML a partir de un objeto comprobante.

### Generar XML CFDI 3.3 #

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
                Console.WriteLine(e.Message);
            }

        }
    }
}
```

### Generar XML CFDI 4.0 #

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
                comprobante.SetConceptoImpuestoTraslado("Tasa", "002", 3592.83m, 0.160000m, 574.85m);
                comprobante.SetConcepto(1, "84131500", "ZZ", "Recargo por pago fraccionado", "1", "NO APLICA", 258.68m, "02", 258.68m);
                comprobante.SetConceptoImpuestoTraslado("Tasa", "002", 258.68m, 0.160000m, 41.38m);
                comprobante.SetConcepto(1, "84131500", "ZZ", "derecho de poliza", "1", "NO APLICA", 550.00m, "02", 550.00m);
                comprobante.SetConceptoImpuestoTraslado("Tasa", "002", 550.00m, 0.160000m, 88.00m);
                comprobante.SetEmisor("EKU9003173C9", "ESCUELA KEMPER URGATE", "601");
                comprobante.SetReceptor("URE180429TM6", "UNIVERSIDAD ROBOTICA ESPAÑOLA", "G01", "65000", "601");

                var invoice = comprobante.GetComprobante();
                var xmlInvoice = SerializerCfdi40.SerializeDocument(invoice);
                xmlInvoice = SignInvoice(xmlInvoice); ;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
```

### Generar XML con complemento de Pagos 2.0 ##

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

## Sign Service #

Servicios para sellar comprobantes CFDI y de Retenciones, generar y aplicar siganture a un XML.
También contiene métodos para crear y sellar XML de cancelación y de aceptación/rechazo.

### Sellar XML CFDI 3.3 #

Una vez construido el xml con todos sus nodos y atributos puedes realizar el sellado del mismo con la siguiente fucnión:

- XML 3.3
- [PFX](#crear-pfx) en Base64
- Password del archivo key

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

## Sellar XML CFDI 4.0 #

Una vez construido el xml con todos sus nodos y atributos puedes realizar el sellado del mismo con la siguiente función:

- XML 4.0
- [PFX](#crear-pfx) en Base64
- Password del archivo key

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

### Sellar XML Retención 2.0 #

Una vez construido el xml con todos sus nodos y atributos puedes realizar el sellado del mismo con la siguiente función:

- XML Retenciones 2.0

- [PFX](#crear-pfx) en Base64
- Password del archivo key

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

### Generar y sellar XML de cancelación #

Puedes construir y sellar un xml de cancelación incluyendo el/los UUID a cancelar.

- Folios (UUID, motivo, foliosustitucion)
- RFC emisor
- [PFX](#crear-pfx) en Base64
- Password del archivo key

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

### Generar y sellar XML Aceptación/Rechazo #

Cuando requieras aceptar o rechazar una o más cancelaciones puedes generar el xml de aceptación/rechazo.

- Folios (UUID, Respuesta)
- RFC emisor
- Password del archivo key

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

                var pfx = Sign.CrearPFX(_build.BytesCer, _build.BytesKey, _build.CerPassword);
                List<AceptacionRechazo> folios = new List<AceptacionRechazo>();
                folios.Add(new AceptacionRechazo()
                {
                    Folio = Guid.Parse("FD74D156-B9B0-44A5-9906-E08182E8363E"),
                    Respuesta = AceptacionRechazoRespuesta.Aceptacion
                });
                var result = Sign.SellarAceptacionRechazo(folios, _build.RfcEmisor, pfx, _build.CerPassword);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
```



## Certificados Service #

### Crear PFX #

Puedes generar un archivo PFX mediante tus CSD con la siguiente función, Los parámetros a recibir son:

- Certificado (.cer) en Base64
- Key (.key) en Base64
- Password del archivo key

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

### Validar CSD/FIEL #

Mediante la siguiente función podrás validar si un certificado(.cer) es de tipo FIEL o de tipo CSD.

- Certificado (.cer) en Base64
- Key (.key) en Base64
- Password del archivo key

```cs
using System;
using System.IO;
using System.Text;
using SW.Tools.Services.Certificate;

namespace ExampleSDK
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                //La función retornará una respuesta indicando si es de tipo CSD o FIEL
                //Es necesario convertir el archivo .cer a base64
                byte[] bytesCer = File.ReadAllBytes(@"Resources\CSD_Pruebas_CFDI_EKU9003173C9.cer");
                var result = Certificate.VerificarTipoCertificado(bytesCer);
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

### Leer Certificado #

Puedes leer un certificado(.cer) para obtener los detalles del mismo como:

- Número de serie
- Autoridad de certificación
- Nombre del certificado
- Número de certificado

```cs
using System;
using System.IO;
using System.Text;
using SW.Tools.Services.Certificate;

namespace ExampleSDK
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                //La función recibe como parámetro el certificado en base64
                byte[] bytesCer = File.ReadAllBytes(@"Resources\CSD_Pruebas_CFDI_EKU9003173C9.cer");
                var result = Certificate.LeerCertificado(bytesCer);
                Console.WriteLine(result.data.serialNumber);
                Console.WriteLine(result.data.issuer);
                Console.WriteLine(result.data.certificateNumber);
                Console.WriteLine(result.data.commonName);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
```

## Fiscal Service #

### Consultar Validez #

Mediante esta función pudes consultar si un RFC es válido o no, **esta función no es una consulta a la LCO ni retorna ningún dato e información del RFC a consultar**. La función recibe los siguientes paramétros:

- RFC emisor

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
                Console.WriteLine(e.Message);
            }
        }
    }
}
```

### Antiguedad en semanas #

Para calcular el número de semanas en que el empleado ha mantenido relación laboral con el empleador puedes utilizar la siguiente función. Los parametros que recibe son:

- Fecha de inicio laboral
- Fecha fin de pago

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

### Antiguedad en años, meses y días #

Para calcular el el periodo de años, meses y días (año
calendario) en que el empleado ha mantenido relación laboral con el empleador puedes utilizar la siguiente función. Los parametros que recibe son:

- Fecha de inicio laboral
- Fecha fin de pago

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

# Autores #

<table>
  <tr>
    <td align="center"><a href="https://github.com/hermesw"><img src="https://avatars.githubusercontent.com/u/23102756?v=4" width="100px;" alt="Hermes jimenez"/><br /><sub><b>Hermes Jimenez</b></sub></a></td>
    <td align="center"><a href="https://github.com/SwAeyrton"><img src="https://avatars.githubusercontent.com/u/88451104?v=4" width="100px;" alt="Aeyrton Villalobos"/><br /><sub><b>Aeyrton Villalobos</b></sub></a></td>
     <td align="center"><a href="https://github.com/martinfnsw"><img src="https://avatars.githubusercontent.com/u/88680430?v=4" width="100px;" alt="Martin Flores"/><br /><sub><b>Martin Flores</b></sub></a></td>
     <td align="center"><a href="https://github.com/helttonrl"><img src="https://avatars.githubusercontent.com/u/23102756?v=4" width="100px;" alt="Heltton Ramirez"/><br /><sub><b>Heltton Ramirez</b></sub></a></td>
  </tr>
  </table>
  <img src="data:image/svg+xml;base64,PHN2ZyB4bWxucz0iaHR0cDovL3d3dy53My5vcmcvMjAwMC9zdmciIHdpZHRoPSIxNTkuNzkwMDAwMDAwMDAwMDIiIGhlaWdodD0iMzUiIHZpZXdCb3g9IjAgMCAxNTkuNzkwMDAwMDAwMDAwMDIgMzUiPjxyZWN0IGNsYXNzPSJzdmdfX3JlY3QiIHg9IjAiIHk9IjAiIHdpZHRoPSIxMTUuMzEiIGhlaWdodD0iMzUiIGZpbGw9IiNGRjY5MDAiLz48cmVjdCBjbGFzcz0ic3ZnX19yZWN0IiB4PSIxMTMuMzEiIHk9IjAiIHdpZHRoPSI0Ni40ODAwMDAwMDAwMDAwMiIgaGVpZ2h0PSIzNSIgZmlsbD0iI0ZGRkZGRiIvPjxwYXRoIGNsYXNzPSJzdmdfX3RleHQiIGQ9Ik0xNS42OSAyMkwxNC4yMiAyMkwxNC4yMiAxMy40N0wxNi4xNCAxMy40N0wxOC42MCAyMC4wMUwyMS4wNiAxMy40N0wyMi45NyAxMy40N0wyMi45NyAyMkwyMS40OSAyMkwyMS40OSAxOS4xOUwyMS42NCAxNS40M0wxOS4xMiAyMkwxOC4wNiAyMkwxNS41NSAxNS40M0wxNS42OSAxOS4xOUwxNS42OSAyMlpNMjguNDkgMjJMMjYuOTUgMjJMMzAuMTcgMTMuNDdMMzEuNTAgMTMuNDdMMzQuNzMgMjJMMzMuMTggMjJMMzIuNDkgMjAuMDFMMjkuMTggMjAuMDFMMjguNDkgMjJaTTMwLjgzIDE1LjI4TDI5LjYwIDE4LjgyTDMyLjA3IDE4LjgyTDMwLjgzIDE1LjI4Wk00MS4xNCAyMkwzOC42OSAyMkwzOC42OSAxMy40N0w0MS4yMSAxMy40N1E0Mi4zNCAxMy40NyA0My4yMSAxMy45N1E0NC4wOSAxNC40OCA0NC41NyAxNS40MFE0NS4wNSAxNi4zMyA0NS4wNSAxNy41Mkw0NS4wNSAxNy41Mkw0NS4wNSAxNy45NVE0NS4wNSAxOS4xNiA0NC41NyAyMC4wOFE0NC4wOCAyMS4wMCA0My4xOSAyMS41MFE0Mi4zMCAyMiA0MS4xNCAyMkw0MS4xNCAyMlpNNDAuMTcgMTQuNjZMNDAuMTcgMjAuODJMNDEuMTQgMjAuODJRNDIuMzAgMjAuODIgNDIuOTMgMjAuMDlRNDMuNTUgMTkuMzYgNDMuNTYgMTcuOTlMNDMuNTYgMTcuOTlMNDMuNTYgMTcuNTJRNDMuNTYgMTYuMTMgNDIuOTYgMTUuNDBRNDIuMzUgMTQuNjYgNDEuMjEgMTQuNjZMNDEuMjEgMTQuNjZMNDAuMTcgMTQuNjZaTTU1LjA5IDIyTDQ5LjUxIDIyTDQ5LjUxIDEzLjQ3TDU1LjA1IDEzLjQ3TDU1LjA1IDE0LjY2TDUxLjAwIDE0LjY2TDUxLjAwIDE3LjAyTDU0LjUwIDE3LjAyTDU0LjUwIDE4LjE5TDUxLjAwIDE4LjE5TDUxLjAwIDIwLjgyTDU1LjA5IDIwLjgyTDU1LjA5IDIyWk02Ni42NSAyMkw2NC42OCAxMy40N0w2Ni4xNSAxMy40N0w2Ny40NyAxOS44OEw2OS4xMCAxMy40N0w3MC4zNCAxMy40N0w3MS45NiAxOS44OUw3My4yNyAxMy40N0w3NC43NCAxMy40N0w3Mi43NyAyMkw3MS4zNSAyMkw2OS43MyAxNS43N0w2OC4wNyAyMkw2Ni42NSAyMlpNODAuMzggMjJMNzguOTAgMjJMNzguOTAgMTMuNDdMODAuMzggMTMuNDdMODAuMzggMjJaTTg2Ljg3IDE0LjY2TDg0LjIzIDE0LjY2TDg0LjIzIDEzLjQ3TDkxLjAwIDEzLjQ3TDkxLjAwIDE0LjY2TDg4LjM0IDE0LjY2TDg4LjM0IDIyTDg2Ljg3IDIyTDg2Ljg3IDE0LjY2Wk05Ni4yNCAyMkw5NC43NSAyMkw5NC43NSAxMy40N0w5Ni4yNCAxMy40N0w5Ni4yNCAxNy4wMkwxMDAuMDUgMTcuMDJMMTAwLjA1IDEzLjQ3TDEwMS41MyAxMy40N0wxMDEuNTMgMjJMMTAwLjA1IDIyTDEwMC4wNSAxOC4yMUw5Ni4yNCAxOC4yMUw5Ni4yNCAyMloiIGZpbGw9IiNGRkZGRkYiLz48cGF0aCBjbGFzcz0ic3ZnX190ZXh0IiBkPSJNMTI3LjA3IDE3LjgwTDEyNy4wNyAxNy44MFExMjcuMDcgMTYuNTQgMTI3LjY3IDE1LjU0UTEyOC4yNyAxNC41NSAxMjkuMzIgMTMuOTlRMTMwLjM3IDEzLjQzIDEzMS42OSAxMy40M0wxMzEuNjkgMTMuNDNRMTMyLjg0IDEzLjQzIDEzMy43NiAxMy44NFExMzQuNjkgMTQuMjUgMTM1LjMwIDE1LjAyTDEzNS4zMCAxNS4wMkwxMzMuNzkgMTYuMzlRMTMyLjk4IDE1LjQwIDEzMS44MSAxNS40MEwxMzEuODEgMTUuNDBRMTMxLjEyIDE1LjQwIDEzMC41OSAxNS43MFExMzAuMDYgMTYgMTI5Ljc2IDE2LjU0UTEyOS40NyAxNy4wOSAxMjkuNDcgMTcuODBMMTI5LjQ3IDE3LjgwUTEyOS40NyAxOC41MSAxMjkuNzYgMTkuMDVRMTMwLjA2IDE5LjYwIDEzMC41OSAxOS45MFExMzEuMTIgMjAuMjAgMTMxLjgxIDIwLjIwTDEzMS44MSAyMC4yMFExMzIuOTggMjAuMjAgMTMzLjc5IDE5LjIyTDEzMy43OSAxOS4yMkwxMzUuMzAgMjAuNThRMTM0LjY5IDIxLjM1IDEzMy43NyAyMS43NlExMzIuODQgMjIuMTcgMTMxLjY5IDIyLjE3TDEzMS42OSAyMi4xN1ExMzAuMzcgMjIuMTcgMTI5LjMyIDIxLjYxUTEyOC4yNyAyMS4wNSAxMjcuNjcgMjAuMDVRMTI3LjA3IDE5LjA2IDEyNy4wNyAxNy44MFpNMTQwLjcyIDIwLjIxTDEzOS4yMCAyMC4yMUwxMzkuMjAgMTguNjdMMTQwLjkxIDE4LjY3TDE0MS4xMSAxNi45NEwxMzkuNjAgMTYuOTRMMTM5LjYwIDE1LjM5TDE0MS4zMCAxNS4zOUwxNDEuNTMgMTMuNjBMMTQzLjE3IDEzLjYwTDE0Mi45NCAxNS4zOUwxNDQuNDEgMTUuMzlMMTQ0LjY0IDEzLjYwTDE0Ni4yNyAxMy42MEwxNDYuMDQgMTUuMzlMMTQ3LjU1IDE1LjM5TDE0Ny41NSAxNi45NEwxNDUuODUgMTYuOTRMMTQ1LjY1IDE4LjY3TDE0Ny4xNSAxOC42N0wxNDcuMTUgMjAuMjFMMTQ1LjQ2IDIwLjIxTDE0NS4yMyAyMkwxNDMuNTkgMjJMMTQzLjgyIDIwLjIxTDE0Mi4zNSAyMC4yMUwxNDIuMTIgMjJMMTQwLjQ5IDIyTDE0MC43MiAyMC4yMVpNMTQyLjc0IDE2Ljk0TDE0Mi41NCAxOC42N0wxNDQuMDIgMTguNjdMMTQ0LjIyIDE2Ljk0TDE0Mi43NCAxNi45NFoiIGZpbGw9IiNGRjY5MDAiIHg9IjEyNi4zMSIvPjwvc3ZnPg==" alt="MADE WITH C#" />