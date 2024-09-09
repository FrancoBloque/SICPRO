using Common;
using EntidadesClases.ModelSicPro;
using Logica.Consumo;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PresentacionWeb.Sitio.Vista.ConfiguracionSistema
{
    public partial class wpr_producto : System.Web.UI.Page
    {
        ConsumoConfiguracionSistema logicaConfiguracion = new ConsumoConfiguracionSistema();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Page.IsPostBack)
                return;
            this.ListProducto();
        }
        protected void ListProducto()
        {
            try
            {
                PopupBuscadorProducto(string.Empty);
            }
            catch (SecureExceptions ex)
            {
                throw new SecureExceptions("Error al Generar la Consulta", (Exception)ex);
            }
        }
        protected void grdListaProducto_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                var grilla = (DevExpress.Web.ASPxGridView)sender;
                var lista = grilla.GetSelectedFieldValues("id_producto");
                if (lista.Count == 0)
                    return;
                var objeto = lista[0].ToString();
                id_producto.Value = objeto.ToString();

                pr_producto item = logicaConfiguracion.ObtenerProducto(long.Parse(id_producto.Value));
                this.id_producto.Value = item.id_producto.ToString();
                this.desc_producto.Text = item.desc_prod;
                this.abrev_prod.Text = item.abrev_prod;

                popupBusquedaProducto.ShowOnPageLoad = false;
                this.btnguardar.Visible = false;
                panelControles();
            }
            catch(Exception ex)
            {
                this.lblmensajeA.Text = "Error al Generar la Transacción";
                throw new SecureExceptions("Error al Generar la Consulta", (Exception)ex);
            }
        }
        protected void pnlCallBackBuscaProducto_Callback(object sender, DevExpress.Web.CallbackEventArgsBase e)
        {
            PopupBuscadorProducto(e.Parameter.ToString());
        }
        protected void PopupBuscadorProducto(string valorBusqueda)
        {
            try
            {
                var listProducto = logicaConfiguracion.TablaProductoP(valorBusqueda);
                Session["LST_PRODUCTO"] = listProducto;
                this.grdListaProducto.DataSource = listProducto;
                this.grdListaProducto.DataBind();
            }
            catch (SecureExceptions ex)
            {
                throw new SecureExceptions("Error al Generar la Consulta", (Exception)ex);
            }
        }
        protected void grdListaProducto_DataBinding(object sender, EventArgs e)
        {
            var lstData = (List<pr_producto>)Session["LST_PRODUCTO"];
            if (lstData != null)
            {
                this.grdListaProducto.DataSource = lstData;
            }
        }
        private void panelControles()
        {
            pnlControles.Visible = true;

            logicaConfiguracion = new ConsumoConfiguracionSistema();
            this.id_riesgo.DataSource = logicaConfiguracion.ObtenerRiesgo();
            this.id_riesgo.DataTextField = "desc_riesgo";
            this.id_riesgo.DataValueField = "id_riesgo";
            this.id_riesgo.DataBind();
            this.id_riesgo.SelectedValue = "-1";
            List<v_pr_cias_resum> listPer = logicaConfiguracion.ObtenerListaCompania();
            this.id_spvs.DataSource = listPer;
            this.id_spvs.DataTextField = "nomraz";
            this.id_spvs.DataValueField = "id_spvs";
            this.id_spvs.DataBind();
            this.id_spvs.SelectedValue = "-1";

            //List<gr_compania> listCompania;
            //List<v_pr_cias_resum> listPer = logicaConfiguracion.ObtenerListaCompania();

            //List<gridCompania> listGrilla = new List<gridCompania>();
            //for (int i = 0; i < listPer.Count; i++)
            //{
            //    listGrilla.Add(new gridCompania
            //    {
            //        nomraz = listPer[i].nomraz,
            //        id_spvs = listCompania[i].id_spvs,
            //        abrev = listCompania[i].abrev_cia
            //    });
            //}

            //this.id_riesgo.DataSource = (object)new pr_producto().ObtenerRiesgo();
            //this.id_riesgo.DataTextField = "desc_riesgo";
            //this.id_riesgo.DataValueField = "id_riesgo";
            //this.id_riesgo.DataBind();

            //new gr_compania() { ddlgeneral = this.id_spvs }.ObtenerListaCompania();

            //this.id_producto.Value = "";
            //string msg_message = new pr_producto()
            //{
            //    a = this.a,
            //    b = this.b
            //}.TablaProductoP(this.desc_producto.Text.ToUpper());
            //this.msgboxpanel.Visible = true;
            //MessageBox messageBox = new MessageBox(this.Server.MapPath("msgboxprod.tpl"));
            //messageBox.SetTitle("Busqueda de Productos por Compañia");
            //messageBox.SetIcon("search_user.png");
            //messageBox.SetMessage(msg_message);
            //messageBox.SetOKButton("msg_button_class");
            //this.msgboxpanel.InnerHtml = messageBox.ReturnObject();
            //this.a.Value = "0";
            //this.b.Value = "10";
            //this.id_producto.Value = "";
            //logicaConfiguracion.ta
            //string msg_message = new pr_producto()
            //{
            //    a = this.a,
            //    b = this.b
            //}.TablaProductoP(this.desc_producto.Text.ToUpper());


            //var listProducto = logicaConfiguracion.TablaProductoP(this.desc_producto.Text.ToUpper());
            //Session["LST_PRODUCTO"] = listProducto;
            //this.grdListaProducto.DataSource = listProducto;
            //this.grdListaProducto.DataBind();




        }
        protected void btnguardar_Click(object sender, EventArgs e)
        {
            try
            {
                bool sw = false;
                string str = "";
                if (this.desc_producto.Text.Trim().Length == 0)
                {
                    str += "Debe Registrar un Nombre de Producto\n";
                    sw = true;
                }
                if (this.desc_producto.Text.Trim().Length > 50)
                {
                    str += "No Debe Exceder De 50 Letras el Nombre de Producto\n";
                    sw = true;
                }
                if (this.abrev_prod.Text.Trim().Length == 0)
                {
                    str += "Debe Registrar una Abreviación de Producto\n";
                    sw = true;
                }
                if (this.abrev_prod.Text.Trim().Length > 5)
                {
                    str += "La abreviacion es muy larga, ingresar solo 5 caracteres";
                    sw = true;
                }
                if (sw)
                {
                    lblerror.Text = str;
                    popUpValidacion.ShowOnPageLoad = true;
                }
                else
                {
                    bool resp = logicaConfiguracion.ExisteProducto(this.desc_producto.Text, this.abrev_prod.Text);
                    if (resp)
                    {
                        lblerror.Text = "Debe Verificar el Nombre del Producto y la Abreviación del Mismo\nEl Producto ya Esta Registrado";
                        popUpValidacion.ShowOnPageLoad = true;
                    }
                    else
                    {
                        logicaConfiguracion.InsertarProducto(this.desc_producto.Text, this.abrev_prod.Text);
                        this.lblmensajeA.Text = "Se Creo El Producto Correctamente";
                    }
                }
            }
            catch
            {
                this.lblmensajeA.Text = "Error al Generar la Transacción";
            }
        }
        //protected void Buscar()
        //{
        //    try
        //    {
        //        pr_producto item = logicaConfiguracion.ObtenerProducto(long.Parse(id_producto.Value));
        //        this.id_producto.Value = item.id_producto.ToString();
        //        this.desc_producto.Text = item.desc_prod;
        //        this.abrev_prod.Text = item.abrev_prod;
        //    }
        //    catch (SecureExceptions ex)
        //    {
        //        throw new SecureExceptions("Error al Generar la Consulta", (Exception)ex);
        //    }
        //}

        protected void btnNuevo_Click(object sender, EventArgs e)
        {
            this.Response.Redirect("wpr_producto.aspx");
        }

        protected void btnSalir_Click(object sender, EventArgs e)
        {
            this.Response.Redirect("~/Default.aspx");
        }

        protected void btnGuardarPanel_Click(object sender, EventArgs e)
        {
            try
            {
                bool sw = true;
                string error = string.Empty;
                if (this.desc_producto.Text.Trim() == string.Empty)
                {
                    error = error + "La descripcion del producto esta vacia\n";
                    sw = false;
                }
                if (this.abrev_prod.Text.Trim() == string.Empty)
                {
                    error = error + "La abreviacion de producto esta vacia\n";
                    sw = false;
                }
                if (this.id_riesgo.SelectedValue == string.Empty)
                {
                    error = error + "El id de riesgo esta vacia\n";
                    sw = false;
                }
                if (this.id_spvs.SelectedValue == string.Empty)
                {
                    error = error + "El id de compania esta vacia\n";
                    sw = false;
                }
                if (this.operador.SelectedValue == string.Empty || this.operador.SelectedValue== "!--")
                {
                    error = error + "El operador de formula esta vacio o un valor invalido\n";
                    sw = false;
                }
                if (this.evaluar.Text.Trim() == string.Empty)
                {
                    error = error + "El campo evaluar al lado del operador esta vacio\n";
                    sw = false;
                }
                if (this.comis_riesgo.Text.Trim() == string.Empty)
                {
                    error = error + "La comision de riesgo esta vacia\n";
                    sw = false;
                }
                if (this.por_cred.Text.Trim() == string.Empty)
                {
                    error = error + "El campo por a cred esta vacio\n";
                    sw = false;
                }
                if (this.plus_neta.Text.Trim() == string.Empty)
                {
                    error = error + "El campo plus neta esta vacio\n";
                    sw = false;
                }
                if (!sw)
                {
                    lblerror.Text = error;
                    popUpValidacion.ShowOnPageLoad = true;
                    return;
                }
                logicaConfiguracion.InsertarFormRiesgo( 
                                                        this.desc_producto.Text.Trim().ToUpper()
                                                        , this.abrev_prod.Text.Trim().ToUpper()
                                                        , this.id_riesgo.SelectedValue
                                                        , this.id_spvs.SelectedValue
                                                        , bool.Parse(this.operador.SelectedItem.Text)
                                                        , decimal.Parse(this.evaluar.Text.Trim())
                                                        , decimal.Parse(this.comis_riesgo.Text.Trim())
                                                        , decimal.Parse(this.por_cred.Text.Trim())
                                                        , decimal.Parse(this.plus_neta.Text.Trim())
                                                      );
                lblMensaje.Text = "Producto Registrado";
                popUpConfirmacion.ShowOnPageLoad = true; 
            }
            catch (SecureExceptions ex)
            {
                throw new SecureExceptions("Error al Generar la Consulta", (Exception)ex);
            }
        }
    }

    public class gridCompania
    {
        public string id_spvs { get; set; }
        public string nomraz { get; set; }
        public string abrev { get; set; }
    }
}