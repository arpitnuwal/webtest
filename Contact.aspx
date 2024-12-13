<%@ Page Title="" Language="C#" MasterPageFile="~/OtherPage.master" AutoEventWireup="true" CodeFile="Contact.aspx.cs" Inherits="Contact" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <section class="page-head">
        <div class="container">
            <div class="row">
                <div class="col-md-12">
                    <ul class="breadcrumb">
                        <li><a href="Index.aspx">Home</a></li>
                        <li>Contacts</li>
                    </ul>
                    <h1>Contacts</h1>
                </div>
            </div>
        </div>
    </section>
    <!-- CONTACTS -->
    <div class="contact-wrap">
        <div class="container">
            <div class="row">
                <div class="col-md-6">
                    <div class="contact-left">
                        <h2>Contacts</h2>
                        <div class="item">
                            <div class="title"><i class="fa fa-location-arrow" aria-hidden="true"></i>ADDRESS</div>
                            <p>Riico Industrial Area, Bhilwara, Rajasthan, 311001</p>
                        </div>
                        <div class="item">
                            <div class="title"><i class="fa fa-phone" aria-hidden="true"></i>PHONE</div>
                            <p>+91 902-427-9377</p>

                            <p>+91 931-455-6630</p>
                            <p>+91 869-030-5654</p>
                        </div>
                        <div class="item">
                            <div class="title"><i class="fa fa-envelope-o" aria-hidden="true"></i>EMAIL</div>
                            <p><a href="mailto:formulachay@gmail.com">formulachay@gmail.com</a></p>
                        </div>
                        <div class="item">
                            <div class="title"><i class="fa fa-skype" aria-hidden="true"></i>SKYPE</div>
                            <p><a href="callto:mrcoffee">mrcoffee</a></p>
                        </div>
                    </div>
                </div>
                <div class="col-md-6">
                    <div class="contact-right">
                        <h2>Send Message</h2>
                        <div class="contact-form">
                            <div class="row">
                                <div class="col-md-12">
                                    <asp:TextBox ID="txtmsg" TextMode="MultiLine" Rows="3" required="" placeholder="Your Comment *" runat="server"></asp:TextBox>

                                </div>
                                <div class="col-md-6">
                                    <asp:TextBox ID="txtname" placeholder="Your Name " class="contact-input" runat="server"></asp:TextBox>

                                </div>
                                <div class="col-md-6">
                                    <asp:TextBox ID="txtemail" placeholder="Your Email *" required="" class="contact-input" runat="server"></asp:TextBox>


                                </div>
                                  <div class="col-md-6">
                                    <asp:TextBox ID="txtphone" placeholder="Your phone *" MaxLength="10" MinLength="10" required="" class="contact-input" runat="server"></asp:TextBox>


                                </div>
                                 <div class="col-md-6">
                                    <asp:TextBox ID="txtsubject" placeholder="Your Subject "  class="contact-input" runat="server"></asp:TextBox>


                                </div>
                                <div class="col-md-12 text-center">
                                   
                                    <button runat="server" onserverclick="Unnamed_ServerClick">SUBMIT</button>
                                    <asp:Label ID="lblerror" ForeColor="Red"  runat="server" Text=""></asp:Label>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <!-- CONTACTS END -->

    <!-- MAP -->
    <div>
        <iframe src="https://www.google.com/maps/embed?pb=!1m17!1m12!1m3!1d3371.5541291349314!2d74.581612075386!3d25.326301677628106!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m2!1m1!2s!5e1!3m2!1sen!2sin!4v1733901393928!5m2!1sen!2sin" width="100%" height="450" style="border: 0;" allowfullscreen="" loading="lazy" referrerpolicy="no-referrer-when-downgrade"></iframe>
    </div>

    <!-- MAP END -->
</asp:Content>

