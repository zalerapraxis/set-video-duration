using System;

namespace set_video_duration
{
    class Program
    {
        static void Main(string[] args = null)
        {
            string startTimeArg;
            string endTimeArg;

            if (args.Length == 2)
            {
                startTimeArg = args[0];
                endTimeArg = args[1];

                // debug values 
                // startTimeArg = "00:00:05";
                // endTimeArg = "00:01:10";
            }
            else
            {
                Console.WriteLine("Null or bad params passed, falling back.");

                Console.WriteLine("Start time: ");
                startTimeArg = Console.ReadLine();

                Console.WriteLine("End time: ");
                endTimeArg = Console.ReadLine();
            }

            var startParseSuccess = TimeSpan.TryParse(startTimeArg, out var startTime);
            var endParseSuccess = TimeSpan.TryParse(endTimeArg, out var endTime);

            if (!startParseSuccess || !endParseSuccess)
            {
                Console.WriteLine("Invalid parameters entered.");
                return;
            }

            var durationSeconds = endTime.Subtract(startTime).TotalSeconds;

            Console.WriteLine($"--position {startTime.TotalSeconds} --duration {durationSeconds}");
        }
    }
}
