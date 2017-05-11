using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Topshelf; 
using Common.Logging;


namespace Wx.Task
{
    class Program
    {
        static void Main(string[] args)
        {
             HostFactory.Run(x =>
            {
                x.UseNLog(); 
                x.Service<ServiceRunner>(); 
                x.SetDescription("QuartzDemo服务描述");
                x.SetDisplayName("QuartzDemo服务显示名称");
                x.SetServiceName("QuartzDemo服务名称"); 
                x.EnablePauseAndContinue();
            });
        }
    }
}
