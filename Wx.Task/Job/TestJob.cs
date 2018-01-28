using Common.Logging;
using Quartz;

namespace Wx.Task.Job
{
    public class TestJob : IJob
    {
        private readonly ILog _logger = LogManager.GetLogger(typeof(TestJob));
        public void Execute(IJobExecutionContext context)
        { 
            _logger.InfoFormat("TestJob测试");
        }


    }
}
