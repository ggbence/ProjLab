﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool
//     Changes to this file will be lost if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;

public class DaO
{
    private MySqlConnection conn;
    
    protected MySqlConnection Conn
    {
        get { return conn; }
    }
	

	private const string server = "mysql12.iworx-host.com";

	private const string user = "bandhu_zenekar";

	private const string password = "zenekarmanager123";

	private const string database = "bandhu_zenekarmanager";
    
    private const string port = "3306";

    private const string charset = "utf8";


    public DaO()
    {
        string connectionString;
        connectionString = "server="+server+";uid="+user+";" +
            "pwd="+password+";database="+database+";port="+port+";Charset="+charset+";";

        try
        {
            conn = new MySqlConnection();
            conn.ConnectionString = connectionString;
            conn.Open();
        }
        catch (MySqlException ex)
        {
            switch (ex.Number)
            {
                case 0:
                    Console.WriteLine("Cannot connect to server. Contact administrator");
                    break;
                case 1045:
                    Console.WriteLine("Invalid username/password. Contact administrator");
                    break;
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Hiba." + ex.Message.ToString());
        }

    }

    ~DaO()
    {
        try
        {
            if (conn != null)
            {
                conn.Close();
            }
        }
        finally
        {
            if (conn != null)
            {
                conn.CloseAsync();
            }
        }
        
    }

}

