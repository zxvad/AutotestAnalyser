using System.IO;
using CSharpMagistrProject.DB;

namespace CSharpMagistrProject.MVC
{
    public class Model
    {
        private DataBase dataBase;
        public LogFile logFile;

        public Model()
        {
            dataBase = new DataBase();
            logFile = new LogFile();
        }

        public DataBase GetDataBase()
        {
            return dataBase;
        }

    }
}
