using Common;
using EntidadesClases.ModelSicPro;
using Logica.Consumo;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PresentacionWeb.Sitio.Vista.ConfiguracionSistema
{
    public partial class wgr_passnuevo : System.Web.UI.Page
    {
        ConsumoConfiguracionSistema logicaConfiguracion = new ConsumoConfiguracionSistema();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Page.IsPostBack)
                return;
            this.Datos();
        }

        protected void Datos()
        {
            try
            {
                this.id_rol.DataSource = logicaConfiguracion.ListaRoles().OrderBy(x=>x.id_par).ToList();
                this.id_rol.DataTextField = "desc_param";
                this.id_rol.DataValueField = "id_par";
                this.id_rol.DataBind();
                this.id_rol.SelectedValue = "0";
            }
            catch (SecureExceptions ex)
            {
                throw new SecureExceptions("Error al Generar la Consulta", (Exception)ex);
            }

            try
            {
                Session["LST_USUARIOS"] = logicaConfiguracion.ListaPersonaConPass().OrderBy(x => x.nomraz).ToList();
                this.grdusuarios.DataSource = Session["LST_USUARIOS"];
                this.grdusuarios.DataBind();
            }
            catch (SecureExceptions ex)
            {
                throw new SecureExceptions("Error al Generar la Consulta", (Exception)ex);
            }
            try
            {
                Session["LST_PERSONAS"] = logicaConfiguracion.TablaPersona(string.Empty);
                this.grdListaPersona.DataSource = Session["LST_PERSONAS"];
                this.grdListaPersona.DataBind();
            }
            catch (SecureExceptions ex)
            {
                throw new SecureExceptions("Error al Generar la Consulta", (Exception)ex);
            }
        }

        protected void grdusuarios_DataBinding(object sender, EventArgs e)
        {
            var lstData = (List<gr_persona>)Session["LST_USUARIOS"];
            if (lstData != null)
            {
                this.grdusuarios.DataSource = lstData;
            }
        }

        protected void grdListaPersona_DataBinding(object sender, EventArgs e)
        {
            var lstData = (List<gr_persona>)Session["LST_PERSONAS"];
            if (lstData != null)
            {
                this.grdListaPersona.DataSource = lstData;
            }
        }

        protected void pnlCallBackBuscaPersona_Callback(object sender, DevExpress.Web.CallbackEventArgsBase e)
        {
            logicaConfiguracion = new ConsumoConfiguracionSistema();
            Session["LST_PERSONAS"] = logicaConfiguracion.TablaPersona(e.Parameter);
            this.grdListaPersona.DataSource = Session["LST_PERSONAS"];
            this.grdListaPersona.DataBind();
        }

        protected void btnguardar_Click(object sender, EventArgs e)
        {
            try
            {
                bool sw = false;
                string str = "";
                if (string.IsNullOrEmpty(login.Text))
                {
                    str += "Debe registrar un Login(Nick)\n";
                    sw = true;
                }
                if (id_rol.SelectedIndex == -1)
                {
                    str += "Debe seleccionar un Rol\n";
                    sw = true;
                }
                if (string.IsNullOrEmpty(nomraz.Text))
                {
                    str += "Debe seleccionar un Usuario";
                    sw = true;
                }
                if (sw)
                {
                    lblerror.Text = str;
                    popUpValidacion.ShowOnPageLoad = true;
                }
                else
                {
                    decimal idRol = decimal.Parse(id_rol.SelectedValue);
                    logicaConfiguracion.AgregarUsuario(login.Text.ToUpper(), idRol, id_per.Value);
                    lblMensaje.Text = "Usuario Agregado Satisfactoriamente";
                    popUpConfirmacion.ShowOnPageLoad = true;
                }
            }
            catch (SecureExceptions ex)
            {
                throw new SecureExceptions("Error al Generar la Consulta", (Exception)ex);
            }
        }

        protected void btnmodificar_Click(object sender, EventArgs e)
        {
            try
            {
                decimal idRol = decimal.Parse(id_rol.SelectedValue);
                logicaConfiguracion.ModificarUsuario1(login.Text.ToUpper(), idRol, id_per.Value);
                lblMensaje.Text = "Usuario Modificado Satisfactoriamente";
                popUpConfirmacion.ShowOnPageLoad = true;
            }
            catch (SecureExceptions ex)
            {
                throw new SecureExceptions("Error al Generar la Consulta", (Exception)ex);
            }
        }

        protected void Selectgrdusuarios_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                var objSender = (ImageButton)sender;
                gr_pass passOut;
                gr_persona personaOut;
                logicaConfiguracion.ObtenerDatos(objSender.CommandArgument,out personaOut, out passOut);

                this.login.Text = passOut.login;
                this.id_rol.SelectedValue = passOut.id_rol.ToString();
                this.nomraz.Text = personaOut.nomraz;
                this.id_per.Value = passOut.id_per;

                this.btnguardar.Visible = false;
                this.btnmodificar.Visible = true;
            }
            catch (SecureExceptions ex)
            {
                throw new SecureExceptions("Error al Generar la Consulta", (Exception)ex);
            }
        }

        protected void grdListaPersona_SelectionChanged(object sender, EventArgs e)
        {
            var grilla = (DevExpress.Web.ASPxGridView)sender;
            var lista = grilla.GetSelectedFieldValues("id_per");
            var objeto = (string)lista[0];
            this.id_per.Value = objeto.ToString();

            lista = grilla.GetSelectedFieldValues("nomraz");
            objeto = (string)lista[0];
            this.nomraz.Text = objeto.ToString();
            
            this.btnguardar.Visible = true;
            this.btnmodificar.Visible = false;

            popupBusquedaPersona.ShowOnPageLoad = false;
        }
    }
}