using DevExpress.Web.Bootstrap;
using DevExpress.Web;
using EntidadesClases.ModelSicPro;
using Logica.Consumo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PresentacionWeb.Sitio.Vista.ModuloCobranzas
{
    public partial class wpr_amortizaanexos : System.Web.UI.Page
    {
        ConsumoRegistroProd _objConsumoRegistroProd = new ConsumoRegistroProd();
        ConsumoModComision _objConsumoModComision = new ConsumoModComision();
        ConsumoValidarProd _objValidarProd = new ConsumoValidarProd();
        ConsumoCobranza conCobranza = new ConsumoCobranza();
        bool sw = false;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                return;
            }
            bool isPostBack = this.Page.IsPostBack;
        }

        protected void btnserper_Click(object sender, EventArgs e)
        {

            var dt = _objValidarProd.ObtenerTablaPersonasC(nomraz.Text.ToUpper());
            Session["lstPersonas"] = dt;
            grdPersonas.DataSource = dt;
            grdPersonas.DataBind();

            pCPersona.ShowOnPageLoad = true;


        }

        protected void btnSelect_Click(object sender, EventArgs e)
        {
            BootstrapButton button = sender as BootstrapButton;
            var container = button.NamingContainer as GridViewDataItemTemplateContainer;
            string[] valores = container.KeyValue.ToString().Split('|');


            var idPer = valores[0];
            var nomRaz = valores[1];
            id_per.Value = idPer;
            nomraz.Text = nomRaz;
            Polizas();
            pCPersona.ShowOnPageLoad = false;
        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            pCPersona.ShowOnPageLoad = false;
        }

        protected void btnguardar_Click(object sender, EventArgs e)
        {
            string msg = string.Empty;
            double num;
            double num1;

            if (this.mcheque.Number == 0)
            {

                msg = string.Concat(msg, "<br /> Debe Registrar un Monto");
                this.sw = true;
            }
            if (string.IsNullOrEmpty(this.cheque.Text))
            {
                msg = string.Concat(msg, "<br /> Debe Registrar un Cheque");
                this.sw = true;
            }
            if (string.IsNullOrEmpty(this.pago_por.Text))
            {

                msg = string.Concat(msg, "<br /> Debe Registrar un Concepto");
                this.sw = true;
            }
            if (string.IsNullOrEmpty(this.banco.Text))
            {
                msg = string.Concat(msg, "<br /> Debe Registrar un Banco");
                this.sw = true;
            }
            if (this.sw)
            {

                msg = string.Concat("<span>Los siguientes valores deben ser verificados antes de proseguir<br /></span><p style='color:#990000; font-weight:bold'>", msg, "</p>");

                imagenFail.Visible = true;
                imagenOk.Visible = false;
                lblMensaje.Text = "Hubo un error al registrar los datos!";
                pnlMensaje.ShowOnPageLoad = true;
                return;
            }
            if (this.saldo_devolucion.Text.Length <= 6)
            {
                num = double.Parse(this.saldo_devolucion.Text.Replace(".", ","));
            }
            else
            {
                num = double.Parse(this.saldo_devolucion.Text.Replace(",", ""));
                num /= 100;
            }
            if (this.mcheque.Text.Length <= 6)
            {
                num1 = double.Parse(this.mcheque.Text.Replace(".", ","));
            }
            else
            {
                num1 = double.Parse(this.mcheque.Text.Replace(",", ""));
                num1 /= 100;
            }
            if (num < num1)
            {
                msg = "El Monto a Pagar tiene que ser menor al Saldo de Devolución";
                imagenFail.Visible = true;
                imagenOk.Visible = false;
                lblMensaje.Text = msg + " - Hubo un error al registrar los datos!";
                pnlMensaje.ShowOnPageLoad = true;
                return;
            }
            var mcheque = Convert.ToDecimal(this.mcheque.Number);
            pr_devolucion prDev = new pr_devolucion()
            {
                id_poliza = Convert.ToInt64(num_poliza.Value),
                id_movimiento = Convert.ToInt64(no_liquida.Value),
                id_devolucion = Convert.ToInt64(cuota_devolucion),

                cheque = cheque.Text.ToUpper(),
                devolucion_por = pago_por.Text.ToUpper(),
                banco = banco.Text.ToUpper()
            };
            if (conCobranza.ActualizarDev(prDev, mcheque))
            {
                lblMensaje.Text = "Amortizacion Realizada!";
                imagenFail.Visible = false;
                imagenOk.Visible = true;
                pnlMensaje.ShowOnPageLoad = true;
                return;
            }
            else
            {
                imagenFail.Visible = true;
                imagenOk.Visible = false;
                lblMensaje.Text = "Hubo un error al registrar los datos!";
                pnlMensaje.ShowOnPageLoad = true;
                return;
            }
        }
        
        protected void btnserper1_Click(object sender, EventArgs e)
        {
            var dt = _objValidarProd.ObtenerTablaPersonasC(nomraz1.Text.ToUpper());
            Session["lstPersonas"] = dt;
            grdPersonas.DataSource = dt;
            grdPersonas.DataBind();
        }
        protected void grdPersonas_DataBinding(object sender, EventArgs e)
        {
            grdPersonas.DataSource = Session["lstPersonas"];
        }
        private void Limpiar()
        {
            this.id_perclie.Value = "";
            this.id_per.Value = "";
            this.nomraz.Text = "";
            this.num_poliza.Value = "";
            this.no_liquida.Value = "";
            this.cuota_devolucion.Value = "";
            this.banco.Text = "";
            this.saldo_devolucion.Text = "";
            this.monto_devolucion.Text = "";
            this.mcheque.Text = "";
            this.cheque.Text = "";
            this.pago_por.Text = "";
        }


        private void Polizas()
        {
            var lstPoliza = conCobranza.ObtenerPoliza1(id_per.Value);
            num_poliza.DataSource = lstPoliza;
            num_poliza.TextField = "num_poliza";
            num_poliza.ValueField = "id_poliza";
            num_poliza.DataBind();

        }

        protected void num_poliza_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {

                var lstLiq = conCobranza.ObtenerMovimiento1(Convert.ToInt64(num_poliza.Value));

                this.no_liquida.DataSource = lstLiq;
                this.no_liquida.TextField = "no_liquida";
                this.no_liquida.ValueField = "id_movimiento";
                this.no_liquida.DataBind();
            }
            catch
            {
            }
        }

        protected void no_liquida_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {

                var lstCuotas = conCobranza.GetCuotasDev(Convert.ToInt64(num_poliza.Value), Convert.ToInt64(no_liquida.Value));

                this.cuota_devolucion.DataSource = lstCuotas;
                this.cuota_devolucion.TextField = "cuota_devolucion1";
                this.cuota_devolucion.ValueField = "id_devolucion";
                this.cuota_devolucion.DataBind();
            }
            catch
            {
            }
        }

        protected void cuota_devolucion_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                var lstCuotas = conCobranza.DatosDev(Convert.ToInt64(num_poliza.Value), Convert.ToInt64(no_liquida.Value), Convert.ToInt64(cuota_devolucion.Value)).FirstOrDefault();
                if (lstCuotas != null)
                {
                    monto_devolucion.Text = lstCuotas.monto_devolucion.ToString();
                    saldo_devolucion.Text = lstCuotas.saldo_devolucion.ToString();
                }
            }
            catch
            {
            }
        }

        protected void btnNuevo_Click(object sender, EventArgs e)
        {

            //if ((this.id_perclie.Value == "") | this.id_perclie.Value == null)
            //{
            //    this.Polizas();
            //}
            Limpiar();
        }
    }
}