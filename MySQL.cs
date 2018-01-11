using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data;
using System.Data;
namespace MySqlLib
{
    public class MySqlData
    {
        public class MySqlExecute
        {
            public class MyResult
            {
                public string ResultText;
                public string ErrorText;
                public bool HasError;
            }

            public static MyResult SqlScalar(string sql, string connection)
            {
                MyResult result = new MyResult();
                try
                {
                    MySql.Data.MySqlClient.MySqlConnection connRC = new MySql.Data.MySqlClient.MySqlConnection(connection);
                    MySql.Data.MySqlClient.MySqlCommand commRC = new MySql.Data.MySqlClient.MySqlCommand(sql, connRC);
                    connRC.Open();
                    try
                    {
                        result.ResultText = commRC.ExecuteScalar().ToString();
                        result.HasError = false;
                    }

                    catch (Exception ex)
                    {
                        result.ErrorText = ex.Message;
                        result.HasError = true;
                    }
                    connRC.Close();
                }

                catch (Exception ex)
                {
                    result.ErrorText = ex.Message;
                    result.HasError = true;
                }

                return result;
            }
            public static MyResult SqlNoneQuery(string sql, string connection)
            {
                MyResult result = new MyResult();
                try

            {
            MySql.Data.MySqlClient.MySqlConnection connRC = new MySql.Data.MySqlClient.MySqlConnection(connection);
            MySql.Data.MySqlClient.MySqlCommand commRC = new MySql.Data.MySqlClient.MySqlCommand(sql, connRC);
            connRC.Open();
            try
            {
                commRC.ExecuteNonQuery();
                result.HasError = false;
            }

            catch (Exception ex)
            {
                result.ErrorText = ex.Message;
                result.HasError = true;
            }

            connRC.Close();
        }

        catch (Exception ex)
        {
            result.ErrorText = ex.Message;
            result.HasError = true;
        }

        return result;
    }
}

public class MySqlExecuteData
    {
        public class MyResultData

        {
        public DataTable ResultData;
        public string ErrorText;
        public bool HasError;
        }


    public static MyResultData SqlReturnDataset(string sql, string connection)
    {
        MyResultData result = new MyResultData();
        try
        {
            MySql.Data.MySqlClient.MySqlConnection connRC = new MySql.Data.MySqlClient.MySqlConnection(connection);
            MySql.Data.MySqlClient.MySqlCommand commRC = new MySql.Data.MySqlClient.MySqlCommand(sql, connRC);
            connRC.Open();
            try
            {
                MySql.Data.MySqlClient.MySqlDataAdapter AdapterP = new MySql.Data.MySqlClient.MySqlDataAdapter();
                AdapterP.SelectCommand = commRC;
                DataSet ds1 = new DataSet();
                AdapterP.Fill(ds1);
                result.ResultData = ds1.Tables[0];
            }

            catch (Exception ex)
            {
                result.HasError = true;
                result.ErrorText = ex.Message;
            }

            connRC.Close();
        }

    catch (Exception ex)
        {
            result.ErrorText = ex.Message;
            result.HasError = true;
        }

        return result;
    }
}
}
}
