﻿<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="QuerySample.WebForm40._Default" %>

<%@ Register TagPrefix="query" Namespace="Query.Web" Assembly="Query.Web" %>

<asp:Content runat="server" ID="FeaturedContent" ContentPlaceHolderID="FeaturedContent">
</asp:Content>
<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <query:GridExtender ID="GridExtender" runat="server" GridViewId="GridView" AutoFilterDelay="2000" Placeholder="Filter..."
                        OnFilter="GridExtender_Filter" OnSort="GridExtender_Sort" />
    <asp:GridView ID="GridView" runat="server" AutoGenerateColumns="False" ShowHeaderWhenEmpty="True" AllowPaging="True" AllowSorting="False" PageSize="8">
        <Columns>
            <query:TextField Name="FullName" HeaderText="Full name" OnClick="FullName_Click" />
            
            <query:TextField Name="Nombre" HeaderText="Nombre"
                             UrlFormat="https://www.google.com.ar/search?q={0} {1}" UrlFields="Nombre, Apellido" />
            <query:TextField Name="Apellido" HeaderText="Apellido" />
            <query:TextField Name="Dni" HeaderText="Dni" Format="N0" />
            <query:DropDownField Name="EstadoCivil" HeaderText="Estado civil" />
            <query:TextField Name="Edad" HeaderText="Edad" />
            <query:TextField Name="Salario" HeaderText="Salario" Format="C" />
            <query:DateField Name="FechaNacimiento" HeaderText="Fecha Nacimiento" Format="d" />
            <query:TextField Name="AttachmentCount" HeaderText="Number of attachments" />
            <query:TextField Name="Cuit" HeaderText="CUIT" />
            <query:TextField Name="AverageHourlyWage" HeaderText="Wage" />
            <query:DynamicField Name="Dynamic" HeaderText="Dynamic" Format="d" OnClick="Dynamic_Click">
            </query:DynamicField>
        </Columns>
        <PagerSettings Mode="NumericFirstLast" PageButtonCount="4"  FirstPageText="First" LastPageText="Last"/>
    </asp:GridView>
    <asp:LinkButton runat="server" OnClick="Link_Click" ID="Link" Text="Link"></asp:LinkButton>
    <asp:ObjectDataSource ID="OdsEmpleado" runat="server" EnablePaging="True"
                          SelectMethod="GetAll" SelectCountMethod="GetCount"
                          MaximumRowsParameterName="maximumRows"
                          StartRowIndexParameterName="startRowIndex"
                          TypeName="QuerySample.WebForm40.EmpleadoService"
                          OnObjectCreating="OdsEmpleado_ObjectCreating"
                          OnSelecting="OdsEmpleado_ObjectSelecting"
                          OnSelected="OdsEmpleado_ObjectSelected" />
</asp:Content>
