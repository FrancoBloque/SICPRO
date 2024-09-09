using EntidadesClases.ModelSicPro;
using Logica.Consumo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PresentacionWeb.Sitio.Vista.ModuloComisiones
{
    public partial class wco_anticom : System.Web.UI.Page
    {
        ConsumoModComision consumoMod = new ConsumoModComision();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                fc_solicitud.Text = DateTime.Now.ToShortDateString();
               var lstPersona= consumoMod.Persona(60);
                id_percart.DataSource= lstPersona;
                id_percart.TextField = "nomraz";
                id_percart.ValueField= "id_per";
                id_percart.DataBind();
                id_percart.Focus();
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            co_anticom coAnticom = new co_anticom()
            {
                id_percart = id_percart.Value.ToString(),
                imp_anticipo =Convert.ToDecimal( imp_anticipo.Text),
                fc_solicitud =(DateTime) fc_solicitud.Value,
                desc_anti = desc_anti.Text.ToUpper(),
                doc_cont = doc_cont.Text.ToUpper()
            };
            if (consumoMod.InsAnticomi(coAnticom))
            {
                lblMensaje.Text = "Insertado";
                pnlMensaje.ShowOnPageLoad = true;
                imagenOk.Visible = true;
                imagenFail.Visible = false;
                //return;
                id_percart.Text = "";
               imp_anticipo.Text = "";
                fc_solicitud.Text = "";
                doc_cont.Text = "";
                desc_anti.Text = "";
            }
            else
            {
                imagenOk.Visible = false;
                imagenFail.Visible = true;
                lblMensaje.Text = "No Insertado";
                pnlMensaje.ShowOnPageLoad = true;
            }
            
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            base.Response.Redirect("~/wco_anticom.aspx");
        }
    }
}