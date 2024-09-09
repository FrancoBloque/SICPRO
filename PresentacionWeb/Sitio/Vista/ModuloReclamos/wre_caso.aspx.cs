using Common;
using EntidadesClases.ModelSicPro;
using Logica.Consumo;
using PresentacionWeb.Lib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PresentacionWeb.Sitio.Vista.ModuloReclamos
{
    public partial class wre_caso : System.Web.UI.Page
    {
        ConsumoReclamos logicaReclamos = new ConsumoReclamos();
        ConsumoConfiguracionSistema logicaConfiguracion = new ConsumoConfiguracionSistema();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Page.IsPostBack)
                return;
            this.id_suc.Focus();
            this.id_perurc.DataSource = logicaReclamos.Persona(35);
            this.id_perurc.DataTextField = "nomraz";
            this.id_perurc.DataValueField = "id_per";
            this.id_perurc.DataBind();
            this.id_perurc.SelectedValue = "0";

            this.id_div.DataSource = logicaReclamos.ParametroA("id_div");
            this.id_div.DataTextField = "abrev_param";
            this.id_div.DataValueField = "id_par";
            this.id_div.DataBind();
            this.id_div.SelectedValue = "0";

            this.id_suc.DataSource = logicaReclamos.Parametro("id_suc");
            this.id_suc.DataTextField = "desc_param";
            this.id_suc.DataValueField = "id_par";
            this.id_suc.DataBind();
            this.id_suc.SelectedValue = "0";

            this.id_rolate.DataSource = logicaReclamos.Parametro("id_rolate");
            this.id_rolate.DataTextField = "desc_param";
            this.id_rolate.DataValueField = "id_par";
            this.id_rolate.DataBind();
            this.id_rolate.SelectedValue = "0";

            this.id_uniobj.DataSource = logicaReclamos.Parametro("id_uniobj");
            this.id_uniobj.DataTextField = "desc_param";
            this.id_uniobj.DataValueField = "id_par";
            this.id_uniobj.DataBind();
            this.id_uniobj.SelectedValue = "0";

            this.anio_caso.DataSource = logicaReclamos.anio_list();
            this.anio_caso.DataTextField = "desc_param";
            this.anio_caso.DataValueField = "valor_param";
            this.anio_caso.DataBind();
            this.anio_caso.SelectedValue = "0";

            Session["LST_PERSONAS"] = logicaConfiguracion.TablaPersona(string.Empty);
            this.grdListaPersona.DataSource = Session["LST_PERSONAS"];
            this.grdListaPersona.DataBind();
        }

        protected void btnsalir_Click(object sender, EventArgs e)
        {
            this.Response.Redirect("~/Default.aspx");
        }

        protected void btnguardar_Click(object sender, EventArgs e)
        {
            bool flag = false;
            string str = "";
            //valid valid = new valid();
            try
            {
                if (this.id_suc.SelectedValue == "0")
                {
                    str += "Debe Seleccionar un valor para sucursal \n ";
                    flag = true;
                }
                if (this.id_per.Value == "" || this.id_per.Value == null || this.nomraz.Text == "" || this.nomraz == null)
                {
                    str += "Debe Seleccionar un cliente \n ";
                    flag = true;
                }
                if (this.id_poliza.SelectedValue == "-1")
                {
                    str += "Debe Seleccionar un número de Póliza \n ";
                    flag = true;
                }
                if (this.id_perurc.SelectedValue == "0")
                {
                    str += "Debe Seleccionar un inspector de reclamos \n ";
                    flag = true;
                }
                if (this.per_cia.Text == "")
                {
                    str += "Debe registrar un inspector de compañía \n ";
                    flag = true;
                }
                if (this.id_rolate.SelectedValue == "0")
                {
                    str += "Debe Seleccionar un valor para tipo de atención \n ";
                    flag = true;
                }
                if (this.per_aten.Text == "")
                {
                    str += "Debe Seleccionar una persona externa de atención \n ";
                    flag = true;
                }
                if (this.direccion.Text == "")
                {
                    str += "Debe Registrar una dirección de atención externa \n ";
                    flag = true;
                }
                if (this.id_uniobj.SelectedValue == "0")
                {
                    str += "Debe Seleccionar un tipo de Identificador único \n ";
                    flag = true;
                }
                if (this.uniobj.Text == "" || this.uniobj.Text == null)
                {
                    str += "Debe registrar un identificador unico \n ";
                    flag = true;
                }
                if (this.mat_aseg.Text == "" || this.mat_aseg.Text == null)
                {
                    str += "Debe registrar una materia asegurada \n ";
                    flag = true;
                }
                if (this.fc_denuncia.Text.Length < 10)
                {
                    str += "Debe verificar el formato de la fecha de denuncia \n ";
                    flag = true;
                }
                //else if (!valid.fv(this.fc_denuncia.Text))
                //{
                //    str += "Debe verificar el formato de la fecha de denuncia \n ";
                //    flag = true;
                //}
                if (this.fc_incidente.Text.Length < 10)
                {
                    str += "Debe verificar el formato de la fecha de incidente \n ";
                    flag = true;
                }
                //else if (!valid.fv(this.fc_incidente.Text))
                //{
                //    str += "Debe verificar el formato de la fecha de incidente \n ";
                //    flag = true;
                //}
                if (this.circunstancia.Text == "" || this.circunstancia.Text == null)
                {
                    str += "Debe registrar las circunstancias del incidente \n ";
                    flag = true;
                }
                if (this.lugar_siniestro.Text == "" || this.lugar_siniestro.Text == null)
                {
                    str += "Debe registrar el lugar del incidente \n ";
                    flag = true;
                }
                if (this.denunciante.Text == "" || this.denunciante.Text == null)
                {
                    str += "Debe registrar un nombe de denunciante \n ";
                    flag = true;
                }
                if (this.reladenun.Text == "" || this.reladenun.Text == null)
                {
                    str += "Debe registrar la relación del denunciante \n ";
                    flag = true;
                }
                if (this.aprox_caso.Text == "0,00" || double.Parse(this.aprox_caso.Text) < 1.0)
                {
                    str += "Debe registrar un monto aproximado mayor \n ";
                    flag = true;
                }
                if (this.id_div.SelectedValue == "0")
                {
                    str += "Debe seleccionar un tipo de divisa \n ";
                    flag = true;
                }
                if (flag)
                {
                    lblerror.Text = str;
                    popUpValidacion.ShowOnPageLoad = true;
                }
                else
                {
                    re_caso reCaso = new re_caso();

                    reCaso.anio_caso = decimal.Parse(this.anio_caso.SelectedValue);

                    // reCaso.id_caso --> se calculara en el controlador
                    decimal id_caso = logicaReclamos.nextval(reCaso.anio_caso);
                    this.id_caso.Text = id_caso.ToString();

                    reCaso.id_caso = id_caso;
                    reCaso.id_sucur = int.Parse(this.id_suc.SelectedValue);
                    reCaso.id_perclie = this.id_per.Value;
                    reCaso.id_perurc = this.id_perurc.SelectedValue;
                    reCaso.id_poliza = long.Parse(this.id_poliza.SelectedValue);
                    reCaso.aprox_caso = decimal.Parse(this.aprox_caso.Text);
                    reCaso.id_divaprox = double.Parse(this.id_div.SelectedValue);
                    //reCaso.id_rolate = this.id_rolate;
                    reCaso.inspector_cia = this.per_cia.Text.ToUpper();
                    reCaso.atendido_en = this.direccion.Text.ToUpper();
                    reCaso.atendido_por = this.per_aten.Text.ToUpper();
                    //reCaso.lblmensaje = this.lblmensaje;

                    logicaReclamos.add_recaso(reCaso);

                    //if (!reCaso.add_recaso())
                    //    return;
                    /*
                    string[] str = new string[] {  };
                    "INSERT INTO re_caso VALUES (" +
                                                    "nextval('sq_", this.anio_caso.SelectedValue.ToString(), "')" +//[id_caso]       id_caso
                                                   ",", this.anio_caso.SelectedValue.ToString(), //[anio_caso]                     , anio_caso
                                                   ", '", this.id_suc.SelectedValue.ToString(), //[id_sucur]                       , id_sucur
                                                  "','", this.id_per.Value, //[id_perclie]                                         , id_perclie
                                                  "','", this.id_perurc.SelectedValue.ToString(), //[id_perurc]                    , id_perurc
                                                  "',", this.id_poliza.SelectedValue.ToString(), //[id_poliza]                     , id_poliza
                                                   ",", this.aprox_caso.Text.Replace(".", "").Replace(",", "."), //[aprox_caso]    , aprox_caso
                                                   ",", this.id_div.SelectedValue.ToString(), //[id_divaprox]                      , id_divaprox
                                                   ",default" +//[pago_caso]                                                       , pago_caso
                                                   ",default" +//[franq_caso]                                                      , franq_caso
                                                   ",default" +//[indem_caso]                                                      , indem_caso
                                                   ",upper('", this.per_cia.Text, "')" +//[inspector_cia]                          , inspector_c
                                                   ",upper('", this.per_aten.Text, "')" +//[atendido_por]                          , atendido_po
                                                   ",upper('", this.direccion.Text, "')" +//[atendido_en]                          , atendido_en
                                                   ",default" +                                                                    , fc_reg
                                                   ")"                                                                             , id_recibo
                                                                                                                              , anio_recibo
                    */
                    //this.id_caso.Text = reCaso.numcaso().ToString();
                    /*
                    string[] str = new string[] { "SELECT max(re_caso.id_caso) as idcaso " +
                                                  "FROM re_caso " +
                                                  "WHERE re_caso.anio_caso=", this.anio_caso.SelectedValue.ToString(), " " +
                                                         "AND re_caso.id_sucur=", this.id_suc.SelectedValue.ToString(), " " +
                                                         "AND re_caso.id_perclie='", this.id_per.Value, "' " +
                                                         "AND re_caso.id_poliza=", this.id_poliza.SelectedValue.ToString() };
                    */

                    //reCaso.pago_caso;
                    //reCaso.franq_caso;
                    //reCaso.indem_caso;
                    //reCaso.fc_reg;
                    //reCaso.id_recibo;
                    //reCaso.anio_recibo;

                    re_siniestro siniestro = new re_siniestro();
                    siniestro.id_caso = id_caso;
                    siniestro.anio = reCaso.anio_caso;
                    siniestro.id_sucur = reCaso.id_sucur;
                    siniestro.fc_incidente = (DateTime)this.fc_incidente.Value;
                    siniestro.denunciante = this.denunciante.Text.ToUpper();
                    siniestro.reladenun = this.reladenun.Text.ToUpper();
                    siniestro.mat_aseg = this.mat_aseg.Text.ToUpper();
                    siniestro.lugar_siniestro = this.lugar_siniestro.Text.ToUpper();
                    siniestro.circunstancia = this.circunstancia.Text.ToUpper();
                    siniestro.id_uniobj = double.Parse(this.id_uniobj.Text);
                    siniestro.uniobj = this.uniobj.Text;
                    siniestro.fc_denuncia = (DateTime)this.fc_incidente.Value;

                    logicaReclamos.add_siniestro(siniestro);

                    /*
                    reCaso.fc_incidente = this.fc_incidente;
                    reCaso.denunciante = this.denunciante;
                    reCaso.reladenun = this.reladenun;
                    reCaso.mat_aseg = this.mat_aseg;
                    reCaso.lugar_siniestro = this.lugar_siniestro;
                    reCaso.circunstancia = this.circunstancia;
                    reCaso.id_uniobj = this.id_uniobj;
                    reCaso.uniobj = this.uniobj;
                    reCaso.fc_denuncia = this.fc_denuncia;
                    reCaso.lblmensaje = this.lblmensaje;

                    reCaso.add_siniestro();
                    string[] text = new string[] { "INSERT INTO re_siniestro values(" +
                                      "", this.id_caso.Text, 
                                      ",", this.anio_caso.SelectedValue.ToString(), 
                                      ",", this.id_suc.SelectedValue.ToString(), 
                                      ",'", Funciones.fc(this.fc_incidente.Text), 
                                     "','", this.denunciante.Text, 
                                     "','", this.reladenun.Text, 
                                     "','", this.mat_aseg.Text, 
                                     "','", this.lugar_siniestro.Text, 
                                     "','", this.circunstancia.Text, 
                                     "',", this.id_uniobj.Text, 
                                      ",'", this.uniobj.Text, 
                                     "','", Funciones.fc(this.fc_denuncia.Text), "')" };
                    */

                    re_histcaso histocaso = new re_histcaso();
                    histocaso.id_histcaso = 0;
                    histocaso.id_caso = id_caso;
                    histocaso.anio = reCaso.anio_caso;
                    histocaso.id_sucur = reCaso.id_sucur;
                    histocaso.fc_iniestado = DateTime.Now;
                    histocaso.fc_finestado = null;
                    histocaso.id_estca = 73;
                    histocaso.obs_histcaso = "Registro Automatico realizado por el Sistema a momento de Insertar la Denuncia";

                    logicaReclamos.add_histcaso1(histocaso);
                    //reCaso.add_histcaso1();
                    //string[] text = new string[] { "INSERT INTO re_histcaso values (default," , this.id_caso.Text, ",", this.anio_caso.SelectedValue.ToString(), ",", this.id_suc.SelectedValue.ToString(), ",current_date ,default         ,73,'Registro Automatico realizado por el Sistema a momento de Insertar la Denuncia')" };
                    //                                                      " SELECT id_histcaso, id_caso             , anio                                        , id_sucur                                 , fc_iniestado , fc_finestado, id_estca, obs_histcaso "

                    popUpConfirmacion.ShowOnPageLoad = true;

                    //this.btnnuevo.Visible = true;
                    this.btnguardar.Visible = false;
                    //this.btnreporte.Visible = true;
                }
            }
            catch (SecureExceptions ex)
            {
                throw new SecureExceptions("Error al Generar la Consulta", (Exception)ex);
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
        protected void grdListaPersona_SelectionChanged(object sender, EventArgs e)
        {
            var grilla = (DevExpress.Web.ASPxGridView)sender;
            var lista = grilla.GetSelectedFieldValues("id_per");
            var objeto = (string)lista[0];
            this.id_per.Value = objeto.ToString();

            lista = grilla.GetSelectedFieldValues("nomraz");
            objeto = (string)lista[0];
            this.nomraz.Text = objeto.ToString();

            this.id_poliza.DataSource = logicaReclamos.ObtenerPolizaP(this.id_per.Value);
            this.id_poliza.DataTextField = "num_poliza";
            this.id_poliza.DataValueField = "id_poliza";
            this.id_poliza.DataBind();

            this.btnguardar.Visible = true;
            //this.btnmodificar.Visible = false;
            popupBusquedaPersona.ShowOnPageLoad = false;
        }

        protected void id_poliza_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                var list = logicaReclamos.ObtenerPolizaPP(long.Parse(this.id_poliza.SelectedValue.ToString()));
                this.nomraz2.Text = list[0].desc_prod;
                this.desc_prod.Text = list[0].nomraz;
            }
            catch (SecureExceptions ex)
            {
                throw new SecureExceptions("Error al Generar la Consulta", (Exception)ex);
            }
        }
    }
}