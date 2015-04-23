using CSharpMagistrProject.DB;

namespace CSharpMagistrProject.MVC
{
    public class Model
    {
        public DataBase DataBase { get; private set; }

        public LogFile LogFile { get; private set; }

        public Model()
        {
            DataBase = new DataBase();
            LogFile = new LogFile();
        }
    }
}
