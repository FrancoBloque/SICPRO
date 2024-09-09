using DevExpress.Web.Bootstrap;
using DevExpress.XtraReports;
using EntidadesClases.ModelSicPro;
using Logica.Consumo;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using static EntidadesClases.CustomModelEntities.OC_DATA_FORM;

namespace PresentacionWeb.Sitio.Vista.RegistroProduccion
{
    public partial class wpr_polizacobranzaan : System.Web.UI.Page
    {
        ConsumoRegistroProd _objConsumoRegistroProd = new ConsumoRegistroProd();
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!this.Page.IsPostBack && base.Request.QueryString["var"] != "")
            {
                long idPoliza = Convert.ToInt64(base.Request.QueryString["var"]);
                long idMov = Convert.ToInt64(base.Request.QueryString["val"]);
                string mov = Convert.ToString(base.Request.QueryString["ver"]);
                Movimiento(mov);
                //this.Buscar(num, num1);
                //this.id_poliza.Value = num.ToString();
                //this.id_mov.Value = num1.ToString();

                CargaInicial(idPoliza, idMov);
            }            
        }

        #region Metodos

        private void Movimiento(string mov)
        {
            if (mov == "46")
            {
                this.titulo.Text = "Datos de Poliza Excluida (Módulo de Cobranzas)";
                this.id_clamov.Value = "46";
                return;
            }
            if (mov == "49")
            {
                this.titulo.Text = "Datos de Poliza Anulada (Módulo de Cobranzas)";
                this.id_clamov.Value = "49";
            }
        }
        
        private void CargaInicial(long idPoliza, long idMov)
        {
            var lstFuncionarios = _objConsumoRegistroProd.ObtenerEjecutivoClientes();
            cmbEjecutivo.DataSource = lstFuncionarios;
            cmbEjecutivo.TextField = "nomraz";
            cmbEjecutivo.ValueField = "id_per";
            cmbEjecutivo.DataBind();

            var itemLstFuncionarios = new BootstrapListEditItem { Text = "Seleccione...", Value = "", Selected = true, Index = 0 };
            cmbEjecutivo.Items.Add(itemLstFuncionarios);

            //para exclusion y anulacion la consulta es la misma
            var objDataCompletaPoliza = _objConsumoRegistroProd.ObtenerDataCompletaPolizaEx(idPoliza, idMov);
            Session["DATA_POLIZA"] = objDataCompletaPoliza;
            if (objDataCompletaPoliza != null)
            {
                fc_emision.Date = objDataCompletaPoliza.objDataPoliza.fc_emision;
                fc_recepcion.Date = objDataCompletaPoliza.objDataPoliza.fc_recepcion;
                fc_inivig.Date = objDataCompletaPoliza.objDataPoliza.fc_inivig;
                lblfc_finvig.Text = objDataCompletaPoliza.objDataPoliza.fc_finvig.ToShortDateString();

                lblNroPoliza.Text = objDataCompletaPoliza.objDataPoliza.num_poliza;
                txtNroLiquidacion.Text = objDataCompletaPoliza.objDataPoliza.no_liquida;
                lblAsegurado.Text = objDataCompletaPoliza.objDataPoliza.nomraz;
                lblDireccion.Text = objDataCompletaPoliza.objDataPoliza.direccion;
                lblGrupo.Text = objDataCompletaPoliza.objGrupo == null ? "SIN GRUPO" : objDataCompletaPoliza.objGrupo.desc_grupo;
                //lblCiaAseg.Text = ;

                lblProducto.Text = objDataCompletaPoliza.objProducto.desc_prod;

                var itemFuncionario = cmbEjecutivo.Items.FindByValue(objDataCompletaPoliza.objDataPoliza.id_perejec);
                if (itemFuncionario != null)
                {
                    cmbEjecutivo.SelectedItem = itemFuncionario;
                }
                lblAgente.Text = objDataCompletaPoliza.objPersonaAgente.nomraz;
                lblTipoPoliza.Text = objDataCompletaPoliza.objDataPoliza.clase_poliza == true ? "Normal" : "Flotante";
                txtPrimaBruta.Text = Convert.ToString(objDataCompletaPoliza.objDataPoliza.prima_bruta);
                //txtNumCuotas.Text = Convert.ToString(objDataCompletaPoliza.objDataPoliza.num_cuota);
                lblDivisa.Text = objDataCompletaPoliza.objParametroDivisa.desc_param;

                txtObservaciones.Text = objDataCompletaPoliza.objDataPoliza.mat_aseg;

                var dataPorcentual = _objConsumoRegistroProd.Porcentuales(objDataCompletaPoliza.objDataPoliza.id_mom);
                txtPrimaNeta.Text = string.Format("{0:n}", Convert.ToDecimal(txtPrimaBruta.Text.Replace(".", "").Replace(".", ",")) * dataPorcentual.por_neta);
                txtPorcentaje.Text = Convert.ToString(dataPorcentual.por_comision);
                txtComision.Text = string.Format("{0:n}", Convert.ToDecimal(txtPrimaBruta.Text.Replace(".", "").Replace(".", ",")) * dataPorcentual.por_neta * (dataPorcentual.por_comision) / 100);


                //grdCuotasPoliza.DataSource = lstCuotas;
                //grdCuotasPoliza.DataBind();
                btnNuevo.Visible = true;
                btnGuardar.Visible = true;
                btnSalir.Visible = true;
                btnMemo.Visible = false;
                pnlDatosCobranza.Visible = false;

            }

        }
        //private void CalculaGrilla()
        //{
        //    var objDataPoliza = (vcb_veripoliza1)Session["vcb_veripoliza1"];
        //    for (int i = 0; i < grdCuotasPoliza.Rows.Count; i++)
        //    {
        //        var txtCuotaTotal = (BootstrapSpinEdit)grdCuotasPoliza.Rows[i].Cells[2].FindControl("txtCuotaTotal");//cuota_total
        //        if (txtCuotaTotal == null)
        //        {
        //            return;
        //        }
        //        if (txtCuotaTotal.Text == "0,00")
        //        {

        //            grdCuotasPoliza.Rows[i].Cells[3].Text = "0.00";
        //            grdCuotasPoliza.Rows[i].Cells[4].Text = "0.00";
        //            //text.Text = "0,00";
        //            //str.Text = "0,00";
        //            //textBox1.Text = "0,00";
        //            return;
        //        }
        //        else
        //        {
        //            var decPrimaNeta = _objConsumoRegistroProd
        //                .Prima_Neta(objDataPoliza.id_spvs, objDataPoliza.id_poliza, objDataPoliza.id_movimiento, Convert.ToDecimal(txtNumCuotas.Text), Convert.ToDecimal(txtPrimaNeta.Text));//"0.00";
        //            //grdCuotasPoliza.Rows[i].Cells[3].Text = Convert.ToString(decPrimaNeta);
        //            var decComision = _objConsumoRegistroProd
        //                .Comision_Neta(objDataPoliza.id_spvs, objDataPoliza.id_poliza, objDataPoliza.id_movimiento, Convert.ToDecimal(txtPorcentaje.Text));//"0.00";

        //            grdCuotasPoliza.Rows[i].Cells[3].Text = Convert.ToString(decPrimaNeta);
        //            grdCuotasPoliza.Rows[i].Cells[4].Text = Convert.ToString(decComision);
        //        }
        //    }

        //    //int num = Convert.ToInt32(e.CommandArgument);
        //    //GridViewRow item = this.gridcuotas.Rows[num];
        //    //TextBox textBox = (TextBox)item.FindControl("fecha_pago");
        //    //TextBox textBox1 = (TextBox)item.FindControl("cuota_total");
        //    //TextBox text = (TextBox)item.FindControl("cuota_neta");
        //    //TextBox str = (TextBox)item.FindControl("cuota_comis");
        //    //TextBox textBox2 = (TextBox)this.gridcuotas.FooterRow.FindControl("scuota_total");
        //    //TextBox textBox3 = (TextBox)this.gridcuotas.FooterRow.FindControl("scuota_neta");
        //    //TextBox textBox4 = (TextBox)this.gridcuotas.FooterRow.FindControl("scuota_comis");
        //    //Label label = (Label)item.FindControl("cuota");
        //    //if (e.CommandName == "Verificar")
        //    //{
        //    //    if (textBox1.Text == "0,00")
        //    //    {
        //    //        text.Text = "0,00";
        //    //        str.Text = "0,00";
        //    //        textBox1.Text = "0,00";
        //    //        return;
        //    //    }
        //    //    this.msgboxpanel.Visible = false;
        //    //    if (label.Text == "0" && this.id_spvs.Value == "109")
        //    //    {
        //    //        pr_cobranzas prCobranza = new pr_cobranzas()
        //    //        {
        //    //            id_spvs1 = this.id_spvs,
        //    //            prima_neta = this.prima_neta,
        //    //            por_comision = this.por_comision,
        //    //            num_cuota = this.num_cuota
        //    //        };
        //    //        string str1 = prCobranza.Prima_Neta1(int.Parse(this.id_poliza.Value), int.Parse(this.id_mov.Value));
        //    //        double num1 = Math.Round(double.Parse(str1), 2);
        //    //        str1 = num1.ToString();
        //    //        text.Text = string.Format("{0:n}", double.Parse(str1));
        //    //        prCobranza.comision = this.comision;
        //    //        string str2 = prCobranza.ComisionTotal1(int.Parse(this.id_poliza.Value), int.Parse(this.id_mov.Value), int.Parse(this.id_producto.Value));
        //    //        double num2 = Math.Round(double.Parse(str2), 2);
        //    //        str2 = num2.ToString();
        //    //        str.Text = string.Format("{0:n}", double.Parse(str2));
        //    //        return;
        //    //    }
        //    //    if (this.id_spvs.Value == "109")
        //    //    {
        //    //        text.Text = textBox1.Text;
        //    //        double num3 = double.Parse(text.Text.Replace(".", "").Replace(",", "")) / 100 * double.Parse(this.por_comision.Text.Replace(".", "").Replace(",", "")) / 100;
        //    //        str.Text = num3.ToString();
        //    //        double num4 = double.Parse(str.Text) / 100;
        //    //        str.Text = num4.ToString();
        //    //        str.Text = string.Format("{0:n}", double.Parse(str.Text));
        //    //        return;
        //    //    }
        //    //    double num5 = double.Parse(textBox1.Text.Replace(".", "").Replace(",", ""));
        //    //    num5 /= 100;
        //    //    double num6 = double.Parse(this.prima_bruta.Text.Replace(".", "").Replace(",", ""));
        //    //    num6 /= 100;
        //    //    double num7 = double.Parse(this.prima_neta.Text.Replace(".", "").Replace(",", ""));
        //    //    num7 /= 100;
        //    //    double num8 = num5 / num6 * num7;
        //    //    num8 = Math.Round(num8, 2);
        //    //    text.Text = string.Format("{0:n}", num8);
        //    //    double num9 = num8 * (double.Parse(this.por_comision.Text.Replace(".", ",")) / 100);
        //    //    num9 = Math.Round(num9, 2);
        //    //    str.Text = string.Format("{0:n}", num9);
        //    //    return;
        //    //}
        //}

        protected void Modificar()
        {
            var objDataCompletaPoliza = (oc_data_vcb_veripoliza3)Session["DATA_POLIZA"];
            //pr_cobranzas prCobranza = new pr_cobranzas()
            //{
            //    id_poliza = this.id_poliza,
            //    neta_anulada = this.neta_anulada,
            //    comision_anulada = this.comision_anulada,
            //    lblmensaje = this.lblmensaje
            //};
            var objPrAnulada = new pr_anulada();
            objPrAnulada.id_poliza = objDataCompletaPoliza.objDataPoliza.id_poliza;
            objPrAnulada.id_movimiento = objDataCompletaPoliza.objDataPoliza.id_movimiento;
            objPrAnulada.neta_anulada = Convert.ToDecimal(txtPrimaNeta.Text);
            objPrAnulada.comision_anulada = Convert.ToDecimal(comision_anulada.Value);
            if (lblDcAnexoDevol.Text == "0"){
               
                _objConsumoRegistroProd.ModificarAnulacion(objPrAnulada);
            }
            //prCobranza.monto_devolucion1 = this.monto_devolucion;
            //prCobranza.neta_devolucion = this.neta_devolucion;
            //prCobranza.comision_devolucion = this.comision_devolucion;
            if (lblDcAnexoDevol.Text != Convert.ToString(0))
            {                
                _objConsumoRegistroProd.ModificarAnulacion(objPrAnulada);

                var objPrDevolucion = new pr_devolucion();
                objPrDevolucion.id_poliza = objDataCompletaPoliza.objDataPoliza.id_poliza;
                objPrDevolucion.id_movimiento = objDataCompletaPoliza.objDataPoliza.id_movimiento;
                objPrDevolucion.cuota_devolucion = 0;
                objPrDevolucion.monto_devolucion = Convert.ToDecimal(lblDcAnexoDevol.Text);
                objPrDevolucion.neta_devolucion = Convert.ToDecimal(txtDcNetaDev.Text);
                objPrDevolucion.comision_devolucion = Convert.ToDecimal(txtComision.Text);
                objPrDevolucion.saldo_devolucion = Math.Abs(Convert.ToDecimal(lblDcAnexoDevol.Text));
                _objConsumoRegistroProd.ModificarDevolucion(objPrDevolucion);
            }
        }

        private void Calculos(decimal primabruta, long idProducto, string idSpvs)
        {
            //pr_cobranzas prCobranza = new pr_cobranzas()
            //{
            //    id_spvs1 = this.id_spvs,
            //    prima_bruta = this.prima_bruta,
            //    id_producto = this.id_producto
            //};
            //HiddenField primaNeta1 = this.prima_neta1;
            decimal num = _objConsumoRegistroProd.Calculo1(primabruta, idProducto, idSpvs);
            primaNeta1.Value = num.ToString();
            por_comision1.Value = _objConsumoRegistroProd.Porco1(idProducto, idSpvs).ToString();
            //HiddenField str = this.comision1;
            decimal num1 = _objConsumoRegistroProd.Com2(primabruta, idProducto, idSpvs);
            str.Value = num1.ToString();
            //txtDcPrimaTotal.Text = string.Format("{0:n}", double.Parse(txtDcPrimaTotal.Text));
            //prima_neta1.Value = string.Format("{0:n}", double.Parse(prima_neta1.Value));
            //por_comision1.Value = string.Format("{0:n}", double.Parse(por_comision1.Value));
            //comision1.Value = string.Format("{0:n}", double.Parse(comision1.Value));
        }

        #endregion

        protected void btnNuevo_Click(object sender, EventArgs e)
        {
            //LimpiarFormulario();
            Response.Redirect("~/Sitio/Vista/RegistroProduccion/wpr_listaanu.aspx", false);
        }


        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            var dcPrimaBruta = Convert.ToDecimal(txtPrimaBruta.Text);

            var objDataCompletaPoliza = (oc_data_vcb_veripoliza3)Session["DATA_POLIZA"];
            var objPrPoliza = new pr_poliza();
            objPrPoliza.num_poliza = objDataCompletaPoliza.objDataPoliza.num_poliza;
            objPrPoliza.id_producto = objDataCompletaPoliza.objDataPoliza.id_producto;
            objPrPoliza.id_perclie = objDataCompletaPoliza.objDataPoliza.id_perclie;
            objPrPoliza.id_spvs = objDataCompletaPoliza.objDataPoliza.id_spvs;//objDataCompletaPoliza.objDataPoliza.num_poliza;
            
            objPrPoliza.id_gru = objDataCompletaPoliza.objDataPoliza.id_gru;
            objPrPoliza.clase_poliza = objDataCompletaPoliza.objDataPoliza.clase_poliza;
            objPrPoliza.id_percart = objDataCompletaPoliza.objDataPoliza.id_percart;
           
            var objPolmov = new pr_polmov();
            objPolmov.id_perejec = Convert.ToString(cmbEjecutivo.SelectedItem.Value);
            objPolmov.fc_emision = fc_emision.Date;
            objPolmov.fc_inivig = fc_inivig.Date;
            objPolmov.fc_finvig = objDataCompletaPoliza.objDataPoliza.fc_finvig;
            objPolmov.prima_bruta = dcPrimaBruta; // Convert.ToDecimal(txtPrimaBruta.Text);
            objPolmov.prima_neta = Convert.ToDecimal(txtPrimaNeta.Text);
            objPolmov.por_comision = Convert.ToDecimal(txtPorcentaje.Text);
            objPolmov.comision = Convert.ToDecimal(txtComision.Text);

            objPolmov.tipo_cuota = true;
            objPolmov.num_cuota = 0;
            objPolmov.id_clamov = 49;
            objPolmov.estado = "COBRANZAS";
            objPolmov.fc_recepcion = fc_recepcion.Date;
            objPolmov.id_div = objDataCompletaPoliza.objDataPoliza.id_div;

            var responsePolCea = _objConsumoRegistroProd.InsertarPolizaCEA(objPrPoliza);
            Calculos(dcPrimaBruta, objDataCompletaPoliza.objDataPoliza.id_producto, objDataCompletaPoliza.objDataPoliza.id_spvs);
            var responseMovCea = _objConsumoRegistroProd.InsertarPolizaMovCEA1(objPolmov);

            lblmensaje.Text = "Poliza Verificada";

            pnlDatosCobranza.Visible = true;
            btnGuardar.Visible = false;
        }

        protected void btnCalcular_Click(object sender, EventArgs e)
        {
            txtComision.Text = string.Format("{0:n}", double.Parse(this.txtPorcentaje.Text.Replace(".", "").Replace(",", "")) / 100 / 100 * double.Parse(this.txtPrimaNeta.Text.Replace(".", "").Replace(",", "")) / 100);
            
        }

        protected void btnDcCalcular_Click(object sender, EventArgs e)
        {
            try
            {
                var objDataCompletaPoliza = (oc_data_vcb_veripoliza3)Session["DATA_POLIZA"];
                
                var decPrimaBruta = Convert.ToDecimal(txtPrimaBruta.Text);
                var idProducto = objDataCompletaPoliza.objDataPoliza.id_producto;
                var idSpvs = objDataCompletaPoliza.objDataPoliza.id_spvs;

                var num = _objConsumoRegistroProd.Calculo1(decPrimaBruta, idProducto, idSpvs);

                txtDcPrimaNeta.Text = Convert.ToString(num);
                
                double num1 = Math.Round(double.Parse(txtDcPrimaNeta.Text), 2);
                //str.Text = num1.ToString();
                txtDcPrimaNeta.Text = string.Format("{0:n}", double.Parse(txtDcPrimaNeta.Text));
                //HiddenField comisionAnulada = this.comision_anulada;
                var num2 = Math.Round(_objConsumoRegistroProd.Com2(decPrimaBruta, idProducto, idSpvs), 2);
                comision_anulada.Value = num2.ToString();
                //this.comision_anulada.Value = string.Format("{0:n}", double.Parse(this.comision_anulada.Value));
                //TextBox netaDevolucion = this.neta_devolucion;
                var num3 = Math.Round(_objConsumoRegistroProd.Calculo1(Convert.ToDecimal(lblDcAnexoDevol.Text),idProducto,idSpvs), 2);
                txtDcNetaDev.Text = num3.ToString();
                //txtDcNetaDev.Text = string.Format("{0:n}", double.Parse(txtDcNetaDev.Text));
                //HiddenField comisionDevolucion = this.comision_devolucion;
                var num4 = Math.Round(_objConsumoRegistroProd.Com2(Convert.ToDecimal(lblDcAnexoDevol.Text), idProducto, idSpvs), 2);
                lblDcAnexoDevol.Text = num4.ToString();
                //comisionDevolucion.Value = num4.ToString();
                //this.comision_devolucion.Value = string.Format("{0:n}", double.Parse(this.comision_devolucion.Value));
                Modificar();
                //this.msgboxpanel.Visible = true;
                //MessageBox messageBox = new MessageBox(base.Server.MapPath("msgbox.tpl"));
                //messageBox.SetTitle("Confirmación");
                //messageBox.SetIcon("msg_icon_1.png");
                //messageBox.SetMessage("Verificación de Anulación de Poliza Realizada Satisfactoriamente");
                //messageBox.SetOKButton("msg_button_class");
                //this.msgboxpanel.InnerHtml = messageBox.ReturnObject();
                btnDcCalcular.Visible = false;
                btnMemo.Visible = true;
                lblmensaje.Text = "Validación completada";
            }
            catch (Exception ex)
            {
            }
        }

        protected void btnSalir_Click(object sender, EventArgs e)
        {
        }

        protected void btnMemo_Click(object sender, EventArgs e)
        {
            var objDataCompletaPoliza = (oc_data_vcb_veripoliza3)Session["DATA_POLIZA"];

            var idPoliza = objDataCompletaPoliza.objDataPoliza.id_poliza;
            var idMovimiento = objDataCompletaPoliza.objDataPoliza.id_movimiento;

            ifrReport.Attributes.Add("src", "../Reportes/re_viewer.aspx?r=1" +
                "&p=" + idPoliza +
                "&m=" + idMovimiento
                );

            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModal();", true);
            //re_memo_report.Visible = true;
            //re_memo_report.Attributes.Add("src", "https://localhost:44347/Sitio/Vista/Reportes/re_viewer.aspx?r=1");
        }
    }
}