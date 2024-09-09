using Common;
using DevExpress.Web.Rendering;
using DevExpress.Web;
using DevExpress.Web.Bootstrap;
using EntidadesClases.ModelSicPro;
using Logica.Consumo;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services.Description;

namespace PresentacionWeb.Sitio.Vista.RegistroProduccion
{
    public partial class wgr_persona1 : System.Web.UI.Page
    {
        ConsumoRegistroProd _objConsumoRegistroProd = new ConsumoRegistroProd();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                return;
            }
            
            if (string.IsNullOrEmpty(base.Request.QueryString["var"]))
            {
                CargaInicial();
                //Limpiarform();
                this.btnGuardar.Visible = true;
                return;
            }
            string itemIdPer = base.Request.QueryString["var"];
            //this.id_per.Value = item;
            CargaInicial();
            SetFormDatosPersona(itemIdPer);
            //this.DireccionPersona();
            ViewState["id_per"] = itemIdPer;
        }

        #region Metodos

        private void CargaInicial()
        {
            btnDirecciones.Visible = false;
            btnNuevo.Visible = false;
            var lstSucursales = _objConsumoRegistroProd.ObtenerLista(CParametros.LexColumna_id_suc);

            cmb_id_suc.DataSource = lstSucursales;
            cmb_id_suc.ValueField = "id_par";
            cmb_id_suc.TextField = "desc_param";            
            cmb_id_suc.DataBind();
            var itemSeleccioneSucursal = new BootstrapListEditItem { Text = "Seleccione...", Value = "", Selected = true, Index = 0 };
            cmb_id_suc.Items.Add(itemSeleccioneSucursal);

            var lstTipoPersona = _objConsumoRegistroProd.ObtenerLista(CParametros.LexColumna_id_tper);

            cmb_tper.DataSource = lstTipoPersona;
            cmb_tper.ValueField = "id_par";
            cmb_tper.TextField = "desc_param";            
            cmb_tper.DataBind();
            var itemSeleccioneTipoPersona = new BootstrapListEditItem { Text = "Seleccione...", Value = "", Selected = true, Index = 0};
            cmb_tper.Items.Add(itemSeleccioneTipoPersona);

            var lstSalutacionPersonal = _objConsumoRegistroProd.ObtenerLista(CParametros.LexColumna_id_sal);

            cmb_id_sal.DataSource = lstSalutacionPersonal;
            cmb_id_sal.ValueField = "id_par";
            cmb_id_sal.TextField = "desc_param";
            cmb_id_sal.DataBind();
            var itemSeleccioneSalPersonal = new BootstrapListEditItem { Text = "Seleccione...", Value = "", Selected = true, Index = 0 };
            cmb_id_sal.Items.Add(itemSeleccioneSalPersonal);

            var lstTipoRol = _objConsumoRegistroProd.ObtenerLista(CParametros.LexColumna_id_rol);

            cmb_id_rol.DataSource = lstTipoRol;
            cmb_id_rol.ValueField = "id_par";
            cmb_id_rol.TextField = "desc_param";
            cmb_id_rol.DataBind();
            var itemSeleccioneTipoRol = new BootstrapListEditItem { Text = "Seleccione...", Value = "", Selected = true, Index = 0 };
            cmb_id_rol.Items.Add(itemSeleccioneTipoRol);

            var lstTipoDocumento = _objConsumoRegistroProd.ObtenerLista(CParametros.LexColumna_id_tdoc);

            cmb_tipodoc.DataSource = lstTipoDocumento;
            cmb_tipodoc.ValueField = "id_par";
            cmb_tipodoc.TextField = "desc_param";
            cmb_tipodoc.DataBind();
            var itemSeleccioneTipoDocumento = new BootstrapListEditItem { Text = "Seleccione...", Value = "", Selected = true, Index = 0 };
            cmb_tipodoc.Items.Add(itemSeleccioneTipoDocumento);

            var lstEmisionDocumento = _objConsumoRegistroProd.ObtenerLista(CParametros.LexColumna_id_emis);

            cmb_id_emis.DataSource = lstEmisionDocumento;
            cmb_id_emis.ValueField = "id_par";
            cmb_id_emis.TextField = "desc_param";
            cmb_id_emis.DataBind();
            var itemSeleccioneEmisionDocumento = new BootstrapListEditItem { Text = "Seleccione...", Value = "", Selected = true, Index = 0 };
            cmb_id_emis.Items.Add(itemSeleccioneEmisionDocumento);

            var lstPersonas = _objConsumoRegistroProd.ObtenerListaPersona();
            grdPersonas.DataSource = lstPersonas;
            Session["LST_PERSONAS"] = lstPersonas;
            grdPersonas.DataBind();
           
        }

        private void LimpiarFormulario()
        {
            this.id_per.Text = string.Empty;
            this.nomraz.Text = string.Empty;
            this.fechaNacimiento.Text = string.Empty;
            this.nit_fac.Text = string.Empty;
            
            cmb_id_suc.SelectedItem = cmb_id_suc.Items.FindByValue(0);            
            cmb_id_sal.SelectedItem = cmb_id_sal.Items.FindByValue(Convert.ToInt64(0));
            cmb_tipodoc.SelectedItem = cmb_tipodoc.Items.FindByValue(Convert.ToInt64(0));
            cmb_tper.SelectedItem = cmb_tper.Items.FindByValue(Convert.ToInt64(0));
            cmb_id_rol.SelectedItem = cmb_id_rol.Items.FindByValue(Convert.ToInt64(0));
            cmb_id_emis.SelectedItem = cmb_id_emis.Items.FindByValue(Convert.ToInt64(0));

            btnDirecciones.Visible = false;
            btnNuevo.Visible = false;
        }

        private void SetFormDatosPersona(string strIdPer)
        {
            var objPersona = _objConsumoRegistroProd.ObtenerPersona(strIdPer);
            if (objPersona == null)
            {
                return;
            }
            id_per.Text = objPersona.id_per;
            nomraz.Text = objPersona.nomraz;

            var itemSucursal = cmb_id_suc.Items.FindByValue(objPersona.id_suc);
            if (itemSucursal != null)
            {
                cmb_id_suc.SelectedItem = itemSucursal;
            }

            var itemTipoPersona = cmb_tper.Items.FindByValue(objPersona.id_tper);
            if (itemTipoPersona != null)
            {
                cmb_tper.SelectedItem = itemTipoPersona;
            }

            fechaNacimiento.Date = objPersona.fechaaniv.Value;

            var itemSal = cmb_id_sal.Items.FindByValue(objPersona.id_sal);
            if (itemSal != null)
            {
                cmb_id_sal.SelectedItem = itemSal;
            }

            var itemTipoRol = cmb_id_rol.Items.FindByValue(objPersona.id_rol);
            if (itemTipoRol != null)
            {
                cmb_id_rol.SelectedItem = itemTipoRol;
            }

            var itemTipoDoc = cmb_tipodoc.Items.FindByValue(objPersona.id_tdoc);
            if (itemTipoDoc != null)
            {
                cmb_tipodoc.SelectedItem = itemTipoDoc;
            }

            var itemEmis = cmb_id_emis.Items.FindByValue(objPersona.id_emis);
            if (itemEmis != null)
            {
                cmb_id_emis.SelectedItem = itemEmis;
            }

            nit_fac.Text = objPersona.nit_fac;
        }
        #endregion

        protected void btnDirecciones_Click(object sender, EventArgs e)
        {
            //Response.Redirect("~/Sitio/Vista/RegistroProduccion/wgr_direccion.aspx", false); 
            //?var=2141515

            Response.Redirect("~/Sitio/Vista/RegistroProduccion/wgr_direccion.aspx?var=" + id_per.Text.TrimStart().TrimEnd());
        }

        protected void btnNuevo_Click(object sender, EventArgs e)
        {
            LimpiarFormulario();
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            lblmensaje.Text = string.Empty;
            var itemIdPer = Convert.ToString(ViewState["id_per"]);
            if (!string.IsNullOrEmpty(itemIdPer))
            {
                try
                {
                    gr_persona grPersona = new gr_persona()
                    {
                        id_per = id_per.Text.ToUpper(),
                        nomraz = nomraz.Text.ToUpper(),
                        id_tper =  Convert.ToInt64(cmb_tper.SelectedItem.Value),
                        fechaaniv = fechaNacimiento.Date,
                        id_sal = Convert.ToInt64(cmb_id_sal.SelectedItem.Value),
                        id_rol = Convert.ToInt64(cmb_id_rol.SelectedItem.Value),
                        id_tdoc = Convert.ToInt64(cmb_tipodoc.SelectedItem.Value),
                        id_emis = Convert.ToInt64(cmb_id_emis.SelectedItem.Value),
                        id_suc = Convert.ToInt32(cmb_id_suc.SelectedItem.Value),
                        nit_fac = nit_fac.Text.ToUpper(),
                        //lblmensaje = this.lblmensaje
                    };

                    var actualizado = _objConsumoRegistroProd.ModificarPersona(grPersona);

                    if (!actualizado)
                    {
                        this.lblmensaje.Text = "Se genero un error al intentar actualizar el registro";
                    }
                    else
                    {
                        this.lblmensaje.Text = "Registro Actualizado";
                    }
                    //if (!grPersona.ModificarPersona(this.hid_per.Value.ToString()))
                    //{
                    //    this.lblmensaje.Text = "Se genero un error al intentar actualizar el registro";
                    //    this.msgboxpanel.Visible = true;
                    //    MessageBox messageBox = new MessageBox(base.Server.MapPath("msgbox1.tpl"));
                    //    messageBox.SetTitle("Confirmación");
                    //    messageBox.SetIcon("msg_icon_2.png");
                    //    messageBox.SetMessage("<p style='color:#990000; font-weight:bold'>Se ha producido un error al actualizar los datos del registro</p>");
                    //    messageBox.SetOKButton("msg_button_class1");
                    //    this.msgboxpanel.InnerHtml = messageBox.ReturnObject();
                    //}
                    //else
                    //{
                    //this.lblmensaje.Text = "Registro Actualizado";
                    //this.msgboxpanel.Visible = true;
                    //MessageBox messageBox1 = new MessageBox(base.Server.MapPath("msgbox.tpl"));
                    //messageBox1.SetTitle("Confirmación");
                    //messageBox1.SetIcon("msg_icon_1.png");
                    //messageBox1.SetMessage("<p style='color:##003366; font-weight:bold'>Se ha actualizado correctamente los valores del registro</p>");
                    //messageBox1.SetOKButton("msg_button_class");
                    //this.msgboxpanel.InnerHtml = messageBox1.ReturnObject();
                    //}
                }
                catch
                {
                }
            }

            else
            {
                try
                {
                    gr_persona grPersona = new gr_persona()
                    {
                        id_per = id_per.Text.ToUpper(),
                        nomraz = nomraz.Text.ToUpper(),
                        id_tper = Convert.ToInt64(cmb_tper.SelectedItem.Value),
                        fechaaniv = fechaNacimiento.Date,
                        id_sal = Convert.ToInt64(cmb_id_sal.SelectedItem.Value),
                        id_rol = Convert.ToInt64(cmb_id_rol.SelectedItem.Value),
                        id_tdoc = Convert.ToInt64(cmb_tipodoc.SelectedItem.Value),
                        id_emis = Convert.ToInt64(cmb_id_emis.SelectedItem.Value),
                        id_suc = Convert.ToInt32(cmb_id_suc.SelectedItem.Value),
                        nit_fac = nit_fac.Text.ToUpper(),
                        //lblmensaje = this.lblmensaje
                    };

                    var actualizado = _objConsumoRegistroProd.InsertarPersona(grPersona);

                    if (actualizado == null)
                    {
                        this.lblmensaje.Text = "Se genero un error al intentar actualizar el registro";
                    }
                    else
                    {
                        this.lblmensaje.Text = "Registro Actualizado";
                        Response.Redirect("~/Sitio/Vista/RegistroProduccion/wgr_direccion.aspx?var=" + id_per.Text.TrimStart().TrimEnd());                        
                    }
                    //string str = "";
                    //bool flag = false;
                    //valid _valid = new valid();
                    //if ((this.hid_per.Value == "") | this.hid_per.Value == null)
                    //{
                    //    if (this.id_per.Text.Trim() == "")
                    //    {
                    //        str = string.Concat(str, "<br />Debe Registrar un valor para documento de identidad");
                    //        flag = true;
                    //    }
                    //    if (this.nomraz.Text.Trim() == "")
                    //    {
                    //        str = string.Concat(str, "<br />Debe Registrar un valor para Nombre o Razón Social");
                    //        flag = true;
                    //    }
                    //    if (this.id_suc.SelectedValue.ToString() == "0")
                    //    {
                    //        str = string.Concat(str, "<br /> Debe seleccionar un valor para sucursal");
                    //        flag = true;
                    //    }
                    //    if (this.id_tper.SelectedValue.ToString() == "0")
                    //    {
                    //        str = string.Concat(str, "<br /> Debe seleccionar un tipo de persona (Natural, Juridica u ONG)");
                    //        flag = true;
                    //    }
                    //    if (this.fechaaniv.Text.Length == 2 || !_valid.fv(this.fechaaniv.Text))
                    //    {
                    //        str = string.Concat(str, "<br /> Debe Registrar una fecha en formato correcto");
                    //        flag = true;
                    //    }
                    //    else if (DateTime.Parse(this.fechaaniv.Text) >= DateTime.Today)
                    //    {
                    //        str = string.Concat(str, "<br /> La fecha registrada no debe ser mayor o igual a la fecha actual");
                    //        flag = true;
                    //    }
                    //    if (this.id_sal.SelectedValue.ToString() == "0")
                    //    {
                    //        str = string.Concat(str, "<br /> Debe seleccionar un tipo de salutación");
                    //        flag = true;
                    //    }
                    //    if (this.id_rol.SelectedValue.ToString() == "0")
                    //    {
                    //        str = string.Concat(str, "<br /> Debe seleccionar un rol para la persona");
                    //        flag = true;
                    //    }
                    //    if (this.id_tdoc.SelectedValue.ToString() == "0")
                    //    {
                    //        str = string.Concat(str, "<br />Debe seleccionar un tipo de documento de identidad");
                    //        flag = true;
                    //    }
                    //    if (this.id_emis.SelectedValue.ToString() == "0")
                    //    {
                    //        str = string.Concat(str, "<br /> Debe seleccionar un lugar de emisión para el documento de identidad");
                    //        flag = true;
                    //    }
                    //    if (flag)
                    //    {
                    //        this.msgboxpanel.Visible = true;
                    //        MessageBox messageBox = new MessageBox(base.Server.MapPath("msgbox1.tpl"));
                    //        messageBox.SetTitle("Validación de Datos");
                    //        messageBox.SetIcon("msg_icon_2.png");
                    //        messageBox.SetMessage(string.Concat("<span>Los siguientes valores deben ser verificados antes de proseguir<br /></span><p style='color:#990000; font-weight:bold'>", str, "</p>"));
                    //        messageBox.SetOKButton("msg_button_class1");
                    //        this.msgboxpanel.InnerHtml = messageBox.ReturnObject();
                    //        flag = false;
                    //    }
                    //    if (this.id_per.Text.Length != 0 && this.nomraz.Text.Length != 0 && this.id_tper.SelectedValue.ToString() != "0" && this.fechaaniv.Text.Length > 2 && this.id_sal.SelectedValue.ToString() != "0" && this.id_rol.SelectedValue.ToString() != "0" && this.id_tdoc.SelectedValue.ToString() != "0" && this.id_emis.SelectedValue.ToString() != "0" && this.id_suc.SelectedValue.ToString() != "0" && _valid.fv(this.fechaaniv.Text) && DateTime.Parse(this.fechaaniv.Text) < DateTime.Today)
                    //    {
                    //        gr_persona grPersona = new gr_persona()
                    //        {
                    //            id_per = this.id_per,
                    //            nomraz = this.nomraz,
                    //            id_tper = this.id_tper,
                    //            fechaaniv = this.fechaaniv,
                    //            id_sal = this.id_sal,
                    //            id_rol = this.id_rol,
                    //            id_tdoc = this.id_tdoc,
                    //            id_emis = this.id_emis,
                    //            nit_fac = this.nit_fac,
                    //            id_suc = this.id_suc
                    //        };
                    //        grPersona.InsertarPersona();
                    //        base.Response.Redirect(string.Concat("~/wgr_direccion.aspx?var=", this.id_per.Text));
                    //    }
                    //}
                }
                catch
                {
                }
            }
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            var strIdPer = id_per.Text;
            if (string.IsNullOrEmpty(strIdPer))
            {
                lblmensaje.Text = "Por favor introduzca el numero de documento";
                return;
            }

            var objPersona = _objConsumoRegistroProd.ObtenerPersona(strIdPer);

            if (objPersona!= null)
            {
                SetFormDatosPersona(objPersona.id_per);

                //this.id_per.Text = objPersona.id_per;
                //this.nomraz.Text = objPersona.nomraz;
                //this.fechaNacimiento.Date = objPersona.fechaaniv.Value;
                //this.nit_fac.Text = objPersona.nit_fac;
                ////this.RTipoPersona(this.id_per.Text);
                ////this.RSalutacionPersona(this.id_per.Text);
                ////this.id_rol.SelectedValue = dtgeneral.Rows[0]["id_rol"].ToString();
                ////this.RTDocPersona(this.id_per.Text);
                ////this.RSucPersona(this.id_per.Text);
                ////this.REmisionPersona(this.id_per.Text);

                lblmensaje.Text = string.Empty;
                btnNuevo.Visible = true;
                btnDirecciones.Visible = true;
            }
            else
            {
                lblmensaje.Text = "Su busqueda no retorno resultados";
            }
        }

        protected void btnSalir_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Sitio/Vista/Default.aspx");
        }

        protected void grdPersonas_DataBinding(object sender, EventArgs e)
        {
            var lstData = (List<gr_persona>)Session["LST_PERSONAS"];

            if (lstData != null)
            {
                grdPersonas.DataSource = lstData;
            }
        }

        //protected void Select_Click(object sender, EventArgs e)
        //{
        //    //LinkButton link = sender as LinkButton;
        //    //if (link == null) return;
        //    //GridViewDataItemTemplateContainer container = link.Parent as GridViewDataItemTemplateContainer;
        //    //if (container == null) return;
        //    //GridViewTableDataCell dataCell = container.Parent as GridViewTableDataCell;
        //    //if (dataCell == null) return;
        //    //GridViewTableDataRow row = dataCell.Parent as GridViewTableDataRow;
        //    //if (row == null) return;
        //    //var gridview = (ASPxGridView)row.Parent.Parent.Parent.Parent.Parent.Parent;
        //    //gridview.Selection.UnselectAll();
        //    //gridview.Selection.SelectRow(row.VisibleIndex);
        //}

        protected void gv_RowCommand(object sender, ASPxGridViewRowCommandEventArgs e)
        {
            ASPxGridView grid = (ASPxGridView)sender;
            object str_id_per = e.KeyValue;

            SetFormDatosPersona(Convert.ToString(str_id_per).TrimStart().TrimEnd());            

            //https://supportcenter.devexpress.com/Ticket/Details/Q494995/fields-value-in-aspxgridview-on-row-command
            //https://docs.devexpress.com/AspNet/17651/components/grid-view/concepts/filter-data/search-panel
        }

        protected void Grid_SearchPanelEditorCreate(object sender, DevExpress.Web.ASPxGridViewSearchPanelEditorCreateEventArgs e)
        {
            //e.Value = "";
            var t = e.Value;
            //e.EditorProperties = new SpinEditProperties();
        }

        protected void grdPersonas_PageIndexChanged(object sender, EventArgs e)
        {
            int currentPage = grdPersonas.PageIndex + 1;
        }

    }
}