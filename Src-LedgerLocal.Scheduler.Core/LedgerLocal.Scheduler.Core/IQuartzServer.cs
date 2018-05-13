using System;
using System.Threading.Tasks;

namespace LedgerLocal.Scheduler.Core
{
    /// <summary>
    /// Service interface for core Quartz.NET server.
    /// </summary>
    public interface IQuartzServer
    {
        /// <summary>
        /// Initializes the instance of <see cref="IQuartzServer"/>.
        /// Initialization will only be called once in server's lifetime.
        /// </summary>
        Task InitializeAsync();

        /// <summary>
        /// Starts this instance.
        /// </summary>
        Task StartAsync();

        /// <summary>
        /// Stops this instance.
        /// </summary>
        Task StopAsync();

        ///// <summary>
        ///// Pauses all activity in scheduler.
        ///// </summary>
        //void Pause();

        ///// <summary>
        ///// Resumes all activity in server.
        ///// </summary>
        //void Resume();
    }
}
