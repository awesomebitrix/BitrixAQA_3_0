using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Reflection;
using System.ServiceProcess;
using BitrixAQA.Selenium.Framework;
using BitrixAQA.Selenium.General;

namespace BitrixAQA.General
{
    /// <summary>
    /// Класс общих методов и переменных
    /// </summary>
    class Shared
    {
        public static string appdir = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
        public static readonly string StartupPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + Path.DirectorySeparatorChar;

        /// <summary>
        /// Возвращает путь до папки TestFiles.
        /// </summary>
        /// <param name="File">Имя файла, который лежит в папке TestFiles</param>
        /// <returns>Возвращает строку - полный путь до файла в папке TestFiles</returns>
        public static string TestFiles(string File)
        {
            string readyPath = System.IO.Path.Combine(Shared.appdir, "TestFiles\\", File);
            return readyPath;
        }

        /// <summary>
        /// Завершает заданный процесс
        /// </summary>
        /// <param name="nameproc">имя процесса, например: WINWORD</param>
        public static void KillProc(string nameproc)
        {
            Process[] procList;
            procList = Process.GetProcessesByName(nameproc);
            foreach (Process proc in procList)
            {
                proc.Kill();
            }
        }

        /// <summary>
        /// Удаление файлов из папки
        /// </summary>
        /// <param name="nameDirectory">имя папки</param>
        public static void ClearDirectory(string nameDirectory)
        {
            string readyPath = Path.Combine(Shared.appdir, nameDirectory);
            if (Directory.Exists(readyPath))
            {
                string[] files = Directory.GetFiles(readyPath);

                foreach (string s in files)
                {
                    File.Delete(s);
                }
            }
        }


        /// <summary>
        /// Метод выполняет последовательно действия, переданные в него коллекцией.
        /// В зависимости от значения cbDebugMode, метод завершает текущее действие и переходит к следующему при появлении исключения,
        /// либо останавливается на исключении.
        /// </summary>
        /// <param name="TestCases">Список действий (методов) для последовательного выполнения. Методы не должны возвращать значение</param>
        public static void Execute(List<Action> TestCases)
        {
            foreach (Action TestCase in TestCases)
            {
                try
                {
                    TestCase.Invoke();
                }
                catch (OpenQA.Selenium.UnhandledAlertException)
                {
                    Log.MesQuestion("неожиданное модальное окно. <a href=\"" + ScreenCapture.Printscreen() + "\">скриншот</a>");
                    BitrixFramework.Wait(5);
                    BitrixFramework.BrowserAlert(false);
                    Log.NodeClose();
                }
                catch (WebException e)
                {
                    Log.MesError("Словили Вэб-эксепшен =( Видимо отвалился вебдрайвер.\r\n" + e.Message + "\r\n" + e.StackTrace +
                        "\r\nStatus Code : " + ((HttpWebResponse)e.Response).StatusCode +
                        "\r\nStatus Description : " + ((HttpWebResponse)e.Response).StatusDescription);
                    Log.NodeClose();
                }
                catch (OpenQA.Selenium.WebDriverException e)
                {
                    Log.MesError("Словили Вэб-эксепшен =( \r\n" + e.Message + "\r\n" + e.StackTrace);
                    BitrixFramework.Refresh();
                    Log.NodeClose();
                }
                catch (Exception Ex)
                {
                    Log.MesError(Ex.Message + "\r\n" + Ex.StackTrace);
                    Log.NodeClose();
                }
            }
        }

        /// <summary>
        /// Метод осуществляет валидацию условия Condidtion, возвращая bool результат, а также опционально пишет сообщения в лог
        /// </summary>
        /// <param name="Condition"> Условие для проверки</param>
        /// <param name="MessagePass"> Сообщение при выполнении условия (опционально)</param>
        /// <param name="MessageFail"> Сообщение при невыполнении условия (опционально)</param>
        /// <param name="MessageQuestion"> Сообщение с типом вопрос (опционально)</param>
        /// <returns> true усли условие выполнено, иначе - false</returns>
        public static bool Validate(bool Condition, string MessagePass = "", string MessageFail = "", string MessageQuestion = "")
        {
            try
            {
                if (Condition)
                {
                    if (MessagePass != "")
                        Log.MesPass(MessagePass);
                    return true;
                }
                else
                {
                    if (MessageFail != "")
                        Log.MesError(MessageFail);
                    if (MessageQuestion != "")
                        Log.MesQuestion(MessageQuestion);
                    return false;
                }
            }
            catch (Exception ex)
            {
                Log.MesError("При проверке условия возникла ошибка:" + ex.Message);
                throw;
            }
        }

        /// <summary>
        /// удаляем каталог с содержимым
        /// </summary>
        /// <param name="path">путь к каталогу</param>
        public static void DeleteCatalog(string path)
        {
            DirectoryInfo di = new DirectoryInfo(path);
            DirectoryInfo[] diA = di.GetDirectories();
            FileInfo[] fi = di.GetFiles();
            foreach (DirectoryInfo df in diA)
            {
                try
                {
                    df.Delete(true);
                    DeleteCatalog(df.FullName);
                }
                catch (Exception) { }
            }
            foreach (FileInfo f in fi)
            {
                try
                {
                    f.Delete();
                }
                catch (Exception) { }
            }
            di.Delete(true);
        }

        /// <summary> 
        /// Процедура копирует файл, заменяя его
        /// </summary>
        /// <param name="source">Путь к источнику</param>
        /// <param name="destination">Путь для копирования</param>
        public static void CopyFile(string source, string destination)
        {
            if (File.Exists(destination))
                File.Delete(destination);
            File.Copy(source, destination, true);
        }

        /// <summary>
        /// Метод считает количество файлов в директории с поддиректориями
        /// </summary>
        /// <param name="DirName">Директория</param>
        /// <returns></returns>
        public static int CountFilesInDirectory(string DirName)
        {
            DirectoryInfo dir = new DirectoryInfo(DirName);
            DirectoryInfo[] dirs = dir.GetDirectories();
            int Result = 0;
            foreach (FileInfo file in dir.GetFiles())
                Result = Result + 1;
            foreach (DirectoryInfo subdir in dirs)
                Result = Result + CountFilesInDirectory(subdir.FullName);
            return Result;
        }

        /// <summary>
        /// Копирует директорию в другую директорию с подкаталогами и файлами
        /// </summary>
        /// <param name="sourceDirName">Исходная директория</param>
        /// <param name="destDirName">Целевая директория</param>
        /// <param name="Overwrite">Перезаписывать ли файлы (по умолчанию - перезаписывать)</param>
        public static void DirectoryCopy(string sourceDirName, string destDirName, bool Overwrite = true)
        {
            DirectoryInfo dir = new DirectoryInfo(sourceDirName);
            DirectoryInfo[] dirs = dir.GetDirectories();
            if (!dir.Exists)
            {
                Log.MesQuestion("Нет исходной директории");
                return;
            }
            if (!Directory.Exists(destDirName))
                Directory.CreateDirectory(destDirName);
            foreach (FileInfo file in dir.GetFiles())
            {
                string temppath = Path.Combine(destDirName, file.Name);
                file.CopyTo(temppath, Overwrite);
            }
            foreach (DirectoryInfo subdir in dirs)
                DirectoryCopy(subdir.FullName, Path.Combine(destDirName, subdir.Name), Overwrite);
        }

        /// <summary>
        /// Поиск текста в файле
        /// </summary>
        /// <param name="FilePath">Путь к файлу</param>
        /// <param name="Text">Текст</param>
        /// <returns></returns>
        public static bool FindInFile(string FilePath, string Text)
        {
            string str = string.Empty;
            using (System.IO.StreamReader reader = System.IO.File.OpenText(FilePath))
                str = reader.ReadToEnd();
            return str.Contains(Text);
        }

        /// <summary>
        /// Перезапуск виндовой службы
        /// </summary>
        /// <param name="serviceName">Имя службы</param>
        /// <param name="timeoutMilliseconds">Таймаут</param>
        public static void RestartService(string serviceName, int timeoutMilliseconds = 30000)
        {
            ServiceController service = new ServiceController(serviceName);
            try
            {
                TimeSpan timeout = TimeSpan.FromMilliseconds(timeoutMilliseconds);
                if (service.Status != ServiceControllerStatus.Stopped)
                {
                    Log.MesNormal("Служба " + serviceName + " запущена. Останавливаем.");
                    service.Stop();
                    service.WaitForStatus(ServiceControllerStatus.Stopped, timeout);
                    Log.MesPass("Служба " + serviceName + " остановлена.");
                }

                Log.MesNormal("Запускаем службу " + serviceName);
                service.Start();
                service.WaitForStatus(ServiceControllerStatus.Running, timeout);
                Log.MesPass("Служба " + serviceName + " запущена.");
            }
            catch(Exception ex)
            {
                Log.MesError("Ошибка перезапуска службы " + serviceName + "\r\n" + ex.Message + "\r\n" + ex.StackTrace);
            }
        }

        /// <summary>
        /// Конвертируем лонг в читабельное количество информации
        /// </summary>
        /// <param name="bytes">Конвертируемый лонг</param>
        /// <returns></returns>
        private static string FormatBytes(long bytes)
        {
            string[] Suffix = { "B", "KB", "MB", "GB", "TB" };
            int i;
            double dblSByte = bytes;
            for (i = 0; i < Suffix.Length && bytes >= 1024; i++, bytes /= 1024)
                dblSByte = bytes / 1024.0;
            return String.Format("{0:0.##} {1}", dblSByte, Suffix[i]);
        }

        /// <summary>
        /// Вычисляем размер папки со всеми вложениями
        /// </summary>
        /// <param name="DirInfo">Директория</param>
        /// <returns></returns>
        public static long DirSize(DirectoryInfo DirInfo)
        {
            long Size = 0;
            FileInfo[] fis = DirInfo.GetFiles();
            foreach (FileInfo fi in fis)
            {
                Size += fi.Length;
            }
            DirectoryInfo[] dis = DirInfo.GetDirectories();
            foreach (DirectoryInfo di in dis)
            {
                Size += DirSize(di);
            }
            return (Size);
        }
    }
}
