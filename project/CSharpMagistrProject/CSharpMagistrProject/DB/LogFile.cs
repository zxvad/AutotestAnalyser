using System;
using System.IO;
using System.Text;

namespace CSharpMagistrProject.DB
{
    /// <summary>
    /// Класс для работы с логом
    /// </summary>
    public class LogFile
    {
        /// <summary>
        /// Объект для реализации потокобезопасности
        /// </summary>
        private static object sync = new object();

        /// <summary>
        /// Добавить запись об исключении в Лог 
        /// </summary>
        /// <param name="ex">Исключение</param>
        public void Write(Exception ex)
        {
            // Путь .\\Log
            string pathToLog = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Log");
            // Создаем директорию, если нужно
            if (!Directory.Exists(pathToLog))
                Directory.CreateDirectory(pathToLog);
            string filename = Path.Combine(pathToLog,
                string.Format("{0}_{1:dd.MM.yyy}.log", AppDomain.CurrentDomain.FriendlyName, DateTime.Now));
            string fullText = string.Format("[{0:dd.MM.yyy HH:mm:ss.fff}] [{1}.{2}()] {3}\r\n",
                DateTime.Now, ex.TargetSite.DeclaringType, ex.TargetSite.Name, ex.Message);
            lock (sync)
            {
                File.AppendAllText(filename, fullText, Encoding.GetEncoding("Windows-1251"));
            }
        }
    }
}

