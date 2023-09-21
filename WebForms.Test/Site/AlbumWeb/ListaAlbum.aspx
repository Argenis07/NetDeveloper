﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site/MantTemplate.Master" AutoEventWireup="true" CodeBehind="ListaAlbum.aspx.cs" Inherits="WebForms.Test.Site.AlbumWeb.ListaAlbum" %>

<asp:Content ID="ButtonContent" ContentPlaceHolderID="ButtonContent" runat="server">
</asp:Content>

<asp:Content ID="ListContent" ContentPlaceHolderID="ArtistContent" runat="server">
    <div class="row">
        <h3>Listado de albums</h3>
    </div>
    <asp:SqlDataSource ID="SqlDataSource"
        runat="server"
        ConnectionString="<%$ConnectionStrings:ChinookcnxEF%>"
        SelectCommand="GetListaAlbum"
        SelectCommandType="StoredProcedure">
        <DeleteParameters>
            <asp:Parameter Name="AlbumId" Type="Int32" />
        </DeleteParameters>
    </asp:SqlDataSource>
    <div class="row">
        <br />
        <asp:GridView ID="AlbumGridView"
            CssClass="table table-striped table-bordered"
            runat="server"
            AllowPaging="true"
            PageSize="12"
            AllowSorting="true"
            AutoGenerateColumns="true"
            AutoGenerateDeleteButton="true"
            DataKeyNames="Albumid"
            AutoGenerateEditButton="true"
            OnPageIndexChanging="AlbumGridView_PageIndexChanging">
            <PagerSettings Mode="NumericFirstLast" Position="TopAndBottom" />
        </asp:GridView>
        <br />
    </div>
    <asp:Button ID="btnfirst" runat="server" Text="Primer Registro" OnClick="btnfirst_Click" />
    <asp:Button ID="btnlast" runat="server" Text="Ultimo Registro" OnClick="btnlast_Click" />
</asp:Content>
