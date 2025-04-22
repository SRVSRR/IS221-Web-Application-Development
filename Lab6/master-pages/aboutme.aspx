<%@ Page Title="About Me" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPages/University.Master" CodeBehind="aboutme.aspx.vb" Inherits="master_pages.WebForm2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
   
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contentArea" runat="server">
        <h1>Hi, I'm Anav Chand (HTML5)</h1>

    <!-- Inline CSS -->
    <p style="font-size: 25px; text-align: center;">
        I am an aspiring DevOps engineer, <em>self-taught web developer</em>, second-year software engineering student,
        and <strong>award-winning peer mentor</strong> at the
        <a href="https://usp.ac.fj">University of the South Pacific</a>.
    </p>

    <h2>My Courses</h2>

    <ol>
        <li>IS221 - Web Application Development</li>
        <li>IS222 - Database Management Systems</li>
        <li>CS211 - Computer Architecture</li>
        <li>CS230 - Requirements Engineering</li>
    </ol>

    <h2>My Websites</h2>

    <ul>
        <li>
            <a target="_blank" href="https://www.anav.dev">My Personal Website</a>
        </li>
        <li>
            <a target="_blank" href="https://links.anav.dev">My Links Website</a>
        </li>
        <li>
            <a target="_blank" href="https://quotes.anav.dev">My Quotes Website</a>
        </li>
        <li>
            <a target="_blank" href="https://www.cs000.dev">My Open Source Course</a>
        </li>
    </ul>

    <h2>My Hobbies</h2>

    <figure>
        <img src="images/chess.jpg" alt="Chess" title="Chess" height="300" width="300" />
        <figcaption>Chess</figcaption>
    </figure>

    <figure>
        <img src="images/games.jpg" alt="Chess" title="Chess" height="300" width="300" />
        <figcaption>Games</figcaption>
    </figure>
</asp:Content>
