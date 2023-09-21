<%@ Page Title="" Language="C#" MasterPageFile="~/Site/MantTemplate.Master" AutoEventWireup="true" CodeBehind="CrearArtist.aspx.cs" Inherits="WebForms.Test.Site.ArtistWeb.CrearArtist" %>

<asp:Content ID="ButtonContent" ContentPlaceHolderID="ButtonContent" runat="server">
    <a class="btn btn-info" href="ListaArtist.aspx">
        <span class="glyphicon glyphicon-hand-left"></span>Regresar
    </a>
</asp:Content>

<asp:Content ID="ArtistContent" ContentPlaceHolderID="ArtistContent" runat="server">
    <h2>Crear nuevo artistas</h2>
    <div class="row">
        <div>
            <asp:Label ID="Label1" runat="server" Text="Nombre"></asp:Label>
            <asp:TextBox ID="txtname" runat="server"></asp:TextBox>
        </div>
        <div>
            <asp:Button class="btn btn-submit" ID="btncrear" runat="server" Text="Crear" OnClick="btncrear_Click" />
        </div>
    </div>
</asp:Content>
