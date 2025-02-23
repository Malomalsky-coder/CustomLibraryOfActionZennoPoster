using System.IO;
using System.Text;

namespace CustomLibraryOfActionZennoPoster.Data.Files
{
    /// <summary>
    /// Метод действия: Данные > Файлы
    /// </summary>
    public class File
    {
        /// <summary>
		/// Создает файл, если файл уже существует, он будет перезаписан, выполняется синхронно.
		/// </summary>
		/// <param name="path">Путь к файлу.</param>
		/// <param name="data">Данные для записи в файл.</param>
        /// <param name="encoding">Кодировка файла.</param>
		/// <param name="objSync">Объект для синхронизации доступа к файлу.</param>
		public static void CreateSync(string path, string data, Encoding encoding = null, object objSync = null)
        {
            if (encoding is null)
            {
                encoding = Encoding.UTF8;
            }

            if (objSync is null)
            {
                objSync = new object();
            }

            lock (objSync)
            {
                using (var fs = new FileStream(path, FileMode.Create, FileAccess.Write, FileShare.None))
                using (var sw = new StreamWriter(fs))
                {
                    sw.WriteLine(data);
                }
            }
        }

        /// <summary>
        /// Добавляет строку в конец файла синхронно.
        /// </summary>
        /// <param name="path">Путь к файлу.</param>
        /// <param name="line">Строка для добавления в файл.</param>
        /// <param name="encoding">Кодировка файла.</param>
        /// <param name="objSync">Объект для синхронизации доступа к файлу.</param>
        public static void AddLineSync(string path, string line, Encoding encoding = null, object objSync = null)
        {
            if (encoding is null)
            {
                encoding = Encoding.UTF8;
            }

            if (objSync is null)
            {
                objSync = new object();
            }

            lock (objSync)
            {
                using (var fs = new FileStream(path, FileMode.Append, FileAccess.Write, FileShare.None))
                using (var sw = new StreamWriter(fs))
                {
                    sw.WriteLine(line);
                }
            }
        }

        /// <summary>
        /// Читает содержимое файла.
        /// </summary>
        /// <param name="path">Путь к файлу.</param>
        /// <returns>Содержимое файла в виде строки.</returns>
        public static string Read(string path)
        {
            using (var fs = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.Read))
            using (var sr = new StreamReader(fs))
            {
                return sr.ReadToEnd();
            }
        }

        /// <summary>
        /// Читает содержимое файла синхронно.
        /// </summary>
        /// <param name="path">Путь к файлу.</param>
        /// <param name="encoding">Кодировка файла.</param>
        /// <param name="objSync">Объект для синхронизации доступа к файлу.</param>
        /// <returns>Содержимое файла в виде строки.</returns>
        public static string ReadSync(string path, Encoding encoding = null, object objSync = null)
        {
            if (encoding is null)
            {
                encoding = Encoding.UTF8;
            }

            if (objSync is null)
            {
                objSync = new object();
            }

            lock (objSync)
            {
                using (var fs = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.Read))
                using (var sr = new StreamReader(fs, encoding))
                {
                    return sr.ReadToEnd();
                }
            }
        }
    }
}