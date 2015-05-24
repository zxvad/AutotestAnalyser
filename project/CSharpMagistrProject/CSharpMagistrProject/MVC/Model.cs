using CSharpMagistrProject.DB;

namespace CSharpMagistrProject.MVC
{
    /// <summary>
    /// Модель (MVC)
    /// </summary>
    public class Model
    {
        /// <summary>
        /// База данных
        /// </summary>
        public DataBase DataBase { get; private set; }

        /// <summary>
        /// Лог файл
        /// </summary>
        public LogFile LogFile { get; private set; }

        /// <summary>
        /// Главный конструктор
        /// </summary>
        public Model()
        {
            DataBase = new DataBase();
            LogFile = new LogFile();
        }
    }
}
