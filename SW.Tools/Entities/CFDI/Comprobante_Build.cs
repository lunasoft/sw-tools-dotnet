using SW.Tools.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using SW.Tools.Catalogs;
using SW.Tools.Entities;

namespace SW.Tools.Cfdi
{
    public partial class Comprobante
    {
        public void SetConcepto(decimal cantidad, string claveProdServ, string claveUnidad, string descripcion,
             string noIdentificacion, string unidad, decimal valorUnitario, string ObjetoImp, decimal importe = 0, decimal descuento = 0)
        {
            if (this.Conceptos != null)
            {
                var conceptList = this.Conceptos.ToList();
                conceptList.Add(new ComprobanteConcepto()
                {
                    Cantidad = cantidad,
                    ClaveProdServ = claveProdServ,
                    ClaveUnidad = claveUnidad,
                    Descripcion = descripcion,
                    Descuento = descuento,
                    DescuentoSpecified = descuento != 0,
                    Importe = importe,
                    NoIdentificacion = noIdentificacion,
                    Unidad = unidad,
                    ValorUnitario = valorUnitario,
                    ObjetoImp = ObjetoImp
                });
                this.Conceptos = conceptList.ToArray();

            }
            else
            {
                this.Conceptos = new ComprobanteConcepto[1];
                this.Conceptos[0] = new ComprobanteConcepto()
                {
                    Cantidad = cantidad,
                    ClaveProdServ = claveProdServ,
                    ClaveUnidad = claveUnidad,
                    Descripcion = descripcion,
                    Descuento = descuento,
                    DescuentoSpecified = descuento != 0,
                    Importe = importe,
                    NoIdentificacion = noIdentificacion,
                    Unidad = unidad,
                    ValorUnitario = valorUnitario,
                    ObjetoImp = ObjetoImp
                };
            }
        }
        public void SetConceptoComplemento(XmlElement complementoConcepto)
        {
            if (this.Conceptos == null)
            {
                this.Conceptos = new ComprobanteConcepto[1];
                this.Conceptos[0] = new ComprobanteConcepto();
            }
            if (this.Conceptos.Last().ComplementoConcepto == null)
            {
                this.Conceptos.Last().ComplementoConcepto = new ComprobanteConceptoComplementoConcepto();
            }
            if (this.Conceptos.Last().ComplementoConcepto.Any == null)
            {
                this.Conceptos.Last().ComplementoConcepto.Any = new XmlElement[1];
                this.Conceptos.Last().ComplementoConcepto.Any[0] = complementoConcepto;
            }
            else
            {
                var listConce = this.Conceptos.Last().ComplementoConcepto.Any.ToList();
                listConce.Add(complementoConcepto);
                this.Conceptos.Last().ComplementoConcepto.Any = listConce.ToArray();
            }
        }
        public void SetConceptoCuentaPredial(string numero)
        {
            if (this.Conceptos == null)
            {
                this.Conceptos = new ComprobanteConcepto[1];
                this.Conceptos[0] = new ComprobanteConcepto();
            }
            if (this.Conceptos.Last().CuentaPredial == null)
            {
                this.Conceptos.Last().CuentaPredial = new ComprobanteConceptoCuentaPredial();
            }
            this.Conceptos.Last().CuentaPredial.Numero = numero;
        }
        public void SetConceptoInformacionAduanera(string numeroDePedimento)
        {
            if (this.Conceptos == null)
            {
                this.Conceptos = new ComprobanteConcepto[1];
                this.Conceptos[0] = new ComprobanteConcepto();
            }
            if (this.Conceptos.Last().InformacionAduanera == null)
            {
                this.Conceptos.Last().InformacionAduanera = new ComprobanteConceptoInformacionAduanera[1];
                this.Conceptos.Last().InformacionAduanera[0] = new ComprobanteConceptoInformacionAduanera()
                { NumeroPedimento = numeroDePedimento };
            }
            else
            {
                var listInfoAduanera = this.Conceptos.Last().InformacionAduanera.ToList();
                listInfoAduanera.Add(new ComprobanteConceptoInformacionAduanera() { NumeroPedimento = numeroDePedimento });
                this.Conceptos.Last().InformacionAduanera = listInfoAduanera.ToArray();
            }
        }
        public void SetConceptoParte(string claveProdServ, string noIdentificacion, decimal cantidad, string unidad,
            string descripcion, decimal valorUnitario = -1, string[] informacionAduaneraNumeroPedimento = null)
        {
            if (this.Conceptos == null)
            {
                this.Conceptos = new ComprobanteConcepto[1];
                this.Conceptos[0] = new ComprobanteConcepto();
            }
            if (this.Conceptos.Last().Parte == null)
            {
                this.Conceptos.Last().Parte = new ComprobanteConceptoParte[1];


                this.Conceptos.Last().Parte[0] = new ComprobanteConceptoParte()
                {
                    InformacionAduanera = GetInofrmacionAduaneraArray(informacionAduaneraNumeroPedimento),
                    Cantidad = cantidad,
                    ClaveProdServ = claveProdServ,
                    Descripcion = descripcion,
                    NoIdentificacion = noIdentificacion,
                    Unidad = unidad,
                    ValorUnitarioSpecified = valorUnitario == -1 ? true : false,
                    ValorUnitario = valorUnitario,
                };
            }
            else
            {
                var listConceptoParte = this.Conceptos.Last().Parte.ToList();
                listConceptoParte.Add(new ComprobanteConceptoParte()
                {
                    InformacionAduanera = GetInofrmacionAduaneraArray(informacionAduaneraNumeroPedimento),
                    Cantidad = cantidad,
                    ClaveProdServ = claveProdServ,
                    Descripcion = descripcion,
                    NoIdentificacion = noIdentificacion,
                    Unidad = unidad,
                    ValorUnitarioSpecified = valorUnitario == -1 ? true : false,
                    ValorUnitario = valorUnitario,
                });
                this.Conceptos.Last().Parte = listConceptoParte.ToArray();
            }
        }

        private ComprobanteConceptoParteInformacionAduanera[] GetInofrmacionAduaneraArray(string[] numerosPedimento)
        {
            List<ComprobanteConceptoParteInformacionAduanera> resultado = null;
            if (numerosPedimento != null && numerosPedimento.Length > 0)
            {
                resultado = new List<ComprobanteConceptoParteInformacionAduanera>();
                foreach (var numero in numerosPedimento)
                {
                    resultado.Add(new ComprobanteConceptoParteInformacionAduanera() { NumeroPedimento = numero });
                }
                return resultado.ToArray();
            }
            return null;
        }
        private ComprobanteCfdiRelacionadosCfdiRelacionado[] GetUuidRelacionado(string[] uuid)
        {
            List<ComprobanteCfdiRelacionadosCfdiRelacionado> resultado = null;
            if (uuid != null && uuid.Length > 0)
            {
                resultado = new List<ComprobanteCfdiRelacionadosCfdiRelacionado>();
                foreach (var folio in uuid)
                {
                    resultado.Add(new ComprobanteCfdiRelacionadosCfdiRelacionado() { UUID = folio });
                }
                return resultado.ToArray();
            }
            return null;
        }

        public void SetConceptoImpuestoTraslado(string tipoFactor, string impuesto, decimal _base, decimal? tasaOCuota = null, decimal? importe = null)
        {


            int positionConcept = this.Conceptos.Length - 1;
            if (this.Conceptos[positionConcept].Impuestos == null)
                this.Conceptos[positionConcept].Impuestos = new ComprobanteConceptoImpuestos();
            ComprobanteConceptoImpuestosTraslado impuestoObj;
            if (tipoFactor.Trim().ToLower() == "exento")
            {
                impuestoObj = new ComprobanteConceptoImpuestosTraslado()
                { Base = _base, Impuesto = impuesto, TipoFactor = tipoFactor, TasaOCuotaSpecified = false, ImporteSpecified = false };
            }
            else
                impuestoObj = new ComprobanteConceptoImpuestosTraslado()
                { Base = _base, ImporteSpecified = true, Importe = importe.Value, Impuesto = impuesto, TasaOCuotaSpecified = true, TasaOCuota = tasaOCuota.Value, TipoFactor = tipoFactor };
            if (this.Conceptos[positionConcept].Impuestos.Traslados != null)
            {
                var listCT = this.Conceptos[positionConcept].Impuestos.Traslados.ToList();
                listCT.Add(impuestoObj);
                this.Conceptos[positionConcept].Impuestos.Traslados = listCT.ToArray();
            }
            else
            {
                this.Conceptos[positionConcept].Impuestos.Traslados = new ComprobanteConceptoImpuestosTraslado[1];
                this.Conceptos[positionConcept].Impuestos.Traslados[0] = impuestoObj;
            }
            if (tipoFactor.Trim().ToLower() != "exento") {
                this.SetImpuestoTraslado(_base, impuesto, tipoFactor, tasaOCuota.Value, importe.Value); }

            else
            {
                this.SetImpuestoTraslado(_base, impuesto, tipoFactor, null, null);
            }
        }

        public void SetConceptoImpuestoRetencion(decimal _base, string impuesto, string tipoFactor, decimal? tasaOCuota = null, decimal? importe = null)
        {


            int positionConcept = this.Conceptos.Length - 1;
            if (this.Conceptos[positionConcept].Impuestos == null)
                this.Conceptos[positionConcept].Impuestos = new ComprobanteConceptoImpuestos();
            if (this.Conceptos[positionConcept].Impuestos.Retenciones != null)
            {
                var listCR = this.Conceptos[positionConcept].Impuestos.Retenciones.ToList();
                listCR.Add(new ComprobanteConceptoImpuestosRetencion()
                { Base = _base, Importe = importe.Value, Impuesto = impuesto, TasaOCuota = tasaOCuota.Value, TipoFactor = tipoFactor });
                this.Conceptos[positionConcept].Impuestos.Retenciones = listCR.ToArray();
            }
            else
            {
                this.Conceptos[positionConcept].Impuestos.Retenciones = new ComprobanteConceptoImpuestosRetencion[1];
                this.Conceptos[positionConcept].Impuestos.Retenciones[0] = new ComprobanteConceptoImpuestosRetencion()
                { Base = _base, Importe = importe.Value, Impuesto = impuesto, TasaOCuota = tasaOCuota.Value, TipoFactor = tipoFactor };
            }
            if (tipoFactor.Trim().ToLower() != "exento")
                this.SetImpuestoRetencion(importe.Value, impuesto);
        }

        public void SetCFDIRelacionado(string tipoRelacion = null, string[] uuid = null)
        {
            if (this.CfdiRelacionados != null)
            {
                var conceptList = this.CfdiRelacionados.ToList();
                conceptList.Add(new ComprobanteCfdiRelacionados()
                {
                    TipoRelacion = tipoRelacion,
                    CfdiRelacionado = GetUuidRelacionado(uuid)
                });
                this.CfdiRelacionados = conceptList.ToArray();
            }
            else
            {
                this.CfdiRelacionados = new ComprobanteCfdiRelacionados[1];
                this.CfdiRelacionados[0] = new ComprobanteCfdiRelacionados()
                {
                    TipoRelacion = tipoRelacion,
                    CfdiRelacionado = GetUuidRelacionado(uuid)
                };
            }
        }

        public void SetComplemento(XmlElement xmlComplemento)
        {
            if (this.Complemento == null)
            {
                this.Complemento = new ComprobanteComplemento[1];
                this.Complemento[0] = new ComprobanteComplemento();
            }
            if (this.Complemento[0].Any != null)
            {
                var complementList = this.Complemento[0].Any.ToList();
                complementList.Add(xmlComplemento);
                this.Complemento[0].Any = complementList.ToArray();
            }
            else
            {
                this.Complemento[0].Any = new XmlElement[1];
                this.Complemento[0].Any[0] = xmlComplemento;
            }
        }

        public void SetAddenda(XmlElement xmlAddenda)
        {
            if (this.Addenda == null)
                this.Addenda = new ComprobanteAddenda();
            if (this.Addenda.Any != null)
            {
                var listAddenda = this.Addenda.Any.ToList();
                listAddenda.Add(xmlAddenda);
                this.Addenda.Any = listAddenda.ToArray();
            }
            else
            {
                this.Addenda.Any = new XmlElement[1];
                this.Addenda.Any[0] = xmlAddenda;
            }
        }


        private void SetImpuestoTraslado(decimal _base, string impuesto, string tipoFactor, decimal? tasaOCuota = null, decimal? importe = null)
        {


            if (this.Impuestos == null || this.Impuestos.Traslados == null)
            {
                
                try
                {
                    this.Impuestos = new ComprobanteImpuestos();
                    if (tipoFactor.Trim().ToLower() != "exento")
                    {
                        this.Impuestos.Traslados = new ComprobanteImpuestosTraslado[1];
                        this.Impuestos.Traslados[0] = new ComprobanteImpuestosTraslado()
                        { Base = _base, ImporteSpecified = true, Importe = importe.Value, Impuesto = impuesto, TasaOCuotaSpecified = true, TasaOCuota = tasaOCuota.Value, TipoFactor = tipoFactor };
                    }
                    else
                    {

                        this.Impuestos.Traslados = new ComprobanteImpuestosTraslado[1];
                        this.Impuestos.Traslados[0] = new ComprobanteImpuestosTraslado()
                        { Base = _base, Impuesto = impuesto, TipoFactor = tipoFactor };

                    }
                }
                catch (Exception)
                {
                    throw;
                }

            }
            else
            {
                try
                {

                    switch (tipoFactor.Trim().ToLower())
                    {
                        case "tasa":
                            if (this.Impuestos.Traslados.Any(a => a.Impuesto == impuesto && a.TipoFactor == tipoFactor && a.TasaOCuota == tasaOCuota))
                            {

                                decimal rounded = Coins.RoundFromZero(importe.Value, 2);
                                this.Impuestos.Traslados.Where(a => a.Impuesto == impuesto && a.TasaOCuota == tasaOCuota.Value && a.TipoFactor == tipoFactor)
                                    .ToList().ForEach(i => i.Importe = i.Importe + importe.Value);
                                this.Impuestos.Traslados.Where(a => a.Impuesto == impuesto && a.TasaOCuota == tasaOCuota.Value && a.TipoFactor == tipoFactor)
                                    .ToList().ForEach(i => i.Base = i.Base + _base);

                            }

                            else
                            {
 
                                var listImpTras = this.Impuestos.Traslados.ToList();
                                listImpTras.Add(new ComprobanteImpuestosTraslado()
                                { Base = _base, ImporteSpecified = true, Importe = importe.Value, Impuesto = impuesto, TasaOCuotaSpecified = true, TasaOCuota = tasaOCuota.Value, TipoFactor = tipoFactor });
                                this.Impuestos.Traslados = listImpTras.ToArray();
                            }

                            break;
                        case "exento":
                            if (this.Impuestos.Traslados.Any(a => a.Impuesto == impuesto && a.TipoFactor == tipoFactor))
                            {
                                
                                this.Impuestos.Traslados.Where(a => a.Impuesto == impuesto && a.TipoFactor == tipoFactor)
                                    .ToList().ForEach(i => i.Base = i.Base + _base);

                            }
                            else
                            {

                                var listImpTras = this.Impuestos.Traslados.ToList();
                                listImpTras.Add(new ComprobanteImpuestosTraslado()
                                { Base = _base, Impuesto = impuesto, TipoFactor = tipoFactor });
                                this.Impuestos.Traslados = listImpTras.ToArray();
                            }

                            break;
                    }

                }
                catch (Exception)
                {
                    throw;
                }
            }


        }

        private void SetImpuestoRetencion(decimal importe, string impuesto)
        {
            if (this.Impuestos == null)
                this.Impuestos = new ComprobanteImpuestos();
            if (this.Impuestos.Retenciones == null)
            {
                this.Impuestos.Retenciones = new ComprobanteImpuestosRetencion[1];
                this.Impuestos.Retenciones[0] = new ComprobanteImpuestosRetencion()
                { Importe = importe, Impuesto = impuesto };
            }
            else
            {
                if (this.Impuestos.Retenciones.Any(a => a.Impuesto == impuesto))
                {
                    this.Impuestos.Retenciones.Where(a => a.Impuesto == impuesto)
                        .ToList().ForEach(i => i.Importe = i.Importe + importe);
                }
                else
                {
                    var listImpRetencion = this.Impuestos.Retenciones.ToList();
                    listImpRetencion.Add(new ComprobanteImpuestosRetencion()
                    { Importe = importe, Impuesto = impuesto });
                    this.Impuestos.Retenciones = listImpRetencion.ToArray();
                }
            }
        }

        public void SetEmisor(string rfc, string nombre, string regimenFiscal)
        {
            if (this.Emisor == null)
                this.Emisor = new ComprobanteEmisor();
            this.Emisor.Nombre = nombre;
            this.Emisor.RegimenFiscal = regimenFiscal;
            this.Emisor.Rfc = rfc;
            
        }

        public void SetReceptor(string rfc, string nombre, string usoCFDI, string DomicilioFiscalReceptor, string RegimenFiscalReceptor, string residenciaFiscal = null, string numRegIdTrib = null)
        {
            if (this.Receptor == null)
                this.Receptor = new ComprobanteReceptor();
            this.Receptor.Rfc = rfc;
            this.Receptor.Nombre = nombre;
            this.Receptor.ResidenciaFiscal = residenciaFiscal;
            this.Receptor.ResidenciaFiscalSpecified = !string.IsNullOrEmpty(residenciaFiscal);
            this.Receptor.NumRegIdTrib = numRegIdTrib;
            this.Receptor.UsoCFDI = usoCFDI;
            this.Receptor.DomicilioFiscalReceptor = DomicilioFiscalReceptor;
            this.Receptor.RegimenFiscalReceptor = RegimenFiscalReceptor;
        }

        public void SetComprobante(string moneda, string tipoDeComprobante, string formaPago, string metodoPago,
            string lugarExpedicion,string exportacion, string serie = null, string folio = null, string condicionesDePago = null, decimal tipoCambio = 0, string confirmacion = null)
        {
            this.Serie = serie;
            this.Folio = folio;
            this.FormaPago = formaPago;
            this.FormaPagoSpecified = !string.IsNullOrEmpty(this.FormaPago);
            this.CondicionesDePago = condicionesDePago;
            this.Moneda = moneda;
            this.TipoDeComprobante = tipoDeComprobante;
            this.MetodoPago = metodoPago;
            this.MetodoPagoSpecified = !string.IsNullOrEmpty(this.MetodoPago);
            this.lugarExpedicionField = lugarExpedicion;
            this.Confirmacion = confirmacion;
            this.TipoCambioSpecified = tipoCambio != 0 ? true : false;
            this.TipoCambio = tipoCambio;
            this.Exportacion = exportacion;
            this.Fecha= DateTime.Now.CentralTime();
        }

        public void SetInformacionGlobal(string periodicidad, string meses, string anio)
        {
            if (this.InformacionGlobal == null)
                this.InformacionGlobal = new ComprobanteInformacionGlobal();
            this.InformacionGlobal.Periodicidad = periodicidad;
            this.InformacionGlobal.Meses = meses;
            this.InformacionGlobal.Año = anio;
        }
        public void SetAcuentaTerceros(string rfcacuentater, string nombreacuentater, string regimenacuentater,string domicilioacuentater)
        {
            if (this.Conceptos == null)
            {
                this.Conceptos = new ComprobanteConcepto[1];
                this.Conceptos[0] = new ComprobanteConcepto();
            }
            if (this.Conceptos.Last().ACuentaTerceros == null)
            {
                this.Conceptos.Last().ACuentaTerceros = new ComprobanteConceptoACuentaTerceros();


                this.Conceptos.Last().ACuentaTerceros = new ComprobanteConceptoACuentaTerceros()
                {
                    
                    RfcACuentaTerceros = rfcacuentater,
                    NombreACuentaTerceros = nombreacuentater,
                    RegimenFiscalACuentaTerceros = regimenacuentater,
                    DomicilioFiscalACuentaTerceros = domicilioacuentater,
                   
                };
            }
           
        }
        public Comprobante GetComprobante()
        {
            if (this.TipoDeComprobante == "I" || this.TipoDeComprobante == "E" || this.TipoDeComprobante == "N")
            {
                this.SubTotal = this.Conceptos.Sum(a => a.Importe).TruncateDecimals(this.Moneda_Info.Decimales);
                if (this.Conceptos != null && this.Conceptos.Any(a => a.DescuentoSpecified))
                {
                    this.Descuento = this.Conceptos.Sum(a => a.Descuento).TruncateDecimals(this.Moneda_Info.Decimales);
                    this.DescuentoSpecified = true;
                }
            }
            else if (this.TipoDeComprobante == "T" || this.TipoDeComprobante == "P")
                this.SubTotal = 0;
            decimal totalCalculado = 0;
            totalCalculado = this.SubTotal - this.Descuento;
            if (this.Impuestos != null)
                totalCalculado = (totalCalculado + this.Impuestos.TotalImpuestosTrasladados) - this.Impuestos.TotalImpuestosRetenidos;
            this.Total = totalCalculado;

            if (this.Impuestos != null)
            {
                if (this.Impuestos.Traslados != null && this.Impuestos.Traslados.Count() > 0)
                {
                    int countTasa = this.Impuestos.Traslados.Count(a => a.TipoFactor.Trim().ToLower() == "tasa");
                    int countExento = this.Impuestos.Traslados.Count(a => a.TipoFactor.Trim().ToLower() == "exento");
                    if (countTasa <= 0 && countExento >= 1)
                    {
                        this.Impuestos.TotalImpuestosTrasladadosSpecified = false;
                    }
                    else
                    {
                        this.Impuestos.TotalImpuestosTrasladados = this.Impuestos.Traslados.Sum(a => a.Importe);
                        this.Impuestos.TotalImpuestosTrasladadosSpecified = true;
                        this.Total += this.Impuestos.TotalImpuestosTrasladados;
                    }



                }

                if (this.Impuestos.Retenciones != null && this.Impuestos.Retenciones.Length > 0)
                {
                    this.Impuestos.TotalImpuestosRetenidos = this.Impuestos.Retenciones.Sum(a => a.Importe);
                    this.Impuestos.TotalImpuestosRetenidosSpecified = true;
                    this.Total -= this.Impuestos.TotalImpuestosTrasladados;
                }
            }
            return this;
        }

    }
}
