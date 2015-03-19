using System.IO;
using CSharpMagistrProject.DB;

namespace CSharpMagistrProject.MVC
{
    public class Model
    {
        public DataBase dataBase;
        private string logFileName;

        public Model()
        {
            dataBase = new DataBase();

        }
    }
}
