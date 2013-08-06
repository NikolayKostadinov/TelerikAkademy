<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Albums.aspx.cs" Inherits="Musicstore.Client.WebApp.Albums" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        $(function () {
            var defaultOptions = {
                moveEffect: 'blind',
                moveEffectOptions: { direction: 'vertical' },
                moveEffectSpeed: 'fast'
            };

            var widgets = {
                '#<%= lbArtists.ClientID %>': $.extend($.extend({}, defaultOptions), {
                    sortMethod: 'standard',
                    sortable: true
                }),
                '#<%= lbSongs.ClientID %>': $.extend($.extend({}, defaultOptions), {
                    sortMethod: 'standard',
                    sortable: true
                })
            };

            $.each(widgets, function (id, i) {
                $(id).multiselect(i).on('multiselectChange', function(evt, ui) {
                    var values = "";
                    var find = $(id).find('option');
                    for (var i = 0; i < find.length; i++) {
                        if (find[i].selected) {
                            values += find[i].value + ";" + find[i].text + ",";
                        }
                    }

                    if (id == '#<%= lbArtists.ClientID %>') {
                        $('#<%= hfArtists.ClientID %>').val(values);
                    } else {
                        $('#<%= hfSongs.ClientID %>').val(values);
                    }
                });
            });
        });
        </script>
        <style type="text/css">
            .multiselect {
                width: 450px;
                height: 200px;
            }
        </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
            <fieldset>
                <legend>Album:</legend>
                Title:
                <asp:TextBox ID="txtAlbumTitle" runat="server"></asp:TextBox><br />
                Year:
                <asp:TextBox ID="txtAlbumYear" runat="server"></asp:TextBox><br />
                Producer:
                <asp:TextBox ID="txtAlbumProducer" runat="server"></asp:TextBox><br />
                Artists:<br/>
                <asp:ListBox ID="lbArtists" runat="server"  CssClass="multiselect" SelectionMode="Multiple"></asp:ListBox>
                <asp:HiddenField ID="hfArtists" runat="server" />
                <br /><br />
                Songs:<br/>
                <asp:ListBox ID="lbSongs" runat="server"  CssClass="multiselect"></asp:ListBox>
                <asp:HiddenField ID="hfSongs" runat="server" />
                <br /><br />
                <asp:LinkButton ID="btnAlbumSave" runat="server" OnClick="btnAlbumSave_Click">Save</asp:LinkButton>
            </fieldset>
            <asp:GridView ID="grdAlbums" runat="server"></asp:GridView>
        </div>
</asp:Content>