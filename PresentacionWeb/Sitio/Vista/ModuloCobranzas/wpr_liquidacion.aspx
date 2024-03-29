﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="wpr_liquidacion.aspx.cs" Inherits="PresentacionWeb.Sitio.Vista.ModuloCobranzas.wpr_liquidacion" %>

<%@ Register Assembly="DevExpress.Web.v23.1, Version=23.1.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.Bootstrap.v23.1, Version=23.1.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.Bootstrap" TagPrefix="dx" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderPrincipal" runat="server">
    <div class="container p-2">
        <div class="card p-3">
            <div class="row">
                <div class="col-12 col-sm-12 col-md-3 col-lg-3 col-xl-2">
                    <img src="../../../UI/img/img07.jgp" alt="" class="img-fluid">
                </div>
                <div class="col-12 col-sm-12 col-md-9 col-lg-9 col-xl-10">

                    <div class="row">
                        <div class="col-12">
                            <h1 class="title">Registro de Liquidación de Recibos</h1>
                        </div>
                    </div>
                    <div class="row">
                        <div class="mt-1 mt-sm-1 mt-md-1 col-4 col-sm-4 col-md-4 col-lg-3 col-xl-3">
                            <span id="Label17">Nº Liquidación:</span>
                        </div>
                        <div class="mt-1 mt-sm-1 mt-md-1 col-8 col-sm-8 col-md-8 col-lg-7 col-xl-7">
                            <asp:Label runat="server" ID="id_liq"></asp:Label>

                        </div>
                    </div>

                    <div class="row mt-1">
                        <div class="col-4 col-sm-4 col-md-4 col-lg-3 col-xl-3">
                            <span id="Label10">Sucursal:</span>
                        </div>
                        <div class="col-8 col-sm-8 col-md-4 col-lg-4 col-xl-4">
                            <dx:BootstrapComboBox ID="id_suc" runat="server" ValueType="System.String" NullText="Seleccione una opcion..." AutoPostBack="true" OnSelectedIndexChanged="id_suc_SelectedIndexChanged">
                                <CssClasses Button="btn-sm" Input="form-control-sm fs-10" ListBox="fs-10" />
                                <ValidationSettings ValidationGroup="Guarda">
                                    <RequiredField ErrorText="Seleccione una opcion" IsRequired="true" />
                                </ValidationSettings>
                            </dx:BootstrapComboBox>
                        </div>
                    </div>

                    <div class="row mt-1">
                        <div class="mt-1 mt-sm-1 mt-md-0 col-4 col-sm-4 col-md-4 col-lg-3 col-xl-3">
                            <span id="Label16">Cobrador:</span>
                        </div>
                        <div class="mt-1 mt-sm-1 mt-md-0 col-8 col-sm-8 col-md-3 col-lg-3 col-xl-4">
                            <dx:BootstrapComboBox ID="id_perucb" runat="server" ValueType="System.String" NullText="Seleccione una opcion..." DropDownStyle="DropDownList" AutoPostBack="true" OnSelectedIndexChanged="id_perucb_SelectedIndexChanged">
                                <CssClasses Button="btn-sm" Input="form-control-sm fs-10" ListBox="fs-10" />
                                <ValidationSettings ValidationGroup="Guarda">
                                   
                                </ValidationSettings>
                            </dx:BootstrapComboBox>

                        </div>
                    </div>
                    <div class="row ">
                        <div class=" col-4 col-sm-4 col-md-4 col-lg-3 col-xl-3">
                            <span id="Label18">Fecha:</span>
                        </div>
                        <div class=" col-8 col-sm-8 col-md-8 col-lg-4 col-xl-4">
                            <dx:BootstrapTextBox runat="server" ID="fc_liq" NullText="" Text="">
                                <CssClasses Input="form-control-sm fs-10" />
                                <ValidationSettings ValidationGroup="Guarda">
                                    <RequiredField IsRequired="true"  />
                                </ValidationSettings>
                            </dx:BootstrapTextBox>
                        </div>

                    </div>

                    <div class="row mt-2">
                        <div class="col-12">
                            <dx:BootstrapButton runat="server" ID="btnguardar" Text="Buscar Factura" ValidationGroup="Guarda">
                                <SettingsBootstrap RenderOption="None" Sizing="Small" />
                                <CssClasses Control="msg_button_class" Text="fs-9" />
                            </dx:BootstrapButton>
                           
                            <%--      <input type="submit" name="ctl00$cpmaster$btncuotas" value="Guardar Cheque" id="ctl00_cpmaster_btncuotas" class="msg_button_class" style="font-family: Arial,Helvetica,sans-serif; font-size: 11px; font-weight: bold;">
                            --%>
                        </div>
                    </div>
      


                </div>
            </div>


        </div>
        <p class="links">
            <span id="ctl00_cpmaster_lblmensaje" class="error">Introduzca Valores</span>
        </p>
    </div>
    <dx:BootstrapPopupControl HeaderText="Mensaje" runat="server" ID="pnlMensaje"
        PopupHorizontalAlign="WindowCenter" PopupVerticalAlign="WindowCenter" Width="300px" CloseAction="CloseButton"
        Modal="true" CssClasses-Header="fs-9 text-white bg-primary">
        <ContentCollection>
            <dx:ContentControl>
                <div class="row">
                    <div class="offset-3 col-9">
                        <asp:Image ImageUrl="../../../UI/img/ok.png" Width="70px" runat="server" ID="imagenOk" />
                        <asp:Image ImageUrl="../../../UI/img/msg_icon_2.png" Width="70px" runat="server" ID="imagenFail" />

                    </div>
                    <div class="col-12">
                        <asp:Label runat="server" ID="lblMensaje" Text=""></asp:Label>
                    </div>
                </div>
            </dx:ContentControl>
        </ContentCollection>
    </dx:BootstrapPopupControl>
</asp:Content>
