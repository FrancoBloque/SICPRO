﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="wpr_polizareno.aspx.cs" Inherits="PresentacionWeb.Sitio.Vista.RegistroProduccion.wpr_polizareno" %>
<%@ Register Assembly="DevExpress.Web.v23.1, Version=23.1.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderPrincipal" runat="server">
        <div class="post">
       <div>                    

        <div class="container">
          <div class="row">
            <div class="col-md-3">      
                <h1 class="title"> <asp:Label ID="lblTitulo" runat="server" Text="Datos de Poliza Incluida (Módulo de Cobranzas)"></asp:Label></h1>
                <div class="entry">
                    <img src="../../../UI/img/aplicacion.png" alt="" width="128" height="128" class="left">
                </div>      
            </div>    
            <div class="col-md-9">
      
                <br /><br /><br />
                  <div class="row">
                    <div class="col-md-12">      
                        <span id="fechas" style="font-weight:bold;">Fechas</span>
                    </div>
                  </div>
              
                  <div class="row">
                      <div class="col-md-3">      
                        <span>Fecha de Emisión:</span>
                      </div>
                      <div class="col-md-3">      
                         <dx:ASPxDateEdit ID="fc_emision" ClientInstanceName="fc_emision" runat="server" Width="100%">
                              <ValidationSettings SetFocusOnError="True" Display="Dynamic" ErrorTextPosition="Bottom" CausesValidation="true"  ErrorDisplayMode="ImageWithText" EnableCustomValidation="true" ValidationGroup="form_wgr_poliza">   <%--ErrorDisplayMode="ImageWithTooltip"--%>
                                   <RequiredField ErrorText="Campo requerido" IsRequired="true"  />  
                               </ValidationSettings>  
                               <ClientSideEvents Init="function(s,e){  
                                                          var dt1 = new Date();  
                                                          var dt2 = new Date(dt1.getFullYear() + 1, dt1.getMonth(), dt1.getDate());  
                                                          var dt3 = new Date(dt1.getFullYear() - 1, dt1.getMonth(), dt1.getDate());  
                                                          fc_emision.SetMinDate(new Date(dt3));  
                                                          fc_emision.SetMaxDate(new Date(dt2));  
                                                       }" />  
                         </dx:ASPxDateEdit>
                      </div>
                      <div class="col-md-3">      
                         <span>Fecha de Recepción:</span>
                      </div>
                      <div class="col-md-3">      
                         <dx:ASPxDateEdit ID="fc_recepcion" ClientInstanceName="fc_recepcion" runat="server" Width="100%">
                              <ValidationSettings SetFocusOnError="True" Display="Dynamic" ErrorTextPosition="Bottom" CausesValidation="true"  ErrorDisplayMode="ImageWithText" EnableCustomValidation="true" ValidationGroup="form_wgr_poliza">   <%--ErrorDisplayMode="ImageWithTooltip"--%>
                                    <RequiredField ErrorText="Campo requerido" IsRequired="true"  />  
                              </ValidationSettings>  
                                <ClientSideEvents Init="function(s,e){  
                                                           var dt1 = new Date();  
                                                           var dt2 = new Date(dt1.getFullYear() + 1, dt1.getMonth(), dt1.getDate());  
                                                           var dt3 = new Date(dt1.getFullYear() - 1, dt1.getMonth(), dt1.getDate());  
                                                           fc_recepcion.SetMinDate(new Date(dt3));  
                                                           fc_recepcion.SetMaxDate(new Date(dt2));  
                                                        }" /> 
                         </dx:ASPxDateEdit>
                      </div>
                  </div>

                  <div class="row">
                      <div class="col-md-3">      
                         <span>Inicio Vigencia:</span>
                      </div>
                      <div class="col-md-3">      
                         <dx:ASPxDateEdit ID="fc_inivig" ClientInstanceName="fc_inivig" runat="server" Width="100%">
                             <ValidationSettings SetFocusOnError="True" Display="Dynamic" ErrorTextPosition="Bottom" CausesValidation="true"  ErrorDisplayMode="ImageWithText" EnableCustomValidation="true" ValidationGroup="form_wgr_poliza">   <%--ErrorDisplayMode="ImageWithTooltip"--%>
                                    <RequiredField ErrorText="Campo requerido" IsRequired="true"  />  
                              </ValidationSettings>  
                                <ClientSideEvents Init="function(s,e){  
                                                           var dt1 = new Date();  
                                                           var dt2 = new Date(dt1.getFullYear() + 1, dt1.getMonth(), dt1.getDate());  
                                                           var dt3 = new Date(dt1.getFullYear() - 1, dt1.getMonth(), dt1.getDate());  
                                                           fc_inivig.SetMinDate(new Date(dt3));  
                                                           fc_inivig.SetMaxDate(new Date(dt2));  
                                                        }" /> 
                         </dx:ASPxDateEdit>
                      </div>
                      <div class="col-md-3">      
                         <span>Fin Vigencia:</span>
                      </div>
                      <div class="col-md-3">      
                          <asp:Label ID="lblfc_finvig" runat="server" Text=""></asp:Label>
                      </div>
                  </div>

                  <div class="row">
                      <div class="col-md-3">      
                         <span id="lblnumero">N° de Poliza:</span>
                      </div>
                      <div class="col-md-3">      
                         <asp:Label ID="lblNroPoliza" runat="server" Text=""></asp:Label>
                      </div>
                      <div class="col-md-3">      
                         <span id="lblnumliquida">Nº Liquidación:</span>
                      </div>
                      <div class="col-md-3">      
                         <dx:ASPxTextBox ID="txtNroLiquidacion" runat="server" Width="100%">
                             <ValidationSettings SetFocusOnError="True" Display="Dynamic" ErrorTextPosition="Bottom" RequiredField-IsRequired="true" ValidationGroup="form_wgr_poliza">
                                   <RequiredField ErrorText="Campo requerido" IsRequired="True"></RequiredField>
                               </ValidationSettings>
                         </dx:ASPxTextBox>  
                      </div>
                  </div>
                  
                  <div class="row">
                       <div class="col-md-3">      
                          <span>Asegurado :</span>
                       </div>
                       <div class="col-md-7">                            
                           <asp:Label ID="lblAsegurado" runat="server" Text=""></asp:Label>
                       </div>
                      <div class="col-md-1">
                          
                      </div>
                   </div>
                  
                  <div class="row">
                       <div class="col-md-3">      
                          <span id="lbldireccion">Dirección :</span>
                       </div>
                       <div class="col-md-7">   
                          <asp:Label ID="lblDireccion" runat="server" Text=""></asp:Label>
                       </div>
                      <div class="col-md-1">
                        
                      </div>
                   </div>
                  
                  <div class="row">
                      <div class="col-md-3">      
                          <span>Grupo :</span>
                      </div>
                      <div class="col-md-8">      
                          <asp:Label ID="lblGrupo" runat="server" Text=""></asp:Label>
                      </div>
                  </div>
                  
                  <div class="row">
                      <div class="col-md-3">      
                          <span>Cia Aseguradora :</span>
                      </div>
                      <div class="col-md-8">      
                          <asp:Label ID="lblCiaAseg" runat="server" Text=""></asp:Label>
                      </div>
                  </div>
                  
                  <div class="row">
                       <div class="col-md-3">      
                           <span>Producto :</span>
                       </div>
                       <div class="col-md-8">      
                           <asp:Label ID="lblProducto" runat="server" Text=""></asp:Label>
                       </div>
                   </div>
                  
                  <div class="row">
                       <div class="col-md-3">      
                           <span>Tipo de Cartera :</span>
                       </div>
                       <div class="col-md-8">      
                           <asp:Label ID="lblTipoCartera" runat="server" Text=""></asp:Label>
                       </div>
                   </div>
                  
                  <div class="row">
                       <div class="col-md-3">      
                          <span>Ejecutivo:</span>
                       </div>
                       <div class="col-md-8">      
                            <dx:ASPxComboBox ID="cmbEjecutivo" runat="server" ValueType="System.String" Width="100%">
                                <ValidationSettings SetFocusOnError="True" Display="Dynamic" ErrorTextPosition="Bottom" ValidationGroup="form_wgr_poliza" ErrorDisplayMode="ImageWithText" CausesValidation="true">
                                  <RequiredField ErrorText="Dato requerido" IsRequired="true" />
                                </ValidationSettings>
                            </dx:ASPxComboBox>
                       </div>
                   </div>
                  
                  <div class="row">
                      <div class="col-md-3">      
                          <span>Agente Cartera:</span>
                      </div>
                      <div class="col-md-8">      
                          <asp:Label ID="lblAgente" runat="server" Text=""></asp:Label>
                      </div>
                  </div>
                 
                  <div class="row">
                      <div class="col-md-3">      
                          <span>Tipo Poliza:</span>
                      </div>
                      <div class="col-md-8">      
                           <asp:Label ID="lblTipoPoliza" runat="server" Text=""></asp:Label>
                      </div>
                  </div>
                  
                  <div class="row">
                       <div class="col-md-3">      
                           <span id="lblprima_bruta">Prima Total:</span>
                       </div>
                       <div class="col-md-8">      
                              <table style="width: 100%;">
                                  <tr>
                                      <td style="width: 125px; height: 18px">          
                                          <dx:ASPxSpinEdit ID="txtPrimaBruta" Width="125px" runat="server" Number="0" MinValue="0" MaxValue="10000000000" Increment="0.1" LargeIncrement="1" NumberType="Float">
                                              <SpinButtons ShowLargeIncrementButtons="true" />
                                          </dx:ASPxSpinEdit>
                 
                                      </td>
                                      <td style="width: 65px; height: 18px">
                                          <span>Nº Cuotas:</span>
                                      </td>
                                      <td style="width: 60px; height: 18px">                                          
                                          <dx:ASPxSpinEdit ID="txtNumCuotas" Width="50px" runat="server" Number="0" MinValue="0" MaxValue="40" Increment="1" NumberType="Float">    
                                          </dx:ASPxSpinEdit>
  
                                      </td>
                                      <td style="width: 45px; height: 18px">
                                           <span>Divisa:</span>                            
                                      </td>
                                      <td style="width: 100px; height: 18px">
                                         <asp:Label ID="lblDivisa" runat="server" Text=""></asp:Label>
                                      </td>
                                  </tr>
          
                              </table>
                       </div>
                   </div>
                  
                <div class="row">
                     <div class="col-md-3">      
                         <span>Prima Neta:</span>
                     </div>
                     <div class="col-md-8">      
                            <table style="width: 100%;">
                                <tr>
                                    <td style="width: 125px; height: 18px">          
                                        <dx:ASPxSpinEdit ID="txtPrimaNeta" Width="125px" runat="server" Number="0" MinValue="0" MaxValue="10000000000" Increment="0.1" LargeIncrement="1" NumberType="Float">
                                            <SpinButtons ShowLargeIncrementButtons="true" />
                                        </dx:ASPxSpinEdit>
                 
                                    </td>
                                    <td style="width: 65px; height: 18px">
                                        <span>Porcentaje:</span>
                                    </td>
                                    <td style="width: 60px; height: 18px">                                          
                                        <dx:ASPxSpinEdit ID="txtPorcentaje" Width="50px" runat="server" Number="0" MinValue="0" MaxValue="40" Increment="1" NumberType="Float">    
                                        </dx:ASPxSpinEdit>
  
                                    </td>
                                    <td style="width: 45px; height: 18px">
                                         <span>Comision:</span>                            
                                    </td>
                                    <td style="width: 100px; height: 18px">
                                       <dx:ASPxSpinEdit ID="txtComision" Width="50px" runat="server" Number="0" MinValue="0" MaxValue="40" Increment="1" NumberType="Float">    
                                        </dx:ASPxSpinEdit>
                                    </td>
                                    <td>
                                        <asp:Button ID="btnCalcular" runat="server" Text="Calcular" OnClick="btnCalcular_Click" />
                                    </td>
                                </tr>
          
                            </table>
                     </div>
                 </div>

                  <div class="row">
                       <div class="col-md-3">      
                           <span id="lbltipo_cuota">Forma de Pago</span>
                       </div>
                       <div class="col-md-8">      
                           <dx:ASPxRadioButtonList ID="tipo_cuota" runat="server" RepeatDirection="Horizontal" Border-BorderStyle="None">
                              <Items>
                                  <dx:ListEditItem Text="Contado" Value="True" Selected></dx:ListEditItem>
                                  <dx:ListEditItem Text="Crédito" Value="False"></dx:ListEditItem>
                              </Items>
                          </dx:ASPxRadioButtonList>
                       </div>
                   </div>
                  
                  <div class="row">
                      <div class="col-md-3">      
                          <span id="lblmat_aseg">Mat. Asegurada:</span>
                      </div>
                      <div class="col-md-8">      
                           <dx:ASPxMemo ID="txtMatAseg" runat="server" Height="71px" Width="100%"></dx:ASPxMemo>
                      </div>
                  </div>
                  
                  <div class="row">
                       <div class="col-md-2">      
           
                       </div>
                       <div class="col-md-8"> 
                           <div class="panel-group">
                            <div class="panel panel-default">
                              <div class="panel-body">Cuotas de la Poliza</div>
                            </div>
                            <div class="panel panel-default">
                              <div class="panel-body">

                                  <asp:GridView ID="grdCuotasPoliza" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3">
                                      <Columns>
                                          <asp:BoundField DataField="cuota" HeaderText="Cuota" >
                                          <ControlStyle Width="20px" />
                                          </asp:BoundField>
                                          <asp:TemplateField HeaderText="Fecha Pago">
                                              <EditItemTemplate>
                                                  <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("fecha_pago") %>'></asp:TextBox>
                                              </EditItemTemplate>
                                              <ItemTemplate>
                                                   <dx:ASPxDateEdit ID="dtFechaPago" ClientInstanceName="dtFechaPago" runat="server" Width="100%" 
                                                       Date='<%# Bind("fecha_pago") %>' DateOnError="Null">
                                                       <ValidationSettings SetFocusOnError="True" Display="Dynamic" ErrorTextPosition="Bottom" ErrorDisplayMode="ImageWithText" EnableCustomValidation="true">  <%--ErrorDisplayMode="ImageWithTooltip"--%>
                                                               <RequiredField ErrorText="Campo requerido" IsRequired="true"  />  
                                                         </ValidationSettings>  
                                                   </dx:ASPxDateEdit>
                                              </ItemTemplate>
                                              <ControlStyle Width="50px" />
                                          </asp:TemplateField>
                                          <asp:TemplateField HeaderText="Cuota Total">
                                              <EditItemTemplate>
                                                  <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("cuota_total") %>'></asp:TextBox>
                                              </EditItemTemplate>
                                              <ItemTemplate>                                                
                                                  <dx:ASPxSpinEdit ID="txtCuotaTotal" Width="125px" runat="server" Number="0" MinValue="0" MaxValue="10000000000" 
                                                      Increment="0.1" LargeIncrement="1" NumberType="Float" Text='<%# Bind("cuota_total") %>'>
                                                      <SpinButtons ShowLargeIncrementButtons="true" />
                                                  </dx:ASPxSpinEdit>
                                              </ItemTemplate>
                                              <ControlStyle Width="50px" />
                                          </asp:TemplateField>
                                      </Columns>
                                      <FooterStyle BackColor="White" ForeColor="#000066" />
                                      <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
                                      <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                                      <RowStyle ForeColor="#000066" />
                                      <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                                      <SortedAscendingCellStyle BackColor="#F1F1F1" />
                                      <SortedAscendingHeaderStyle BackColor="#007DBB" />
                                      <SortedDescendingCellStyle BackColor="#CAC9C9" />
                                      <SortedDescendingHeaderStyle BackColor="#00547E" />
                                  </asp:GridView>
                              </div>
                            </div>
                          </div>
           

            
                       </div>
                   </div>

                  <div class="row">
                      <div class="col-md-4">      
        
                      </div>
                      <div class="col-md-7">   
                          <%--<dx:ASPxButton ID="btnNuevo" runat="server" Text="Nuevo" CssClass="msg_button_class" OnClick="btnNuevo_Click"></dx:ASPxButton>
                          <dx:ASPxButton ID="btnCuotas" runat="server" Text="Cuotas" CssClass="msg_button_class" OnClick="btnCuotas_Click" ></dx:ASPxButton>                          
                          <dx:ASPxButton ID="btnSalir" runat="server" Text="Salir" CssClass="msg_button_class" OnClick="btnSalir_Click"></dx:ASPxButton>--%>
                      </div>
                  </div>

            </div>
          </div>
        </div>

        <p class="links">
             <asp:Label ID="lblmensaje" runat="server" Text="Introduzca Valores" CssClass="error"></asp:Label>  
         </p>
       </div>
    </div>

</asp:Content>