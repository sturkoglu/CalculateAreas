using System;

namespace Refactoring
{
    public interface ILogger
    {
        void Log(string log);
    }

    public class Logger : ILogger
    {
        public void Log(string pLog)
        {
            Console.WriteLine(pLog);
        }
    }
}
