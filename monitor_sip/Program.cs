using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace monitor_sip
{
    class Program
    {
        static void Main(string[] args)
        {
            EndpointAddress endpoint = new EndpointAddress("http://sapqascloud.satus.lan:8000/sap/bc/srt/wsdl/flv_10002A111AD1/bndg_url/sap/bc/srt/rfc/sap/zinterfaces_sip_sap/300/zinterfaces_sip_sap/zmm_ifz_sip_sap?sap-client=300");
            ServiceReference1.ZINTERFACES_SIP_SAPClient WS = new ServiceReference1.ZINTERFACES_SIP_SAPClient();


            try
            {
                WS.ClientCredentials.UserName.UserName = "CRYSTALIS_AB";
                WS.ClientCredentials.UserName.Password = "Seidor-2020";


                ServiceReference1.ZMmSipMovPlanta input = new ServiceReference1.ZMmSipMovPlanta();

                ServiceReference1.ZMmSipMovPlantaRequest input2 = new ServiceReference1.ZMmSipMovPlantaRequest();
                ServiceReference1.ZMmSipMovPlantaResponse output = new ServiceReference1.ZMmSipMovPlantaResponse();

                input.ItPosicion = new ServiceReference1.ZsmmSipIf3Posicion[1];

                input.IsCabecera = new ServiceReference1.ZsmmSipIf3Cabecera
                {

                    //Cabecera
                    FechaDocumento = "2020-03-01",
                    FechaContabilizacion = "2020-03-01",
                    Texto = " ",
                    Nota = "0020R00002040",
                    DocMat = "",
                    DocYear = "",
                    Wvers3 = "3"
                };

                //Posiciones
                input.ItPosicion[0] = new ServiceReference1.ZsmmSipIf3Posicion
                {
                    ClaseMovimiento = "303",
                    NroMaterial = "",
                    Centro = "1100",
                    Almacen = "1120",
                    Lote = "D170804012",
                    Cantidad = 10,
                    NroMaterial2 = "500245",
                    Centro2 = "1200",
                    Almacen2 = "1281",
                    Lote2 = "D170804012",
                    Motivo = "0000",
                    CentroCosto = "",
                    Orden = "",
                    Pedido = "",
                    Posicion = "0000",
                    Texto = ""
                };


                output = WS.ZMmSipMovPlanta(input);

                var serxml = new System.Xml.Serialization.XmlSerializer(output.GetType());
                var ms = new MemoryStream();
                serxml.Serialize(ms, output);
                string xml = Encoding.UTF8.GetString(ms.ToArray());
                Console.Write(xml);
                WS.Close();
            }
            catch (Exception e)
            {
                Console.Write(e.Message);
            }
        }
    }
}
