﻿using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;
using Query.Sample.Model;
using QueryTables.Common.Extension;
using QueryTables.Web;
using SortDirection = QueryTables.Common.SortDirection;

namespace QuerySample.WebForm40
{
    public partial class _Default : Page
    {
        protected void Page_Init(object sender, EventArgs e)
        {
            // Databind of a drop down filter. The value of the ListItem will be the value of the filter.
            // No need to include the empty option, it will be added automatically.
            var field = (DropDownField)this.GridView.Columns[4];
            field.Items = new List<ListItem>
                {
                    new ListItem("Soltero", EstadoCivil.Soltero.ToOrdinalString()),
                    new ListItem("Casado", EstadoCivil.Casado.ToOrdinalString()),
                    new ListItem("Separado", EstadoCivil.Separado.ToOrdinalString()),
                    new ListItem("Casado/Separado", "10"),
                    new ListItem("Divorciado", EstadoCivil.Divorciado.ToOrdinalString()),
                    new ListItem("Viudo", EstadoCivil.Viudo.ToOrdinalString()),
                };

            var dynField = (DynamicField) this.GridView.Columns[11];
            dynField.FieldType = FieldType.List;
            dynField.Items = new List<ListItem>
            {
                new ListItem("Opcion 1", "-1"),
                new ListItem("Opcion 2", "-2"),
            };
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.IsPostBack)
            {
                return;
            }

            // initial filters
            this.GridExtender.Filters = new Dictionary<string, string>
                {
                    {"EstadoCivil", EstadoCivil.Casado.ToOrdinalString()},
                };

            // initial sortings
            this.GridExtender.Sortings = new List<KeyValuePair<string, SortDirection>>
                {
                    new KeyValuePair<string, SortDirection>("Salario", SortDirection.Descending),
                    new KeyValuePair<string, SortDirection>("Edad", SortDirection.Ascending),
                    new KeyValuePair<string, SortDirection>("Dynamic", SortDirection.Ascending)
                };

            this.GridView.DataSourceID = this.OdsEmpleado.ID;
            this.GridView.DataBind();
        }

        protected void GridExtender_Filter(object sender, EventArgs e)
        {
            this.GridView.DataSourceID = this.OdsEmpleado.ID;
            this.GridView.PageIndex = 0;
            this.GridView.DataBind();
        }

        protected void GridExtender_Sort(object sender, EventArgs e)
        {
            this.GridView.DataSourceID = this.OdsEmpleado.ID;
            this.GridView.DataBind();
        }

        protected void OdsEmpleado_ObjectCreating(object sender, ObjectDataSourceEventArgs e)
        {
            e.ObjectInstance = new EmpleadoService();
        }

        protected void OdsEmpleado_ObjectSelecting(object sender, ObjectDataSourceSelectingEventArgs e)
        {
            e.InputParameters["filters"] = this.GridExtender.Filters;
            e.InputParameters["sortings"] = this.GridExtender.Sortings;
        }

        protected void OdsEmpleado_ObjectSelected(object sender, ObjectDataSourceStatusEventArgs e)
        {

        }

        protected void FullName_Click(object sender, EventArgs e)
        {
            this.Response.Redirect("http://www.google.com.ar", true);
        }

        protected void Link_Click(object sender, EventArgs e)
        {
            
        }

        protected void Dynamic_Click(object sender, EventArgs e)
        {
            this.Response.Redirect("http://www.yahoo.com.ar", true);
        }
    }
}