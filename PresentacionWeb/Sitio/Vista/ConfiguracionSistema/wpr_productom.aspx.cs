using Common;
using DevExpress.XtraPrinting;
using DevExpress.XtraSpreadsheet.Model;
using EntidadesClases.ModelSicPro;
using Logica.Consumo;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
//using info.lundin.Math;

namespace PresentacionWeb.Sitio.Vista.ConfiguracionSistema
{
    public partial class wpr_productom : System.Web.UI.Page
    {
        ConsumoConfiguracionSistema logicaConfiguracion = new ConsumoConfiguracionSistema();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Page.IsPostBack)
                return;
            this.Combos();
        }
        protected void Combos()
        {
            try
            {
                var list = logicaConfiguracion.ObtenerRiesgo();
                this.id_riesgo.DataSource = list;
                this.id_riesgo.DataTextField = "desc_riesgo";
                this.id_riesgo.DataValueField = "id_riesgo";
                this.id_riesgo.DataBind();
                this.id_riesgo.SelectedValue = "-1";

                var listComp = logicaConfiguracion.ObtenerListaCompania();
                this.id_spvs.DataSource = listComp;
                this.id_spvs.DataTextField = "nomraz";
                this.id_spvs.DataValueField = "id_spvs";
                this.id_spvs.DataBind();
                this.id_spvs.SelectedValue = "-1";
            }
            catch (SecureExceptions ex)
            {
                throw new SecureExceptions("Error al Generar la Consulta", (Exception)ex);
            }
        }

        protected void btnsalir_Click(object sender, EventArgs e)
        {
            this.Response.Redirect("~/Default.aspx");
        }

        protected void btnnuevo_Click(object sender, EventArgs e)
        {
            this.Response.Redirect("wpr_producto.aspx");
        }

        protected void id_spvs_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                var list = logicaConfiguracion.ObtenerTablaProducto(id_spvs.SelectedValue);
                this.id_producto.DataSource = list;
                this.id_producto.DataTextField = "desc_prod";
                this.id_producto.DataValueField = "id_producto";
                this.id_producto.DataBind();

                this.id_producto.SelectedIndex = -1;
                this.id_riesgo.SelectedIndex = -1;
                this.comis_riesgo.Text = "0,00";
                this.evaluar.Text = "0,00";
                this.opera.SelectedIndex = 0;
                this.operar.Value = "";
                this.por_cred.Text = "0,00";
                this.plus_neta.Text = "0,00";
            }
            catch (SecureExceptions ex)
            {
                throw new SecureExceptions("Error al Generar la Consulta", (Exception)ex);
            }
        }

        protected void id_producto_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                var idSpvs = logicaConfiguracion.ObtenerFormRiesgo(id_spvs.SelectedValue,long.Parse(id_producto.SelectedValue));
                if (idSpvs.Count > 0)
                {
                    var list = logicaConfiguracion.ObtenerRiesgo();
                    this.id_riesgo.DataSource = list;
                    this.id_riesgo.DataTextField = "desc_riesgo";
                    this.id_riesgo.DataValueField = "id_riesgo";
                    this.id_riesgo.DataBind(); 

                    this.id_riesgo.Text = idSpvs[0].id_riesgo.ToString();
                    this.comis_riesgo.Text = string.Format("{0:n}", double.Parse(idSpvs[0].comis_riesgo.ToString()));
                    this.operar.Value = idSpvs[0].opera.ToString();
                    this.evaluar.Text = string.Format("{0:#,##0.000000;(#,##0.00);0.00}", double.Parse(idSpvs[0].evaluar.ToString()));
                    this.por_cred.Text = string.Format("{0:n}", double.Parse(idSpvs[0].por_cred.ToString()));
                    this.plus_neta.Text = string.Format("{0:n}", double.Parse(idSpvs[0].plus_neta.ToString()));
                    this.form_riesgo2.Text = idSpvs[0].form_riesgo2.ToString();
                    this.form_riesgo1.Text = idSpvs[0].form_riesgo1.ToString();
                }

                if (this.operar.Value == "True")
                    this.opera.SelectedIndex = 2;
                else
                    this.opera.SelectedIndex = 1;
            }
            catch (SecureExceptions ex)
            {
                throw new SecureExceptions("Error al Generar la Consulta", (Exception)ex);
            }
        }

        protected void btnguardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.Hform_riesgo1.Value != "0" && this.Hform_riesgo2.Value != "0")
                {

                    pr_formriesgo item=new pr_formriesgo();
                    item.id_riesgo = this.id_riesgo.SelectedValue;
                    item.id_spvs = this.id_spvs.SelectedValue;

                    bool flag=false;
                    if(this.opera.SelectedValue=="true")
                        flag= true;
                    else
                        flag= false;
                    item.opera = flag;

                    item.evaluar = decimal.Parse(this.evaluar.Text);
                    item.comis_riesgo = decimal.Parse(this.comis_riesgo.Text);
                    item.por_cred = decimal.Parse(this.por_cred.Text);
                    item.plus_neta = decimal.Parse( this.plus_neta.Text);
                    item.form_riesgo1 = this.form_riesgo1.Text.ToUpper();
                    item.form_riesgo2 = this.form_riesgo2.Text.ToUpper();
                    item.id_producto = long.Parse(this.id_producto.SelectedValue);
                    item.id_spvs = this.id_spvs.SelectedValue;

                    logicaConfiguracion.ModificarFormRiesgo(item);

                    lblMensajePop.Text = "Producto Modificado";
                    popUpConfirmacion.ShowOnPageLoad = true;
                }
                else
                {
                    lblerror.Text = "Debe verificar la formula antes de proseguir";
                    popUpValidacion.ShowOnPageLoad = true;
                }
            }
            catch(Exception ex)
            {
                this.lblmensajeGuardar.Text = "Se produjo un error al modificar el producto  "+ex.Message;
            }
        }

        protected void ib1_Click(object sender, EventArgs e)
        {
            System.Data.DataTable table = new System.Data.DataTable();
            this.form_riesgo1.Text = this.form_riesgo1.Text.ToUpper();
            string exp = this.form_riesgo1.Text.ToUpper();
            if (exp.IndexOf("PT") >= 0)
            {
                try
                {
                    this.ib1.ImageUrl = "~/UI/img/lc_okcheckbox.png";
                    exp = exp.Replace("PT", "100");
                    object result = table.Compute(exp, string.Empty);
                    var num = Convert.ToDouble(result);
                    this.lblmensajeGuardar.Text = "La formula esta escrita correctamente."+ exp + "=" + num.ToString();
                    this.Hform_riesgo1.Value = "1";
                }
                catch
                {
                    this.lblmensajeGuardar.Text = "La formula esta escrita incorrectamente. "+ exp;
                    this.ib1.ImageUrl = "~/UI/img/lc_uncheckbox.png";
                }
            }
            else
            {
                this.lblmensajeGuardar.Text = "La Fórmula debe contener la sentencia PT (Prima Total)";
                this.ib1.ImageUrl = "~/UI/img/lc_uncheckbox.png";
            }
        }

        protected void ib2_Click(object sender, EventArgs e)
        {
            System.Data.DataTable table = new System.Data.DataTable();
            this.form_riesgo2.Text = this.form_riesgo2.Text.ToUpper();
            string exp = this.form_riesgo2.Text.ToUpper();
            if (exp.IndexOf("PT") >= 0)
            {
                try
                {
                    this.ib2.ImageUrl = "~/UI/img/lc_okcheckbox.png";
                    exp = exp.Replace("PT", "100");
                    object result = table.Compute(exp, string.Empty);
                    var num = Convert.ToDouble(result);
                    this.lblmensajeGuardar.Text = "La formula esta escrita correctamente." + exp + "=" + num.ToString();
                    this.Hform_riesgo2.Value = "1";
                }
                catch
                {
                    this.lblmensajeGuardar.Text = "La formula esta escrita incorrectamente. " + exp;
                    this.ib2.ImageUrl = "~/UI/img/lc_uncheckbox.png";
                }
            }
            else
            {
                this.lblmensajeGuardar.Text = "La Fórmula debe contener la sentencia PT (Prima Total)";
                this.ib2.ImageUrl = "~/UI/img/lc_uncheckbox.png";
            }
        }
    }
}