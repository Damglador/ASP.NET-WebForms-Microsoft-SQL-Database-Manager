using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;
using dotNET_V8.Models;

namespace dotNET_V8
{
    public class Search
    {
        string con = ConfigurationManager.ConnectionStrings["LibraryDB"].ToString();
        public string[] searchByName(string Name)
        {
            Book matchingBook = new Book();
            using (SqlConnection myConnection = new SqlConnection(con))
            {
                string oString = "Select * from Book where Name=@Name";
                SqlCommand oCmd = new SqlCommand(oString, myConnection);
                oCmd.Parameters.AddWithValue("@Name", Name);
                myConnection.Open();
                using (SqlDataReader oReader = oCmd.ExecuteReader())
                {
                    while (oReader.Read())
                    {
                        matchingBook.ID = int.Parse(oReader["ID"].ToString());
                        matchingBook.Name = oReader["Name"].ToString();
                        matchingBook.ShortDesc = oReader["ShortDesc"].ToString();
                        matchingBook.ReleaseYear = int.Parse(oReader["ReleaseYear"].ToString());
                        matchingBook.ManufactureCode = int.Parse(oReader["ManufactureCode"].ToString());
                        matchingBook.AuthorCode = int.Parse(oReader["AuthorCode"].ToString());
                        matchingBook.StorageCode = int.Parse(oReader["StorageCode"].ToString());
                    }

                    myConnection.Close();
                }
            }
            string[] theBook = {
                Convert.ToString(matchingBook.ID),
                matchingBook.Name,
                matchingBook.ShortDesc,
                Convert.ToString(matchingBook.ReleaseYear),
                Convert.ToString(matchingBook.ManufactureCode),
                Convert.ToString(matchingBook.AuthorCode),
                Convert.ToString(matchingBook.StorageCode)
            };
            return theBook;
        }
        public bool isReal(int ID)
        {
            Book matchingBook = new Book();
            using (SqlConnection myConnection = new SqlConnection(con))
            {
                string oString = "Select * from Book where ID=@ID";
                SqlCommand oCmd = new SqlCommand(oString, myConnection);
                oCmd.Parameters.AddWithValue("@ID", ID);
                myConnection.Open();
                using (SqlDataReader oReader = oCmd.ExecuteReader())
                {
                    while (oReader.Read())
                    {
                        matchingBook.ID = int.Parse(oReader["ID"].ToString());
                    }

                    myConnection.Close();
                }
            }
            if (matchingBook.ID != 0)
            {
                return true;
            } else 
                return false;
        }
    }
}