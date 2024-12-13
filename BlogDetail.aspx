<%@ Page Title="" Language="C#" MasterPageFile="~/OtherPage.master" AutoEventWireup="true" CodeFile="BlogDetail.aspx.cs" Inherits="BlogDetail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <section class="page-head">
        <div class="container">
            <div class="row">
                <div class="col-md-12">
                    <ul class="breadcrumb">
                        <li><a href="Index.aspx">Home</a></li>
                        <li>Blog Details</li>
                    </ul>
                    <h1>Blog Details</h1>
                </div>
            </div>
        </div>
    </section>

    <section class="blog-list">
        <div class="blog-content">
            <div class="container">
                <div class="row">
                    <asp:ListView ID="lstblog" runat="server">
                        <ItemTemplate>
                            <div class="col-md-12">
                                <div class="blog-post text-page">
                                    <div class="img-wrap">
                                        <img class="img-responsive" src="img/Blog/<%# Eval("image") %>" alt="Blog- Formula Chai"></div>
                                    <div class="item-info">
                                        <div class="date"><i class="fa fa-clock-o" aria-hidden="true"></i><%# Eval("ndate") %></div>
                                        <div class="like"><i class="fa fa-heart" aria-hidden="true"></i>12</div>
                                        <div class="comm"><i class="fa fa-commenting" aria-hidden="true"></i>3</div>
                                    </div>
                                    <p><strong><%# Eval("title") %></strong></p>
                                    <p><%# Eval("description") %></p>


                                </div>
                            </div>
                        </ItemTemplate>
                    </asp:ListView>
                </div>
            </div>
        </div>
    </section>
</asp:Content>

