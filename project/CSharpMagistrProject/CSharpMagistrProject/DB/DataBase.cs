using System;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.IO;
using System.Windows.Forms;


namespace CSharpMagistrProject.DB
{
	class DataBase
	{
	    private string userName;
        private string password;
        private string server;
        private string DBName;

	    private OleDbConnection connection;
	    private OleDbCommand command;

        public bool isConnected;

	    public DataBase(string server, string DBName, string userName, string password)
	    {
            this.server = server;
            this.DBName = DBName;
            this.userName = userName;
            this.password = password;

            isConnected = false;
            Connect();
	    }
        
	    private void Connect()
	    {
			//FIXME: не оставлять кучу закометареных строк избавляйся от них
            //string сonnectionString = "";
            //сonnectionString = "Provider=SQLNCLI10; Persist Security Info=True";
            //сonnectionString+="; Data Source=" + this.server;
            //сonnectionString+="; Password=" + this.password;
            //сonnectionString+="; User ID=" + this.userName;
            //сonnectionString+="; Initial Catalog=" + this.DBName;

            //string connectionString = "";
            //connectionString = "Provider=Microsoft.Jet.OLEDB.4.0";
            //connectionString += "; Data Source=" + Path.GetDirectoryName(Application.ExecutablePath) + "\\" +
            //                    "MagistrDB.accdb";
            //connectionString += "; Password="+@""""+password+@"""";
            //connectionString += "; User ID=" + @"""" + userName + @""";";
	        string connectionString =
                @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\Вася\Documents\Visual Studio 2010\Projects\WinFormsMagistrProject\MagistrDB.accdb;  User ID=Admin";

	        try
	        {
	            // открываем соединение
	            connection = new OleDbConnection(connectionString);
	            connection.Open();
	            isConnected = true;

	            MessageBox.Show("DB Opened");

	        }
	        catch (Exception exception)
	        {
	            CommonMethods.ShowError(exception.Message);
                connection.Close();
	        }   
	    }

	    public void Close()
	    {
	        try
		    {
			    //закрытие соединения
		        if (isConnected)
		        {
		            connection.Close();
		        }
                isConnected = false;
		    }
            catch (Exception exception)
		    {
                CommonMethods.ShowError(exception.Message);
		    }
	    }

	    public void DoNoSelectQuery(string queryText)
	    {
		//try catch не располагать вдали от пользователя в глубинах классов, использовать только в GUI элементах
		//try catch в математических классах проекта по возможности заменять на "сторожевые условия"
	        try
	        {
	            if (isConnected)
	            {
	                // ... выполнение запроса 
                    command=new OleDbCommand(queryText,connection);
	                command.ExecuteNonQuery();
	            }
	            else
	            {
	                CommonMethods.ShowError("Нет соединения с БД");
	            }
	        }
	        catch (Exception exception)
	        {
                CommonMethods.ShowError(exception.Message);
	        }

	    }

	    public void DoQuery(string quertText)
	    {
	        
	    }
	};
}