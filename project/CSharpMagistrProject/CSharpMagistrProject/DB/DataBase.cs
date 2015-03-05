using System;


namespace CSharpMagistrProject.DB
{
	class DataBase
	{
	    string userName;
	    string password;
	    string server;
        string DBName;

        public static bool isConnected;

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
	        string ConnectionString = "Provider=SQLNCLI10; Persist Security Info=True";
		    ConnectionString+="; Data Source=" + this.server;
		    ConnectionString+="; Password=" + this.password;
		    ConnectionString+="; User ID=" + this.userName;
		    ConnectionString+="; Initial Catalog=" + this.DBName;

		    try 
		    {
			    // ... соединение с БД через компонент

			    isConnected=true;
		    }
		    catch(Exception exception)
		    {
                CommonMethods.ShowError("Ошибка соединения с БД");
		    };

	    }

	    private void Close()
	    {
	        try
		    {
			    // .....закрытие соединения

			    isConnected=false;
		    }
            catch (Exception exception)
		    {
                CommonMethods.ShowError("Ошибка закрытия БД");
		    }
	    }

	    public static void DoQuery(string queryText)
	    {
            if (isConnected)
            {
                // ... выполнение запроса 
            }
            else
            {
                CommonMethods.ShowError("Нет соединения с БД");
            };
	    }
	};
}