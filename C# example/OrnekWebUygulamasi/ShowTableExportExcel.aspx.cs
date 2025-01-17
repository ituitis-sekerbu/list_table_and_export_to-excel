﻿
using ClosedXML.Excel;
using DocumentFormat.OpenXml.Drawing.Charts;
using Microsoft.Azure.Management.Batch.Fluent;
using Microsoft.Office.Interop.Excel;
using OfficeOpenXml;
using System;
using System.Data.SqlClient;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Runtime;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using DataTable = System.Data.DataTable;

namespace OrnekWebUygulamasi
{
    public partial class Default : System.Web.UI.Page
    {
        private DataTable dt  = new DataTable();
        private DataTable xx = new DataTable();

        private string connectionString = "Server=ATEZ006;Database=selam;Trusted_Connection=True;";

        protected void Page_Load(object sender, EventArgs e)
        {   

            int check = Check_is_login();
            if (check == 0)
            {
                Response.Redirect("Login.aspx");
            }
        }
        protected void btnConnectDB_Click(object sender, EventArgs e)
        {
            
            
            Create_dt();
            Liste.DataSource = dt;
            Liste.DataBind();
            
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Response.Redirect("Register.aspx");
        }

        protected void LinkButton2_Click(object sender, EventArgs e)
        {
              
            Create_dt();
            Write_to_Excel();
        
        }

        private void Write_to_Excel()
        {
           ExcelPackage.LicenseContext = LicenseContext.Commercial;
            using (ExcelPackage excel = new ExcelPackage())
            {
                ExcelWorksheet worksheet1 = excel.Workbook.Worksheets.Add("Worksheet1");
                worksheet1.Cells["A1"].LoadFromDataTable(dt, true);
                worksheet1.Cells[worksheet1.Dimension.Address].AutoFitColumns();
                        
                DateTime currentDateTime = DateTime.Now;
                string filename = @"C:\Users\"+ Environment.UserName+"\\output" + DateTime.Now.ToString("yyyy-dd-M--HH-mm-ss") + ".xlsx";
                FileInfo excelFile = new FileInfo(filename);
                excel.SaveAs(excelFile);
 
                string message = "Excel file is recorded on " + filename;

                System.Windows.Forms.MessageBox.Show(message, "Prompt", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);

                Process.Start(filename);
                
            }
        }

        private void Create_dt()
        {
            

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                
                using (SqlCommand cmd = new SqlCommand())
                {

                    SqlDataAdapter da = new SqlDataAdapter(@"SELECT *
                                                            FROM users", connectionString);
                    da.Fill(dt);
                }
            }
        }
        protected void gvProducts_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            // Gridview'in PageIndexChanging Eventında grid'in PageIndex'ine seçilen
            // sayfanın numarası atanır.
            Liste.PageIndex = e.NewPageIndex;

            // Tekrar kayıtların gridview'e aktarılması sağlanır.
            Create_dt();
            Liste.DataSource = dt;
            Liste.DataBind();
        }

        protected void LinkButton3_Click(object sender, EventArgs e)
        {
            Disable_Auth();
            Response.Redirect("Login.aspx");
        }

        private void Disable_Auth()
        {

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string user__name = Session["Send"].ToString();

                SqlDataAdapter da = new SqlDataAdapter(@"Update users Set IsAuth = 0
                                                    where IsAuth = 1 and Username = '" + user__name + "'", connection);

                da.Fill(dt);

                connection.Close();

            }
        }

        private int Check_is_login()
        {

            using (SqlConnection connection = new SqlConnection(connectionString))
            {

                string user__name = Session["Send"].ToString();
                Label1.Text = user__name;

                SqlDataAdapter da = new SqlDataAdapter(@"Select * from users
                                                    where IsAuth = 1 and Username = '" + user__name + "'" , connection);

                da.Fill(xx);

                return xx.Rows.Count;
            }
        }
    }
}
    
