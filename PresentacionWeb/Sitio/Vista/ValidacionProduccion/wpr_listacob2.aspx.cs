using Common;
using DevExpress.Web;
using EntidadesClases.ModelSicPro;

using Logica.Consumo;
using PresentacionWeb.Lib;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PresentacionWeb.Sitio.Vista.ValidacionProduccion
{
    public partial class wpr_listacob2 : System.Web.UI.Page
    {
        ConsumoValidarProd _objConsumoValidarProd = new ConsumoValidarProd();
        private long ll = 0;
        private long aa = 0;
        private long bb = 0;
        private long cc = 0;
        private long dd = 0;
        public static string valor;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                fc_finvig.Text = DateTime.Now.ToShortDateString();
                fc_inivig.Text = DateTime.Now.ToShortDateString();
                Limpiar();
                wpr_listacob2.valor = base.Request.QueryString["var"];
                id_clamov.Value = wpr_listacob2.valor;
                Datos();


            }
        }
        private void Limpiar()
        {
            id_per.Value = "";
            id_producto.Value = "0";
            id_spvs.Value = "";
        }

        private void Datos()
        {
            msgboxpanel.Visible = false;
            if (!vigencia.Checked & (num_poliza.Text.ToUpper() == "") & (nomraz.Text.ToUpper() == "") & (nomco.Text.ToUpper() == "") & (desc_producto.Text.ToUpper() == "") & !porvencer.Checked)
            {
                //msgboxpanel.Visible = true;
                //MessageBox messageBox = new MessageBox(base.Server.MapPath("../msgbox1.tpl"));
                //messageBox.SetTitle("Información");
                //messageBox.SetIcon("msg_icon_2.png");
                //messageBox.SetMessage("<p style='color:#990000; font-weight:bold'>Introduzca Criterios de Búsqueda</p>");
                //messageBox.SetOKButton("msg_button_class1");
                //this.msgboxpanel.InnerHtml = messageBox.ReturnObject();
                //this.lblmensaje.Text = "Introduzca Criterios de Búsqueda";
                return;
            }
            //Cpr_cobranzas prCobranza = new Cpr_cobranzas();

            string item = base.Request.QueryString["var"];
            //prCobranza.lblmensaje = this.lblmensaje;
            //prCobranza.num_poliza = this.num_poliza;
            //prCobranza.id_perclie = this.id_per;
            //prCobranza.fc_inivig = this.fc_inivig;
            //prCobranza.fc_finivig = this.fc_finvig;
            //prCobranza.fc_finvig = this.fc_polizavencida;
            //prCobranza.id_spvs1 = this.id_spvs;
            //prCobranza.id_producto = this.id_producto;
            //prCobranza.vigencia = this.vigencia;
            //prCobranza.porvencer = this.porvencer;
            //prCobranza.a = this.ap;
            //prCobranza.b = this.bp;
            //prCobranza.RecuperaTablaPolizaNRI(item);

            //RecuperaTablaPolizaNRI(item);
            var dataTable = _objConsumoValidarProd.ObtenerTablaPolizaAp(item, num_poliza.Text.ToUpper(), id_per.Value, id_spvs.Value, id_producto.Value, vigencia.Checked, fc_inivig.Date, fc_finvig.Date, fc_polizavencida.Date, porvencer.Checked);
            Session["lstGridPoliza"] = dataTable;
            gridpoliza.DataSource = dataTable;
            gridpoliza.DataBind();
            this.gridcontainer.Visible = true;
        }



        protected void btnserprod_Click(object sender, EventArgs e)
        {
            if (nomco.Text.Trim() == "")
            {
                //    //this.msgboxpanel.Visible = true;
                //    //MessageBox messageBox = new MessageBox(base.Server.MapPath("../msgbox1.tpl"));
                //    //messageBox.SetTitle("Validación de Datos");
                //    //messageBox.SetIcon("msg_icon_2.png");
                //    //messageBox.SetMessage("<p style='color:#990000; font-weight:bold'>Seleccione una Compañia Existente <br />Para realizar la Busqueda de un Producto</p>");
                //    //messageBox.SetOKButton("msg_button_class1");
                //    //this.msgboxpanel.InnerHtml = messageBox.ReturnObject();
                lblmensaje.Text = "Seleccione una Compañia Existente Para realizar la Busqueda de un Producto";
                return;
            }

            var dt = _objConsumoValidarProd.ObtenerTablaProductoL(id_spvs.Value, desc_producto.Text.ToUpper());
            Session["lstProducto"] = dt;
            grdProducto.DataSource = dt;
            grdProducto.DataBind();

            pCProducto.ShowOnPageLoad = true;
            ////this.msgboxpanel.Visible = true;
            ////MessageBox messageBox1 = new MessageBox(base.Server.MapPath("../msgboxprod.tpl"));
            ////messageBox1.SetTitle("Busqueda de Productos por Compañia");
            ////messageBox1.SetIcon("search_user.png");
            ////messageBox1.SetMessage(str);
            ////messageBox1.SetOKButton("msg_button_class");
            ////this.msgboxpanel.InnerHtml = messageBox1.ReturnObject();
            //a.Value = "0";
            //b.Value = "10";
        }

        protected void btnbuscar_Click(object sender, EventArgs e)
        {
            Datos();
        }
        protected void btnnuevo_Click(object sender, EventArgs e)
        {
            //this.msgboxpanel.Visible = false;
            base.Response.Redirect(string.Concat("~/wpr_listacob1.aspx?var=", wpr_listacob1.valor));
        }

        protected void btnsercom_Click(object sender, EventArgs e)
        {


            var dt = _objConsumoValidarProd.ObtenerTablaCompania(nomco.Text.ToUpper());
            Session["lstCompania"] = dt;
            grdCompania.DataSource = dt;
            grdCompania.DataBind();

            pCCompania.ShowOnPageLoad = true;

        }

        protected void btnserper_Click(object sender, EventArgs e)
        {

            var dt = _objConsumoValidarProd.ObtenerTablaPersonasC(nomraz.Text.ToUpper());
            Session["lstPersonas"] = dt;
            grdPersonas.DataSource = dt;
            grdPersonas.DataBind();

            pCPersona.ShowOnPageLoad = true;


        }

        protected void CallBPersona_Callback(object sender, DevExpress.Web.CallbackEventArgsBase e)
        {
            var index = e.Parameter;
            var idPer = grdPersonas.GetRowValues(Convert.ToInt32(index), "id_per").ToString();
            var nombre = grdPersonas.GetRowValues(Convert.ToInt32(index), "nomraz").ToString();
            nomraz.Value = nombre;
            id_per.Value = idPer;

        }

        protected void btnserper1_Click(object sender, EventArgs e)
        {
            var dt = _objConsumoValidarProd.ObtenerTablaPersonasC(nomraz1.Text.ToUpper());
            Session["lstPersonas"] = dt;
            grdPersonas.DataSource = dt;
            grdPersonas.DataBind();
        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            pCPersona.ShowOnPageLoad = false;
        }

        protected void grdPersonas_DataBinding(object sender, EventArgs e)
        {
            grdPersonas.DataSource = Session["lstPersonas"];
        }

        protected void CallBCompania_Callback(object sender, DevExpress.Web.CallbackEventArgsBase e)
        {
            var index = e.Parameter;
            var idCompania = grdCompania.GetRowValues(Convert.ToInt32(index), "id_spvs").ToString();
            var nombreCompania = grdCompania.GetRowValues(Convert.ToInt32(index), "nomraz").ToString();
            nomco.Value = nombreCompania;
            id_spvs.Value = idCompania;
        }

        protected void btnnomco_Click(object sender, EventArgs e)
        {
            var dt = _objConsumoValidarProd.ObtenerTablaCompania(nomco1.Text.ToUpper());
            Session["lstCompania"] = dt;
            grdCompania.DataSource = dt;
            grdCompania.DataBind();

        }

        protected void grdCompania_DataBinding(object sender, EventArgs e)
        {
            grdCompania.DataSource = Session["lstCompania"];
        }

        protected void btnAceptarCompania_Click(object sender, EventArgs e)
        {
            pCCompania.ShowOnPageLoad = false;
        }

        protected void CallBProducto_Callback(object sender, DevExpress.Web.CallbackEventArgsBase e)
        {
            var index = e.Parameter;
            var idProducto = grdProducto.GetRowValues(Convert.ToInt32(index), "id_producto").ToString();
            var nombreProducto = grdProducto.GetRowValues(Convert.ToInt32(index), "desc_prod").ToString();
            desc_producto.Value = nombreProducto;
            id_producto.Value = idProducto;
        }

        protected void btnProd_Click(object sender, EventArgs e)
        {
            var dt = _objConsumoValidarProd.ObtenerTablaProductoL(id_spvs.Value.ToUpper(), desc_producto1.Text.ToUpper());
            Session["lstProducto"] = dt;
            grdProducto.DataSource = dt;
            grdProducto.DataBind();
        }

        protected void btnAceptarProducto_Click(object sender, EventArgs e)
        {
            pCProducto.ShowOnPageLoad = false;
        }

        protected void grdProducto_DataBinding(object sender, EventArgs e)
        {
            grdProducto.DataSource = Session["lstProducto"];
        }

        protected void gridpoliza_DataBinding(object sender, EventArgs e)
        {
            gridpoliza.DataSource = Session["lstGridPoliza"];
        }



        protected void CallBGridPoliza_Callback(object sender, DevExpress.Web.CallbackEventArgsBase e)
        {
            var index = e.Parameter;
            var idPoliza = gridpoliza.GetRowValues(Convert.ToInt32(index), "id_poliza").ToString();
            var idMovimiento = gridpoliza.GetRowValues(Convert.ToInt32(index), "id_movimiento").ToString();
            var idClamov = gridpoliza.GetRowValues(Convert.ToInt32(index), "id_clamov").ToString();
            if (this.IsCallback)
                ASPxWebControl.RedirectOnCallback("../RegistroProduccion/wpr_polizacobranzaap.aspx?var=" + idPoliza + "&val=" + idMovimiento + "&ver=" + idClamov);
            else

                Response.Redirect("../RegistroProduccion/wpr_polizacobranzaap.aspx?var=" + idPoliza + "&val=" + idMovimiento + "&ver=" + idClamov);

        }
        public string Grupo(object num)
        {

            if (num == null)
                return "";
            if (Convert.ToInt32(num) == 0)
                return "SIN GRUPO";

            string descGrupo = "";
            if (!string.IsNullOrEmpty(num.ToString()))
            {
                var idGrupo = Convert.ToInt64(num.ToString());
                descGrupo = _objConsumoValidarProd.objGrupoById(idGrupo).desc_grupo;
            }
            return descGrupo;
        }
        public string CompaniaAseg(object num)
        {
            if (num == null)
                return "";
            string descCompania = "";
            if (!string.IsNullOrEmpty(num.ToString()))
            {

                descCompania = _objConsumoValidarProd.GetDescCompaniaById(num.ToString());
            }
            return descCompania;
        }
        public string NombreProducto(object num)
        {
            if (num == null)
                return "";
            string descProducto = "";
            if (!string.IsNullOrEmpty(num.ToString()))
            {
                var idProducto = Convert.ToInt64(num.ToString());
                descProducto = _objConsumoValidarProd.GetProductoById(idProducto).desc_prod;
            }
            return descProducto;
        }
        public string TipoPoliza(object num)
        {
            if (num == null)
                return "";
            string descProducto = "";
            if (!string.IsNullOrEmpty(num.ToString()))
            {
                var idProducto = Convert.ToInt64(num.ToString());
                var tipo = _objConsumoValidarProd.GetPolizaByIdPoliza(idProducto).clase_poliza;
                if ((bool)tipo)
                    descProducto = "Normal";
                else descProducto = "Flotante";

            }
            return descProducto;
        }
        public string FormaPago(object num)
        {
            if (num == null)
                return "";
            string formaPago = "";
            if (Convert.ToBoolean(num.ToString()))

                formaPago = "Contado";
            else formaPago = "Crédito";


            return formaPago;
        }
        public string Ejecutivo(object num)
        {
            if (num == null)
                return "";
            string nomEjecutivo = "";
            if (!string.IsNullOrEmpty(num.ToString()))
            {
                var idEjecutivo = num.ToString();
                nomEjecutivo = _objConsumoValidarProd.GetPersonaById(idEjecutivo).nomraz;
            }
            return nomEjecutivo;
        }
    }
}