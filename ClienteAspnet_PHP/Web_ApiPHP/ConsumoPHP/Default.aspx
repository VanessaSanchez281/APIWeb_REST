<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="ConsumoPHP.Default" %>
<%@ Register Assembly="AjaxControlToolkit"  Namespace="AjaxControlToolkit"  TagPrefix="ajaxToolkit"%> 
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
 <title> Mantenimiento de Categorias</title>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link href="Content/bootstrap.min.css" rel="stylesheet" />
    <link href="Content/Site.css" rel="stylesheet" />
    <script src="Scripts/bootstrap.min.js"></script>

</head>
<body>
    <div class="container">
        <header class="jumbotron">
            <img src="Images/banner.jpg" />
        </header>
        <main>
         <form id="form1" runat="server">
             <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
             <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                 <ContentTemplate>

              
                        <div class="row">

                            <div class="col-sm-6 table-responsive">
                                <h1>Editar Categorias</h1>
                                <asp:GridView ID="gvCategories" CssClass="table table-bordered table-condensed table-striped" runat="server" OnSelectedIndexChanging="gvCategories_SelectedIndexChanging" >
                                    <Columns>
                                        <asp:CommandField ShowSelectButton="True" />
                                    </Columns>
                                    <HeaderStyle CssClass="bg-halloween" />
                                </asp:GridView>
                            </div>
                            <br />
                             <div id="details" class="col-sm-6">
                                 <div class="form-group" >
                                     <asp:Label ID="lblId" CssClass="control-label" runat="server" Text="ID"></asp:Label>
                                     <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtId" Display="None"></asp:RequiredFieldValidator>
                                      <ajaxToolkit:ValidatorCalloutExtender ID="ValidatorCalloutExtender1" HighlightCssClass="validatorCalloutHighlight" TargetControlID="RequiredFieldValidator1" runat="server"/>
                                     <asp:TextBox ID="txtId" CssClass="form-control" runat="server"></asp:TextBox>
                                      <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server" TargetControlID="txtId"  FilterType="UppercaseLetters,LowercaseLetters" />
                                     
                                 </div>
                                  <div class="form-group" >
                                     <asp:Label ID="lblNombreLargo" CssClass="control-label" runat="server" Text="NOMBRE LARGO"></asp:Label>
                                      <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtNombreLargo" Display="None"></asp:RequiredFieldValidator>
                                      <ajaxToolkit:ValidatorCalloutExtender ID="ValidatorCalloutExtender2" HighlightCssClass="validatorCalloutHighlight" TargetControlID="RequiredFieldValidator2" runat="server"/>
                                      <asp:TextBox ID="txtNombreLargo" CssClass="form-control" runat="server"></asp:TextBox>
                                      <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" runat="server" TargetControlID="txtNombreLargo"  FilterType="UppercaseLetters,LowercaseLetters" />   
                                  </div>
                                  <div class="form-group" >
                                      <asp:Label ID="lblNombreCorto" CssClass="control-label" runat="server" Text="NOMBRE CORTO"></asp:Label>
                                       <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtNombreCorto" Display="None"></asp:RequiredFieldValidator>
                                     <ajaxToolkit:ValidatorCalloutExtender ID="ValidatorCalloutExtender3" HighlightCssClass="validatorCalloutHighlight" TargetControlID="RequiredFieldValidator3" runat="server"/>
                                      <asp:TextBox ID="txtNombreCorto" CssClass="form-control" runat="server"></asp:TextBox>
                                  <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender3" runat="server" TargetControlID="txtNombreCorto"  FilterType="UppercaseLetters,LowercaseLetters" />  
                                  </div>
                                 <div class="form-group" >
                                     <asp:Button ID="Button1" CssClass="btn btn-warning" runat="server" Text="Insertar" OnClick="Button1_Click" />   
                                     <asp:Button ID="Button2" CssClass="btn btn-warning" runat="server" Text="Actualizar"  Visible="False" OnClick="Button2_Click" />
                                     <asp:Button ID="Button3" CssClass="btn btn-warning" runat="server" Text="Eliminar" OnClick="Button3_Click"/>
                                      <ajaxToolkit:ConfirmButtonExtender  ID="ConfirmButtonExtender1" runat="server" TargetControlID="Button3" ConfirmText="Desea Eliminar el Registro?" />
                                     <asp:Button ID="Button4" CssClass="btn btn-warning" runat="server" Text="Limpiar" OnClick="Button4_Click"  />
                                    <br />
                                     <asp:Label ID="lblMensajeError" CssClass="control-label" runat="server" ForeColor="#CC0000"></asp:Label>
                                 </div>
                                 
                             </div>

                        </div>
                     
                     </ContentTemplate>
             </asp:UpdatePanel>
            </form>
        </main>
    </div>
 
    
                                      
</body>
</html>
