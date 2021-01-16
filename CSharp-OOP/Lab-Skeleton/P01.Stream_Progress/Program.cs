using System;

namespace P01.Stream_Progress
{
    public class Program
    {
        static void Main()
        {
            BaseClass baseClass;
            StreamProgressInfo streamProgress;

            baseClass = new File("Nayo", 114,214 );
            baseClass = new Music("Nayo","The best Album", 114, 214);

            streamProgress = new StreamProgressInfo(baseClass);

            Console.WriteLine(streamProgress.CalculateCurrentPercent());

        }
    }
}
