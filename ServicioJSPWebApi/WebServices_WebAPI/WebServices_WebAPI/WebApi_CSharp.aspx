<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebApi_CSharp.aspx.cs" Inherits="WebServices_WebAPI.WebApi_CSharp" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="ajaxToolkit" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Consumir un servicio Web API con C#</title>
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <link href="Content/bootstrap.min.css" rel="stylesheet" />
    <link href="Content/site.css" rel="stylesheet" />
    <script src="Scripts/jquery-3.0.0.min.js"></script>
    <script src="Scripts/bootstrap.min.js"></script>
    <script src="Scripts/webapi.js"></script>
    <style type="text/css">
        .auto-style1 {
            color: #FF0000;
        }
    </style>
</head>
<body>
    <div class="container">
        <!-- La imagen se configura en el archivo site.css -->
        <header class="jumbotron">
            <img src="Images/banner.jpg" />
        </header>
        <main>
            <form id="form1" runat="server">
                <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                <div class="row">
                    <div class="col-sm-6 table-responsive" style="left: 0px; top: 0px">
                        <h1>Editar Categorias</h1>

                        <asp:GridView ID="gvCategories" runat="server"
                            CssClass="table table-bordered table-condensed tablestriped"
                            OnPreRender="gvCategories_PreRender" OnRowCommand="gvCategories_RowCommand">
                            <Columns>
                                <asp:ButtonField Text="Select" />
                            </Columns>
                            <HeaderStyle CssClass="bg-halloween" />
                        </asp:GridView>
                    </div>
                    <div id="details" class="col-lg-6">
                        <input type="hidden" id="orig_id" />
                        <div class="form-group">
                           <asp:Label ID="Label1" runat="server" Text="ID" class="control-label"></asp:Label> 
                            <asp:TextBox ID="TextBoxCategoryID" runat="server" class="form-control" MaxLength="32" ></asp:TextBox>
                            <ajaxToolkit:FilteredTextBoxExtender ID="TextBoxCategoryID_FilteredTextBoxExtender" runat="server" BehaviorID="TextBoxCategoryID_FilteredTextBoxExtender" TargetControlID="TextBoxCategoryID" FilterMode="InvalidChars" InvalidChars="1;2;3;4;5;6;7;8;9;0" />
                        </div>
                        <div class="form-group">
                           <asp:Label ID="Label2" runat="server" Text="Nombre Corto" class="control-label"></asp:Label>   
                            <asp:TextBox ID="TextBoxShortName" runat="server" class="form-control" MaxLength="32"></asp:TextBox>
                            <ajaxToolkit:FilteredTextBoxExtender ID="TextBoxShortName_FilteredTextBoxExtender" runat="server" BehaviorID="TextBoxShortName_FilteredTextBoxExtender" TargetControlID="TextBoxShortName" FilterMode="InvalidChars" InvalidChars="1;2;3;4;5;6;7;8;9;0" />
                        </div>
                        <div class="form-group">
                            <asp:Label ID="Label3" runat="server" Text="Nombre Largo" class="control-label"></asp:Label>                          
                            <asp:TextBox ID="TextBoxLongName" runat="server" class="form-control" MaxLength="32" ></asp:TextBox>
                           
                            <ajaxToolkit:FilteredTextBoxExtender ID="TextBoxLongName_FilteredTextBoxExtender" runat="server" BehaviorID="TextBoxLongName_FilteredTextBoxExtender" TargetControlID="TextBoxLongName" FilterMode="InvalidChars" InvalidChars="1;2;3;4;5;6;7;8;9;0" />
                           
                        </div>
                        <div class="form-group">
                          
                            <asp:Button ID="ButtonInsertar" runat="server" Text="Insertar" class="btn" OnClick="ButtonInsertar_Click"/>
                            <asp:Button ID="ButtonActualizar" runat="server" Text="Actualizar" class="btn" OnClick="ButtonActualizar_Click"/>
                            <asp:Button ID="ButtonEliminar" runat="server" Text="Eliminar" class="btn" OnClick="ButtonEliminar_Click"/>

                            <ajaxToolkit:ModalPopupExtender ID="ButtonEliminar_ModalPopupExtender" runat="server"  
                               PopupControlID="PNL" OkControlID="ButtonOk" CancelControlID="ButtonCancel" BackgroundCssClass="modalBackground"
                                TargetControlID="ButtonEliminar">
                            </ajaxToolkit:ModalPopupExtender>                                            
                            <ajaxToolkit:ConfirmButtonExtender ID="ButtonEliminar_ConfirmButtonExtender" DisplayModalPopupID="ButtonEliminar_ModalPopupExtender" 
                                runat="server" TargetControlID="ButtonEliminar" />
    
                            <asp:Button ID="ButtonLimpiar" runat="server" Text="Limpiar" class="btn" OnClick="ButtonLimpiar_Click"/>
                              <asp:Label ID="Label4" runat="server" Text="" class="control-label" CssClass="auto-style1"></asp:Label>
                        </div>
                    </div>
                </div>
                <!-- fin de la fila (Row) -->
           <asp:Panel ID="PNL" runat="server" Style="display: none; width: 200px; background-color: White; border-width: 2px; border-color: Black; border-style: solid; padding: 20px;">
                ¿Eliminar el Registro?
                <br />
                <br />
                <div style="text-align: right;">
                    <asp:Button ID="ButtonOk" runat="server" Text="OK"  />
                    <asp:Button ID="ButtonCancel" runat="server" Text="Cancelar"  />
                 
                </div>
            </asp:Panel>
                  </ContentTemplate>
                    </asp:UpdatePanel>
            </form>
        </main>
    </div>
</body>
</html>
