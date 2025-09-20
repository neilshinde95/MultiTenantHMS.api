using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiTenantHMS.BLL.Helper
{
    public static class ErrorLogger
    {
        public static async Task LogErrorAsync(Exception ex)
        {
            try
            {
                // Defines the directory path within the BLL project.
                string projectDirectory = Path.Combine(Directory.GetCurrentDirectory(), "..", "MultiTenantHMS.BLL");
                string logDirectory = Path.Combine(projectDirectory, "ErrorLogs");

                // Creates the directory if it does not exist.
                if (!Directory.Exists(logDirectory))
                {
                    Directory.CreateDirectory(logDirectory);
                }

                // Generates the file path with the current date.
                string logFilePath = Path.Combine(logDirectory, $"{DateTime.Today:yyyy-MM-dd}.log");

                // Prepares the log message with a timestamp and exception details.
                var logMessage = new StringBuilder();
                logMessage.AppendLine("------------------------------------------------------------------");
                logMessage.AppendLine($"Timestamp: {DateTime.UtcNow:yyyy-MM-dd HH:mm:ss}");
                logMessage.AppendLine($"Exception Type: {ex.GetType().FullName}");
                logMessage.AppendLine($"Message: {ex.Message}");
                logMessage.AppendLine($"Stack Trace: {ex.StackTrace}");
                if (ex.InnerException != null)
                {
                    logMessage.AppendLine($"Inner Exception Message: {ex.InnerException.Message}");
                    logMessage.AppendLine($"Inner Exception Stack Trace: {ex.InnerException.StackTrace}");
                }
                logMessage.AppendLine("------------------------------------------------------------------");

                // Appends the log message to the file asynchronously.
                await File.AppendAllTextAsync(logFilePath, logMessage.ToString());
            }
            catch (Exception)
            {
                // Ignores any exceptions that occur during the logging process to prevent a loop.
            }
        }
    }
}
