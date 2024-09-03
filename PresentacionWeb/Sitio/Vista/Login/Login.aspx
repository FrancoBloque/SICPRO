<%@ Page Title="" Language="C#" MasterPageFile="~/Inicio.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="PresentacionWeb.Sitio.Vista.Login.Login" %>

<%@ Register Assembly="DevExpress.Web.Bootstrap.v23.1, Version=23.1.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.Bootstrap" TagPrefix="dx" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderPrincipal" runat="server">
    <div class="container">
        <div class="row">
            <div class="col-12 col-sm-11 offset-sm-1 col-md-8 offset-md-2 col-lg-6  offset-lg-3  col-xl-5 offset-xl-3">
                <div class="card card-body pt-4 pb-0 pe-4 ps-4">
                    <h6 class="  fw-bold text-info fs-9">Inicio de Sesión</h6>
                    <div class="row">
                        <div class="col-4">
                            <img src="../../../UI/img/lock.gif" alt="" width="120" height="120" class="left">
                        </div>

                        <div class="col-8">
                            <div class="row mb-1">
                                <div class="col-5 pt-2 ps-1">
                                    <asp:Label runat="server" ID="lblusuario">Usuario :</asp:Label>
                                </div>
                                <div class="col-7">
                                    <dx:BootstrapTextBox ID="txtusuario" runat="server" NullText="Usuario">
                                        <CssClasses Input="form-control-sm fs-10" />
                                        <ValidationSettings>
                                            <RequiredField IsRequired="true" ErrorText="Campo Obligatorio" />
                                        </ValidationSettings>
                                    </dx:BootstrapTextBox>
                                </div>
                            </div>
                            <div class="row mb-1">
                                <div class="col-5 pt-2 ps-1">
                                    <asp:Label runat="server" ID="lblcontraseña">Contraseña :</asp:Label>
                                </div>
                                <div class="col-7">
                                    <dx:BootstrapTextBox ID="txtpassword" runat="server" NullText="Contraseña" Password="true">
                                        <CssClasses Input="form-control-sm fs-10" />
                                        <ValidationSettings>
                                            <RequiredField IsRequired="true" ErrorText="Campo Obligatorio" />
                                        </ValidationSettings>
                                    </dx:BootstrapTextBox>

                                </div>
                            </div>
                            <%--<div class="row mb-1">
                                <div class="col-5 pt-2 ps-1 pe-0">
                                    <asp:Label runat="server" ID="lblTiempo">Tiempo de Conexion:</asp:Label>
                                </div>
                                <div class="col-7">

                                    <dx:BootstrapComboBox ID="sesion" runat="server" DropDownStyle="DropDownList" NullText="Seleccione una opción" ValueType="System.String">
                                        <CssClasses Button="btn-sm" Input="form-control-sm fs-10" ListBox="fs-10" />
                                        <Items>
                                            <dx:BootstrapListEditItem Text="Sel. una Opción" Value="0" Selected="true" />
                                            <dx:BootstrapListEditItem Text="30 Minutos" Value="30" />
                                            <dx:BootstrapListEditItem Text="60 Minutos" Value="60" />
                                            <dx:BootstrapListEditItem Text="90 Minutos" Value="90" />
                                        </Items>
                                    </dx:BootstrapComboBox>

                                </div>
                            </div>--%>
                            <div class="row mt-3">
                                <div class="offset-4 col-8">
                                    
                                        <dx:BootstrapButton ID="btnAceptar" runat="server" AutoPostBack="false" Text="Aceptar" OnClick="btnAceptar_Click">
                                            <CssClasses Control="ms-1 msg_button_class btn-sm fs-10" />
                                            <SettingsBootstrap RenderOption="None" />
                                        </dx:BootstrapButton>
                               </div>


                            </div>
                        </div>
                        <p class="border-top border-primary   mt-3 mb-3 pt-1">
                            <a ><asp:label runat="server" ID="lblmensaje" Text="" CssClass="text-danger mt-1"></asp:label></a>
                        </p>
                    </div>

                </div>
            </div>

        </div>
    </div>
</asp:Content>
