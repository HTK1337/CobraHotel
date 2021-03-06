﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Model;
using System.Data.SqlClient;

namespace DAL
{
    public class CustomerDAL
    {

        public static void CreateCustomer()
        {
            DBUtil conn = new DBUtil();
            SqlConnection myConnection = conn.connection();
            try
            {
                SqlCommand myCommand = new SqlCommand("INSERT INTO dbo.customer (pnr, name, email, phone, address) " +
                                    "Values (941223331222, 'Otto', 'fredriksson.otto@gmail.com', 0732206670, 'NotarieG')", myConnection);
                myCommand.ExecuteNonQuery();
                Console.WriteLine("Efter SQL");
            }
            catch (SqlException)
            {
                //ERROR
                Console.Write("Kunde inte skapa kund.");
            }
            conn.closeConn(myConnection);
        }

        public Customer ShowCustomer(string pnr)
        {
            DBUtil conn = new DBUtil();
            SqlConnection myConnection = conn.connection();
            try
            {
                Customer c = new Customer();
                SqlDataReader myReader = null;
                SqlCommand myCommand = new SqlCommand("select * from customer where pnr = " + pnr,
                                                         myConnection);
                myReader = myCommand.ExecuteReader();
                while (myReader.Read())
                {
                    c.Pnr = myReader["pnr"].ToString();
                    c.Name = myReader["name"].ToString();
                    c.Email = myReader["email"].ToString();
                    c.Phone = myReader["phone"].ToString();
                    c.Address = myReader["address"].ToString();
                }
                return c;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
            return null;
        }
    }
}
