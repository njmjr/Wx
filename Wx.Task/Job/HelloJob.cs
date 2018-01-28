using Common.Logging;
using Quartz;

namespace Wx.Task.Job
{
    public class HelloJob : IJob
    {
        private readonly ILog _logger = LogManager.GetLogger(typeof(HelloJob));
        public void Execute(IJobExecutionContext context)
        {
            _logger.InfoFormat("HelloJob测试");
        }


    }
}
