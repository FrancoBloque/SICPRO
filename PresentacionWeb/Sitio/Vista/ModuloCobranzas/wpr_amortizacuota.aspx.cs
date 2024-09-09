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
using System.Data;

namespace PresentacionWeb.Sitio.Vista.ModuloCobranzas
{
    public partial class wpr_amortizacuota : System.Web.UI.Page
    {
        ConsumoRegistroProd _objConsumoRegistroProd = new ConsumoRegistroProd();
        ConsumoModComision _objConsumoModComision = new ConsumoModComision();
        ConsumoValidarProd _objValidarProd = new ConsumoValidarProd();
        ConsumoCobranza conCobranza = new ConsumoCobranza();
        bool sw = false;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.Page.IsPostBack)
            {
                this.Combos();
            }
        }
        private void Combos()
        {
            try

            {
                var sucursal = _objConsumoRegistroProd.ObtenerLista("id_tpago");
                id_tpago.DataSource = sucursal;
                id_tpago.TextField = "desc_param";
                id_tpago.ValueField = "id_par";
                id_tpago.DataBind();

            }
            catch
            {
            }
        }

        protected void btnserper1_Click(object sender, EventArgs e)
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
        private void Polizas()
        {
            var lstPoliza = conCobranza.ObtenerPoliza(id_per.Value);
            num_poliza.DataSource = lstPoliza;
            num_poliza.TextField = "num_poliza";
            num_poliza.ValueField = "id_poliza";
            num_poliza.DataBind();


        }
        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            pCPersona.ShowOnPageLoad = false;
        }


        protected void btnrec_Click(object sender, EventArgs e)
        {
            if (this.id_tpago.Value.ToString() == "69")
            {
                var datar = conCobranza.ObtenerRD69(this.id_per.Value, this.id_gru.Value, 85);

                grdReciboCompensacion.DataSource = datar;
                grdReciboCompensacion.DataBind();
                pnlReciboCompensacion.ShowOnPageLoad = true;
                return;
            }
            if (this.id_tpago.Value.ToString() != "70")
            {
                this.id_liq.Value = "0";
                var data = conCobranza.ObtenerRD70(this.id_per.Value, this.id_gru.Value, 85);

                GrdDevolucion.DataSource = data;
                GrdDevolucion.DataBind();
                pnlGrdDevolucion.ShowOnPageLoad = true;

                return;

            }

            var dataTable = conCobranza.ObtenerRD69(this.id_per.Value, "0", 85);

            grdReciboCompensacion.DataSource = dataTable;
            grdReciboCompensacion.DataBind();
            pnlReciboCompensacion.ShowOnPageLoad = true;
            return;

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            base.Response.Redirect("wpr_amortizacuota.aspx");
        }

        protected void b1_Click(object sender, EventArgs e)
        {

            if (this.id_perclie.Value == "" || this.id_perclie.Value == null)
            {
                this.Polizas();
                return;
            }
            base.Response.Redirect("wpr_amortizacuota.aspx");
        }

        protected void btnguardar_Click(object sender, EventArgs e)
        {
            try
            {
                string str = "";

                if (string.IsNullOrEmpty(this.monto_pago.Text))
                {
                    str = string.Concat(str, "<br />Debe Ingresar un monto a pagar");
                    this.sw = true;
                }
                if (string.IsNullOrEmpty(this.pago_por.Text))
                {
                    str = string.Concat(str, "<br />Debe Ingresar un Concepto");
                    this.sw = true;
                }
                double num = double.Parse(this.monto_exclusion.Text) / 100;
                double num1 = double.Parse(this.monto_pago.Text) / 100;
                if (Math.Round(num1 + double.Parse(this.monto_devolucion.Text) / 100 - num, 2) > 0)
                {
                    str = string.Concat(str, "<br /> La suma del monto pagado mas el monto a pagar no puede exceder el valor de la prima total ");
                    this.sw = true;
                }
                if (!this.sw)
                {
                    double num2 = double.Parse(this.cuota_neta.Value);
                    double num3 = double.Parse(this.cuota_total.Value);
                    double num4 = double.Parse(this.comision_cuota.Value);
                    if (this.monto_pago.Text.Length <= 6)
                    {
                        num1 = double.Parse(this.monto_pago.Text);
                    }
                    else
                    {
                        num1 = double.Parse(this.monto_pago.Text);
                        num1 /= 100;
                    }
                    double num5 = 0;
                    if (this.monto_resto.Text != "")
                    {
                        num5 = double.Parse(this.monto_resto.Text);
                        double num6 = num2 / num3 * num1;
                        double num7 = num4 / num3 * num1;
                        this.neta_pago.Value = num6.ToString();
                        this.comision_pago.Value = num7.ToString();
                    }
                    else
                    {
                        this.monto_resto.Text = "0";
                    }
                    if (this.id_tpago.Value.ToString() == "68")
                    {
                        this.anio_recibo.Value = "0";
                        this.recibo.Text = "0";
                        this.monto_resto.Text = "0";


                        pr_pago prPago = new pr_pago()
                        {
                            id_poliza = Convert.ToInt64(num_poliza.Value),
                            id_movimiento = Convert.ToInt64(no_liquida.Value),
                            cuota = Convert.ToDecimal(cuota.Value),
                            anio_recibo = Convert.ToDecimal(anio_recibo.Value),
                            monto_pago = Convert.ToDecimal(monto_pago.Text),
                            neta_pago = Convert.ToDecimal(neta_pago.Value),
                            comision_pago = Convert.ToDecimal(comision_pago.Value),
                            id_tpago = Convert.ToInt64(id_tpago.Value),
                            pago_por = pago_por.Text.ToUpper(),
                            id_liq = Convert.ToInt32(id_liq.Value),
                        };

                        var objPagos = conCobranza.InsertarPago(prPago);
                        pr_cuotapoliza objCuotaPoliza = new pr_cuotapoliza()
                        {
                            id_poliza = Convert.ToInt64(num_poliza.Value),
                            id_movimiento = Convert.ToInt64(no_liquida.Value),
                            cuota = Convert.ToDecimal(cuota.Value),
                            cuota_pago = Convert.ToDecimal(monto_pago.Value)
                        };
                        var objcuotaPoliza = conCobranza.ActualizarCuotaPago(objCuotaPoliza);

                        if (this.id_tpago.Value.ToString() != "69")
                        {
                            if (this.id_tpago.Value.ToString() == "70")
                            {
                                pr_devolucion prDev = new pr_devolucion()
                                {
                                    id_devolucion = Convert.ToInt64(recibo.Text),
                                    id_poliza = Convert.ToInt64(num_poliza.Value),
                                };
                                var objDevo = conCobranza.ActualizarSaldoDev(prDev, Convert.ToDecimal(monto_pago.Text));
                            }
                            // return;
                        }
                        else
                        {
                            pr_recibo prRecibo = new pr_recibo()
                            {
                                id_liq = Convert.ToInt64(id_liq.Value),
                                id_recibo = Convert.ToInt64(recibo.Text),
                                anio_recibo = Convert.ToDecimal(anio_recibo.Value)
                            };
                            var objRec = conCobranza.ActualizarReciboCob(prRecibo, Convert.ToDecimal(monto_pago.Text));
                        }

                       

                        this.Grilla();
                        this.Limpiar();

                        var lstLiq = conCobranza.ObtenerMovimiento(Convert.ToInt64(num_poliza.Value));

                        this.no_liquida.DataSource = lstLiq;
                        this.no_liquida.TextField = "no_liquida";
                        this.no_liquida.ValueField = "id_movimiento";
                        this.no_liquida.DataBind();

                        var lstGrupo = conCobranza.ObtenerGrupoM(Convert.ToInt64(num_poliza.Value));
                        id_gru.Value = lstGrupo.Count == 0 ? "" : lstGrupo.FirstOrDefault().id_gru.ToString();
                        desc_grupo.Text = lstGrupo.Count == 0 ? "" : lstGrupo.FirstOrDefault().desc_grupo;

                        ////////////////////////




                   

                    }
                    else if (num1 > num5)
                    {
                        this.lblMensaje.Text = "El monto a pagar tiene que ser menor al Monto total";
                        imagenFail.Visible = true;
                        imagenOk.Visible = false;

                        pnlMensaje.ShowOnPageLoad = true;
                        return;
                    }
                    else
                    {
                        pr_pago prPago = new pr_pago()
                        {

                            id_poliza = Convert.ToInt64(num_poliza.Value),
                            id_movimiento = Convert.ToInt64(no_liquida.Value),
                            cuota = Convert.ToDecimal(cuota.Value),
                            anio_recibo = Convert.ToDecimal(anio_recibo.Value),
                            monto_pago = Convert.ToDecimal(monto_pago.Text),
                            neta_pago = Convert.ToDecimal(neta_pago.Value),
                            comision_pago = Convert.ToDecimal(comision_pago.Value),
                            id_tpago = Convert.ToInt64(id_tpago.Value),
                            pago_por = pago_por.Text.ToUpper(),
                            id_liq = Convert.ToInt32(id_liq.Value),

                        };

                        var objPagos = conCobranza.InsertarPago(prPago);

                        pr_cuotapoliza objCuotaPoliza = new pr_cuotapoliza()
                        {
                            id_poliza = Convert.ToInt64(num_poliza.Value),
                            id_movimiento = Convert.ToInt64(no_liquida.Value),
                            cuota = Convert.ToDecimal(cuota.Value),
                            cuota_pago = Convert.ToDecimal(monto_pago.Value)
                        };
                        var objcuotaPoliza = conCobranza.ActualizarCuotaPago(objCuotaPoliza);

                        if (this.id_tpago.Value.ToString() != "69")
                        {
                            if (this.id_tpago.Value.ToString() == "70")
                            {
                                pr_devolucion prDev = new pr_devolucion()
                                {
                                    id_devolucion = Convert.ToInt64(recibo.Text),
                                    id_poliza = Convert.ToInt64(num_poliza.Value),

                                };

                                var objDevo = conCobranza.ActualizarSaldoDev(prDev, Convert.ToDecimal(monto_pago.Text));

                            }
                            return;
                        }
                        pr_recibo prRecibo = new pr_recibo()
                        {
                            id_liq = Convert.ToInt64(id_liq.Value),
                            id_recibo = Convert.ToInt64(recibo.Text),
                            anio_recibo = Convert.ToDecimal(anio_recibo.Value)

                        };

                        var objRec = conCobranza.ActualizarReciboCob(prRecibo, Convert.ToDecimal(monto_pago.Text));
                        this.Grilla();
                        this.Limpiar();
                    }
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
            catch
            {
            }
        }
        private void Limpiar()
        {
            var lstCuotas = conCobranza.Cuotas(Convert.ToInt64(num_poliza.Value), Convert.ToInt64(no_liquida.Value));

            this.cuota.DataSource = lstCuotas;
            this.cuota.TextField = "cuota";
            this.cuota.ValueField = "cuota";
            this.cuota.DataBind();

            this.cuota.SelectedIndex = -1;
            this.id_tpago.SelectedIndex = -1;
            this.recibo.Text = "";
            this.monto_resto.Text = "";
            this.monto_exclusion.Text = "";
            this.monto_devolucion.Text = "";
            this.monto_pago.Text = "";
            this.pago_por.Text = "";
        }
        protected void btnserper_Click(object sender, EventArgs e)
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

        protected void num_poliza_SelectedIndexChanged(object sender, EventArgs e)
        {

            try
            {

                var lstLiq = conCobranza.ObtenerMovimiento(Convert.ToInt64(num_poliza.Value));

                this.no_liquida.DataSource = lstLiq;
                this.no_liquida.TextField = "no_liquida";
                this.no_liquida.ValueField = "id_movimiento";
                this.no_liquida.DataBind();


                var lstGrupo = conCobranza.ObtenerGrupoM(Convert.ToInt64(num_poliza.Value));
                id_gru.Value = lstGrupo.Count == 0 ? "" : lstGrupo.FirstOrDefault().id_gru.ToString();
                desc_grupo.Text = lstGrupo.Count == 0 ? "" : lstGrupo.FirstOrDefault().desc_grupo;
            }
            catch
            {
            }

        }

        protected void no_liquida_SelectedIndexChanged(object sender, EventArgs e)
        {

            try
            {


                var lstCuotas = conCobranza.Cuotas(Convert.ToInt64(num_poliza.Value), Convert.ToInt64(no_liquida.Value));

                this.cuota.DataSource = lstCuotas;
                this.cuota.TextField = "cuota";
                this.cuota.ValueField = "cuota";
                this.cuota.DataBind();
                this.Grilla();

            }
            catch
            {
            }
        }
        public void Grilla()
        {
            try
            {
                var lstCuotas = conCobranza.GridCuotas(Convert.ToInt64(num_poliza.Value), Convert.ToInt64(no_liquida.Value));
                this.grdcuotas.DataSource = lstCuotas;
                this.grdcuotas.DataBind();
                grdcuotas.Visible = true;
            }
            catch
            {

            }
        }

        protected void cuota_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {

                var vnum_poliza = Convert.ToInt64(num_poliza.Value);
                var vno_liquida = Convert.ToInt64(no_liquida.Value);
                var vcuota = Convert.ToInt64(cuota.Value);

                var datos = conCobranza.DatosCuota(vnum_poliza, vno_liquida, vcuota).FirstOrDefault();
                this.cuota_total.Value = datos.cuota_total.ToString();
                this.cuota_neta.Value = datos.cuota_neta.ToString();
                this.comision_cuota.Value = datos.cuota_comis.ToString();
                this.monto_exclusion.Text = datos.monto_exclusion.ToString();
                this.monto_devolucion.Text = datos.monto_devolucion.ToString();
            }
            catch
            {
            }

        }

        protected void id_tpago_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (this.id_tpago.Value.ToString() != "68")
            {
                this.recibo.Text = "";
                this.monto_resto.Text = "";
            }
            else
            {
                this.recibo.Text = "";
                this.monto_resto.Text = "0";
                this.id_liq.Value = "0";
                this.idliq.Text = "0";
                this.btnguardar.Enabled = true;
            }


            var vnum_poliza = Convert.ToInt64(num_poliza.Value);
            var vno_liquida = Convert.ToInt64(no_liquida.Value);
            var vcuota = Convert.ToInt64(cuota.Value);


            var datos = conCobranza.DatosCuota(vnum_poliza, vno_liquida, vcuota).FirstOrDefault();
            this.cuota_total.Value = datos.cuota_total.ToString();
            this.cuota_neta.Value = datos.cuota_neta.ToString();
            this.comision_cuota.Value = datos.cuota_comis.ToString();
            this.monto_exclusion.Text = datos.cuotatotal.ToString();
            this.monto_devolucion.Text = datos.cuotapago.ToString();

        }
        protected void Insertar(object sender, EventArgs e)
        {

        }
    }
}