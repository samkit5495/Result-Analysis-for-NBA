using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Result_Analysis_for_NBA
{
    class Server
    {
        public void start()
        {
            Process process = new Process();
            process.StartInfo.FileName = "mongod.exe";
            process.StartInfo.WorkingDirectory = @"C:\Program Files\MongoDB\Server\3.0\bin";
            process.StartInfo.Arguments = @" --dbpath ""D:\Dropbox\Documents\Project\NBA Project\Result Analysis for NBA\DB""";
            process.StartInfo.WindowStyle = ProcessWindowStyle.Minimized;
            process.Start();
        }
        public void stop()
        {
            Process[] pro = Process.GetProcessesByName("mongod");
            foreach(Process process in pro)
            {
                process.CloseMainWindow();
            }
        }
    }
}
