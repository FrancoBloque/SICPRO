using DevExpress.Web;
using DevExpress.Web.Bootstrap;
using EntidadesClases.ModelSicPro;
using Logica.Consumo;
using PresentacionWeb.Parametros;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PresentacionWeb.Sitio.Vista.ReportesSistema
{
    public partial class wco_reportes : System.Web.UI.Page
    {
        ConsumoRegistroProd _objConsumoRegistroProd = new ConsumoRegistroProd();
        ConsumoValidarProd _objConsumoValidarProd = new ConsumoValidarProd();
        ConsumoReportes _objConsumoReportes = new ConsumoReportes();

        CParametros _cParametros = new CParametros();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                Combos();
                divMensajeError.Visible = false;
                lblMensaje.Text = string.Empty;
            }
        }

        #region 

        private void Combos()
        {
            try
            {
                var lstCompanias = _objConsumoRegistroProd.ObtenerListaCompania();
                var lstPersona60 = _objConsumoRegistroProd.Persona(60);
                var lstGrupo = _objConsumoRegistroProd.ObtenerGrupo();
                var sucursal = _objConsumoRegistroProd.ObtenerLista("id_suc");
               
                #region clientes

                cmbCompaniaClientes.DataSource = lstCompanias;
                cmbCompaniaClientes.ValueField = "id_spvs";
                cmbCompaniaClientes.TextField = "nomraz";
                cmbCompaniaClientes.DataBind();
                var itemSelecCompaniaCli = new BootstrapListEditItem { Text = "SELECCIONE...", Value = "", Selected = true, Index = 0 };
                cmbCompaniaClientes.Items.Add(itemSelecCompaniaCli);
                //cmbCompaniaClientes.SelectedIndex = 0;

                cmbCarteraClientes.DataSource = lstPersona60;
                cmbCarteraClientes.ValueField = "id_per";
                cmbCarteraClientes.TextField = "nomraz";
                cmbCarteraClientes.DataBind();
                var itemSelecCarteraCli = new BootstrapListEditItem { Text = "SELECCIONE...", Value = "", Selected = true, Index = 0 };
                cmbCarteraClientes.Items.Add(itemSelecCarteraCli);
                //cmbCarteraClientes.SelectedIndex = 0;


                #endregion

                #region vencimiento

                cmbCompaniaVcmto.DataSource = lstCompanias;
                cmbCompaniaVcmto.ValueField = "id_spvs";
                cmbCompaniaVcmto.TextField = "nomraz";
                cmbCompaniaVcmto.DataBind();
                var itemSelecCompaniaVcm = new BootstrapListEditItem { Text = "SELECCIONE...", Value = "", Selected = true, Index = 0 };
                cmbCompaniaVcmto.Items.Add(itemSelecCompaniaVcm);

                //cmbCompaniaVcmto.SelectedIndex = 0;

                cmbCarteraVcmto.DataSource = lstPersona60;
                cmbCarteraVcmto.ValueField = "id_per";
                cmbCarteraVcmto.TextField = "nomraz";
                cmbCarteraVcmto.DataBind();
                var itemSelecCarteraVcm = new BootstrapListEditItem { Text = "SELECCIONE...", Value = "", Selected = true, Index = 0 };
                cmbCarteraVcmto.Items.Add(itemSelecCarteraVcm);
                //cmbCarteraVcmto.SelectedIndex = 0;

                cmbSucursalVcmto.DataSource = sucursal;
                cmbSucursalVcmto.TextField = "desc_param";
                cmbSucursalVcmto.ValueField = "id_par";
                cmbSucursalVcmto.DataBind();
                var itemSelecSucursalVcm = new BootstrapListEditItem { Text = "SELECCIONE...", Value = "", Selected = true, Index = 0 };
                cmbSucursalVcmto.Items.Add(itemSelecSucursalVcm);
                //cmbSucursalVcmto.SelectedIndex = 0;

                cmbGrupoVcmto.DataSource = lstGrupo;
                cmbGrupoVcmto.ValueField = "id_gru";
                cmbGrupoVcmto.TextField = "desc_grupo";
                cmbGrupoVcmto.DataBind();
                var itemSelecGrupoVcm = new BootstrapListEditItem { Text = "SELECCIONE...", Value = "", Selected = true, Index = 0 };
                cmbGrupoVcmto.Items.Add(itemSelecGrupoVcm);
                //cmbGrupoVcmto.SelectedIndex = 0;
                #endregion

                #region pagos

                cmbSucursalPagos.DataSource = sucursal;
                cmbSucursalPagos.TextField = "desc_param";
                cmbSucursalPagos.ValueField = "id_par";
                cmbSucursalPagos.DataBind();
                var itemSelecSucursalPagos = new BootstrapListEditItem { Text = "SELECCIONE...", Value = "", Selected = true, Index = 0 };
                cmbSucursalPagos.Items.Add(itemSelecSucursalPagos);
                //cmbSucursalPagos.SelectedIndex = 0;


                #endregion

                #region estado

                cmbCompaniaEstado.DataSource = lstCompanias;
                cmbCompaniaEstado.ValueField = "id_spvs";
                cmbCompaniaEstado.TextField = "nomraz";
                cmbCompaniaEstado.DataBind();
                var itemSelecCompaniaEst = new BootstrapListEditItem { Text = "SELECCIONE...", Value = "", Selected = true, Index = 0 };
                cmbCompaniaEstado.Items.Add(itemSelecCompaniaEst);
                //cmbCompaniaEstado.SelectedIndex = 0;

                cmbSucursalEstado.DataSource = sucursal;
                cmbSucursalEstado.TextField = "desc_param";
                cmbSucursalEstado.ValueField = "id_par";
                cmbSucursalEstado.DataBind();
                var itemSelecSucursalEst = new BootstrapListEditItem { Text = "SELECCIONE...", Value = "", Selected = true, Index = 0 };
                cmbSucursalEstado.Items.Add(itemSelecSucursalEst);
                //cmbSucursalEstado.SelectedIndex = 0;

                #endregion

                #region reimpresion

                cmbSucursalReimp.DataSource = sucursal;
                cmbSucursalReimp.TextField = "desc_param";
                cmbSucursalReimp.ValueField = "id_par";
                cmbSucursalReimp.DataBind();
                var itemSelecSucursalReimp = new BootstrapListEditItem { Text = "SELECCIONE...", Value = "", Selected = true, Index = 0 };
                cmbSucursalReimp.Items.Add(itemSelecSucursalReimp);
                //cmbSucursalReimp.SelectedIndex = 0;

                #endregion

                #region cobranza

                cmbSucursalCobranza.DataSource = sucursal;
                cmbSucursalCobranza.TextField = "desc_param";
                cmbSucursalCobranza.ValueField = "id_par";
                cmbSucursalCobranza.DataBind();
                var itemSelecSucursalCob = new BootstrapListEditItem { Text = "SELECCIONE...", Value = "", Selected = true, Index = 0 };
                cmbSucursalCobranza.Items.Add(itemSelecSucursalCob);
                //cmbSucursalCobranza.SelectedIndex = 0;

                #endregion

                #region recibos

                cmbSucursalRecibos.DataSource = sucursal;
                cmbSucursalRecibos.TextField = "desc_param";
                cmbSucursalRecibos.ValueField = "id_par";
                cmbSucursalRecibos.DataBind();
                var itemSelecSucursalRec = new BootstrapListEditItem { Text = "SELECCIONE...", Value = "", Selected = true, Index = 0 };
                cmbSucursalRecibos.Items.Add(itemSelecSucursalRec);
                //cmbSucursalRecibos.SelectedIndex = 0;

                #endregion
            }
            catch
            {
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



        protected void cmbSucursalReimp_SelectedIndexChanged(object sender, EventArgs e)
        {
            var longIdSuc = Convert.ToInt64(cmbSucursalReimp.SelectedItem.Value);

            var lstCobrador = _objConsumoReportes.ObtenerCobrador(longIdSuc);
            cmbCobradorReimp.DataSource = lstCobrador;
            cmbCobradorReimp.TextField = "nomraz";
            cmbCobradorReimp.ValueField = "id_per";
            cmbCobradorReimp.DataBind();

            var itemSelec = new BootstrapListEditItem { Text = "Seleccione...", Value = "", Selected = true, Index = 0 };
            cmbCobradorReimp.Items.Add(itemSelec);
        }

        protected void cmbCobradorReimp_SelectedIndexChanged(object sender, EventArgs e)
        {
            var strIdCobrador = Convert.ToString(cmbCobradorReimp.SelectedItem.Value);

            var lstCiaAseguradora = _objConsumoReportes.ListTop(strIdCobrador);
            cmbLiquidacionReimp.DataSource = lstCiaAseguradora;
            cmbLiquidacionReimp.TextField = "id_liq";
            cmbLiquidacionReimp.ValueField = "id_liq";
            cmbLiquidacionReimp.DataBind();

            var itemSelec = new BootstrapListEditItem { Text = "Seleccione...", Value = "", Selected = true, Index = 0 };
            cmbLiquidacionReimp.Items.Add(itemSelec);
        }
        
        
        #region botones tab

        protected void clientes_tab_Click(object sender, EventArgs e)
        {
            divMensajeError.Visible = false;
            lblMensaje.Text = string.Empty;
            hidtab.Value = "v-pills-clientes-tab";
        }
        protected void vcmto_tab_Click(object sender, EventArgs e)
        {
            divMensajeError.Visible = false;
            lblMensaje.Text = string.Empty;
            hidtab.Value = "v-pills-vcmto-tab";            
        }
        protected void pagos_tab_Click(object sender, EventArgs e)
        {
            divMensajeError.Visible = false;
            lblMensaje.Text = string.Empty;
            hidtab.Value = "v-pills-pagos-tab";
        }
        protected void estado_tab_Click(object sender, EventArgs e)
        {
            divMensajeError.Visible = false;
            lblMensaje.Text = string.Empty;
            hidtab.Value = "v-pills-estado-tab";
        }
        protected void reimp_tab_Click(object sender, EventArgs e)
        {
            divMensajeError.Visible = false;
            lblMensaje.Text = string.Empty;
            hidtab.Value = "v-pills-reimp-tab";
        }
        protected void cobranzas_tab_Click(object sender, EventArgs e)
        {
            divMensajeError.Visible = false;
            lblMensaje.Text = string.Empty;
            hidtab.Value = "v-pills-cobranzas-tab";
        }
        protected void recibos_tab_Click(object sender, EventArgs e)
        {
            divMensajeError.Visible = false;
            lblMensaje.Text = string.Empty;
            hidtab.Value = "v-pills-recibos-tab";
        }

        #endregion

        protected void btnGenerarReporteClientes_Click(object sender, EventArgs e)
        {
            divMensajeError.Visible = false;
            lblMensaje.Text = string.Empty;

            var ic = id_per.Value;

            if (string.IsNullOrEmpty(ic) || ic == "0")
            {
                divMensajeError.Visible = true;
                lblMensaje.Text = "Seleccione una persona";
                return;
            }
                       
            var ci = Convert.ToString(cmbCompaniaClientes.SelectedItem.Value);

            var ca = Convert.ToString(cmbCarteraClientes.SelectedItem.Value);
            var np = txtNumPolizaClientes.Text.ToUpper();
            var nl = txtNumLiquidacionClientes.Text.ToUpper();
            var h = historicoCliente.SelectedItem == null? true : historicoCliente.SelectedItem.Value;

            ifrReport.Visible = true;
            ifrReport.Attributes.Add("src", "../Reportes/re_viewer.aspx?r=11" +
                "&ic=" +  ic + 
                "&ci=" +  ci + 
                "&ca=" +  ca + 
                "&np=" +  np + 
                "&nl=" +  nl + 
                "&h=" +  h
                );

            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModal();", true);
        }

        protected void btnGenerarReporteVcmto_Click(object sender, EventArgs e)
        {
            divMensajeError.Visible = false;
            lblMensaje.Text = string.Empty;
            var ci = Convert.ToString(cmbCompaniaVcmto.SelectedItem.Value);
            var ca = Convert.ToString(cmbCarteraVcmto.SelectedItem.Value);
            var isuc = Convert.ToString(cmbSucursalVcmto.SelectedItem.Value);
            var gr = Convert.ToString(cmbGrupoVcmto.SelectedItem.Value);

            var e1 = txtVenc1Vcmto.Text.ToUpper();
            var e2 = txtVenc2Vcmto.Text.ToUpper();
            var vv = Convert.ToString(cmbDiasVcmto.SelectedItem.Value);
            var fc = listadoVcmto.Date.ToShortDateString();

            ifrReport.Visible = true;
            ifrReport.Attributes.Add("src", "../Reportes/re_viewer.aspx?r=12" +                
                "&ci=" + ci +
                "&ca=" + ca +
                "&is=" + isuc +
                "&e1=" +  e1 + 
                "&e2=" +  e2 + 
                "&vv=" +  vv + 
                "&gr=" +  gr + 
                "&fc=" +  fc          

                );

            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModal();", true);
        }

        protected void btnGenerarReportePagos_Click(object sender, EventArgs e)
        {
            divMensajeError.Visible = false;
            lblMensaje.Text = string.Empty;
            var isuc = Convert.ToString(cmbSucursalPagos.SelectedItem.Value);            

            ifrReport.Visible = true;
            ifrReport.Attributes.Add("src", "../Reportes/re_viewer.aspx?r=6" +                
                "&is=" + isuc                 
                );

            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModal();", true);
        }

        protected void btnGenerarReporteEstado_Click(object sender, EventArgs e)
        {
            divMensajeError.Visible = false;
            lblMensaje.Text = string.Empty;
            var isuc = Convert.ToString(cmbSucursalEstado.SelectedItem.Value);
            var sp = Convert.ToString(cmbCompaniaEstado.SelectedItem.Value);
            ifrReport.Visible = true;
            ifrReport.Attributes.Add("src", "../Reportes/re_viewer.aspx?r=7" +
                "&is=" + isuc +
                "&sp=" + sp
                );

            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModal();", true);
        }

        protected void btnGenerarReporteReimp_Click(object sender, EventArgs e)
        {
            divMensajeError.Visible = false;
            lblMensaje.Text = string.Empty;

            var isuc = Convert.ToString(cmbSucursalReimp.SelectedItem.Value);
            if (string.IsNullOrEmpty(isuc) || isuc == "0")
            {
                divMensajeError.Visible = true;
                lblMensaje.Text = "Seleccione una sucursal";
                return;
            }
            var cob = Convert.ToString(cmbCobradorReimp.SelectedItem.Value);

            if (string.IsNullOrEmpty(cob) || cob == "0")
            {
                divMensajeError.Visible = true;
                lblMensaje.Text = "Seleccione un cobrador";
                return;
            }

            var il = Convert.ToString(cmbLiquidacionReimp.SelectedItem.Value);

            if (string.IsNullOrEmpty(il) || il == "0")
            {
                divMensajeError.Visible = true;
                lblMensaje.Text = "Seleccione un numero de liquidacion";
                return;
            }

            ifrReport.Visible = true;
            ifrReport.Attributes.Add("src", "../Reportes/re_viewer.aspx?r=5" +
                "&is=" + isuc + 
                "&il=" + il
                );

            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModal();", true);
        }

        protected void btnGenerarReporteCobranzas_Click(object sender, EventArgs e)
        {
            divMensajeError.Visible = false;
            lblMensaje.Text = string.Empty;
            var isuc = Convert.ToString(cmbSucursalCobranza.SelectedItem.Value);
           if (string.IsNullOrEmpty(isuc) || isuc == "0")
            {
                divMensajeError.Visible = true;
                lblMensaje.Text = "Seleccione una sucursal";
                return;
            }

            var fi = fechaInicioCobranza.Date.ToShortDateString();
            if (string.IsNullOrEmpty(fechaInicioCobranza.Text))
            {
                divMensajeError.Visible = true;
                lblMensaje.Text = "Seleccione una fecha inicial valida";
                return;
            }

            var ff = fechaFinCobranza.Date.ToShortDateString();
            if (string.IsNullOrEmpty(fechaFinCobranza.Text))
            {
                divMensajeError.Visible = true;
                lblMensaje.Text = "Seleccione una fecha final valida";
                return;
            }

            ifrReport.Visible = true;
            ifrReport.Attributes.Add("src", "../Reportes/re_viewer.aspx?r=22" +
                "&is=" + isuc +
                "&fi=" + fi +
                "&ff=" + ff
                );

            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModal();", true);
        }

        protected void btnGenerarReporteRecibos_Click(object sender, EventArgs e)
        {
            divMensajeError.Visible = false;
            lblMensaje.Text = string.Empty;
            var isuc = Convert.ToString(cmbSucursalRecibos.SelectedItem.Value);
            if (string.IsNullOrEmpty(isuc) || isuc == "0")
            {
                divMensajeError.Visible = true;
                lblMensaje.Text = "Seleccione una sucursal";
                return;
            }

            ifrReport.Visible = true;
            ifrReport.Attributes.Add("src", "../Reportes/re_viewer.aspx?r=25" +
                "&is=" + isuc
                );

            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModal();", true);
        }


        //protected void btnCerrarSession_Click(object sender, EventArgs e)
        //{
        //    //if ((bool)Session["clientes_tab"]) return;
        //    //else 
        //        ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "cerrarModal();", true);

        //}
    }
}