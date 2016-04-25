using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Data;  // additional usings
using System.Data.SqlClient;
using System.Web.UI.WebControls;
using System.Configuration;

public class NorthwindAccess
{
    public static SqlDataSource GetSuppliersSDS(string s)
    {
        string query = "SELECT CompanyName, SupplierID FROM Suppliers";  // basic query

        if (s != null)  // query addition if we have a filter
            query += " WHERE CompanyName LIKE '%" + s + "%'";

        return new SqlDataSource(
        ConfigurationManager.ConnectionStrings["msheikh11_NorthwindConnectionString"].ConnectionString,  // the connection string
        query);  // the query
    }

    public static List<List<string>> GetProducts(string s)
    {
        List<List<string>> data = new List<List<string>>();  // list of list of string
        List<string> titles = new List<string>();  // sub-list of string

        if (s == null)  // if we have no filter, quit out
            return data;

        string query = "SELECT ProductName, QuantityPerUnit, UnitsInStock FROM Products WHERE SupplierID = '"
            + s + "'";

        using (SqlConnection connection = new SqlConnection
            (ConfigurationManager.ConnectionStrings["msheikh11_NorthwindConnectionString"].ConnectionString))
        {
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                connection.Open();  // open the connection

                SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);  // start the reader

                for (int i = 0; i < reader.FieldCount; i++)  // grab all of the titles
                    titles.Add(reader.GetName(i));

                data.Add(titles);  // and add them to the list of list of strings

                if (!reader.HasRows)  // if we have nothing beyond that, quit out
                    return data;

                while (reader.Read())  // otherwise, we have stuff to read to the table
                {
                    List<string> temp = new List<string>();  // make a temp list of string

                    for (int i = 0; i < titles.Count; ++i)  // read across as many columns as we have headers
                        temp.Add(reader[titles[i]].ToString());  // add the string to the temp list

                    data.Add(temp);  // then add it to the list of list of string
                }
            }
        }
        
        return data;  // we're all done - return the completed list of list of string
    }
    public static void GetCustomers(string filter, DropDownList d)
    {
        SqlDataReader reader = null;
        SqlConnection connect = new SqlConnection(
            ConfigurationManager.ConnectionStrings["msheikh11_NorthwindConnectionString"].ConnectionString);

        connect.Open();

        using (SqlCommand command = new SqlCommand())
        {
            command.Connection = connect;
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "GetCustomers";

            SqlParameter param = new SqlParameter("@filter", // name in the database
                SqlDbType.VarChar, // type of the thing in the database, in this case, @filter is a Varchar
                25);  // size of the thing - @filter's size is 80
            param.Value = filter;
            param.Direction = ParameterDirection.Input;

            command.Parameters.Add(param);  // add the parameter into the command

            reader = command.ExecuteReader(CommandBehavior.CloseConnection);
        }
        d.DataSource = reader;
        d.DataTextField = "CompanyName";  // data text and values
        d.DataValueField = "CustomerID";

        d.Items.Clear();
        d.DataBind();  // pops all data in
        d.AppendDataBoundItems = true;  // allows for dynamic adding of...  stuff...
        d.Items.Insert(0, "Now Pick a Customer from " + d.Items.Count);  // make this the first item in the DDL
    }

    public static SqlDataReader CustomerCategorySummary(string filly)
    {
        SqlDataReader reader = null;
        SqlConnection connect = new SqlConnection(
            ConfigurationManager.ConnectionStrings["msheikh11_NorthwindConnectionString"].ConnectionString);

        connect.Open();
            using (SqlCommand command = new SqlCommand())
            {
                command.Connection = connect;
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "CustCatSummary";

                SqlParameter param = new SqlParameter("@custID", // name in the database
                    SqlDbType.NChar, // type of the thing in the database, in this case, @filter is a Varchar
                    5);  // size of the thing - @filter's size is 80
                param.Value = filly;
                param.Direction = ParameterDirection.Input;

                command.Parameters.Add(param);  // add the parameter into the command

                reader = command.ExecuteReader(CommandBehavior.CloseConnection);
            }
        return reader;        
    }

    static public string DeleteOrderDetails(int orderID, string productName)
    {
        SqlConnection connect = new SqlConnection(
            ConfigurationManager.ConnectionStrings["msheikh11_NorthwindConnectionString"].ConnectionString);
        string output = "Status: Row Deleted";
        connect.Open();

        using (SqlCommand command = new SqlCommand())
        {
            command.Connection = connect;
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "DeleteOrderDetails";

            SqlParameter param = new SqlParameter("@orderID",
                SqlDbType.Int);

            param.Value = orderID;
            param.Direction = ParameterDirection.Input;
            command.Parameters.Add(param);

            param = new SqlParameter("@productName",
                SqlDbType.VarChar, 40);
            param.Value = productName;
            param.Direction = ParameterDirection.Input;
            command.Parameters.Add(param);

            param = new SqlParameter("@result",
                SqlDbType.VarChar, 80);
            param.Value = output;
            param.Direction = ParameterDirection.Output;
            command.Parameters.Add(param);
            //output = command.Parameters[2].Value.ToString();
            command.ExecuteReader(CommandBehavior.CloseConnection);
        }
        return output;
    }

    static public SqlDataReader GetOrderDetails(int orderID)
    {
        SqlDataReader reader = null;
        SqlConnection connect = new SqlConnection(
            ConfigurationManager.ConnectionStrings["msheikh11_NorthwindConnectionString"].ConnectionString);
        connect.Open();

        using (SqlCommand command = new SqlCommand())
        {
            command.Connection = connect;
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "getOrderDetails";

            SqlParameter param = new SqlParameter("@orderID",
                SqlDbType.Int);

            param.Value = orderID;
            param.Direction = ParameterDirection.Input;
            command.Parameters.Add(param);

            reader = command.ExecuteReader(CommandBehavior.CloseConnection);
        }
        return reader;
    }

    static public void FillProductsDDL(DropDownList drop)
    {
        SqlDataReader reader = null;
        SqlConnection connect = new SqlConnection(
            ConfigurationManager.ConnectionStrings["msheikh11_NorthwindConnectionString"].ConnectionString);

        connect.Open();

        using (SqlCommand command = new SqlCommand())
        {
            command.Connection = connect;
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "getProducts";

            reader = command.ExecuteReader(CommandBehavior.CloseConnection);
        }
        drop.DataSource = reader;
        drop.DataTextField = "productName";
        drop.DataValueField = "productID";
        drop.DataBind();
        drop.Items.Insert(0, "Select a Product");
    }

    static public string InsertOrderDetails(int orderID, int productID, int quantity)
    {
        SqlConnection connect = new SqlConnection(
            ConfigurationManager.ConnectionStrings["msheikh11_NorthwindConnectionString"].ConnectionString);
        int result = 0;
        connect.Open();

        using (SqlCommand command = new SqlCommand())
        {
            command.Connection = connect;
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "InsertOrderDetails";

            SqlParameter param = new SqlParameter("@orderID",
                SqlDbType.Int);
            param.Value = orderID;
            param.Direction = ParameterDirection.Input;
            command.Parameters.Add(param);

            param = new SqlParameter("@productID",
                SqlDbType.Int);
            param.Value = productID;
            param.Direction = ParameterDirection.Input;
            command.Parameters.Add(param);

            param = new SqlParameter("@quantity",
                SqlDbType.Int);
            param.Value = quantity;
            param.Direction = ParameterDirection.Input;
            command.Parameters.Add(param);

            param = new SqlParameter("@rows",
                SqlDbType.Int);
            param.Direction = ParameterDirection.ReturnValue;
            command.Parameters.Add(param);

            int value1 = command.ExecuteNonQuery();
            result = (int)command.Parameters["@rows"].Value;
            //connect.Close();
        }
        return "Inserted: " + result.ToString() + " rows";
    }
}