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

public class ManagerDaO : DaO
{
	internal bool changeRole(int users_id, int jogkor_id)
	{
        try
        {

            // Query string 
            string strSQL = "UPDATE USERS SET jogkor_id=@_jogkor WHERE users_id=@_id";

            // Add query text
            MySqlCommand cmd = new MySqlCommand(strSQL, this.Conn);

            // Prepare the query
            cmd.Prepare();

            // Add parameter
            cmd.Parameters.AddWithValue("@_id", users_id);
            cmd.Parameters.AddWithValue("@_jogkor", jogkor_id);
        
            // Execute query
            if (cmd.ExecuteNonQuery() == 1)
            {
                return true;
            }

        }
        catch (MySqlException ex)
        {
            Console.WriteLine("MySQL error. Number: " + ex.Number);
        }
        
        return false;
	}

	internal bool deleteUserdata(int users_id)
	{
        try {
            // Query string 
            string strSQL = "DELETE FROM USERS WHERE users_id=@_id";

            // Add query text
            MySqlCommand cmd = new MySqlCommand(strSQL, this.Conn);

            // Prepare the query
            cmd.Prepare();

            // Add parameter
            cmd.Parameters.AddWithValue("@_id", users_id);

            // Execute query
            if (cmd.ExecuteNonQuery() != 1)
            {
                return false;
            }


            // Query string 
            strSQL = "DELETE FROM USERS_HANGSZER WHERE users_id=@_id";

            // Add query text
            cmd = new MySqlCommand(strSQL, this.Conn);

            // Prepare the query
            cmd.Prepare();

            // Add parameter
            cmd.Parameters.AddWithValue("@_id", users_id);

            // Execute query
            if (cmd.ExecuteNonQuery() >= 0)
            {
                return true;
            }
        
        }
        catch (MySqlException ex)
        {
            Console.WriteLine("MySQL error. Number: " + ex.Number);
        }

        return false;
	}

	internal List<KeyValuePair<int, string>> getAllRole()
	{
        MySqlDataReader rdr = null;

        var result = new List<KeyValuePair<int, string>>();

        try
        {

            string stm = "SELECT jogkor_id, jogkor_nev FROM JOGKOR ORDER BY jogkor_id ASC";

            MySqlCommand cmd = new MySqlCommand(stm, this.Conn);

            rdr = cmd.ExecuteReader();

            while (rdr.Read())
            {
                int key = rdr.GetInt32(0);
                string value = rdr.GetString(1);

                result.Add(new KeyValuePair<int, string>(key, value));
            }

        }
        catch (MySqlException ex)
        {
            Console.WriteLine("Error: {0}", ex.ToString());

        }
        finally
        {
            if (rdr != null)
            {
                rdr.Close();
            }

        }

        // Return with the result string
        return result;
	}


    internal List<User> getUsers()
    {
        MySqlDataReader rdr = null;

        var result = new List<User>();

        try
        {
            
            string stm = "SELECT users_id, users_nev, users_email, jogkor_id, aktiv, " +
             "koncertre_jar, users_password FROM USERS";
           
            MySqlCommand cmd = new MySqlCommand(stm, this.Conn);
            
            rdr = cmd.ExecuteReader();

            while (rdr.Read())
            {
                int users_id = rdr.GetInt32(0);
                string users_email = rdr.GetString(2);
                string users_nev = rdr.GetString(1);
                int jogkor_id = rdr.GetInt32(3);
                string users_password = rdr.GetString(6);
                bool aktiv = rdr.GetBoolean(4);
                bool koncertre_jar = rdr.GetBoolean(5);

                result.Add(new User(users_id, users_nev, users_email, jogkor_id, users_password, aktiv, koncertre_jar));
            }

        }
        catch (MySqlException ex)
        {
            Console.WriteLine("Error: {0}", ex.ToString());

        }
        finally
        {
            if (rdr != null)
            {
                rdr.Close();
            }

        }

        // Return with the result string
        return result;






        
    }

    internal bool newInstruments(List<KeyValuePair<string, int>> hangszerek) 
    {
        // uj hangszerek irasa

        // Query string 
        string strSQL = "INSERT INTO HANGSZER (hangszer_nev, hangszertipus_id) VALUES (@_hangszernev, @_hangszertipus_id); ";

        // Add query text
        MySqlCommand cmd = new MySqlCommand(strSQL, this.Conn);

        // Prepare the query
        cmd.Prepare();

        bool ok = true;

        for (int i = 0; i < hangszerek.Count; i++)
        {
            cmd.Parameters.AddWithValue("@_hangszernev", hangszerek[i].Key);
            cmd.Parameters.AddWithValue("@_hangszertipus_id", hangszerek[i].Value);
            // Execute query

            if (cmd.ExecuteNonQuery() != 1)
            {
                ok = false;
            }
        }

        return ok;
        
    }


    internal bool newInstrumentTypes(List<String> tipuslista)
    {
        // hangszertipusok adatbazisba irasa

        // Query string 
        string strSQL = "INSERT INTO HANGSZERTIPUS (hangszertipus_nev) VALUES (@_hangszertipus_nev); ";

        // Add query text
        MySqlCommand cmd = new MySqlCommand(strSQL, this.Conn);

        // Prepare the query
        cmd.Prepare();

        bool ok = true;

        for (int i = 0; i < tipuslista.Count; i++)
        {
            cmd.Parameters.AddWithValue("@_hangszertipus_nev", tipuslista[i]);
            // Execute query

            if (cmd.ExecuteNonQuery() != 1)
            {
                ok = false;
            }
        }

        return ok;
    }


    internal bool delInstrument(int hangszer_id)
    {

       
        try
        {

            // a torlendo hangszer id-jat tartalmazo sorok torlese az user hangszerei tablabol
            // Query string 
            string strSQL = "DELETE FROM USERS_HANGSZER WHERE hangszer_id=@_hangszer_id";

            // Add query text
            MySqlCommand cmd = new MySqlCommand(strSQL, this.Conn);

            // Prepare the query
            cmd.Prepare();

            // Add parameter
            cmd.Parameters.AddWithValue("@_hangszer_id", hangszer_id);

            // Execute query
            cmd.ExecuteNonQuery();


            // a torlendo hangszer torlese a hangszer tablabol
            // Query string 
            strSQL = "DELETE FROM HANGSZER WHERE hangszer_id=@_hangszer_id";

            // Add query text
            cmd = new MySqlCommand(strSQL, this.Conn);

            // Prepare the query
            cmd.Prepare();

            // Add parameter
            cmd.Parameters.AddWithValue("@_hangszer_id", hangszer_id);

            // Execute query
            if (cmd.ExecuteNonQuery() == 1)
            {
                return true;
            }

            
        }
        catch (MySqlException ex)
        {
            Console.WriteLine("Error: {0}", ex.ToString());

        }
       

        // Return with the result string
        return false;

       
    }


    internal bool delInstrumentType(int hangszertipus_id)
    {
        

        try
        {

            // a torlendo hangszertipus id-jat tartalmazo sorok torlese az users_hangszer tablabol
            // Query string 
            string strSQL = "DELETE UH.* FROM HANGSZER H INNER JOIN USERS_HANGSZER UH ON H.hangszer_id=UH.hangszer_id WHERE H.hangszertipus_id=@_hangszertipus_id";

            // Add query text
            MySqlCommand cmd = new MySqlCommand(strSQL, this.Conn);

            // Prepare the query
            cmd.Prepare();

            // Add parameter
            cmd.Parameters.AddWithValue("@_hangszertipus_id", hangszertipus_id);

            // Execute query
            cmd.ExecuteNonQuery();

            
            // a torlendo hangszertipus torlese a hangszer tablabol
            // Query string 
            strSQL = "DELETE FROM HANGSZER WHERE hangszertipus_id=@_hangszertipus_id";

            // Add query text
            cmd = new MySqlCommand(strSQL, this.Conn);

            // Prepare the query
            cmd.Prepare();

            // Add parameter
            cmd.Parameters.AddWithValue("@_hangszertipus_id", hangszertipus_id);

            // Execute query
            cmd.ExecuteNonQuery();

           
            // a torlendo hangszertipus torlese a hangszertipus tablabol
            // Query string 
            strSQL = "DELETE FROM HANGSZERTIPUS WHERE hangszertipus_id=@_hangszertipus_id";

            // Add query text
            cmd = new MySqlCommand(strSQL, this.Conn);

            // Prepare the query
            cmd.Prepare();

            // Add parameter
            cmd.Parameters.AddWithValue("@_hangszertipus_id", hangszertipus_id);

            // Execute query
            if (cmd.ExecuteNonQuery() == 1)
            {
                return true;
            }


        }
        catch (MySqlException ex)
        {
            Console.WriteLine("Error: {0}", ex.ToString());

        }


        // Return with the result string
        return false;


    }


    internal bool deleteConcertdata(int koncert_id)
    {
        try
        {
            // Query string 
            string strSQL = "DELETE FROM KONCERT_RESZVETEL WHERE koncert_id=@_koncert_id";

            // Add query text
            MySqlCommand cmd = new MySqlCommand(strSQL, this.Conn);

            // Prepare the query
            cmd.Prepare();

            // Add parameter
            cmd.Parameters.AddWithValue("@_koncert_id", koncert_id);

            // Execute query
            if (cmd.ExecuteNonQuery() >= 0)
            {
                return false;
            }


            // Query string 
            strSQL = "DELETE FROM KONCERT WHERE koncert_id=@_koncert_id";

            // Add query text
            cmd = new MySqlCommand(strSQL, this.Conn);

            // Prepare the query
            cmd.Prepare();

            // Add parameter
            cmd.Parameters.AddWithValue("@_koncert_id", koncert_id);

            // Execute query
            if (cmd.ExecuteNonQuery() == 1)
            {
                return true;
            }

        }
        catch (MySqlException ex)
        {
            Console.WriteLine("MySQL error. Number: " + ex.Number);
        }

        return false;
    }


    internal bool deleteRehearsaldata(int proba_id)
    {

        try
        {
            // Query string 
            string strSQL = "DELETE FROM PROBA_RESZVETEL WHERE proba_id=@_proba_id";

            // Add query text
            MySqlCommand cmd = new MySqlCommand(strSQL, this.Conn);

            // Prepare the query
            cmd.Prepare();

            // Add parameter
            cmd.Parameters.AddWithValue("@_proba_id", proba_id);

            // Execute query
            if (cmd.ExecuteNonQuery() >= 0)
            {
                return false;
            }


            // Query string 
            strSQL = "DELETE FROM PROBA WHERE proba_id=@_proba_id";

            // Add query text
            cmd = new MySqlCommand(strSQL, this.Conn);

            // Prepare the query
            cmd.Prepare();

            // Add parameter
            cmd.Parameters.AddWithValue("@_proba_id", proba_id);

            // Execute query
            if (cmd.ExecuteNonQuery() == 1)
            {
                return true;
            }

        }
        catch (MySqlException ex)
        {
            Console.WriteLine("MySQL error. Number: " + ex.Number);
        }

        return false;
    }


    internal bool deleteRehearsalMaterialdata(int probaanyag_id)
    {
        try
        {
            // Query string 
            string strSQL = "DELETE FROM PROBA_ZENESZ WHERE probaanyag_id=@_probaanyag_id";

            // Add query text
            MySqlCommand cmd = new MySqlCommand(strSQL, this.Conn);

            // Prepare the query
            cmd.Prepare();

            // Add parameter
            cmd.Parameters.AddWithValue("@_probaanyag_id", probaanyag_id);

            // Execute query
            if (cmd.ExecuteNonQuery() != 1)
            {
                return false;
            }


            // Query string 
            strSQL = "DELETE FROM PROBAANYAG WHERE probaanyag_id=@_probaanyag_id";

            // Add query text
            cmd = new MySqlCommand(strSQL, this.Conn);

            // Prepare the query
            cmd.Prepare();

            // Add parameter
            cmd.Parameters.AddWithValue("@_probaanyag_id", probaanyag_id);

            // Execute query
            if (cmd.ExecuteNonQuery() >= 0)
            {
                return true;
            }

        }
        catch (MySqlException ex)
        {
            Console.WriteLine("MySQL error. Number: " + ex.Number);
        }

        return false;
    }


    internal List<int> getAllInactiveRehearsalMaterial()
    {

        MySqlDataReader rdr = null;

        var result = new List<int>();

        try
        {

            // user adatok lekerdezese
            string stm = "SELECT probaanyag_id FROM PROBAANYAG where probaanyag_aktiv=false";

            MySqlCommand cmd = new MySqlCommand(stm, this.Conn);

            cmd.Prepare();

            rdr = cmd.ExecuteReader();



            while (rdr.Read())
            {
                result.Add(rdr.GetInt32(0));
            }


        }
        catch (MySqlException ex)
        {
            Console.WriteLine("Error: {0}", ex.ToString());

        }
        finally
        {
            if (rdr != null)
            {
                rdr.Close();
            }

        }

        // Return with the result string
        return result;
    }
}




