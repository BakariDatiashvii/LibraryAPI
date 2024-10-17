using LibraryAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Oracle.ManagedDataAccess.Client;
using System.Configuration;
using System.Data;

namespace LibraryAPI.Librarymanagmen
{
    public class PKG_Library_BD : PKG_BASE, IPKG_Managment
    {
        public PKG_Library_BD(IConfiguration configuration) : base(configuration)
        {
        }

        public IActionResult addbooks(addbookDTO books)
        {
            using (OracleConnection con = new OracleConnection(Connstr))
            {
                con.Open(); 
                using (OracleCommand cmd = new OracleCommand("PKG_BAKARI_LIBRARY.add_books_bd", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("p_NAME", OracleDbType.Varchar2).Value = books.Name;
                    cmd.Parameters.Add("p_QUANTITY", OracleDbType.Int32).Value = books.Quantity;
                    cmd.Parameters.Add("p_AUTHOR", OracleDbType.Varchar2).Value = books.Author;
                    cmd.Parameters.Add("p_PRICE", OracleDbType.Int32).Value = books.Price;
                    cmd.Parameters.Add("p_MANAGERBOOKID", OracleDbType.Int32).Value = 1;
                    cmd.Parameters.Add("p_USERBOOKID", OracleDbType.Int32).Value = 1;

                    cmd.ExecuteNonQuery();


                    return new OkResult();
                }
            }
        }


        public IActionResult GetAllBooks()
        {
            List<BookDTO> books = new List<BookDTO>();

            using (OracleConnection con = new OracleConnection(Connstr))
            {
                con.Open();
                using (OracleCommand cmd = new OracleCommand("PKG_BAKARI_LIBRARY.get_all_books_bd", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    // Use an output parameter for the cursor
                    var cursor = cmd.Parameters.Add("p_book_cursor", OracleDbType.RefCursor);
                    cursor.Direction = ParameterDirection.Output;

                    using (OracleDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            books.Add(new BookDTO
                            {
                                Name = reader.GetString(0),
                                Quantity = reader.GetInt32(1),
                                Author = reader.GetString(2),
                                Price = reader.GetDecimal(3),
                                ManagerBookId = reader.GetInt32(4),
                                UserBookId = reader.GetInt32(5)
                            });
                        }
                    }
                }
            }

            return new OkObjectResult(books);
        }
    }
}

       
    

