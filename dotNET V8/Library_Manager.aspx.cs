using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Data.SqlClient;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using System.Xml.Linq;
using System.Configuration;
using dotNET_V8.Models;
using System.Data;
using System.Drawing;

namespace dotNET_V8
{
    public partial class Library_Manager : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }
        protected void btnWrite_Click(object sender, EventArgs e)
        {
            try
            {
                LibraryContext DB = new LibraryContext();
                Book book = new Book();
                Search search = new Search();
                try {
                    book.ID = Convert.ToInt32(tbID.Text);
                    errID.Visible = false;
                } catch {
                    errID.Visible = true;
                }
                if (tbName.Text != "")
                {
                    try
                    {
                        book.Name = tbName.Text;
                        errName.Visible = false;
                    }
                    catch
                    {
                        errName.Visible = true;
                    }
                }
                else
                    errName.Visible = true;
                try {
                    book.ShortDesc = tbDesc.Text;
                    errDesc.Visible = false;
                } catch {
                    errDesc.Visible = true;
                }
                try {
                    book.ReleaseYear = Convert.ToInt32(tbReleaseYear.Text);
                    errReleaseYear.Visible = false;
                } catch {
                    errReleaseYear.Visible = true;
                } 
                try {
                    book.ManufactureCode = Convert.ToInt32(tbManufactureCode.Text);
                    errManufactureCode.Visible = false;
                } catch {
                    errManufactureCode.Visible = true;
                } 
                try {
                    book.AuthorCode = Convert.ToInt32(tbAuthorCode.Text);
                    errAuthorCode.Visible = false;
                } catch {
                    errAuthorCode.Visible = true;
                } 
                try {
                    book.StorageCode = Convert.ToInt32(tbStorageCode.Text);
                    errStorageCode.Visible = false;
                } catch {
                    errStorageCode.Visible = true;
                }

                if (search.isReal(book.ID))
                {
                    DB.Book.Update(book);
                }
                else
                    DB.Book.Add(book);
                DB.SaveChanges();
                /*tbID.Text = "";
                tbName.Text = "";
                tbDesc.Text = "";
                tbReleaseYear.Text = "";
                tbManufactureCode.Text = "";
                tbAuthorCode.Text = "";
                tbStorageCode.Text = "";*/
            }
            catch {
            }
            LibraryDB.EnableCaching = false;
            GridView1.DataBind();
            LibraryDB.EnableCaching = true;
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            Search Search = new Search();
            string[] result = Search.searchByName(tbName.Text);
            MessageBox.Show($"ID = {result[0]}, Name = {result[1]}, Desc = {result[2]}");
        }

        protected void btnRemove_Click(object sender, EventArgs e)
        {
            LibraryContext DB = new LibraryContext();
            Book book = new Book();
            Search search = new Search();
            if (tbID.Text != null)
                book.ID = Convert.ToInt32(tbID.Text);
            if (search.isReal(book.ID))
            {
                DB.Book.Remove(book);
                DB.SaveChanges();
            }
            LibraryDB.EnableCaching = false;
            GridView1.DataBind();
            LibraryDB.EnableCaching = true;
        }

        protected void btnGet_Click(object sender, EventArgs e)
        {
            string con = ConfigurationManager.ConnectionStrings["LibraryDB"].ToString();
            Book matchingBook = new Book();
            try
            {
                using (SqlConnection myConnection = new SqlConnection(con))
                {
                    string oString = "Select * from Book where ID=@ID";
                    SqlCommand oCmd = new SqlCommand(oString, myConnection);
                    oCmd.Parameters.AddWithValue("@ID", tbID.Text);
                    myConnection.Open();
                    using (SqlDataReader oReader = oCmd.ExecuteReader())
                    {
                        while (oReader.Read())
                        {
                            tbName.Text = oReader["Name"].ToString();
                            tbDesc.Text = oReader["ShortDesc"].ToString();
                            tbReleaseYear.Text = oReader["ReleaseYear"].ToString();
                            tbManufactureCode.Text = oReader["ManufactureCode"].ToString();
                            tbAuthorCode.Text = oReader["AuthorCode"].ToString();
                            tbStorageCode.Text = oReader["StorageCode"].ToString();
                        }
                        myConnection.Close();
                    }
                }
                errID.Visible = false;
            }
            catch
            {
                errID.Visible = true;
            }
        }
    }
}