using System.IO;
using CSharpMagistrProject.DB;

namespace CSharpMagistrProject.MVC
{
    public class Model
    {
        public DataBase DataBase { get; private set; }
        public LogFile logFile;

        public Model()
        {
            DataBase = new DataBase();
            logFile = new LogFile();
        }
    }
}
