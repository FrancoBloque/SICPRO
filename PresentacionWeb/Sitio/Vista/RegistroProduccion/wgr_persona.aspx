﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="wgr_persona.aspx.cs" Inherits="PresentacionWeb.Sitio.Vista.RegistroProduccion.wgr_persona1" %>

<%@ Register Assembly="DevExpress.Web.v23.1, Version=23.1.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>

<%@ Register Assembly="DevExpress.Web.Bootstrap.v23.1, Version=23.1.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.Bootstrap" TagPrefix="dx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderPrincipal" runat="server">
    

        <div >
            <div >
                <div>                   
                                     
                    <div id="ctl00_cpmaster_ctl00">
	
                       <div id="ctl00_cpmaster_msgboxpanel"></div> 
                            <div class="post">
                            <h1 class="title">Registro de Personas</h1>
			                    <div class="entry"> <img src="../../../UI/img/add-user.gif" alt="" width="122" height="122" class="left">
			                    </div>

                                <table width="500">
                                        <tbody><tr><td style="height: 18px">

                                            <span id="ctl00_cpmaster_lblcodigo">Documento Identificación :</span></td>
                                            <td style="height: 18px">
                                                <dx:ASPxTextBox ID="id_per" runat="server" Width="100%">
                                                    <ValidationSettings SetFocusOnError="True" Display="Dynamic" ErrorTextPosition="Bottom" RequiredField-IsRequired="true" ValidationGroup="form_wgr_persona">
                                                        <RequiredField ErrorText="Este campo es requerido" IsRequired="True"></RequiredField>
                                                    </ValidationSettings>
                                                </dx:ASPxTextBox>                                                
                                            </td>
                                             <td style="height: 18px">
                                                <span id="lblid">(C.I, NIT, otros)</span>
                                             </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <span id="ctl00_cpmaster_lblnombre">Nombre o Razon Social :</span>
                                            </td>
                                            <td id="btnper">                                                
                                                <dx:ASPxTextBox ID="nomraz" runat="server" Width="100%">
                                                    <ValidationSettings SetFocusOnError="True" Display="Dynamic" ErrorTextPosition="Bottom" RequiredField-IsRequired="true" ValidationGroup="form_wgr_persona">
                                                        <RequiredField ErrorText="Este campo es requerido" IsRequired="True"></RequiredField>
                                                    </ValidationSettings>
                                                </dx:ASPxTextBox>  
                                            </td>
                                             <td >    
                                                 <button type="button" name="btnserper" data-bs-toggle="modal" data-bs-target="#modal_btnserper" id="btnserper" class="msg_button_class" style="font-family:Arial,Helvetica,sans-serif;font-size:11px;font-weight:bold;">
                                                  ...
                                                </button>
                                             </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                &nbsp;<span id="ctl00_cpmaster_Label1">Sucursal :</span>
                                            </td>
                                            <td>                                                   
                                                <dx:ASPxComboBox ID="cmb_id_suc" runat="server" ValueType="System.Int32" Width="100%" NullText="Seleccione.....">
                                                    <ValidationSettings SetFocusOnError="True" Display="Dynamic" ErrorTextPosition="Bottom" ValidationGroup="form_wgr_persona" ErrorDisplayMode="ImageWithText" CausesValidation="true">
                                                        <RequiredField ErrorText="Dato requerido" IsRequired="true" />
                                                    </ValidationSettings>
                                                </dx:ASPxComboBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="height: 18px">
                                                <span id="ctl00_cpmaster_lbltipoper">Tipo de Persona :</span>
                                            </td>
                                                <td style="height: 18px">
                                                    <dx:ASPxComboBox ID="cmb_tper" runat="server" ValueType="System.Int64" Width="100%">
                                                        <ValidationSettings SetFocusOnError="True" Display="Dynamic" ErrorTextPosition="Bottom" ValidationGroup="form_wgr_persona" ErrorDisplayMode="ImageWithText" CausesValidation="true">
                                                            <RequiredField ErrorText="Dato requerido" IsRequired="true" />
                                                        </ValidationSettings>
                                                    </dx:ASPxComboBox>                                           
                                                </td>
                                        </tr>
                                        <tr>
                                            <td style="height: 24px">
                                                <span id="ctl00_cpmaster_lblfecha_nac">Fecha de Nacimiento :</span>
                                            </td>
                                            <td style="height: 24px">
                                                                                                                 
                                                <dx:ASPxDateEdit ID="fechaNacimiento" ClientInstanceName="fechaNacimiento" runat="server">
                                                    <ValidationSettings SetFocusOnError="True" Display="Dynamic" ErrorTextPosition="Bottom" CausesValidation="true"  ErrorDisplayMode="ImageWithText" EnableCustomValidation="true" ValidationGroup="form_wgr_persona">   <%--ErrorDisplayMode="ImageWithTooltip"--%>
                                                        <RequiredField ErrorText="Este campo es requerido" IsRequired="true"  />  
                                                    </ValidationSettings>  
                                                    <ClientSideEvents Init="function(s,e){  
                                                                               var dt1 = new Date();  
                                                                               var dt2 = new Date(dt1.getFullYear() - 1, dt1.getMonth(), dt1.getDate());  
                                                                               var dt3 = new Date(dt1.getFullYear() - 100, dt1.getMonth(), dt1.getDate());  
                                                                               fechaNacimiento.SetMinDate(new Date(dt3));  
                                                                               fechaNacimiento.SetMaxDate(new Date(dt2));  
                                                                            }" />  
                                                </dx:ASPxDateEdit>
                                            </td>
                                        </tr>
                                        <tr><td>
                                                <span id="ctl00_cpmaster_lblsal">Salutación Personal :</span></td>
                                            <td>                                                
                                                <dx:ASPxComboBox ID="cmb_id_sal" runat="server" ValueType="System.Int64" Width="100%">
                                                    <ValidationSettings SetFocusOnError="True" Display="Dynamic" ErrorTextPosition="Bottom" ValidationGroup="form_wgr_persona" ErrorDisplayMode="ImageWithText" CausesValidation="true">
                                                        <RequiredField ErrorText="Dato requerido" IsRequired="true" />
                                                    </ValidationSettings>
                                                </dx:ASPxComboBox>                                           
                                            </td>
                                        </tr>
                                        <tr><td>
                                                <span id="ctl00_cpmaster_lblrol">Tipo de Rol :</span></td>
                                            <td>          
                                                <dx:ASPxComboBox ID="cmb_id_rol" runat="server" ValueType="System.Int64" Width="100%">
                                                    <ValidationSettings SetFocusOnError="True" Display="Dynamic" ErrorTextPosition="Bottom" ValidationGroup="form_wgr_persona" ErrorDisplayMode="ImageWithText" CausesValidation="true">
                                                        <RequiredField ErrorText="Dato requerido" IsRequired="true" />
                                                    </ValidationSettings>
                                                </dx:ASPxComboBox>                                           
                                            </td>

                                        </tr>
                                        <tr><td>
                                                <span id="ctl00_cpmaster_lbltipodoc">Tipo de Documento :</span></td>
                                            <td>
                                                <dx:ASPxComboBox ID="cmb_tipodoc" runat="server" ValueType="System.Int64" Width="100%">
                                                    <ValidationSettings SetFocusOnError="True" Display="Dynamic" ErrorTextPosition="Bottom" ValidationGroup="form_wgr_persona" ErrorDisplayMode="ImageWithText" CausesValidation="true">
                                                        <RequiredField ErrorText="Dato requerido" IsRequired="true" />
                                                    </ValidationSettings>
                                                </dx:ASPxComboBox>                                           
                                            </td>
                                        </tr>
                                        <tr><td>
                                                <span id="ctl00_cpmaster_lblldoc">Emisión del Documento :</span></td>
                                            <td>                                                
                                                <dx:ASPxComboBox ID="cmb_id_emis" runat="server" ValueType="System.Int64" Width="100%">
                                                    <ValidationSettings SetFocusOnError="True" Display="Dynamic" ErrorTextPosition="Bottom" ValidationGroup="form_wgr_persona" ErrorDisplayMode="ImageWithText" CausesValidation="true">
                                                        <RequiredField ErrorText="Dato requerido" IsRequired="true" />
                                                    </ValidationSettings>
                                                </dx:ASPxComboBox>                                           
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <span id="ctl00_cpmaster_lblnit">Datos de Facturación :</span>
                                            </td>
                                            <td>
                                                <dx:ASPxTextBox ID="nit_fac" runat="server" Width="100%">
                                                     <ValidationSettings SetFocusOnError="True" Display="Dynamic" ErrorTextPosition="Bottom" RequiredField-IsRequired="true" ValidationGroup="form_wgr_persona">
                                                         <RequiredField ErrorText="Este campo es requerido" IsRequired="True"></RequiredField>
                                                     </ValidationSettings>
                                                </dx:ASPxTextBox>                                                
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="2" align="center">
                                                <dx:ASPxButton ID="btnNuevo" runat="server" Text="Nuevo" CssClass="msg_button_class" OnClick="btnNuevo_Click"></dx:ASPxButton>

                                                <dx:ASPxButton ID="btnGuardar" runat="server" Text="Guardar" CssClass="msg_button_class" OnClick="btnGuardar_Click" ValidationGroup="form_wgr_persona"></dx:ASPxButton>

                                                <dx:ASPxButton ID="btnDirecciones" runat="server" Text="Direcciones" CssClass="msg_button_class" OnClick="btnDirecciones_Click"></dx:ASPxButton>
                                           

                                                <dx:ASPxButton ID="btnBuscar" runat="server" Text="Buscar" CssClass="msg_button_class" OnClick="btnBuscar_Click"></dx:ASPxButton>

                                                <dx:ASPxButton ID="btnSalir" runat="server" Text="Salir" CssClass="msg_button_class" OnClick="btnSalir_Click"></dx:ASPxButton>

                                               <%-- <input type="submit" name="ctl00$cpmaster$btnguardar" value="Guardar" id="ctl00_cpmaster_btnguardar" class="msg_button_class" style="font-family:Arial,Helvetica,sans-serif;font-size:11px;font-weight:bold;">
                            
                            
                                                <input type="button" name="ctl00$cpmaster$b1" value="Buscar" onclick="javascript:__doPostBack('ctl00$cpmaster$b1','')" id="ctl00_cpmaster_b1" class="msg_button_class" style="font-family:Arial,Helvetica,sans-serif;font-size:11px;font-weight:bold;">
                                                <input type="submit" name="ctl00$cpmaster$btnsalir" value="Salir" id="ctl00_cpmaster_btnsalir" class="msg_button_class" style="font-family:Arial,Helvetica,sans-serif;font-size:11px;font-weight:bold;">

--%>


                                            </td>
                                        </tr>
                                    </tbody></table>

			                    <p class="links">                                    
                                    <asp:Label ID="lblmensaje" runat="server" Text="Introduzca Valores" CssClass="error"></asp:Label>                                   
                                </p>
                                                                   
                            </div>
            
                    </div>
                    
            
                </div>
            </div>
        </div>


<!-- Modal class="modal fade"-->
<div  class="modal fade" id="modal_btnserper" tabindex="-1" aria-labelledby="Busca Persona" aria-hidden="true">
  <div class="modal-dialog modal-lg">
    <div class="modal-content">
      <div class="modal-header" style="background-color:#0F5B96">
        <h6 class="modal-title" id="exampleModalLabel">Busqueda de Persona por Nombre o Razón Social</h6>
        <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
      </div>
      <div class="modal-body" style="color:#0F5B96">
        <div class="container">
          <div class="row">
            <div class="col-md-12" style="text-align:center">
                <img src="../../../UI/img/search_user.png" width="48" height="48">               
            </div>
          </div>
            <br />
          <div class="row">
            <div class="col-md-12">
               
                <dx:ASPxGridView ID="grdPersonas" KeyFieldName="id_per" runat="server" Width="100%"
                    OnSearchPanelEditorCreate="Grid_SearchPanelEditorCreate"
                    OnDataBinding="grdPersonas_DataBinding" OnRowCommand="gv_RowCommand" OnPageIndexChanged="grdPersonas_PageIndexChanged">
                    <Columns>     
                         <dx:GridViewDataTextColumn FieldName="id_per" Caption ="Opciones" VisibleIndex="0">
                            <DataItemTemplate>
                                <dx:ASPxButton ID="btn" runat="server" Text="Seleccionar" Font-Size="x-Small"></dx:ASPxButton>
                            </DataItemTemplate>
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn FieldName="nomraz" Caption="Nombre o Razon Social" />   
                    </Columns>
                     <SettingsSearchPanel Visible="true" ColumnNames="nomraz" ShowApplyButton="True" ShowClearButton="True"/>
                    <SettingsPager Mode="ShowPager" PageSize="10" />
                    <%--<SettingsSearchPanel CustomEditorID="ASPxTextBox1" />--%>
                </dx:ASPxGridView>
            </div>
          </div>         
        </div>
      </div>
      <div class="modal-footer" >
        <button type="button" class="btn btn-secondary" data-bs-dismiss="modal">Aceptar</button>
        
      </div>
    </div>
  </div>
</div>

</asp:Content>
