using DevExpress.Web;
using DevExpress.Web.Bootstrap;
using EntidadesClases.ModelSicPro;
using Logica.Consumo;
using PresentacionWeb.Parametros;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PresentacionWeb.Sitio.Vista.ReportesSistema
{
    public partial class wpr_reportes : System.Web.UI.Page
    {
        ConsumoRegistroProd _objConsumoRegistroProd = new ConsumoRegistroProd();
        ConsumoValidarProd _objConsumoValidarProd = new ConsumoValidarProd();

        CParametros _cParametros = new CParametros();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Combos();
                divMensajeError.Visible = false;
                lblMensaje.Text = string.Empty;
            }
            return;
        }

        #region metodos

        private void Combos()
        {
            try
            {
                var lstParametroRe = _objConsumoRegistroProd.ParametroRE("id_suc");
                var lstParametroA = _objConsumoRegistroProd.ParametroA("id_div");
                var lstParametro = _objConsumoRegistroProd.ParametroA("id_clamov");

                var lstPersona60 = _objConsumoRegistroProd.Persona(60);
                var lstPersona30 = _objConsumoRegistroProd.Persona(30);

                var lstCompanias = _objConsumoRegistroProd.ObtenerListaCompania();

                var lstRiesgo = _objConsumoRegistroProd.ObtenerRiesgo();

                var lstGrupo = _objConsumoRegistroProd.ObtenerGrupo();

                var lstMeses = _cParametros.GetListMeses();

                var lstRangoFechas = _cParametros.GetListRangoFechas();

                var lstComparaPrima = _cParametros.GetListComparaPrima();

                #region Clientes

                cmbOficina.DataSource = lstParametroRe;
                cmbOficina.ValueField = "id_par";
                cmbOficina.TextField = "desc_param";
                cmbOficina.DataBind();

                cmbOficina.SelectedIndex = 0;

                cmbAniv.DataSource = lstMeses;
                cmbAniv.TextField = "value";
                cmbAniv.ValueField = "key";
                cmbAniv.DataBind();
                cmbAniv.SelectedIndex = 0;
                #endregion

                #region Grupos

                cmbGrupoGrupos.DataSource = lstGrupo;
                cmbGrupoGrupos.ValueField = "id_gru";
                cmbGrupoGrupos.TextField = "desc_grupo";
                cmbGrupoGrupos.DataBind();

                //cmbGrupoGrupos.SelectedIndex = 0;
                var itemSeleccioneGrupos = new BootstrapListEditItem { Text = "SELECCIONE...", Value = 0, Selected = true, Index = 0 };
                cmbGrupoGrupos.Items.Add(itemSeleccioneGrupos);


                cmbSucursalGrupos.DataSource = lstParametroRe;
                cmbSucursalGrupos.ValueField = "id_par";
                cmbSucursalGrupos.TextField = "desc_param";
                cmbSucursalGrupos.DataBind();

                //cmbSucursalGrupos.SelectedIndex = 0;

                var itemSeleccioneTodosSucursal = new BootstrapListEditItem { Text = "SELECCIONE TODAS", Value = "*", Selected = true, Index = 0 };
                cmbSucursalGrupos.Items.Add(itemSeleccioneTodosSucursal);

                #endregion

                #region Proy Cartera

                cmbSucursalCartera.DataSource = lstParametroRe;
                cmbSucursalCartera.ValueField = "id_par";
                cmbSucursalCartera.TextField = "desc_param";
                cmbSucursalCartera.DataBind();

                cmbSucursalCartera.SelectedIndex = 0;

                #endregion

                #region Produccion general

                cmbSucursalProd.DataSource = lstParametroRe;
                cmbSucursalProd.ValueField = "id_par";
                cmbSucursalProd.TextField = "desc_param";
                cmbSucursalProd.DataBind();

                //cmbSucursalProd.SelectedIndex = 0;
                var itemSucursalProd = new BootstrapListEditItem { Text = "SELECCIONE...", Value = 0, Selected = true, Index = 0 };
                cmbSucursalProd.Items.Add(itemSucursalProd);

                cmbDivisaProd.DataSource = lstParametroA;
                cmbDivisaProd.ValueField = "id_par";
                cmbDivisaProd.TextField = "desc_param";
                cmbDivisaProd.DataBind();

                //cmbDivisaProd.SelectedIndex = 0;
                var itemDivisaProd = new BootstrapListEditItem { Text = "SELECCIONE...", Value = 0, Selected = true, Index = 0 };
                cmbDivisaProd.Items.Add(itemDivisaProd);

                cmbCarteraProd.DataSource = lstPersona60;
                cmbCarteraProd.ValueField = "id_per";
                cmbCarteraProd.TextField = "nomraz";
                cmbCarteraProd.DataBind();

                //cmbCarteraProd.SelectedIndex = 0;
                var itemCarteraProd = new BootstrapListEditItem { Text = "SELECCIONE...", Value = 0, Selected = true, Index = 0 };
                cmbCarteraProd.Items.Add(itemCarteraProd);

                cmbEjecutivoProd.DataSource = lstPersona30;
                cmbEjecutivoProd.ValueField = "id_per";
                cmbEjecutivoProd.TextField = "nomraz";
                cmbEjecutivoProd.DataBind();

                //cmbEjecutivoProd.SelectedIndex = 0;
                var itemEjecutivoProd = new BootstrapListEditItem { Text = "SELECCIONE...", Value = 0, Selected = true, Index = 0 };
                cmbEjecutivoProd.Items.Add(itemEjecutivoProd);

                cmbCompaniaProd.DataSource = lstCompanias;
                cmbCompaniaProd.ValueField = "id_spvs";
                cmbCompaniaProd.TextField = "nomraz";
                cmbCompaniaProd.DataBind();

                //cmbCompaniaProd.SelectedIndex = 0;
                var itemCompaniaProd = new BootstrapListEditItem { Text = "SELECCIONE...", Value = 0, Selected = true, Index = 0 };
                cmbCompaniaProd.Items.Add(itemCompaniaProd);

                cmbRamoProd.DataSource = lstRiesgo;
                cmbRamoProd.ValueField = "id_riesgo";
                cmbRamoProd.TextField = "desc_riesgo";
                cmbRamoProd.DataBind();

                //cmbRamoProd.SelectedIndex = 0;
                var itemRamoProd = new BootstrapListEditItem { Text = "SELECCIONE...", Value = 0, Selected = true, Index = 0 };
                cmbRamoProd.Items.Add(itemRamoProd);

                cmbGrupoProd.DataSource = lstGrupo;
                cmbGrupoProd.ValueField = "id_gru";
                cmbGrupoProd.TextField = "desc_grupo";
                cmbGrupoProd.DataBind();
                //cmbGrupoProd.SelectedIndex = 0;
                var itemGrupoProd = new BootstrapListEditItem { Text = "SELECCIONE...", Value = 0, Selected = true, Index = 0 };
                cmbGrupoProd.Items.Add(itemGrupoProd);

                cmbMovimientoProd.DataSource = lstParametro;
                cmbMovimientoProd.ValueField = "id_par";
                cmbMovimientoProd.TextField = "desc_param";
                cmbMovimientoProd.DataBind();
                //cmbMovimientoProd.SelectedIndex = 0;
                var itemMovimientoProd = new BootstrapListEditItem { Text = "SELECCIONE...", Value = 0, Selected = true, Index = 0 };
                cmbMovimientoProd.Items.Add(itemMovimientoProd);

                cmbRangosFechasProd.DataSource = lstRangoFechas;
                cmbRangosFechasProd.ValueField = "key";
                cmbRangosFechasProd.TextField = "value";
                cmbRangosFechasProd.DataBind();
                //cmbRangosFechasProd.SelectedIndex = 0;
                var itemRangosProd = new BootstrapListEditItem { Text = "SELECCIONE...", Value = 0, Selected = true, Index = 0 };
                cmbRangosFechasProd.Items.Add(itemRangosProd);


                cmbPrimaTotal.DataSource = lstComparaPrima;
                cmbPrimaTotal.ValueField = "key";
                cmbPrimaTotal.TextField = "value";
                cmbPrimaTotal.DataBind();

                //cmbPrimaTotal.SelectedIndex = 0;
                var itemPrimaTProd = new BootstrapListEditItem { Text = "SELECCIONE...", Value = 0, Selected = true, Index = 0 };
                cmbPrimaTotal.Items.Add(itemPrimaTProd);

                cmbPrimaNeta.DataSource = lstComparaPrima;
                cmbPrimaNeta.ValueField = "key";
                cmbPrimaNeta.TextField = "value";
                cmbPrimaNeta.DataBind();

                //cmbPrimaNeta.SelectedIndex = 0;
                var itemPrimaNProd = new BootstrapListEditItem { Text = "SELECCIONE...", Value = 0, Selected = true, Index = 0 };
                cmbPrimaNeta.Items.Add(itemPrimaNProd);

                #endregion

                #region Memos

                cmbCarteraMemo.DataSource = lstPersona60;
                cmbCarteraMemo.ValueField = "id_per";
                cmbCarteraMemo.TextField = "nomraz";
                cmbCarteraMemo.DataBind();

                //cmbCarteraMemo.SelectedIndex = 0;
                var itemCarteraMemo = new BootstrapListEditItem { Text = "SELECCIONE...", Value = 0, Selected = true, Index = 0 };
                cmbCarteraMemo.Items.Add(itemCarteraMemo);

                cmbFechasMemo.DataSource = lstRangoFechas;
                cmbFechasMemo.ValueField = "key";
                cmbFechasMemo.TextField = "value";
                cmbFechasMemo.DataBind();
                cmbFechasMemo.SelectedIndex = 0;
                                
                #endregion

                //gr_parametro grParametro = new gr_parametro()
                //{
                //    ddlgeneral = this.id_suc
                //};
                //grParametro.ParametroRE("id_suc");
                //grParametro.ddlgeneral = this.id_suc1;
                //grParametro.ParametroRE("id_suc");
                //grParametro.ddlgeneral = this.id_suc2;
                //grParametro.ParametroRE("id_suc");
                //grParametro.ddlgeneral = this.id_suc3;
                //grParametro.ParametroRE("id_suc"); 
                //grParametro.ddlgeneral = this.id_div;
                //grParametro.ParametroA("id_div");
                //grParametro.ddlgeneral = this.id_clamov;
                //grParametro.Parametro("id_clamov");


                //gr_persona grPersona = new gr_persona()
                //{
                //    id_rol = this.id_percart
                //};
                //grPersona.Persona(60);
                //grPersona.id_rol = this.id_percart1;
                //grPersona.Persona(60);
                //grPersona.id_rol = this.id_perejec;
                //grPersona.Persona(30);
                //(new gr_compania()
                //{
                //    ddlgeneral = this.id_spvs
                //}).ObtenerListaCompania();
                //DataTable dataTable = (new pr_producto()).ObtenerRiesgo();
                //this.id_riesgo.DataSource = dataTable;
                //this.id_riesgo.DataTextField = "desc_riesgo";
                //this.id_riesgo.DataValueField = "id_riesgo";
                //this.id_riesgo.DataBind();
                //pr_grupo prGrupo = new pr_grupo()
                //{
                //    ddlgeneral = this.id_gru
                //};
                //prGrupo.ObtenerGrupo();
                //prGrupo.ddlgeneral = this.id_gru1;
                //prGrupo.ObtenerGrupo();
            }
            catch
            {
                //gr_parametro idSuc1 = new gr_parametro()
                //{
                //    ddlgeneral = this.id_suc
                //};
                //idSuc1.ParametroRE("id_suc");
                //idSuc1.ddlgeneral = this.id_suc1;
                //idSuc1.ParametroRE("id_suc");
                //idSuc1.ddlgeneral = this.id_suc2;
                //idSuc1.ParametroRE("id_suc");
                //idSuc1.ddlgeneral = this.id_suc3;
                //idSuc1.ParametroRE("id_suc");
                //idSuc1.ddlgeneral = this.id_div;
                //idSuc1.ParametroA("id_div");
                //idSuc1.ddlgeneral = this.id_clamov;
                //idSuc1.Parametro("id_clamov");
                //gr_persona idPercart1 = new gr_persona()
                //{
                //    id_rol = this.id_percart
                //};
                //idPercart1.Persona(60);
                //idPercart1.id_rol = this.id_percart1;
                //idPercart1.Persona(60);
                //idPercart1.id_rol = this.id_perejec;
                //idPercart1.Persona(30);
                //(new gr_compania()
                //{
                //    ddlgeneral = this.id_spvs
                //}).ObtenerListaCompania();
                //DataTable dataTable1 = (new pr_producto()).ObtenerRiesgo();
                //this.id_riesgo.DataSource = dataTable1;
                //this.id_riesgo.DataTextField = "desc_riesgo";
                //this.id_riesgo.DataValueField = "id_riesgo";
                //this.id_riesgo.DataBind();
                //pr_grupo idGru1 = new pr_grupo()
                //{
                //    ddlgeneral = this.id_gru
                //};
                //idGru1.ObtenerGrupo();
                //idGru1.ddlgeneral = this.id_gru1;
                //idGru1.ObtenerGrupo();
            }
        }

        #endregion


        protected void CallBPersona_Callback(object sender, CallbackEventArgsBase e)
        {
            var index = e.Parameter;
            var idPer = grdPersonas.GetRowValues(Convert.ToInt32(index), "id_per").ToString();
            var nombre = grdPersonas.GetRowValues(Convert.ToInt32(index), "nomraz").ToString();
            nomraz.Value = nombre;
            id_per.Value = idPer;
        }

        protected void btnserper_Click(object sender, EventArgs e)
        {
            var dt = _objConsumoValidarProd.ObtenerTablaPersonasC(nomraz.Text.ToUpper());
            Session["lstPersonas"] = dt;
            grdPersonas.DataSource = dt;
            grdPersonas.DataBind();

            pCPersona.ShowOnPageLoad = true;


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


        protected void clientes_tab_Click(object sender, EventArgs e)
        {
            divMensajeError.Visible = false;
            lblMensaje.Text = string.Empty;
            hidtab.Value = "nav-clientes-tab";
        }
        protected void grupos_tab_Click(object sender, EventArgs e)
        {
            divMensajeError.Visible = false;
            lblMensaje.Text = string.Empty;
            hidtab.Value = "nav-grupos-tab";
        }
        protected void cartera_tab_Click(object sender, EventArgs e)
        {
            divMensajeError.Visible = false;
            lblMensaje.Text = string.Empty;
            hidtab.Value = "nav-cartera-tab";
        }
        protected void produccion_tab_Click(object sender, EventArgs e)
        {
            divMensajeError.Visible = false;
            lblMensaje.Text = string.Empty;
            hidtab.Value = "nav-produccion-tab";
        }
        protected void memo_tab_Click(object sender, EventArgs e)
        {
            divMensajeError.Visible = false;
            lblMensaje.Text = string.Empty;
            hidtab.Value = "nav-memo-tab";
        }


        protected void cmbCompaniaProd_SelectedIndexChanged(object sender, EventArgs e)
        {
            divMensajeError.Visible = false;
            lblMensaje.Text = string.Empty;

            var response = _objConsumoRegistroProd.ObtenerTablaProducto(Convert.ToString(cmbCompaniaProd.SelectedItem.Value));
            cmbProductoProd.DataSource = response;
            cmbProductoProd.TextField = "desc_prod";
            cmbProductoProd.ValueField = "id_producto";
            cmbProductoProd.DataBind();
        }



        protected void btnGenerarReporteClientes_Click(object sender, EventArgs e)
        {
            divMensajeError.Visible = false;
            lblMensaje.Text = string.Empty;

            var mesAniv = Convert.ToString(cmbAniv.SelectedItem.Value);
            var nomcli = txtNomclie.Text.ToUpper();
            var suc = cmbOficina.SelectedItem.Value;

            reportTabClientes.Visible = true;
            //reportTabClientes.Attributes.Add("src", "https://localhost:44347/Sitio/Vista/Reportes/re_viewer.aspx?r=13&fc=");
            reportTabClientes.Attributes.Add("src", "../Reportes/re_viewer.aspx?r=13&fc=" + mesAniv + "&nc=" + nomcli + "&sc=" + suc);

            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModal();", true);
            //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "none", "<script>$('#exampleModal').modal('show');</script>", false);
            //string[] str = new string[] { "<iframe src='re_viewer.aspx?r=13&fc=", this.mes_aniv.SelectedValue.ToString(), "&nc=", this.nomclie.Text, "&sc=", this.id_suc1.SelectedValue.ToString(), "' runat='server' name='repo' width='100%' scrolling='auto' border='0' marginwidth='0' height='100%'></iframe>" };
        }

        protected void btnGenerarReporteGrupos_Click(object sender, EventArgs e)
        {
            divMensajeError.Visible = false;
            lblMensaje.Text = string.Empty;

            var idGrupo = Convert.ToString(cmbGrupoGrupos.SelectedItem.Value);
            var suc = Convert.ToString(cmbSucursalGrupos.SelectedItem.Value);
            reportTabClientes.Visible = true;
            reportTabClientes.Attributes.Add("src", "../Reportes/re_viewer.aspx?r=15&ig=" + idGrupo + "&sc=" + suc);

            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModal();", true);
        }

        protected void btnGenerarReporteCartera_Click(object sender, EventArgs e)
        {
            divMensajeError.Visible = false;
            lblMensaje.Text = string.Empty;

            var suc = Convert.ToString(cmbSucursalCartera.SelectedItem.Value);
            reportTabClientes.Visible = true;
            reportTabClientes.Attributes.Add("src", "../Reportes/re_viewer.aspx?r=16&sc=" + suc);

            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModal();", true);
        }

        protected void btnGenerarReporteProduccion_Click(object sender, EventArgs e)
        {
            divMensajeError.Visible = false;
            lblMensaje.Text = string.Empty;

            var s = Convert.ToString(cmbSucursalProd.SelectedItem.Value);

            if (string.IsNullOrEmpty(s) || s == "0")
            {
                //this.sw = 1;
                //wpr_reportes wprReporte = this;
                //wprReporte.cad = string.Concat(wprReporte.cad, "Debe Seleccionar una Sucursal <br />");
                divMensajeError.Visible = true;
                lblMensaje.Text = "Debe Seleccionar una Sucursal";
                return;
            }

            var idi = Convert.ToString(cmbDivisaProd.SelectedItem.Value); //this.id_div.SelectedValue

            if (string.IsNullOrEmpty(idi) || idi == "0")
            {
                //this.sw = 1;
                //wpr_reportes wprReporte = this;
                //wprReporte.cad = string.Concat(wprReporte.cad, "Debe Seleccionar una Sucursal <br />");
                divMensajeError.Visible = true;
                lblMensaje.Text = "Debe Seleccionar una Divisa";
                return;
            }

            var ipc = Convert.ToString(id_per.Value); //this.id_per.Value.ToString()
            var nup = Convert.ToString(txtNumPolizaProd.Text.ToUpper()); //this.num_poliza.Text
            var nl = Convert.ToString(txtNumLiquidacionProd.Text.ToUpper()); //this.num_liquida.Text
            var de1 = Convert.ToString(txtDelProd.Text.ToUpper()); //this.del1.Text
            var de2 = Convert.ToString(txtAlProd.Text.ToUpper()); //this.del2.Text

            var ca = Convert.ToString(cmbCarteraProd.SelectedItem.Value); //this.id_percart.SelectedValue
            var ej = Convert.ToString(cmbEjecutivoProd.SelectedItem.Value); //this.id_perejec.SelectedValue
            var sp = Convert.ToString(cmbCompaniaProd.SelectedItem.Value); //this.id_spvs.SelectedValue
            var ip = cmbProductoProd.SelectedItem == null? string.Empty:Convert.ToString(cmbProductoProd.SelectedItem.Value); //this.id_producto.SelectedValue

            var idr = Convert.ToString(cmbRamoProd.SelectedItem.Value); //this.id_riesgo.SelectedValue
            var g = Convert.ToString(cmbGrupoProd.SelectedItem.Value); //this.id_gru.SelectedValue
            var mv = Convert.ToString(cmbMovimientoProd.SelectedItem.Value); //this.id_clamov.SelectedValue
            var fc = Convert.ToString(cmbRangosFechasProd.SelectedItem.Value); //this.ddl_fecha.SelectedValue

            var iv1 = string.IsNullOrEmpty(fechaDelProd.Text) ? string.Empty : fechaDelProd.Date.ToShortDateString(); //this.inivig1.Text
            var iv2 = string.IsNullOrEmpty(fechaAlProd.Text) ? string.Empty : fechaAlProd.Date.ToShortDateString(); //this.inivig2.Text

            var ve0 = Convert.ToString(cmbPrimaTotal.SelectedItem.Value); //this.ve0.SelectedValue
            var pt = Convert.ToString(txtPrimaTotal.Text); //this.ptotal.Text

            var ve = Convert.ToString(cmbPrimaNeta.SelectedItem.Value); //this.ve.SelectedValue
            var pn = Convert.ToString(txtPrimaNeta.Text); //this.pneta.Text
            
            reportTabClientes.Visible = true;
            reportTabClientes.Attributes.Add("src", "../Reportes/re_viewer.aspx?r=2" +
            "&s=" + s + 
			"&ca=" + ca +
			"&ej=" + ej + 
			"&sp=" + sp + 
			"&ip=" + ip + 

			"&iv1=" + iv1 + 
			"&iv2=" + iv2 + 
			"&ipc=" + ipc + 
			"&nup=" + nup + 
			"&pt=" + pt + 

			"&pn=" + pn + 
			"&fc=" + fc + 
			"&nl=" + nl + 
			"&de1=" + de1 + 
			"&de2=" + de2 + 

			"&idi=" + idi +  
			"&idr=" + idr +  
			"&ve=" + ve +  
			"&ve0=" +  ve0 +  
			"&mv=" +  mv +  
			"&g=" +  g
                );
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModal();", true);
        }

        protected void btnGenerarReporteMemo_Click(object sender, EventArgs e)
        {
            divMensajeError.Visible = false;
            lblMensaje.Text = string.Empty;
            
            var numPoliza = txtNumPolizaMemo.Text.ToUpper();
            var numLiquidacion = txtNumLiquidacionMemo.Text.ToUpper();
            var cartera = Convert.ToString(cmbCarteraMemo.SelectedItem.Value);
            var fechaMemo = Convert.ToString(cmbFechasMemo.SelectedItem.Value);
            var fechaDe = fechaDel.Date.ToShortDateString();
            var fechaA = fechaAl.Date.ToShortDateString();

            if ((!(numPoliza != "") || !(numLiquidacion != "")) && (!(fechaDe != "") || !(fechaA != "")))
            {
                divMensajeError.Visible = true;
                lblMensaje.Text = "<span>Los siguientes valores deben ser verificados antes de proseguir<br /></span><p style='color:#990000; font-weight:bold'> Debe Registrar Número de Póliza y Liquidación O una fecha de registro para generar los memos</p>";
                
                return;
            }

            string str = "";
            str = (this.cmbCopiasMemo.SelectedItem.Value.ToString() != "1" ? "10" : "9");

            reportTabClientes.Visible = true;
            reportTabClientes.Attributes.Add("src", "../Reportes/re_viewer.aspx?r=" + str + "&np=" + numPoliza + 
                "&nl=" + numLiquidacion +
                "&fc=" + fechaDe +
                "&fc2=" + fechaA +
                "&fb=" + fechaMemo +
                "&ca=" + cartera
                );

            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModal();", true);
        }

        
    }
}