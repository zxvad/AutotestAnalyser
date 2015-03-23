using System.IO;
using CSharpMagistrProject.DB;

namespace CSharpMagistrProject.MVC
{
    public class Model
    {
        private DataBase dataBase;
        private string logFileName;

        public Model()
        {
            dataBase = new DataBase();

        }

        public DataBase GetDataBase()
        {
            return dataBase;
        }

    }
}
