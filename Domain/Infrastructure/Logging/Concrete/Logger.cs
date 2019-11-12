using System;
using System.IO;
using Domain.Infrastructure.Logging.Abstract;
using Microsoft.AspNetCore.Hosting;

namespace Domain.Infrastructure.Logging.Concrete
{
    public class Logger : ILogger
    {
#pragma warning disable 618
        private readonly IHostingEnvironment _hostingEnvironment;

        private static readonly object Object = new object();

        public Logger(IHostingEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
        }
#pragma warning restore 618
        public void Log(string toLog)
        {
            LogMessage(toLog);
        }

        public void Log(Exception toLog)
        {
            LogMessage($"----------------------------------------\n{DateTime.Now}\n{toLog.GetType()}\n{toLog.StackTrace}\n{toLog.Message}\n{toLog}");

            if (toLog.InnerException != null)
                Log(toLog.InnerException);
        }

        private void LogMessage(string toLog)
        {
            try
            {
                string filePath;
                lock (Object)
                {
                    string directoryPath = PrepareDirectoryPath();
                    string fileName = PrepareFileName();
                    filePath = Path.Combine(directoryPath, fileName);
                    if (!Directory.Exists(directoryPath))
                    {
                        Directory.CreateDirectory(directoryPath);
                    }

                    using StreamWriter sw = File.AppendText(filePath);
                    sw.WriteLine(toLog);

                }
            }
            catch
            {
                // ignored
            }
        }

        private string PrepareFileName()
        {
            return $"{DateTime.Today.Day}.txt";
        }

        private string PrepareDirectoryPath()
        {
            DateTime now = DateTime.Today;

            return $"{_hostingEnvironment.ContentRootPath}\\Logging\\{now.Year}-{now.Month}";
        }
    }
}
