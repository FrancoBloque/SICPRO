using DevExpress.Web;
using DevExpress.Web.Bootstrap;
using EntidadesClases.CustomModelEntities;
using Logica.Consumo;
using PresentacionWeb.Sitio.Vista.ValidacionProduccion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PresentacionWeb.Sitio.Vista.RegistroProduccion
{
    public partial class wpr_listaapli : System.Web.UI.Page
    {
        ConsumoValidarProd _objConsumoValidarProd = new ConsumoValidarProd();
        ConsumoRegistroProd _objConsumoRegistroProd = new ConsumoRegistroProd();
        //private long ll = 0;
        //private long aa = 0;
        //private long bb = 0;
        //private long cc = 0;
        //private long dd = 0;
        public static string valor;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                return;
            }
            if (!IsPostBack)
            {
                fc_finvig.Text = DateTime.Now.ToShortDateString();
                fc_inivig.Text = DateTime.Now.ToShortDateString();
                Limpiar();
            }
        }

        #region metodos
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
                this.lblmensaje.Text = "Introduzca Criterios de Búsqueda";
                return;
            }
            var objTablaPolizaIn = new OC_ObtenerTablaPolizaIn();
            objTablaPolizaIn.num_poliza = num_poliza.Text.ToUpper();
            objTablaPolizaIn.id_perclie = id_per.Value;
            objTablaPolizaIn.id_spvs = id_spvs.Value;
            objTablaPolizaIn.id_producto = Convert.ToInt64(id_producto.Value);
            objTablaPolizaIn.vigencia = vigencia.Checked;
            objTablaPolizaIn.fc_inivig = fc_inivig.Date;
            objTablaPolizaIn.fc_finvig = fc_finvig.Date;
            objTablaPolizaIn.fc_polizavencida = fc_polizavencida.Date;
            objTablaPolizaIn.porvencer = porvencer.Checked;

            var lstResponse = _objConsumoRegistroProd.ObtenerTablaPolizaAp(objTablaPolizaIn);
            Session["LST_LISTA_APLI"] = lstResponse;
            //gridpoliza.DataSource = lstResponse;
            gridpoliza.DataBind();
            this.gridcontainer.Visible = true;
        }

        public string Grupo(object num)
        {

            if (num == null)
                return "";

            if (Convert.ToInt64(num) == 0)
                return "";

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

        #endregion

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
            base.Response.Redirect("~/Sitio/Vista/RegistroProduccion/wpr_listaapli.aspx");
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

        protected void btnSeleccionar_Click(object sender, EventArgs e)
        {
            Button control = (Button)sender;
            GridViewDataItemTemplateContainer container = (GridViewDataItemTemplateContainer)control.NamingContainer;
            var index = container.VisibleIndex;

            var idPoliza = gridpoliza.GetRowValues(index, "id_poliza")?.ToString();
            var idMovimiento = gridpoliza.GetRowValues(index, "id_movimiento")?.ToString();
            ////var idPoliza = gridpoliza.GetRowValues(_grid.EditingRowVisibleIndex, "id_poliza").ToString();
            Response.Redirect("wpr_polizaapli.aspx?var=" + idPoliza + "&val=" + idMovimiento);

            ////TextBox _textBox = _grid.GetDataItemControl(_grid.FocusedRowIndex, "CustomCode", "txtCustCode") as TextBox;

            ////String _text = _textBox.Text;

            ////https://stackoverflow.com/questions/64555062/how-to-access-gridviewdatacolumn-of-detailrow-on-server-side

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
            if (Session["LST_LISTA_APLI"] != null)
            {
                gridpoliza.DataSource = Session["LST_LISTA_APLI"];                
            }
        }

        protected void gridpoliza_HtmlDataCellPrepared(object sender, BootstrapGridViewTableDataCellEventArgs e)
        {
            if (e.DataColumn.Caption == "Opciones")
                e.Cell.Attributes.Add("onclick", "event.cancelBubble = true");
            //if (e.DataColumn.FieldName == "UnitPrice")
            //    e.Cell.Attributes.Add("onclick", "event.cancelBubble = true");

            ////https://supportcenter.devexpress.com/ticket/details/t189804/gridview-how-to-disable-row-click-in-particular-column
        }
    }
}