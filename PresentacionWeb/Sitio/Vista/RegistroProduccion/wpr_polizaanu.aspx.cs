using DevExpress.Web.Bootstrap;
using DevExpress.XtraPrinting;
using EntidadesClases.CustomModelEntities;
using EntidadesClases.ModelSicPro;
using Logica.Consumo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PresentacionWeb.Sitio.Vista.RegistroProduccion
{
    public partial class wpr_polizaanu : System.Web.UI.Page
    {
        ConsumoRegistroProd _objConsumoRegistroProd = new ConsumoRegistroProd();
        internal void Page_Load(object sender, EventArgs e)
        {
            if (!this.Page.IsPostBack && base.Request.QueryString["var"] != "")
            {
                int idPoliza = int.Parse(base.Request.QueryString["var"]);
                int idMovimiento = int.Parse(base.Request.QueryString["val"]);
                this.Buscar(idPoliza, idMovimiento);
                //this.id_poliza.Value = num.ToString();               
                //this.nomdiv1.Text = this.nomdiv.Text;
                this.SumaCuotas(idPoliza);
                //this.fc_reg.Value = DateTime.Today.Date.ToShortDateString();
            }
        }

        #region Metodos

        private void Buscar(int par1, int par2)
        {
            try
            {
                var lstFuncionarios = _objConsumoRegistroProd.ObtenerEjecutivoClientes();
                cmbEjecutivo.DataSource = lstFuncionarios;
                cmbEjecutivo.TextField = "nomraz";
                cmbEjecutivo.ValueField = "id_per";
                cmbEjecutivo.DataBind();

                var itemLstFuncionarios = new BootstrapListEditItem { Text = "Seleccione...", Value = "", Selected = true, Index = 0 };
                cmbEjecutivo.Items.Add(itemLstFuncionarios);
                var objDataCompletaPoliza = _objConsumoRegistroProd.ObtenerDataCompletaPolAnuvar(par1, par2);
                Session["DATA_POLIZA"] = objDataCompletaPoliza;
                if (objDataCompletaPoliza != null)
                {
                    lblNroPoliza.Text = objDataCompletaPoliza.objPoliza.num_poliza;

                    txtNroLiquidacion.Text = string.Empty;
                    lblAsegurado.Text = objDataCompletaPoliza.objPersona.nomraz;
                    lblDireccion.Text = objDataCompletaPoliza.objDireccion == null ? string.Empty : objDataCompletaPoliza.objDireccion.direccion;
                    lblGrupo.Text = objDataCompletaPoliza.objGrupo == null ? string.Empty : objDataCompletaPoliza.objGrupo.desc_grupo;

                    lblProducto.Text = objDataCompletaPoliza.objProducto.desc_prod;

                    var itemFuncionario = cmbEjecutivo.Items.FindByValue(objDataCompletaPoliza.objPoliza.id_perejec);
                    if (itemFuncionario != null)
                    {
                        cmbEjecutivo.SelectedItem = itemFuncionario;
                    }

                    lblAgente.Text = objDataCompletaPoliza.objPersonaAgente.nomraz;
                    //lblTipoPoliza.Text = objDataCompletaPoliza.objPoliza.clase_poliza == true ? "Normal" : "Flotante";
                    //txtPrimaBruta.Text = string.Empty;
                    //txtNumCuotas.Text = string.Empty;
                    lblDivisa.Text = objDataCompletaPoliza.objParametroDivisa.desc_param;
                    lblDivisaAnulada.Text = objDataCompletaPoliza.objParametroDivisa.desc_param;
                    lblFinVigencia.Text = objDataCompletaPoliza.objPoliza.fc_finvig.ToShortDateString();
                    //txtMatAseg.Text = string.Empty;
                }

            }
            catch
            {
            }
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
        }

        protected void SumaCuotas(int var)
        {
           var response =_objConsumoRegistroProd.ObtenerTotalCuotas(var);
            lblPrimaTotal.Text = string.Format("{0:n}", response);
        }

        #endregion

        protected void btnNuevo_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Sitio/Vista/RegistroProduccion/wpr_listaanu.aspx", false);
        }

        //protected void btnCuotas_Click(object sender, EventArgs e)
        //{
        //    //lblmensaje.Text = string.Empty;
        //    //if (string.IsNullOrEmpty(txtNumCuotas.Text))
        //    //{
        //    //    lblmensaje.Text = "Las cuotas no deben estar vacio";
        //    //    return;
        //    //}
        //    //var numeroCuotas = Convert.ToDouble(txtNumCuotas.Text);
        //    //if (numeroCuotas <= 0)
        //    //{
        //    //    lblmensaje.Text = "Las cuotas no debe ser 0";
        //    //    return;
        //    //}

        //    //var lstCuotas = GetDataCuotas(numeroCuotas);
        //    //Session["LST_CUOTAS"] = lstCuotas;

        //    //grdCuotasPoliza.DataSource = lstCuotas;
        //    //grdCuotasPoliza.DataBind();
        //}

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            var primaTotal = Convert.ToDecimal(lblPrimaTotal.Text);
            var primarTotalAnulada = Convert.ToDecimal(txtPrimaTotalAnulada.Text);
            if (primarTotalAnulada > primaTotal)
            {
                lblmensaje.Text = "La Prima Total no debe ser Mayor a la Suma total de los Movimientos";
                return;
            }
            if (DateTime.Parse(this.fc_emision.Text) > DateTime.Today)
            {
                lblmensaje.Text = "La fecha de Emisión no puede ser mayor a la fecha actual";
                return;
            }
            if (DateTime.Parse(this.fc_emision.Text) > DateTime.Parse(this.fc_recepcion.Text))
            {
                lblmensaje.Text = "<br />La fecha de Emisión no puede ser mayor a la fecha de recepción";
                return;
            }
            if (this.txtPrimaTotalAnulada.Text == "0.00" || this.txtPrimaTotalAnulada.Text.Length == 0)
            {
                lblmensaje.Text = "<br />Debe registrar un valor para La prima de la póliza";
                return;
            }

            var objData = (OC_DATA_FORM.oc_data_vpr_polanuvar)Session["DATA_POLIZA"];

            var objPolizaMovimiento = new pr_polmov();
            objPolizaMovimiento.id_poliza = objData.objPoliza.id_poliza;// id_poliza.Value;
            objPolizaMovimiento.id_perejec = Convert.ToString(cmbEjecutivo.SelectedItem.Value);
            objPolizaMovimiento.fc_emision = fc_emision.Date;
            objPolizaMovimiento.fc_inivig = fc_inivig.Date;
            objPolizaMovimiento.fc_finvig = objData.objPoliza.fc_finvig;// fc_finvig.Date;
            objPolizaMovimiento.prima_bruta = Convert.ToDecimal(txtPrimaTotalAnulada.Text) * (-1);
            objPolizaMovimiento.prima_neta = 0;
            objPolizaMovimiento.por_comision = 0;
            objPolizaMovimiento.comision = 0;
            objPolizaMovimiento.id_div = objData.objPoliza.id_div;
            //objPolizaMovimiento.variable = true;//variable
            objPolizaMovimiento.num_cuota = 0;
            objPolizaMovimiento.id_clamov = 49;
            objPolizaMovimiento.estado = "PRODUCCION";
            objPolizaMovimiento.id_dir = objData.objPoliza.id_dir;
            objPolizaMovimiento.fc_recepcion = fc_recepcion.Date;
            objPolizaMovimiento.mat_aseg = txtObservaciones.Text.ToUpper();
            objPolizaMovimiento.fc_reg = DateTime.Now;
            objPolizaMovimiento.no_liquida = txtNroLiquidacion.Text.ToUpper();
            objPolizaMovimiento.tipo_cuota = true;// Convert.ToBoolean(tipo_cuota.SelectedItem.Value);
            objPolizaMovimiento.id_mom = objData.objPoliza.id_mom; ;

            //var lstCuotas = (List<pr_cuotapoliza>)Session["LST_CUOTAS"];

            var objPolizaAnulada = new pr_anulada();
            objPolizaAnulada.monto_anulada = Convert.ToDecimal(txtPrimaTotalAnulada.Text) * -1;
            //objPolizaAnulada.neta_anulada

            if (_objConsumoRegistroProd.ExistePol(lblNroPoliza.Text.ToUpper(), txtNroLiquidacion.Text.ToUpper()))
            {
                lblmensaje.Text = "Verifique el número de Póliza y liquidación se encuentran registrados con anterioridad <br/> Haga uso de los reportes para poder verificar este dato</p>";

                return;
            }
                var response = _objConsumoRegistroProd.InsertarPolizaMovAn(objPolizaMovimiento, objPolizaAnulada);

            if (response == false)
            {
                lblmensaje.Text = "Ocurrio un error";
                return;
            }
            var idPoliza = objPolizaMovimiento.id_poliza;
            var idMovimiento = objPolizaMovimiento.id_movimiento;
            var idClaMov = objPolizaMovimiento.id_clamov;
            Response.Redirect("../RegistroProduccion/wpr_polizacobranzaan.aspx?var=" + idPoliza + "&val=" + idMovimiento + "&ver=" + idClaMov);
        }

        protected void btnSalir_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Sitio/Vista/Default.aspx");
        }
    }
}