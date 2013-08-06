<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Artists.aspx.cs" Inherits="Musicstore.Client.WebApp.Artists" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <fieldset>
            <legend>Artist:</legend>
            Name:
                <asp:TextBox ID="txtArtistName" runat="server"></asp:TextBox><br />
            Country:
                <asp:TextBox ID="txtArtistCountry" runat="server"></asp:TextBox><br />
            Albums:
                <asp:ListBox ID="lbAlbums" runat="server"  CssClass="multiselect"></asp:ListBox>
            Songs:
                <asp:ListBox ID="lbSongs" runat="server"  CssClass="multiselect"></asp:ListBox>
            <asp:LinkButton ID="btnArtistSave" runat="server" OnClick="btnArtistSave_Click">Save</asp:LinkButton>
        </fieldset>
        <asp:GridView ID="grdArtists" runat="server" DataKeyNames="Id" OnRowDeleting="grdArtists_RowDeleting" OnSelectedIndexChanged="grdArtists_SelectedIndexChanged">
            <Columns>
                <asp:CommandField HeaderText="Action" ShowDeleteButton="True" ShowSelectButton="True" />
            </Columns>
        </asp:GridView>
    </div>
</asp:Content>
