﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace BarcodeTracking.Biz
{
    public class DapperHelper
    {
        public static SqlConnection SqlConnection()
        {
            string sqlconnectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ToString();
            var connection = new SqlConnection(sqlconnectionString);
            connection.Open();
            return connection;
        }
        //public static MySqlConnection MySqlConnection()
        //{
        //    string mysqlconnectionString = ConfigurationManager.ConnectionStrings["mysqlconnectionString"].ToString();
        //    var connection = new MySqlConnection(mysqlconnectionString);
        //    connection.Open();
        //    return connection;
        //}
    }
}
