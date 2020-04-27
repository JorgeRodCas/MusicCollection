<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Music Collection</title>
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.4.1/jquery.min.js"></script>
    <script>
        var commentEndpoint = '<%= ConfigurationManager.AppSettings["commentEndpoint"] %>'
    </script>
</head>
<body>
    <form id="frmAlbum" runat="server">
        <div class="mainContainer">
            <div class="albumsContainer">
                <asp:DropDownList runat="server" ID="ddlAlbums"></asp:DropDownList>
                <asp:Button runat="server" ID="btnVisualizeAlbum" Text="Visualizar álbum" OnClick="btnVisualizeAlbum_Click" />
            </div>
            <div class="photosContainer">
                <asp:Repeater runat="server" ID="repPhotos">
                    <ItemTemplate>
                        <div>
                            <div class="photo">
                                <img src='<%#Eval("thumbnailUrl") %>' />
                            </div>
                            <div class="_photoInfo photoOptions">
                                <span><%# Eval("title") %></span><br />
                                <asp:Button runat="server" id="btnSeeComments" Text="Ver comentarios" />
                                <asp:HiddenField runat="server" ID="hfPhotoId" value='<%#Eval("id") %>' />
                            </div>
                        </div>
                    </ItemTemplate>
                </asp:Repeater>
            </div>
            <div class="commentsContainer">
                <asp:Table runat="server" ID="tbComments"></asp:Table>
            </div>
        </div>
    </form>
</body>
<script src="scritps/music.js"></script>
</html>
