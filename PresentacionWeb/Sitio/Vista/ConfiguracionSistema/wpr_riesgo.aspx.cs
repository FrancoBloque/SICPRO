using Common;
using EntidadesClases.ModelSicPro;
using Logica.Consumo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PresentacionWeb.Sitio.Vista.ConfiguracionSistema
{
    public partial class wpr_riesgo : System.Web.UI.Page
    {
        ConsumoConfiguracionSistema logicaConfiguracion = new ConsumoConfiguracionSistema();
        protected void Page_Load(object sender, EventArgs e)
        {
        }
        protected void btnguardar_Click(object sender, EventArgs e)
        {
            try
            {
                bool sw = false;
                string str = string.Empty;
                if (cod_mod.Text.Trim().Length == 0)
                {
                    str += "Debe Registrar un Código Válido\n";
                    sw = true;
                }
                if (cod_ram.Text.Trim().Length == 0)
                {
                    str += "Debe Registrar un Código Válido\n";
                    sw = true;
                }
                if (cod_pol.Text.Trim().Length == 0)
                {
                    str += "Debe Registrar un Código Válido\n";
                    sw = true;
                }
                if (desc_riesgo.Text.Trim().Length == 0)
                {
                    str += "Debe Registrar un Riesgo Válido\n";
                    sw = true;
                }
                if (cobertura.SelectedIndex == 0)
                {
                    str += "Debe Registrar una Cobertura Válida\n";
                    sw = true;
                }
                if (sw)
                {
                    lblerror.Text = str;
                    popUpValidacion.ShowOnPageLoad = true;
                }
                else
                {
                    logicaConfiguracion.InsertarRiesgo(cod_mod.Text.ToUpper(), cod_ram.Text.ToUpper(), cod_pol.Text.ToUpper(), desc_riesgo.Text.ToUpper(), cobertura.SelectedValue);
                    this.lblmensaje.Text = "Nuevo riesgo insertado";
                }
            }
            catch (SecureExceptions ex)
            {
                throw new SecureExceptions("Error al Generar la Consulta", (Exception)ex);
            }
        }
    }
}