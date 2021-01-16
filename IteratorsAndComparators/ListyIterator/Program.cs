using System;
using System.Linq;

namespace ListyIterator
{
    public class Program
    {
        static void Main(string[] args)
        {
            string cmd = String.Empty;
            ListyIterator<string> collection = null;

            while ((cmd = Console.ReadLine())!= "END")
            {
                var cmdArgs = cmd.Split();

                switch (cmdArgs[0])
                {
                    case "Create": collection = new ListyIterator<string>(cmdArgs.Skip(1).ToArray());
                        break;
                    case "Move":
                        Console.WriteLine(collection.Move());
                        break;
                    case "HasNext":
                        Console.WriteLine(collection.HasNext());
                        break;
                    case "Print":
                        try
                        {
                            collection.Print();
                        }
                        catch (InvalidOperationException e)
                        {

                            Console.WriteLine(e.Message);
                        }
                        break;
                    case "PrintAll":
                        try
                        {
                            collection.PrintAll();
                        }
                        catch (InvalidOperationException e)
                        {
                            Console.WriteLine(e.Message);
                        }
                        break;
                }
            }
        }
    }
}
