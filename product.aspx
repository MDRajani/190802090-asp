<%@ Page Title="" Language="C#" MasterPageFile="~/ClientMasterPage.master" AutoEventWireup="true"
    CodeFile="product.aspx.cs" Inherits="Default4" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <form id="form1" runat="server">
    <!-- Service Start -->
    <div class="container-xxl py-5">
        <div class="container py-5 px-lg-5">
            <div class="wow fadeInUp" data-wow-delay="0.1s">
                <p class="section-title text-secondary justify-content-center">
                    <span></span>Our Services</p>
                <h1 class="text-center mb-5">
                    What Solutions We Provide</h1>
            </div>
            <div class="row g-4">
                        <asp:Repeater ID="Repeater1" runat="server">
                        <ItemTemplate>
                            <div class="col-lg-4 col-sm-6">
                                <div class="grids-1">
                                    <div class="icon-style">
                                        <i class="fas fa-chart-pie"></i>
                                    </div>
                                    <h4 class="title-head mb-2">
                                        <a href="#">
                                            <%# Eval("ser_title") %>
                                        </a>
                                    </h4>
                                    <p>
                                        <%# Eval("ser_description") %></p>
                                    <a href="#" class="btn btn-style btn-style-primary mt-4">Read More<i class="fas fa-arrow-right ms-1"></i></a>
                                </div>
                            </div>
                        </ItemTemplate>
                    </asp:Repeater>
            </div>
        </div>
    </div>
    <!-- Service End -->
    </form>
</asp:Content>
