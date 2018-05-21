<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" EnableEventValidation="false" CodeBehind="AdminPanel.aspx.cs" Inherits="WebProgramiranjeASP.AdminPanel" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
    .auto-style1 {
        width: 268435424px;
    }
        .auto-style2 {
            width: 54px;
        }
        .auto-style3 {
            width: 120px;
        }
        .auto-style4 {
            width: 74px;
        }
        .auto-style5 {
            width: 552px;
        }
        .highlight:hover{
            color: #FD7777;
            cursor: pointer;
        }
        .auto-style8 {
            width: 283px;
        }
        .auto-style9 {
            width: 381px;
        }
    </style>
    <script type="text/javascript">
        function ShowHide() {
            $('.panel8').css({ "display": "block" });
        }
    </script>
    </asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contents" runat="server">
    <section id="admin">
  <h1>Admin Panel</h1>
	<h2 class="highlight" id="userList" >List of users</h2> 
     <form  method="post" runat="server" enctype="multipart/form-data" id="Form1">
         <asp:Panel ID="Panel8" CssClass="panel8" runat="server">
     <table style="width:100%;">
         <tr>
             <td colspan="3">
                 <asp:Panel ID="Panel10" runat="server" Width="767px">
                     <table style="width:100%;">
                         <tr>
                             <th>UserName</th>
                             <th>Password</th>
                             <th>Mail</th>
                             <th>Function</th>
                             <th>Operation</th>
                         </tr>
                         <tr>
                             <td>
                                 <asp:TextBox ID="tbUserNameAdd" runat="server"></asp:TextBox>
                             </td>
                             <td>
                                 <asp:TextBox ID="tbPasswordAdd" runat="server"></asp:TextBox>
                                 
                             </td>
                             <td>
                                 <asp:TextBox ID="tbMailAdd" runat="server"></asp:TextBox>
                             </td>
                             <td>
                                 
                                 <asp:DropDownList ID="ddlFunctionAdd" runat="server" DataSourceID="SqlDataSource1" DataTextField="function_name" DataValueField="functionId">
                                 </asp:DropDownList>                                 
                             </td>
                             <td>
                                <asp:Button ID="btnUserAdd" class="btnDelete" runat="server" Text="Add" OnClick="btnUserAdd_Click" />
                             </td>
                         </tr>
                     </table>
                     <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString2 %>" SelectCommand="SELECT * FROM [function]"></asp:SqlDataSource>
                 </asp:Panel>
             </td>
         </tr>
        <tr>
            <td rowspan="3">
                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" Width="700px">
                    <Columns>
                        <asp:BoundField DataField="idUser" HeaderText="Id User" ReadOnly="True" SortExpression="idUser" />
                        <asp:BoundField DataField="userName" HeaderText="UserName" ReadOnly="True" SortExpression="userName" />
                        <asp:BoundField DataField="password" HeaderText="Password" ReadOnly="True" SortExpression="password" />
                        <asp:BoundField DataField="mail" HeaderText="Mail" ReadOnly="True" SortExpression="mail" />
                        <asp:TemplateField HeaderText="Update">
                            <ItemTemplate>
                                <asp:Button text="Update" runat="server" UseSubmitBehavior="false" class="btnDelete" ID="btnUserUpdate" commandName="btnUpdateUser" commandArgument='<%# Eval("idUser") + ";" + Eval("userName") + ";" + Eval("password") + ";" + Eval("mail") + ";" + Eval("idFunction") %>' OnClick="btnUserUpdate_Click"/>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Delete">
                            <ItemTemplate>
                                <asp:Button text="Delete" runat="server" class="btnDelete" ID="btnDeleteUser" commandName="btnDeleteUser" commandArgument='<%# Eval("idUser")  %>' OnClick="btnUserDelete_Click" />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </td>
        </tr>
        <tr>
            <td rowspan="3" class="auto-style1">&nbsp;</td>
        </tr>
        <tr>
            <td rowspan="3">
                <asp:Panel ID="Panel1" runat="server">
                    <table style="width:100%;">
                        <tr>
                            <td>UserName:</td>
                            <td><asp:TextBox id="tbUserName" runat="server"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td>Password:</td>
                            <td><asp:TextBox id="tbPassword" runat="server"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td>Mail:</td>
                            <td><asp:TextBox id="tbMail" runat="server"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td>Function:</td>
                            <td>
                                <asp:DropDownList ID="ddlFunctionUser" runat="server" DataSourceID="UserFunctionSource" DataTextField="function_name" DataValueField="functionId" Height="16px" Width="126px">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td><asp:TextBox id="tbIdUser" runat="server" Visible="False"></asp:TextBox></td>
                            <td>
                                <asp:Button Text="Update" runat="server" class="btnDelete" ID="btnUserUpdateFunction" OnClick="btnUserUpdateFunction_Click"/>
                            </td>
                        </tr>
                    </table>
                    <asp:SqlDataSource ID="UserFunctionSource" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString2 %>" SelectCommand="SELECT * FROM [function]"></asp:SqlDataSource>
                </asp:Panel>
            </td>
        </tr>
     </table>
             </asp:Panel>
    <h2 class="highlight">Comments</h2>
    <table style="width:100%;">
        <tr>
            <td rowspan="3" colspan="3">
                <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" Width="700px">
                    <Columns>
                        <asp:BoundField DataField="idContact" HeaderText="Id comment" ReadOnly="True" SortExpression="idContact" />
                        <asp:BoundField DataField="text" HeaderText="Text" ReadOnly="True" SortExpression="text" />
                        <asp:BoundField DataField="date" HeaderText="Date and Time" ReadOnly="True" SortExpression="date" />
                        <asp:BoundField DataField="user" HeaderText="User" ReadOnly="True" SortExpression="user" />
                        <asp:TemplateField HeaderText="Delete">
                            <ItemTemplate>
                                <asp:Button ID="btnDeleteComment" runat="server" Text="Delete" class="btnDelete" commandName="btnDeleteComment" CommandArgument='<%# Eval("idContact") %>' OnClick="btnDeleteComment_Click"/>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </td>
        </tr>
    </table>
    <h2 class="highlight">Gallery</h2>
    <table style="width:100%;">
        <tr>
            <td colspan="3">
                    <table style="width:600px">
                        <tr>
                            <th class="auto-style9">Title</th>
                            <th class="auto-style8">Location</th>
                            <th>Operation</th>
                            <th>Result</th>
                        </tr>
                        <tr>
                            <td class="auto-style9">
                                <asp:TextBox ID="tbAddGallery" runat="server" Width="218px"></asp:TextBox>
                            </td>
                            <td class="auto-style8">
                                <asp:FileUpload ID="FileUploadImage" runat="server" />    
                            </td>
                            <td>
                                <asp:Button ID="btnAddGallery" class="btnDelete" runat="server" Text="Add" OnClick="btnAddGallery_Click" />
                            </td>
                            <td>

                                <asp:Label ID="lbAddGallery" runat="server" Text=""></asp:Label>

                            </td>
                        </tr>
                    </table>
            </td>
        </tr>
        <tr>
            <td rowspan="4" class="auto-style2">
                <asp:GridView ID="GridView3" runat="server" AutoGenerateColumns="False" Width="700px">
                    <Columns>
                        <asp:BoundField DataField="idGallery" HeaderText="Id Image" ReadOnly="True" SortExpression="idGallery" />
                        <asp:BoundField DataField="name" HeaderText="Name" ReadOnly="True" SortExpression="name" />
                        <asp:BoundField DataField="image" HeaderText="Location" ReadOnly="True" SortExpression="image" />
                        <asp:TemplateField HeaderText="Update">
                            <ItemTemplate>
                                <asp:Button ID="btnUpdateGallery" class="btnDelete"  UseSubmitBehavior="false" runat="server" Text="Update" CommandName="btnUpdateGallery" CommandArgument='<%# Eval("idGallery") + ";" + Eval("name") + ";" + Eval("image") %>' OnClick="btnUpdateGallery_Click"/>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Delete">
                            <ItemTemplate>
                                <asp:Button ID="btnDeleteGallery" class="btnDelete" runat="server"  Text="Delete" CommandName="btnDeleteGallery" CommandArgument='<%# Eval("idGallery") %>' OnClick="btnDeleteGallery_Click"/>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </td>
        </tr>
        <tr>
            <td rowspan="3">&nbsp;</td>
        </tr>
        <tr>
            <td rowspan="3">
                <asp:Panel ID="Panel2" runat="server">
                    <table style="width:100%;">
                        <tr>
                            <td class="auto-style3">Name:</td>
                            <td>
                                <asp:TextBox ID="tbGalName" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style3">Location:</td>
                            <td>
                                <asp:TextBox ID="tbGalLoc" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style3">
                                <asp:TextBox ID="tbGalId" runat="server" Visible="False" Width="51px"></asp:TextBox>
                            </td>
                            <td>
                                <asp:Button ID="btnUpdateGalleryFunction" class="btnDelete" runat="server" Text="Update" OnClick="btnUpdateGalleryFunction_Click" />
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
            </td>
        </tr>
    </table>
    <h2 class="highlight">About me section</h2>
    <table style="width:100%;">
        <tr>
            <td rowspan="3" class="auto-style4">
                <asp:GridView ID="GridView4" runat="server" AutoGenerateColumns="False" Width="701px">
                    <Columns>
                        <asp:BoundField DataField="idAbout" HeaderText="IdAbout" ReadOnly="True" SortExpression="idAbout" />
                        <asp:BoundField DataField="title" HeaderText="Title" ReadOnly="True" SortExpression="title" />
                        <asp:BoundField DataField="text" HeaderText="Text" ReadOnly="True" SortExpression="text" />
                        <asp:BoundField DataField="fb" HeaderText="Fb" ReadOnly="True" SortExpression="fb" />
                        <asp:BoundField DataField="insta" HeaderText="Insta" ReadOnly="True" SortExpression="insta" />
                        <asp:BoundField DataField="plus" HeaderText="GPlus" ReadOnly="True" SortExpression="plus" />
                        <asp:BoundField DataField="mail" HeaderText="Mail" ReadOnly="True" SortExpression="mail" />
                        <asp:TemplateField HeaderText="Update">
                            <ItemTemplate>
                                <asp:Button ID="btnUpdateAbout"  UseSubmitBehavior="false" class="btnDelete" runat="server" Text="Update" CommandName="btnUpdateAbout" CommandArgument='<%# Eval("idAbout")+ ";" + Eval("title")+ ";" + Eval("text")+ ";" + Eval("fb")+ ";" + Eval("insta")+ ";" + Eval("plus")+ ";" +Eval("mail") %>' OnClick="btnUpdateAbout_Click" />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </td>
        </tr>
        <tr>
            <td rowspan="3">&nbsp;</td>
        </tr>
        <tr>
            <td rowspan="3">
                <asp:Panel ID="Panel3" runat="server">
                    <table style="width:100%;">
                        <tr>
                            <td>Title:</td>
                            <td>
                                <asp:TextBox ID="tbAboutTitle" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>Text:</td>
                            <td>
                                <asp:TextBox ID="tbAboutText" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>Facebook:</td>
                            <td>
                                <asp:TextBox ID="tbAboutFacebook" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>Instagram:</td>
                            <td>
                                <asp:TextBox ID="tbAboutInstagram" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>GooglePlus:</td>
                            <td>
                                <asp:TextBox ID="tbAboutPlus" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>Mail:</td>
                            <td>
                                <asp:TextBox ID="tbAboutMail" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:TextBox ID="tbAboutId" runat="server" Visible="False"></asp:TextBox>
                            </td>
                            <td>
                                <asp:Button ID="btnUpdateAboutFunction" class="btnDelete" runat="server" Text="Update" OnClick="btnUpdateAboutFunction_Click" />
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
            </td>
        </tr>
     </table>
    <h2 class="highlight">Home section</h2>
    <table style="width:100%;">
        <tr>
            <td rowspan="3" class="auto-style4">
                <asp:GridView ID="GridView5" runat="server" AutoGenerateColumns="False" Width="700px">
                    <Columns>
                        <asp:BoundField DataField="idBlock" HeaderText="IdBlock" ReadOnly="True" SortExpression="idBlock" />
                        <asp:BoundField DataField="blockTitle" HeaderText="Title" ReadOnly="True" SortExpression="blockTitle" />
                        <asp:BoundField DataField="blockText" HeaderText="Text" ReadOnly="True" SortExpression="blockText" />
                        <asp:TemplateField HeaderText="Update">
                            <ItemTemplate>
                                <asp:Button ID="btnUpdateHome"  UseSubmitBehavior="false" class="btnDelete" runat="server" Text="Update" CommandName="btnUpdateHome" CommandArgument='<%# Eval("idBlock")+ ";" + Eval("blockTitle")+ ";" + Eval("blockText") %>' OnClick="btnUpdateHome_Click"/>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </td>
        </tr>
        <tr>
            <td rowspan="3">&nbsp;</td>
        </tr>
        <tr>
            <td rowspan="3">
                <asp:Panel ID="Panel4" runat="server">
                    <table style="width:100%;">
                        <tr>
                            <td>Title:</td>
                            <td>
                                <asp:TextBox ID="tbBlockTitle" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>Text:</td>
                            <td>
                                <asp:TextBox ID="tbBlockText" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:TextBox ID="tbBlockId" runat="server"></asp:TextBox>
                            </td>
                            <td>
                                <asp:Button ID="btnUpdateHomeFunction" class="btnDelete" runat="server" Text="Update" OnClick="btnUpdateHomeFunction_Click" />
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
            </td>
        </tr>
     </table>
    <h2 class="highlight">History page</h2>
    <table style="width:100%;">
        <tr>
            <td rowspan="3" class="auto-style4">
                <asp:GridView ID="GridView6" runat="server" AutoGenerateColumns="False" Width="700px">
                    <Columns>
                        <asp:BoundField DataField="idHistory" HeaderText="Id" ReadOnly="True" SortExpression="idHistory" />
                        <asp:BoundField DataField="title" HeaderText="Title" ReadOnly="True" SortExpression="title" />
                        <asp:BoundField DataField="text" HeaderText="Text" ReadOnly="True" SortExpression="text" />
                        <asp:TemplateField HeaderText="Update">
                            <ItemTemplate>
                                <asp:Button ID="btnUpdateHistory" UseSubmitBehavior="false" class="btnDelete" runat="server" Text="Update" CommandName="btnUpdateHistory" CommandArgument='<%# Eval("idHistory")+ ";" + Eval("title")+ ";" + Eval("text") %>' OnClick="btnUpdateHistory_Click" />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </td>
        </tr>
        <tr>
            <td rowspan="3">&nbsp;</td>
        </tr>
        <tr>
            <td rowspan="3">
                <asp:Panel ID="Panel5" runat="server">
                    <table style="width:100%;">
                        <tr>
                            <td>Title:</td>
                            <td>
                                <asp:TextBox ID="tbHistoryTitle" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>Text:</td>
                            <td>
                                <asp:TextBox ID="tbHistoryText" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:TextBox ID="tbHistoryId" runat="server"></asp:TextBox>
                            </td>
                            <td>
                                <asp:Button ID="btnUpdateHistoryFunction" class="btnDelete" runat="server" Text="Update" OnClick="btnUpdateHistoryFunction_Click" />
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
            </td>
        </tr>
     </table>
    <h2 class="highlight">Price page</h2>
    <table style="width:100%;">
        <tr>
            <td rowspan="3" class="auto-style4">
                <asp:GridView ID="GridView7" runat="server" AutoGenerateColumns="False" Width="700px">
                    <Columns>
                        <asp:BoundField DataField="idPrice" HeaderText="Id" ReadOnly="True" SortExpression="idPrice" />
                        <asp:BoundField DataField="title" HeaderText="Title" ReadOnly="True" SortExpression="title" />
                        <asp:BoundField DataField="text" HeaderText="Text" ReadOnly="True" SortExpression="text" />
                        <asp:TemplateField HeaderText="Update">
                            <ItemTemplate>
                                <asp:Button ID="btnUpdatePrice"  UseSubmitBehavior="false" class="btnDelete" runat="server" Text="Update" CommandName="btnUpdatePrice" CommandArgument='<%# Eval("idPrice")+ ";" + Eval("title")+ ";" + Eval("text") %>' OnClick="btnUpdatePrice_Click" />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </td>
        </tr>
        <tr>
            <td rowspan="3">&nbsp;</td>
        </tr>
        <tr>
            <td rowspan="3">
                <asp:Panel ID="Panel6" runat="server">
                    <table style="width:100%;">
                        <tr>
                            <td>Title:</td>
                            <td>
                                <asp:TextBox ID="tbPriceTitle" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>Text:</td>
                            <td>
                                <asp:TextBox ID="tbPriceText" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:TextBox ID="tbPriceId" runat="server"></asp:TextBox>
                            </td>
                            <td>
                                <asp:Button ID="btnUpdatePriceFunction" class="btnDelete" runat="server" Text="Update" OnClick="btnUpdatePriceFunction_Click" />
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
            </td>
        </tr>
     </table>
    <h2 class="highlight">ModernDay page</h2>
    <table style="width:100%;">
        <tr>
            <td rowspan="3" class="auto-style5">
                <asp:GridView ID="GridView8" runat="server" AutoGenerateColumns="False" Width="700px">
                    <Columns>
                        <asp:BoundField DataField="idModernDay" HeaderText="Id" ReadOnly="True" SortExpression="idModernDay" />
                        <asp:BoundField DataField="title" HeaderText="Title" ReadOnly="True" SortExpression="title" />
                        <asp:BoundField DataField="text" HeaderText="Text" ReadOnly="True" SortExpression="text" />
                        <asp:TemplateField HeaderText="Update">
                            <ItemTemplate>
                                <asp:Button ID="btnUpdateModern"  UseSubmitBehavior="false" class="btnDelete" runat="server" Text="Update" CommandName="btnUpdateModern" CommandArgument='<%# Eval("idModernDay")+ ";" + Eval("title")+ ";" + Eval("text") %>' OnClick="btnUpdateModern_Click" />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </td>
        </tr>
        <tr>
            <td rowspan="3">&nbsp;</td>
        </tr>
        <tr>
            <td rowspan="3">
                <asp:Panel ID="Panel7" runat="server">
                    <table style="width:100%;">
                        <tr>
                            <td>Title:</td>
                            <td>
                                <asp:TextBox ID="tbModernTitle" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>Text:</td>
                            <td>
                                <asp:TextBox ID="tbModernText" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:TextBox ID="tbModernId" runat="server"></asp:TextBox>
                            </td>
                            <td>
                                <asp:Button ID="btnUpdateModernFunction" class="btnDelete" runat="server" Text="Update" OnClick="btnUpdateModernFunction_Click" />
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
            </td>
        </tr>
     </table>  
</form>
</section>
</asp:Content>
