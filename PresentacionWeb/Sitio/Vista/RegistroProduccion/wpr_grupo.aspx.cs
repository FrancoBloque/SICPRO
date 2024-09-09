using Common;
using EntidadesClases.ModelSicPro;
using Logica.Consumo;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PresentacionWeb.Sitio.Vista.RegistroProduccion
{
    public partial class wpr_grupo : System.Web.UI.Page
    {
        ConsumoRegistroProd _objConsumoRegistroProd = new ConsumoRegistroProd();
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
                var response = _objConsumoRegistroProd.TablaGrupo();
                Session["LST_GRUPOS"] = response;
                grdGrupos.DataBind();
                ViewState["ID_GRUPO"] = null;
                lblMensajeError.Text = string.Empty;
            }
            catch (SecureExceptions ex)
            {
                throw new SecureExceptions("Error al Generar la Consulta", (Exception)ex);
            }
        }

        protected void grdGrupos_DataBinding(object sender, EventArgs e)
        {
            var lstData = (List<pr_grupo>)Session["LST_GRUPOS"];
            if (lstData != null)
            {
                grdGrupos.DataSource = lstData;
            }
        }

        protected void Selectgrdusuarios_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                var objSender = (ImageButton)sender;
                var id_gru = Convert.ToInt64(objSender.CommandArgument);
                if (id_gru != 0)
                {
                    var response = _objConsumoRegistroProd.ObtenerGrupo(id_gru);
                    ViewState["ID_GRUPO"] = response.id_gru;
                    txtDescripcionGrupo.Text = response.desc_grupo;
                }                            
            }
            catch (SecureExceptions ex)
            {
                throw new SecureExceptions("Error al Generar la Consulta", (Exception)ex);
            }

        }
        protected void btnNuevo_Click(object sender, EventArgs e)
        {
            ViewState["ID_GRUPO"] = null;
            txtDescripcionGrupo.Text = string.Empty;
            lblMensajeError.Text = string.Empty;
        }

        protected void btnguardar_Click(object sender, EventArgs e)
        {
            lblMensajeError.Text = string.Empty;
            try
            {
                if (string.IsNullOrEmpty(txtDescripcionGrupo.Text.ToUpper()))
                {
                    lblMensajeError.Text = "Ingrese la descripcion del grupo";
                    return;
                }

                var idGrupo = Convert.ToDecimal(ViewState["ID_GRUPO"]);

                if (idGrupo == 0)
                {
                    //nuevo
                    var objGrupo = new pr_grupo();
                    objGrupo.desc_grupo = txtDescripcionGrupo.Text.ToUpper();
                    var response = _objConsumoRegistroProd.InsertarGrupo(objGrupo);

                    if (response != null)
                    {
                        lblMensaje.Text = "El Grupo fue registrado correctamente";
                        popUpConfirmacion.ShowOnPageLoad = true;
                    }
                    else
                    {
                        lblMensaje.Text = "El Grupo no pudo ser registrado";
                        popUpConfirmacion.ShowOnPageLoad = true;
                    }
                }
                else
                {
                    //actualizar
                    var objGrupo = new pr_grupo();
                    objGrupo.id_gru = idGrupo;
                    objGrupo.desc_grupo = txtDescripcionGrupo.Text.ToUpper();
                    var response = _objConsumoRegistroProd.ModificarGrupo(objGrupo);

                    if (response != null)
                    {
                        lblMensaje.Text = "El Grupo fue actualizado correctamente";
                        popUpConfirmacion.ShowOnPageLoad = true;
                    }
                    else
                    {
                        lblMensaje.Text = "El Grupo no pudo ser actualizado";
                        popUpConfirmacion.ShowOnPageLoad = true;
                    }
                }                
            }
            catch (SecureExceptions ex)
            {
                throw new SecureExceptions("Error al Generar la Consulta", (Exception)ex);
            }
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            lblMensajeError.Text = string.Empty;
            var idGrupo = Convert.ToDecimal(ViewState["ID_GRUPO"]);
            if (idGrupo == 0)
            {
                lblMensajeError.Text = "No se ha seleccionado ningun grupo";
                return;
            }
            var response = _objConsumoRegistroProd.EliminarGrupo(idGrupo);
            if (response)
            {
                lblMensaje.Text = "El Grupo fue eliminado correctamente";
                popUpConfirmacion.ShowOnPageLoad = true;
            }
            else
            {
                lblMensaje.Text = "El grupo no ha podido ser eliminado";
                popUpConfirmacion.ShowOnPageLoad = true;
            }
            Datos();
        }

    }
}