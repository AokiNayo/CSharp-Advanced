using System;

namespace Stealer
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Spy spy = new Spy();
            string result = spy.StealFieldInfo("Stealer.Hacker", "username", "password");
            string analyzedData = spy.AnalyzeAcessModifiers("Stealer.Hacker");

            Console.WriteLine(result);
            Console.WriteLine(new string('-', 60));
            Console.WriteLine(analyzedData);
        }
    }
}
