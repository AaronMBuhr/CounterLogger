using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Threading;

namespace CounterLogger
{
    class Program
    {

        private static bool quit_requested_ = false;

        static void ShowHelp()
        {
            Console.WriteLine("Appends lines with line number to given file. Usage:");
            Console.WriteLine("LogCounter filename lineprefix msecperline");

        }

        static void Main(string[] args)
        {
            if (args.Length < 3)
            {
                ShowHelp();
                return;
            }

            Console.CancelKeyPress += (object sender, ConsoleCancelEventArgs e) => { e.Cancel = true; quit_requested_ = true; };

            int i = 0;
            using (StreamWriter sw = File.AppendText(args[0]))
            {
                while (!quit_requested_)
                {
                    ++i;
                    Console.WriteLine("Line {0} {1:0000000}", args[1], i);
                    sw.WriteLine("Line {0} {1:0000000}", args[1], i);
                    System.Threading.Thread.Sleep(int.Parse(args[2]));
                }
            }
            Console.WriteLine("Quit requested, exiting");
        }
    }
}
