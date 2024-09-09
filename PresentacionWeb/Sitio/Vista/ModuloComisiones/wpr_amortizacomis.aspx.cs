using DevExpress.Web.Bootstrap;
using EntidadesClases.ModelSicPro;
using Logica.Consumo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PresentacionWeb.Sitio.Vista.ModuloComisiones
{
    public partial class wpr_amortizacomis : System.Web.UI.Page
    {
        ConsumoRegistroProd _objConsumoRegistroProd = new ConsumoRegistroProd();
        ConsumoModComision _objConsumoModComision = new ConsumoModComision();
        ConsumoValidarProd _objValidarProd = new ConsumoValidarProd();
        public bool sw;
        protected void Page_Load(object sender, EventArgs e)
        {
            CargaInicial();
        }
        private void CargaInicial()
        {


            var lstDivisa = _objConsumoRegistroProd.ParametroA("id_div");
            id_div.DataSource = lstDivisa;
            id_div.TextField = "abrev_param";
            id_div.ValueField = "id_par";
            id_div.DataBind();

            var itemLstDivisa = new BootstrapListEditItem { Text = "Seleccione...", Value = "", Selected = true, Index = 0 };
            id_div.Items.Add(itemLstDivisa);

            pc_anio.Items.Clear();
            int year = DateTime.Now.Year;
            this.pc_anio.Items.Add("Seleccione una opcion...");
            int num = year - 1;
            this.pc_anio.Items.Add(num.ToString());
            this.pc_anio.Items.Add(year.ToString());
            int num1 = year + 1;
            this.pc_anio.Items.Add(num1.ToString());

            var objTablaCompania = _objValidarProd.ObtenerTablaCompania("");

            id_spvs.DataSource = objTablaCompania;
            id_spvs.TextField = "nomraz";
            id_spvs.ValueField = "id_spvs";
            id_spvs.DataBind();
        }
        protected void btncuotas_Click(object sender, EventArgs e)
        {
            try
            {
               
                pr_pagocompania prAmortizacione = new pr_pagocompania()
                {

                    cheque = cheque.Text.ToUpper(),
                    id_spvs = id_spvs.Value.ToString(),
                    fecha = (DateTime)fecha.Value,
                    monto_pc = Convert.ToDecimal(monto_pc.Value),
                    comision_pc = Convert.ToDecimal(comision_pc.Value),
                    factura_pc = factura_pc.Text.ToUpper(),
                    pc_mes = Convert.ToDecimal(this.pc_mes.Value),
                    pc_anio = Convert.ToDecimal(this.pc_anio.Text),
                    id_div = Convert.ToInt64(id_div.Value),
                    comision_spc = 0,
                    comisaldo_pc = 0
                };
                var pagoCompania = _objConsumoModComision.InsertarPagoComp(prAmortizacione);
                if (pagoCompania != null)
                {
                    cheque.Text = "";
                    fecha.Text = "";
                    id_spvs.Text = "";
                    monto_pc.Text = "";
                    comision_pc.Text = "";
                    factura_pc.Text = "";
                    pc_mes.Text = "";
                    pc_anio.Text = "";
                    id_div.Text = "";
                    lblMensaje.Text = "Cheque para pago de comisiones registrado correctamente!";
                    imagenFail.Visible= false;
                    imagenOk.Visible= true;
                    pnlMensaje.ShowOnPageLoad = true;
                }
                else
                {
                    imagenFail.Visible = true;
                    imagenOk.Visible = false;
                    lblMensaje.Text = "Hubo un error al registrar los datos!";
                    pnlMensaje.ShowOnPageLoad = true;
                }
                //this.msgboxpanel.Visible = true;
                //MessageBox messageBox = new MessageBox(base.Server.MapPath("msgbox.tpl"));
                //messageBox.SetTitle("Confirmación");
                //messageBox.SetIcon("msg_icon_1.png");
                //messageBox.SetMessage("Cheque para pago de comisiones registrado correctamente ");
                //MessageBoxButton messageBoxButton = new MessageBoxButton("Aceptar");
                //messageBoxButton.SetLocation("wpr_amortizacomis.aspx");
                //messageBoxButton.SetClass("msg_button_class");
                //messageBox.AddButton(messageBoxButton.ReturnObject());
                //this.msgboxpanel.InnerHtml = messageBox.ReturnObject();

            }
            catch
            {
            }
        }


    }
}