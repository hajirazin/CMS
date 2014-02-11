// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Logger.cs" company="">
//   
// </copyright>
// <summary>
//   The logger.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Ramesoft.Cms.Common.Logging
{
    using System;
    using System.IO;
    using System.Text;
    using System.Threading.Tasks;

    using Ramesoft.Cms.Common.Config;
    using Ramesoft.Cms.Common.DAL.Factory;
    using Ramesoft.Cms.Common.DAL.Repository;
    using Ramesoft.Cms.Common.Entity;

    /// <summary>
    /// The logger.
    /// </summary>
    public static class Logger
    {
        #region Static Fields

        /// <summary>
        /// The unit of work.
        /// </summary>
        private static readonly IUnitOfWork UnitOfWork = UnityConfig.Resolve<IUnitOfWork>();

        /// <summary>
        /// The logging.
        /// </summary>
        private static readonly IRepository<Log> Logging = UnitOfWork.GetStanderdRepository<Log>();

        /// <summary>
        /// The locker.
        /// </summary>
        private static readonly object Locker = new object();

        /// <summary>
        /// The log path.
        /// </summary>
        private static string logPath = @"C:\Logs";

        #endregion

        #region Public Methods and Operators

        /// <summary>
        /// The initialize logs.
        /// </summary>
        /// <param name="path">
        /// The path.
        /// </param>
        public static void InitializeLogs(string path)
        {
            logPath = path;
        }

        /// <summary>
        /// The log exception.
        /// </summary>
        /// <param name="e">
        /// The e.
        /// </param>
        /// <param name="extraInformation">
        /// The extra information.
        /// </param>
        public static void LogException(Exception e, string extraInformation = "")
        {
            Task.Factory.StartNew(
                () =>
                    {
                        if (!Directory.Exists(logPath))
                        {
                            Directory.CreateDirectory(logPath);
                        }

                        StringBuilder path =
                            new StringBuilder(logPath).Append("/")
                                .Append(DateTime.Now.ToString("dd-MM-yyyy"))
                                .Append("_Exceptions.log");

                        var message = new StringBuilder();
                        bool isInner = false;
                        var log = new Log();
                        var logBackup = log;
                        while (e != null)
                        {
                            var logs = new Log
                                           {
                                               CreateDate = DateTime.Now, 
                                               Exception = e.Message, 
                                               Message = extraInformation, 
                                               StackTrace = e.StackTrace, 
                                               LogLevel = isInner ? "Inner Exception" : "Main Exception"
                                           };

                            message.Append(DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss"))
                                .Append("  ")
                                .Append(extraInformation)
                                .Append(Environment.NewLine)
                                .Append(e.Message);
                            message.Append(Environment.NewLine)
                                .Append(e.StackTrace)
                                .Append(Environment.NewLine)
                                .Append(Environment.NewLine)
                                .Append(
                                    "********************************************************************************************")
                                .Append(Environment.NewLine)
                                .Append(Environment.NewLine);
                            e = e.InnerException;
                            if (isInner)
                            {
                                log.Log1.Add(logs);
                            }
                            else
                            {
                                logBackup = logs;
                            }

                            log = logs;
                            isInner = true;
                        }

                        Logging.Add(logBackup);
                        message.Append(
                            "========================================================================================================")
                            .Append(Environment.NewLine)
                            .Append(Environment.NewLine);
                        lock (Locker)
                        {
                            File.AppendAllText(path.ToString(), message.ToString());
                        }

                        Logging.Save();
                    });
        }

        /// <summary>
        /// The log info.
        /// </summary>
        /// <param name="info">
        /// The info.
        /// </param>
        public static void LogInfo(string info)
        {
            Task.Factory.StartNew(
                () =>
                    {
                        if (!Directory.Exists(logPath))
                        {
                            Directory.CreateDirectory(logPath);
                        }

                        var path = new StringBuilder(logPath);
                        path.Append("/").Append(DateTime.Now.ToString("dd-MM-yyyy")).Append("_Info.log");

                        StringBuilder message =
                            new StringBuilder(DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss")).Append("  ").Append(info);
                        message.Append(Environment.NewLine)
                            .Append("====================================================")
                            .Append(Environment.NewLine);
                        lock (Locker)
                        {
                            File.AppendAllText(path.ToString(), message.ToString());
                        }
                    });
        }

        #endregion
    }
}