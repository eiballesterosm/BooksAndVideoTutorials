using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DropDownList1.DataSource = SqlDataSource1;
            DropDownList1.DataBind();
        }

        private void Test()
        {
            WSDesmaterializado.RequestWSDesmaterializadoReq l_objRequest = new WSDesmaterializado.RequestWSDesmaterializadoReq();
            WSDesmaterializado.ResponseWSDesmaterializadoResp l_objResponse = new WSDesmaterializado.ResponseWSDesmaterializadoResp();
            WSDesmaterializado.SIOTypeClient l_objConsulta = new WSDesmaterializado.SIOTypeClient();

            l_objRequest.NumeroSolicitud = "p_strNumSolicitud";
            l_objRequest.NumeroID = 10;
            l_objRequest.TipoID = 1;

            try
            {
                l_objResponse = l_objConsulta.WSDesmaterializado(l_objRequest);
                if (l_objResponse != null)
                {
                    if (l_objResponse.respuesta == 1)
                    {    
                        string p_strNombreCliente = l_objResponse.Cliente[0].PrimerNombre + " " + l_objResponse.Cliente[0].SegundoNombre +
                            " " + l_objResponse.Cliente[0].PrimerApellido + " " + l_objResponse.Cliente[0].SegundoApellido;
                    }
                    else
                    {
                    }
                }
                else
                {
                }
            }
            catch (Exception p_objException)
            {
                throw p_objException;
            }
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}