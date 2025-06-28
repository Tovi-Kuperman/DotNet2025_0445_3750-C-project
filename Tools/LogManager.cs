using System.IO;
namespace Tools
{
    public static class LogManager
    {
        private const string path = "Log";
        public static string Tab = "";
        public static string GetDirectory()
        {
            return DateTime.Now.Month.ToString();
        }

        public static string GetLogFile()
        {
            return DateTime.Now.Day.ToString();
        }



        private static string getCurrentPathDir()
        {
            return Path.Combine(AppDomain.CurrentDomain.BaseDirectory, path);

        }
        //ניתוב של החודשים
        private static string getLogPathForCurrentFolder()
        {
            string currentMonth = $"{DateTime.Now:yyyy-MM}";
            string logDir = getCurrentPathDir();
            string currentLogFolder = $@"{logDir}\{currentMonth}";

            if (!Directory.Exists(currentLogFolder))
            {
                Directory.CreateDirectory($@"{logDir}\{currentMonth}");
            }
            Directory.CreateDirectory(currentLogFolder);
            return currentLogFolder;
        }
        //ניתוב של הימים
        private static string getLogPathForCurrentDayFiles()
        {
            string currentFolder = getLogPathForCurrentFolder();
            int currentDay = DateTime.Now.Day;
            string currentFile = $@"{currentFolder}/{currentDay}.log";
            if (!File.Exists(currentFile))
                File.Create(currentFile).Close();
            return currentFile;
        }

        public static void WriteToLog(string projectName, string functionName, string message)
        {
            string dir = @$"{LogManager.path}\{GetDirectory()}";

            if (!Directory.Exists(dir))
            {
                Directory.CreateDirectory(dir);
            }
            dir+= @$"\{GetLogFile()}.txt";
            if (!File.Exists(dir))
            {
                File.Create(dir).Close();
            }
            FileStream fs = new FileStream(dir, FileMode.Append, FileAccess.Write);
            StreamWriter sw = new StreamWriter(fs);
            sw.WriteLine($"{DateTime.Now}\t{projectName}.{functionName}:\t{message}");
            sw.Close();
            fs.Close();
        }

        public static void DeleteLog()
        {
            string dir = LogManager.path;
            int monthNumber = int.Parse(GetDirectory());
            foreach (var currentDirectory in Directory.GetDirectories(dir).ToList())
            {
                if(int.Parse(currentDirectory) != monthNumber&& int.Parse(currentDirectory) != monthNumber - 1)
                {
                    Directory.Delete($@"{dir}\{currentDirectory}",true);
                }
            }

         
         }
    }
}
