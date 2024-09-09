using DevExpress.Web;
using DevExpress.Web.Bootstrap;
using EntidadesClases.ModelSicPro;
using Logica.Consumo;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data.Entity.Core.Common.CommandTrees.ExpressionBuilder;
using System.Linq;
using System.Reflection.Emit;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PresentacionWeb.Sitio.Vista.RegistroProduccion
{
    public partial class wpr_poliza : System.Web.UI.Page
    {
        ConsumoRegistroProd _objConsumoRegistroProd = new ConsumoRegistroProd();
        ConsumoValidarProd _objConsumoValidarProd = new ConsumoValidarProd();
        protected void Page_Load(object sender, EventArgs e)
        {
            //GridViewFeaturesHelper.SetupGlobalGridViewBehavior(Grid);
            //DemoHelper.Instance.PrepareControlOptions(OptionsFormLayout, new ControlOptionsSettings
            //{
            //    ColumnMinWidth = 380,
            //    RightBlockWidth = 410,
            //    ColumnCountMode = RecalculateColumnCountMode.RootGroup
            //});

            //Grid.SettingsPager.Mode = (GridViewPagerMode)Enum.Parse(typeof(GridViewPagerMode), PagerModeCombo.Text, true);
            //grdCuotas.SettingsEditing.BatchEditSettings.EditMode = (GridViewBatchEditMode)Enum.Parse(typeof(GridViewBatchEditMode), "Row", true);
            //grdCuotas.SettingsEditing.BatchEditSettings.StartEditAction = (GridViewBatchStartEditAction)Enum.Parse(typeof(GridViewBatchStartEditAction), "Click", true);
            //grdCuotas.SettingsEditing.BatchEditSettings.HighlightDeletedRows = true;
            //grdCuotas.SettingsEditing.BatchEditSettings.KeepChangesOnCallbacks = false;

            if (IsPostBack)
            {
                return;
            }
            CargaInicial();
        }

        #region Metodos

        private void CargaInicial()
        {
            var lstGrupo = _objConsumoRegistroProd.ObtenerGrupo();
            cmbGrupo.DataSource = lstGrupo;
            cmbGrupo.TextField = "desc_grupo";
            cmbGrupo.ValueField = "id_gru";
            cmbGrupo.DataBind();

            var itemLstGrupo = new BootstrapListEditItem { Text = "Seleccione...", Value = "", Selected = true, Index = 0 };
            cmbGrupo.Items.Add(itemLstGrupo);

            var lstTipoCartera = _objConsumoRegistroProd.listas1();
            cmbTipoCartera.DataSource = lstTipoCartera;
            cmbTipoCartera.TextField = "desc_param";
            cmbTipoCartera.ValueField = "id_par";
            cmbTipoCartera.DataBind();

            var itemTipoCartera = new BootstrapListEditItem { Text = "Seleccione...", Value = "", Selected = true, Index = 0 };
            cmbTipoCartera.Items.Add(itemTipoCartera);

            var lstFuncionarios = _objConsumoRegistroProd.ObtenerEjecutivoClientes();
            cmbEjecutivo.DataSource = lstFuncionarios;
            cmbEjecutivo.TextField = "nomraz";
            cmbEjecutivo.ValueField = "id_per";
            cmbEjecutivo.DataBind();

            var itemLstFuncionarios = new BootstrapListEditItem { Text = "Seleccione...", Value = "", Selected = true, Index = 0 };
            cmbEjecutivo.Items.Add(itemLstFuncionarios);

            var lstCiaAseguradora = _objConsumoRegistroProd.ObtenerListaCompania();
            cmbCiaAseg.DataSource = lstCiaAseguradora;
            cmbCiaAseg.TextField = "nomraz";
            cmbCiaAseg.ValueField = "id_spvs";
            cmbCiaAseg.DataBind();

            var itemLstCiaAseguradora = new BootstrapListEditItem { Text = "Seleccione...", Value = "", Selected = true, Index = 0 };
            cmbCiaAseg.Items.Add(itemLstCiaAseguradora);


            var lstAgenteCartera = _objConsumoRegistroProd.Persona(60);
            cmbAgente.DataSource = lstAgenteCartera;
            cmbAgente.TextField = "nomraz";
            cmbAgente.ValueField = "id_per";
            cmbAgente.DataBind();

            var itemLstAgenteCartera = new BootstrapListEditItem { Text = "Seleccione...", Value = "", Selected = true, Index = 0 };
            cmbAgente.Items.Add(itemLstAgenteCartera);

            var lstDivisa = _objConsumoRegistroProd.ParametroA("id_div");
            cmbDivisa.DataSource = lstDivisa;
            cmbDivisa.TextField = "abrev_param";
            cmbDivisa.ValueField = "id_par";
            cmbDivisa.DataBind();

            var itemLstDivisa = new BootstrapListEditItem { Text = "Seleccione...", Value = "", Selected = true, Index = 0 };
            cmbDivisa.Items.Add(itemLstDivisa);


            //var lstPersonas = _objConsumoRegistroProd.ObtenerListaPersona();
            //cmbAsegurado.DataSource = lstPersonas;
            //cmbAsegurado.TextField = "nomraz";
            //cmbAsegurado.ValueField = "id_per";
            //cmbAsegurado.DataBind();

            //var itemLstPersonas = new ListEditItem { Text = "Seleccione...", Value = "", Selected = true, Index = 0 };
            //cmbAsegurado.Items.Add(itemLstPersonas);

            pnlCuotas.Visible = false;
            btnCuotas.Visible = true;
            btnCuotasPoliza.Visible = false;
        }

        private List<pr_cuotapoliza> GetDataCuotas(double numeroCuotas)
        {
            var lstCuotas = new List<pr_cuotapoliza>();
            for (int i = 0; i < numeroCuotas; i++)
            {
                var objCuotasPoliza = new pr_cuotapoliza();
                objCuotasPoliza.cuota = i;
                objCuotasPoliza.fecha_pago = DateTime.Now;
                objCuotasPoliza.cuota_total = 0;

                lstCuotas.Add(objCuotasPoliza);
            }
            return lstCuotas;


            //var lstActual = (List<pr_cuotapoliza>)Session["LST_CUOTAS"];
            //if (lstActual == null)
            //{
            //    var lstCuotas = new List<pr_cuotapoliza>();
            //    for (int i = 0; i < numeroCuotas; i++)
            //    {
            //        var objCuotasPoliza = new pr_cuotapoliza();
            //        objCuotasPoliza.cuota = i;
            //        objCuotasPoliza.fecha_pago = DateTime.Now;
            //        objCuotasPoliza.cuota_total = 0;

            //        lstCuotas.Add(objCuotasPoliza);
            //    }
            //    return lstCuotas;
            //}
            //else
            //{
            //    ActualizaSessionCuotas();
            //    if (lstActual.Count == numeroCuotas)
            //    {
            //        return lstActual;
            //    }
            //    if (lstActual.Count < numeroCuotas)
            //    {
            //        var diferencia = numeroCuotas - lstActual.Count;

            //        for (int i = 1;i < diferencia; i++)
            //        {
            //            var objCuotasPoliza = new pr_cuotapoliza();
            //            objCuotasPoliza.cuota = i + lstActual.Count;
            //            objCuotasPoliza.fecha_pago = DateTime.Now;
            //            objCuotasPoliza.cuota_total = 0;

            //            lstActual.Add(objCuotasPoliza);
            //        }
            //    }
            //    if (lstActual.Count > numeroCuotas)
            //    {
            //        var diferencia = lstActual.Count - numeroCuotas;
            //        for (int i = 0; i < diferencia; i++)
            //        {
            //            lstActual.RemoveAt(lstActual.Count - 1);
            //        }
            //        return lstActual;
            //    }
            //}
            ////Session["LST_CUOTAS"] = lstCuotas;

            ////grdCuotas.DataBind();

            //return null;
        }

        private void LimpiarFormulario()
        {
            fc_emision.Text = string.Empty;
            fc_recepcion.Text = string.Empty;
            fc_inivig.Text = string.Empty;
            fc_finvig.Text = string.Empty;
            txtNroPoliza.Text = string.Empty;
            txtNroLiquidacion.Text = string.Empty;

            //cmbAsegurado.Text = string.Empty;
            //cmbDireccion.Text = string.Empty;
            cmbGrupo.SelectedItem = cmbGrupo.Items.FindByValue("");

            //this.id_per.Text = string.Empty;
            //this.nomraz.Text = string.Empty;
            //this.fechaNacimiento.Text = string.Empty;
            //this.nit_fac.Text = string.Empty;

            //cmb_id_suc.SelectedItem = cmb_id_suc.Items.FindByValue(0);
            //cmb_id_sal.SelectedItem = cmb_id_sal.Items.FindByValue(Convert.ToInt64(0));
            //cmb_tipodoc.SelectedItem = cmb_tipodoc.Items.FindByValue(Convert.ToInt64(0));
            //cmb_tper.SelectedItem = cmb_tper.Items.FindByValue(Convert.ToInt64(0));
            //cmb_id_rol.SelectedItem = cmb_id_rol.Items.FindByValue(Convert.ToInt64(0));
            //cmb_id_emis.SelectedItem = cmb_id_emis.Items.FindByValue(Convert.ToInt64(0));

            //btnDirecciones.Visible = false;
            //btnNuevo.Visible = false;
        }

        //private bool ActualizarCuota(long poliza, long movimiento, int cuota)
        //{
        //    var objActualizaCuota = new pr_cuotapoliza();
        //    objActualizaCuota.id_poliza = poliza;
        //    objActualizaCuota.id_movimiento = movimiento;
        //    objActualizaCuota.cuota = cuota;
        //    return _objConsumoRegistroProd.ActualizarCuotaPoliza(objActualizaCuota);
        //}

        private decimal ActualizaSessionCuotas()
        {
            var lstCuotasSession = (List<pr_cuotapoliza>)Session["LST_CUOTAS"];
            decimal montoTotalSuma = 0;
            foreach (GridViewRow item in grdCuotasPoliza.Rows)
            {
                var cuota = Convert.ToDecimal(item.Cells[0].Text);
                var fechaPago = item.Cells[1].FindControl("dtFechaPago") as ASPxDateEdit;
                var cuotaTotal = item.Cells[2].FindControl("txtCuotaTotal") as ASPxSpinEdit;
                var itemSession = lstCuotasSession.Where(w => w.cuota == cuota).FirstOrDefault();

                itemSession.fecha_pago = fechaPago.Date;
                itemSession.cuota_total = Convert.ToDecimal(cuotaTotal.Text);

                montoTotalSuma += Convert.ToDecimal(cuotaTotal.Text);
            }
            Session["LST_CUOTAS"] = lstCuotasSession;
            return montoTotalSuma;
        }
        #endregion

        protected void btnNuevo_Click(object sender, EventArgs e)
        {
            LimpiarFormulario();
        }

        protected void btnCuotas_Click(object sender, EventArgs e)
        {
            lblmensaje.Text = string.Empty;
            var numeroCuotas = Convert.ToDouble(txtNumCuotas.Text);

            if (numeroCuotas == 0)
            {
                lblmensaje.Text = "El numero de Cuotas no puede ser 0";
                return;
            }

            var lstCuotas = GetDataCuotas(numeroCuotas);
            Session["LST_CUOTAS"] = lstCuotas;

            grdCuotasPoliza.DataSource = lstCuotas;
            grdCuotasPoliza.DataBind();

            pnlCuotas.Visible = true;
            btnCuotas.Visible = false;
            btnCuotasPoliza.Visible = true;
            //int id = 0;
            //lstCoutasTest.ForEach(s =>
            //{
            //    s.id_movimiento = 3;                
            //    s.cuota = id++;
            //});           
        }

        protected void btnSalir_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Sitio/Vista/Default.aspx");
        }

        
        //protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        //{
        //    //if there is an error
        //    if (errorFound == true)
        //    {
        //        //cancel the edit by setting editindex to -1 and rebind the grid
        //        GridView1.EditIndex = -1;
        //        BindData();

        //        //display the error in a label placed outside the grid
        //        Label1.Text = "There was an error";
        //        Label1.Visible = true;

        //        //or display javascript error message
        //        ScriptManager.RegisterStartupScript(Page, Page.GetType(), "showError", "alert('There was an error');", true);

        //        //or do not set the editindex back to -1, but show an error in the edititem template itself
        //        GridViewRow row = GridView1.Rows[e.RowIndex];
        //        Label label = row.FindControl("Label2") as Label;
        //        label.Text = "There was an error in the textbox";
        //        label.Visible = true;
        //    }
        //}
        //protected pr_cuotapoliza UpdateItem(OrderedDictionary keys, OrderedDictionary newValues)
        //{
        //    var id = Convert.ToInt32(keys["cuota"]);
        //    var lstCuotas = (List<pr_cuotapoliza>)Session["LST_CUOTAS"];
        //    var item = lstCuotas.First(i => i.cuota == id);
        //    LoadNewValues(item, newValues);
        //    return item;
        //}
        
        //protected void LoadNewValues(pr_cuotapoliza item, OrderedDictionary values)
        //{
        //    item.id_poliza = Convert.ToInt64(values["id_poliza"]);
        //    item.id_movimiento = Convert.ToInt64(values["id_movimiento"]);
        //    item.cuota = Convert.ToDecimal(values["cuota"]);
        //    item.fecha_pago = Convert.ToDateTime(values["fecha_pago"]);
        //    item.cuota_total = Convert.ToDecimal(values["cuota_total"]);

        //    item.cuota_neta = Convert.ToDecimal(values["cuota_neta"]);
        //    item.cuota_comis = Convert.ToDecimal(values["cuota_comis"]);
        //    item.cuota_pago = Convert.ToDecimal(values["cuota_pago"]);
        //    item.cuota_comicob = Convert.ToDecimal(values["cuota_comicob"]);
        //}


        protected void id_spvs_SelectedIndexChanged(object sender, EventArgs e)
        {
            var strIdSpvs = Convert.ToString(cmbCiaAseg.SelectedItem.Value);

            var lstCiaAseguradora = _objConsumoRegistroProd.ObtenerTablaProducto(strIdSpvs);
            cmbProducto.DataSource = lstCiaAseguradora;
            cmbProducto.TextField = "desc_prod";
            cmbProducto.ValueField = "id_producto";
            cmbProducto.DataBind();

            var itemLstCiaAseguradora = new BootstrapListEditItem { Text = "Seleccione...", Value = "", Selected = true, Index = 0 };
            cmbProducto.Items.Add(itemLstCiaAseguradora);
        }

        //protected void cmb_nomraz_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    var strIdPer = Convert.ToString(cmbAsegurado.SelectedItem.Value);

        //    var lstDirecciones = _objConsumoRegistroProd.ObtenerDireccionesPersona(strIdPer.TrimStart().TrimEnd());
        //    cmbDireccion.DataSource = lstDirecciones;
        //    cmbDireccion.TextField = "direccion";
        //    cmbDireccion.ValueField = "id_dir";
        //    cmbDireccion.DataBind();

        //    var itemLstDirecciones = new ListEditItem { Text = "Seleccione...", Value = "", Selected = true, Index = 0 };
        //    cmbDireccion.Items.Add(itemLstDirecciones);
        //}

        protected void btnCuotasPoliza_Click(object sender, EventArgs e)
        {
            if (DateTime.Parse(this.fc_finvig.Text) < DateTime.Parse(this.fc_inivig.Text))
            {
                lblmensaje.Text = "La fecha de Fin de Vigencia no puede ser menor a la fecha de Incio de vigencia";
                return;
            }
            if (string.IsNullOrEmpty(txtNumCuotas.Text) || Convert.ToDecimal(txtNumCuotas.Text) == 0)
            {
                lblmensaje.Text = "El Numero de Cuotas no es valido";
                return;
            }
            if ( string.IsNullOrEmpty(Convert.ToString(cmbDivisa.SelectedItem.Value)))
            {
                lblmensaje.Text = "Seleccione una divisa valida";
                return;
            }
            if (string.IsNullOrEmpty(Convert.ToString(id_direccion.Value)))
            {
                lblmensaje.Text = "Seleccione una direccion valida";
                return;
            }

            var montoTotalSuma = ActualizaSessionCuotas();
            var lstCuotasSession = (List<pr_cuotapoliza>)Session["LST_CUOTAS"];
            if (montoTotalSuma != Convert.ToDecimal(txtPrimaBruta.Text))
            {
                grdCuotasPoliza.DataSource = lstCuotasSession;
                grdCuotasPoliza.DataBind();
                lblmensaje.Text = "La Prima total es diferente de la suma de las cuotas por favor verifique este dato";
                return;
            }
            else
            {
                //ActualizaSessionCuotas();
                if (_objConsumoRegistroProd.ExistePol(txtNroPoliza.Text, txtNroLiquidacion.Text))
                {
                    lblmensaje.Text = "Datos existentes, Debe Verificar el Número de Póliza y Liquidación";
                    return;
                }
                //else
                //{
                //    var numeroCuotas = Convert.ToDouble(txtNumCuotas.Text);

                var objPoliza = new pr_poliza();
                objPoliza.num_poliza = txtNroPoliza.Text.ToUpper();
                objPoliza.id_producto = Convert.ToInt64(cmbProducto.SelectedItem.Value);
                objPoliza.id_perclie = id_per.Value;//Convert.ToString(cmbAsegurado.SelectedItem.Value);
                
                objPoliza.id_spvs = Convert.ToString(cmbCiaAseg.SelectedItem.Value);
                objPoliza.id_gru = Convert.ToInt64(cmbGrupo.SelectedItem.Value);
                objPoliza.clase_poliza = Convert.ToBoolean(rbTipoPoliza.SelectedItem.Value);
                objPoliza.estado = true;
                objPoliza.fc_reg = DateTime.Now;
                objPoliza.id_percart = Convert.ToString(cmbAgente.SelectedItem.Value);// Convert.ToString(cmbTipoCartera.SelectedItem.Value);

                objPoliza.id_suc = Convert.ToInt64(Session["suc"]);

                    var objResponse = _objConsumoRegistroProd.InsertarPoliza(objPoliza);

                pr_polmov prPolmov = new pr_polmov();

                prPolmov.id_poliza = objResponse.id_poliza;
                prPolmov.id_perejec = Convert.ToString(cmbEjecutivo.SelectedItem.Value);
                prPolmov.fc_emision = fc_emision.Date;
                prPolmov.fc_inivig = fc_inivig.Date;
                prPolmov.fc_finvig = fc_finvig.Date;
                prPolmov.prima_bruta = Convert.ToDecimal(txtPrimaBruta.Text);
                //prima_neta =  this.prima_neta,
                //por_comision = this.por_comision,
                //comision = this.comision,
                prPolmov.id_div = Convert.ToInt64(cmbDivisa.SelectedItem.Value);
                //num_cuota = intNumeroCuotas,
                prPolmov.id_clamov = Convert.ToInt64(cmbTipoCartera.SelectedItem.Value);
                prPolmov.estado = "PRODUCCION"; //this.estado,
                prPolmov.id_dir =string.IsNullOrEmpty(id_direccion.Value)? 0 : Convert.ToInt64(id_direccion.Value);// Convert.ToInt64(cmbDireccion.SelectedItem.Value);
                prPolmov.fc_recepcion = fc_recepcion.Date;
                prPolmov.mat_aseg = txtMatAseg.Text.ToUpper();
                prPolmov.fc_reg = DateTime.Now;
                prPolmov.no_liquida = txtNroLiquidacion.Text.ToUpper();
                prPolmov.num_cuota = Convert.ToDouble(txtNumCuotas.Text);
                prPolmov.tipo_cuota = Convert.ToBoolean(tipo_cuota.SelectedItem.Value);
                //id_mom = this.id_mom


                 var responsePolMov = _objConsumoRegistroProd.InsertarPolizaMovimiento(prPolmov);

                //    int idx = 0;
                //    var lstCoutas = GetDataCuotas(numeroCuotas);
                lstCuotasSession.ForEach(s =>
                {
                    s.id_movimiento = responsePolMov.id_movimiento;
                    s.id_poliza = objPoliza.id_poliza;
                });

                var responseSaveCuotas = _objConsumoRegistroProd.InsertarLstCuotasPoliza(lstCuotasSession);
                //}
                Session["POLIZA"] = objPoliza;
                Session["POLIZA_MOVIMIENTO"] = prPolmov;
                Response.Redirect("~/Sitio/Vista/ValidacionProduccion/wpr_polizacobranza.aspx?var=" + objPoliza.id_poliza + "&val=" + responsePolMov.id_movimiento + "&ver=42");
                //Response.Redirect("~/Sitio/Vista/RegistroProduccion/wpr_polizacobranzain.aspx?var=" + objPoliza.id_poliza + "&val=" + responsePolMov.id_movimiento + "&ver=0");
            }
        }

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

        //protected void btnGuardar_Click(object sender, EventArgs e)
        //{

        //    var objPoliza = new pr_poliza();
        //    objPoliza.num_poliza = txtNroPoliza.Text;
        //    objPoliza.id_perclie = Convert.ToString(cmbAsegurado.SelectedItem.Value);
        //    objPoliza.id_gru = Convert.ToInt64(cmbGrupo.SelectedItem.Value);
        //    objPoliza.id_spvs = Convert.ToString(cmbCiaAseg.SelectedItem.Value);
        //    objPoliza.id_producto = Convert.ToInt64(cmbProducto.SelectedItem.Value);
        //    objPoliza.id_percart = Convert.ToString(cmbTipoCartera.SelectedItem.Value);
        //    //objPoliza.clase_poliza = rbTipoPoliza.SelectedItem.Value;
        //    //objPoliza.fc_reg = DateTime.Now;
        //    //objPoliza.id_suc = "";

        //}

        #region direccion

        protected void btnserdireccion_Click(object sender, EventArgs e)
        {
            if (nomraz.Text.Trim() == "")
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
            var lstDirecciones = _objConsumoRegistroProd.ObtenerDireccionesPersona(id_per.Value.ToUpper().TrimStart().TrimEnd())
                .Where(w => w.direccion.Contains(desc_direccion.Text.ToUpper()))
                .ToList();
            //var dt = _objConsumoValidarProd.ObtenerTablaProductoL(id_per.Value, desc_direccion.Text.ToUpper());
            Session["lstDireccion"] = lstDirecciones;
            grdDireccion.DataSource = lstDirecciones;
            grdDireccion.DataBind();

            pCDireccion.ShowOnPageLoad = true;
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
        protected void CallBDireccion_Callback(object sender, DevExpress.Web.CallbackEventArgsBase e)
        {
            var index = e.Parameter;
            var idProducto = grdDireccion.GetRowValues(Convert.ToInt32(index), "id_dir").ToString();
            var nombreProducto = grdDireccion.GetRowValues(Convert.ToInt32(index), "direccion").ToString();
            desc_direccion.Value = nombreProducto;
            id_direccion.Value = idProducto;

        }

        protected void btnDireccion_Click(object sender, EventArgs e)
        {
            var lstDirecciones = _objConsumoRegistroProd.ObtenerDireccionesPersona(id_per.Value.ToUpper().TrimStart().TrimEnd())
                .Where(w=>w.direccion.Contains(desc_direccion.Text.ToUpper()))
                .ToList() ;
            //var dt = _objConsumoValidarProd.ObtenerTablaProductoL(id_per.Value.ToUpper(), desc_direccion1.Text.ToUpper());
            Session["lstDireccion"] = lstDirecciones;
            grdDireccion.DataSource = lstDirecciones;
            grdDireccion.DataBind();
        }

        protected void btnAceptarDireccion_Click(object sender, EventArgs e)
        {
            pCDireccion.ShowOnPageLoad = false;
        }

        protected void grdDireccion_DataBinding(object sender, EventArgs e)
        {
            grdDireccion.DataSource = Session["lstDireccion"];
        }
        #endregion

    }
}