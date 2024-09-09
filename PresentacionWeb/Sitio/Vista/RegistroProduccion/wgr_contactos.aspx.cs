using Common;
using DevExpress.Web;
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
    public partial class wgr_contactos : System.Web.UI.Page
    {
        ConsumoRegistroProd _objConsumoRegistroProd = new ConsumoRegistroProd();
        ConsumoValidarProd _objConsumoValidarProd = new ConsumoValidarProd();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                return;
            }

            string idDireccion = base.Request.QueryString["var"];
            string idPersona = base.Request.QueryString["val"];

            ViewState["id_dir"] = idDireccion;
            ViewState["id_per"] = idPersona;

            if (base.Request.QueryString["var"] == "")
            {
                CargaInicial();
                //this.btnmodificar.Visible = false;
                //this.btnnuevo.Visible = false;
                return;
            }
            CargaInicial();
            

            

            //this.id_dir.Value = item;
            //this.id_perclie.Value = str;
            //this.DatosPersona(int.Parse(this.id_dir.Value));
            //this.Combos();
            //this.btnmodificar.Visible = false;
            //this.btnnuevo.Visible = false;

        }

        #region Metodos

        private void CargaInicial()
        {
            var lstLugarContactos = _objConsumoRegistroProd.ObtenerLista(CParametros.LexColumna_id_emis);

            cmb_id_emis.DataSource = lstLugarContactos;
            cmb_id_emis.ValueField = "id_par";
            cmb_id_emis.TextField = "desc_param";
            cmb_id_emis.DataBind();

            var itemLugarContactos = new ListEditItem { Text = "Seleccione...", Value = 0, Selected = true, Index = 0 };
            cmb_id_emis.Items.Add(itemLugarContactos);

            var idPersona = (string)ViewState["id_per"];
            var idDireccion = ViewState["id_dir"] == null? 0 : Convert.ToInt64(ViewState["id_dir"]);
            var objPersona = _objConsumoRegistroProd.ObtenerPersona(idPersona);
            nomraz.Text = objPersona.nomraz;

            var lstDireccionParametro = _objConsumoRegistroProd.ObtenerListaContactosByIdDir(idDireccion);
            //grdContactos.DataSource = lstDireccionParametro;
            
            Session["LST_CONTACTOS"] = lstDireccionParametro;
            grdContactos.DataBind();
        }

        private void Limpiarform()
        {
            nomraz.Text = string.Empty;            
            cmb_id_emis.SelectedItem = cmb_id_emis.Items.FindByValue(0);
            relacion.Text = string.Empty;            
        }

        private void SetFormContactos(long strIdDir, string strIdPer)
        {            
            var objContacto = _objConsumoRegistroProd.ObtenerContactosByIdPerDir(strIdPer, strIdDir);
            relacion.Text = objContacto.relacion;
        }

        #endregion

        #region BuscaPersonas

        protected void btnserper_Click(object sender, EventArgs e)
        {

            var dt = _objConsumoValidarProd.ObtenerTablaPersonasC(nomraz.Text.ToUpper());
            Session["lstPersonas"] = dt;
            grdPersonas.DataSource = dt;
            grdPersonas.DataBind();

            pCPersona.ShowOnPageLoad = true;


        }

        protected void CallBPersona_Callback(object sender, DevExpress.Web.CallbackEventArgsBase e)
        {
            var index = e.Parameter;
            var idPer = grdPersonas.GetRowValues(Convert.ToInt32(index), "id_per").ToString();
            var nombre = grdPersonas.GetRowValues(Convert.ToInt32(index), "nomraz").ToString();
            nomraz.Value = nombre;
            id_per.Value = idPer;

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


        #endregion

        protected void btnDirecciones_Click(object sender, EventArgs e)
        {
            var idPersona = Convert.ToString(ViewState["id_per"]);
            Response.Redirect("~/Sitio/Vista/RegistroProduccion/wgr_direccion.aspx?var=" + idPersona.TrimStart().TrimEnd());
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            lblmensaje.Text = string.Empty;

            var edit = Convert.ToString(ViewState["EDITAR"]);
                var idPersona = (string)ViewState["id_per"];
                var idDireccion = Convert.ToDecimal(ViewState["id_dir"]);
                
                var objContacto = new gr_contacto();
                objContacto.id_per = idPersona;
                objContacto.id_dir = idDireccion;
                objContacto.relacion = relacion.Text.ToUpper();
            objContacto.activo = true;
            if (edit == "EDITAR")
            {
                var responseUpdate = _objConsumoRegistroProd.ModificarContacto(objContacto);
                if (responseUpdate)
                {
                    CargaInicial();
                }
                else
                {
                    lblmensaje.Text = "No se puede Actualizar";
                }
            }
            else
            {       
                var response = _objConsumoRegistroProd.InsertarContacto(objContacto);
                if (response != null)
                {
                    CargaInicial();
                }
                else
                {
                    lblmensaje.Text = "La Persona ya tiene un registro, no se puede registrar";
                }
            }
            ViewState["EDITAR"] = null;
        }

        protected void btnSalir_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Sitio/Vista/Default.aspx");
        }

        protected void grdContactos_DataBinding(object sender, EventArgs e)
        {
            var lstData = (List<OC_DIRECCION_CONTACTO>)Session["LST_CONTACTOS"];

            if (lstData != null)
            {
                grdContactos.DataSource = lstData;
            }
        }

        protected void grdContactos_RowCommand(object sender, ASPxGridViewRowCommandEventArgs e)
        {            
            GridViewDataItemTemplateContainer cont = (GridViewDataItemTemplateContainer)(((ASPxButton)e.CommandSource).NamingContainer);

            var idPersona = grdContactos.GetRowValues(cont.VisibleIndex, "id_per").ToString();

            ViewState["EDITAR"] = "EDITAR";
            object str_id_dir = e.KeyValue;
            ViewState["id_dir"] = Convert.ToInt64(str_id_dir);
            var idPer = idPersona;
            ViewState["id_per"] = idPersona;

            SetFormContactos(Convert.ToInt64(str_id_dir), idPer);
        }
    }
}