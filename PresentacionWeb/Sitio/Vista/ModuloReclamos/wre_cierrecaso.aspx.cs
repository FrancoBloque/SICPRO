using DevExpress.XtraPrinting;
using EntidadesClases.ModelSicPro;
using Logica.Consumo;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PresentacionWeb.Sitio.Vista.ModuloReclamos
{
    public partial class wre_cierrecaso : System.Web.UI.Page
    {
        ConsumoReclamos logicaReclamos = new ConsumoReclamos();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Page.IsPostBack)
                return;

            this.anio_caso.DataSource = logicaReclamos.anio_list();
            this.anio_caso.DataTextField = "desc_param";
            this.anio_caso.DataValueField = "valor_param";
            this.anio_caso.DataBind();
            this.anio_caso.SelectedValue = "0";

            this.id_estca.DataSource = logicaReclamos.ParametroV("id_estca", 2);
            this.id_estca.DataTextField = "desc_param";
            this.id_estca.DataValueField = "id_par";
            this.id_estca.DataBind();
            this.id_estca.SelectedValue = "0";
        }
        protected void btnnuevo_Click(object sender, EventArgs e)
        {
            this.Response.Redirect("wre_cierrecaso.aspx");
        }

        protected void btnsalir_Click(object sender, EventArgs e)
        {
            this.Response.Redirect("Index.aspx");
        }

        protected void btnser_Click(object sender, ImageClickEventArgs e)
        {
            decimal idCaso = decimal.Parse(this.id_caso.Text);
            decimal idAnioCaso = decimal.Parse(this.anio_caso.SelectedValue);
            var item = logicaReclamos.ser_histcaso(idCaso, idAnioCaso);
            if (item == null)
            {
                this.lblerror.Text = " El número de caso no fue encontrado, es problable que el mismo se encuentre cerrado.\r\nVerifique el mismo mediante reportes";
                this.popUpValidacion.ShowOnPageLoad = true;
                this.btnguardar.Visible = false;
                this.id_caso.Focus();
                this.divisa2.Text = this.divisa1.Text.ToUpper();
                this.divisa3.Text = this.divisa1.Text.ToUpper();
                return;
            }

            this.monto_aprox1.Text = string.Format("{0:n}", item.aprox_caso);
            this.fc_denuncia.Text = string.Format(CultureInfo.CreateSpecificCulture("es-MX"), "{0:D}", (object)DateTime.Parse(item.fc_denuncia.Value.ToString()));
            this.fc_iniestado.Text = string.Format(CultureInfo.CreateSpecificCulture("es-MX"), "{0:D}", (object)DateTime.Parse(item.fc_iniestado.ToString()));
            this.nomraz.Text = item.nomraz;//dt.Rows[0]["nomraz"].ToString();
            this.nomraz2.Text = item.nomraz2;//dt.Rows[0]["nomraz2"].ToString();
            this.num_poliza.Text = item.num_poliza;//dt.Rows[0]["num_poliza"].ToString();
            this.desc_prod.Text = item.desc_prod;//dt.Rows[0]["desc_prod"].ToString();
            this.mat_aseg.Text = item.mat_aseg;//dt.Rows[0]["mat_aseg"].ToString();
            this.uni_obj.Text = item.uniobj;//dt.Rows[0]["uniobj"].ToString();
            this.circunstancia.Text = item.circunstancia;//dt.Rows[0]["circunstancia"].ToString();
            this.desc_param.Text = item.desc_param;//dt.Rows[0]["desc_param"].ToString();
            this.obs_histcaso1.Text = item.obs_histcaso;//dt.Rows[0]["obs_histcaso"].ToString();
            this.id_sucur.Value = item.id_sucur.ToString();//dt.Rows[0]["id_sucur"].ToString();
            this.divisa.Text = item.divisa;//dt.Rows[0]["divisa"].ToString();
            this.id_per.Value = item.id_perclie;//dt.Rows[0]["id_perclie"].ToString();

            this.lblmensaje.Text = "Actualice los datos para el cierre del caso";
            this.divisa1.Text = this.divisa.Text;
            this.id_estca.Focus();
        }
        protected void btncalcular_Click(object sender, EventArgs e)
        {
            double coafranVal = Convert.ToDouble(this.coafran.Value);
            double pago_casoVal = Convert.ToDouble(this.pago_caso.Value);

            if (coafranVal <= pago_casoVal)
            {
                //this.indem.Text = string.Format("{0:n}", (object)(double.Parse(this.pago_caso.Text.Replace(".", "").Replace(",", ".")) / 100.0 - double.Parse(this.coafran.Text.Replace(".", "").Replace(",", "")) / 100.0));
                this.indem.Text = string.Format("{0:n}", (object)(pago_casoVal - coafranVal));
                this.btnguardar.Visible = true;
            }
            else
            {
                this.lblerror.Text = "Los siguientes valores deben ser verificados antes de proseguir\r\nEl valor del Coaseguro o Franquicia no debe sobrepasar el valor pagado";
                this.popUpValidacion.ShowOnPageLoad = true;
                this.btnguardar.Visible = false;
            }
        }
        //protected void pnlCallBackBuscaRecibo_Callback(object sender, DevExpress.Web.CallbackEventArgsBase e)
        //{
        //    logicaReclamos=new ConsumoReclamos();
        //    var listaRecibos=logicaReclamos.ObtenerRD_Recibo(e.Parameter.ToString(), "0", 86);
        //    Session["LST_RECIBO"] = listaRecibos;
        //    grdListaRecibo.DataSource = listaRecibos;
        //    grdListaRecibo.DataBind();   
        //}
        protected void btnrec_Click(object sender, EventArgs e)
        {
            var listaRecibos = logicaReclamos.ObtenerRD_Recibo(id_per.Value.ToString(), "0", 86);
            Session["LST_RECIBO"] = listaRecibos;
            grdListaRecibo.DataSource = listaRecibos;
            grdListaRecibo.DataBind();
            popupBusquedaRecibo.ShowOnPageLoad = true;
        }
        protected void btnguardar_Click(object sender, EventArgs e)
        {
            //this.msgboxpanel.Visible = false;
            bool flag = false;
            string str = "";
            if (this.id_caso.Text.Length == 0)
            {
                str += "Debe registrar un número de caso\r\n";
                flag = true;
            }
            if (this.anio_caso.SelectedValue == "0")
            {
                str += "Debe Seleccionar un año de reclamo\r\n";
                flag = true;
            }
            if (this.id_estca.SelectedIndex == 0)
            {
                str += "Debe Seleccionar un estado para el caso\r\n";
                flag = true;
            }
            if (this.obs_histcaso.Text.Length < 25)
            {
                str += "Debe registrar un mínimo de 25 caracteres para las observaciones\r\n";
                flag = true;
            }

            double pago_casoVal = Convert.ToDouble(this.pago_caso.Value);
            if (pago_casoVal<=0)
            {
                str += "Debe modificar el monto, no es válido para el pago del caso\r\n";
                flag = true;
            }

            double coafranVal = Convert.ToDouble(this.coafran.Value);
            if (coafranVal > pago_casoVal)
            {
                str += "El valor del Coaseguro o Franquicia no debe sobrepasar el valor pagado\r\n";
                flag = true;
            }

            if (flag)//con problemas
            {
                this.lblerror.Text = "Los siguientes valores deben ser verificados antes de proseguir\r\n" + str;
                this.popUpValidacion.ShowOnPageLoad = true;
                return;
            }

            logicaReclamos.upd_histcaso1(
                                          decimal.Parse(this.id_caso.Text.ToUpper())
                                         , decimal.Parse(this.anio_caso.SelectedValue)
                                        );
            logicaReclamos.ins_histcaso(
                                        decimal.Parse(this.id_caso.Text.ToUpper())
                                        , decimal.Parse(this.anio_caso.SelectedValue)
                                        , int.Parse(this.id_sucur.Value)
                                        , double.Parse(this.id_estca.SelectedValue)
                                        , this.obs_histcaso.Text.ToUpper()
                                        );
            this.anio_recibo.Value = string.IsNullOrEmpty(this.anio_recibo.Value) ? "0" : this.anio_recibo.Value;
            logicaReclamos.upd_recaso(
                                      decimal.Parse(this.id_caso.Text.ToUpper())
                                      , decimal.Parse(this.anio_caso.SelectedValue)
                                      , this.recibo.Text
                                      , Convert.ToDecimal(this.pago_caso.Value)
                                      , Convert.ToDecimal(this.coafran.Value)
                                      , Convert.ToDecimal(this.indem.Value)
                                      , decimal.Parse(this.anio_recibo.Value)
                                      );
            logicaReclamos.upd_histcaso1(
                                         decimal.Parse(this.id_caso.Text)
                                         , decimal.Parse(this.anio_caso.SelectedValue)
                                        );

            if (this.recibo.Text != "")
            {
                logicaReclamos.ActuaReciboR(long.Parse(this.recibo.Text.ToUpper()), decimal.Parse(this.anio_recibo.Value));
            }

            this.popUpConfirmacion.ShowOnPageLoad = true;
            this.btnguardar.Visible = false;
            this.id_caso.Focus();
            this.lblmensaje.Text = "Caso Cerrado Correctamente";
        }
        protected void grdListaRecibo_DataBinding(object sender, EventArgs e)
        {
            var lstData = (List<pr_recibo>)Session["LST_RECIBO"];
            if (lstData != null)
            {
                this.grdListaRecibo.DataSource = lstData;
            }
        }
        protected void grdListaRecibo_SelectionChanged(object sender, EventArgs e)
        {
            var grilla = (DevExpress.Web.ASPxGridView)sender;
            var lista = grilla.GetSelectedFieldValues("id_recibo");
            var objeto1 = (long)lista[0];
            this.recibo.Value = objeto1;

            lista = grilla.GetSelectedFieldValues("monto_resto");
            var objeto2 = (decimal)lista[0];
            this.coafran.Value = objeto2;

            lista = grilla.GetSelectedFieldValues("anio_recibo");
            var objeto3 = (decimal)lista[0];
            this.anio_recibo.Value = objeto3.ToString();

            popupBusquedaRecibo.ShowOnPageLoad = false;
        }
    }
}