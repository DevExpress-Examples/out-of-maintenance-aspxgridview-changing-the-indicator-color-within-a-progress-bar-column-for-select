using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using DevExpress.Web.ASPxEditors;
using DevExpress.Web.ASPxGridView;

public partial class _Default : System.Web.UI.Page 
{
    protected void Page_Load(object sender, EventArgs e) {
        //Create the grid's data source on the first load
        if (!IsPostBack && !IsCallback) Session["GridDataSource"] = CreateDataSource();

        //Populate the grid with data on each page load
        if (Session["GridDataSource"] != null){
            ASPxGridView1.DataSource = Session["GridDataSource"] as DataTable;
            ASPxGridView1.DataBind();
        }

    }

    private DataTable CreateDataSource() {
        DataTable dataTable = new DataTable("Tasks");
        dataTable.Columns.Add("ID", typeof(int));
        dataTable.Columns.Add("Name", typeof(string));
        dataTable.Columns.Add("Complete", typeof(decimal));
        dataTable.PrimaryKey = new DataColumn[] { dataTable.Columns["ID"] };
        Random r = new Random();
        for (int i = 0; i < 15; i++){
            dataTable.Rows.Add(new object[] { i, "Task " + i, r.Next(0, 100) });
        }
        return dataTable;
    }

    protected void ASPxProgressBar1_Load(object sender, EventArgs e) {
        ASPxProgressBar progressBar = (ASPxProgressBar)sender;
        GridViewDataItemTemplateContainer container = (GridViewDataItemTemplateContainer)progressBar.Parent;
        if (ASPxGridView1.Selection.IsRowSelectedByKey(container.KeyValue))
            progressBar.IndicatorStyle.BackColor = System.Drawing.Color.Red;
    }
}
