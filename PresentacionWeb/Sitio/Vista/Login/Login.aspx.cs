using EntidadesClases.ModelSicPro;
using Logica.Consumo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Security.Claims;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PresentacionWeb.Sitio.Vista.Login
{
    public partial class Login : System.Web.UI.Page
    {
        private readonly ConsumoAuth _consumoAuth = new ConsumoAuth();
        private long tiempo;
        protected void Page_Load(object sender, EventArgs e)
        {
            //Principal aaa = Page.Master as Principal;
            //var d = aaa.FindControl("accordionFlushExample");
            //d.Visible = false;
        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {

                if (!_consumoAuth.VerificarUsuario(base.Server.HtmlEncode(this.txtusuario.Text.ToUpper()), base.Server.HtmlEncode(this.txtpassword.Text.ToUpper())))
                {
                    lblmensaje.Text = "Usuario Inválido o ha Iniciado sesión en otro equipo";
                }
                else
                {
                    string str = _consumoAuth.ObtenerSuc(this.txtusuario.Text.ToUpper(), this.txtpassword.Text.ToUpper());
                    this.Session["suc"] = str;
                    string str1 = _consumoAuth.ObtenerRol(this.txtusuario.Text.ToUpper(), this.txtpassword.Text.ToUpper());
                    this.Session["roles"] = str1;
                    string str2 = _consumoAuth.ObtenerId(this.txtusuario.Text.ToUpper(), this.txtpassword.Text.ToUpper());
                    this.Session["id"] = str2;
                    //if (sesion.Value.ToString() != "0")
                    //{
                    //    tiempo = int.Parse(sesion.Value.ToString());
                    //}
                    //else
                    //{
                        tiempo = 30;
                    //}

                    string text = this.txtusuario.Text;
                    DateTime now = DateTime.Now;
                    DateTime dateTime = DateTime.Now;
                    double tiempSesion = Convert.ToDouble(tiempo);

                    string str4 = this.Session["id"].ToString();
                    _consumoAuth.Logeo(str4);
                    if (!_consumoAuth.VerificarEstado(base.Server.HtmlEncode(this.txtusuario.Text.ToUpper()), base.Server.HtmlEncode(this.txtpassword.Text.ToUpper())))
                    {

                        //Principal aaa = Page.Master as Principal;
                        //var d = aaa.FindControl("Menu1");
                        //d.Visible = false;
                        Response.Redirect("../Default.aspx");
                    }
                    else
                    {
                        //Response.Redirect("~/Sitio/Vista/ConfiguracionSistema/wgr_pass.aspx");
                        Response.Redirect("../Default.aspx");
                    }
                }
            }
            catch(Exception ex)
            {
                lblmensaje.Text = ex.Message;
            }

        }

        public void Page_Error(object sender, EventArgs e)
        {
            string mensajeError = string.Empty;
            Exception objErr = Server.GetLastError();
            if (objErr.InnerException == null)
                mensajeError = objErr.Message;
            else
                mensajeError = objErr.InnerException.Message;
            Response.Redirect("~/Sitio/Vista/Exceptions/Error.aspx?error=" + mensajeError.Replace("\r\n", ""));
        }

        public HttpCookie GetAuthCookie(string user, double time)
        {
            // Temporalmente se coloca un rol de sesión por defecto
            string sessionRoles = "GUEST"; //rolesManager.GetSessionRoles(validUser);

            DateTime expires = DateTime.Now.AddMinutes(time);
            FormsAuthenticationTicket authTicket = new FormsAuthenticationTicket(
                1,                  // version
                user,        // user name
                DateTime.Now,       // created
                expires,           // expires
                true,   // persistent?
                sessionRoles        // roles for use in IsInRole() method
                );

            string encryptedTicket = FormsAuthentication.Encrypt(authTicket);

            HttpCookie authCookie = new HttpCookie(FormsAuthentication.FormsCookieName, encryptedTicket);

            return authCookie;
        }
    }
}