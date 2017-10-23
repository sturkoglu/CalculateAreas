using System;
using Refactoring.Config;
using Refactoring.Services;
using SimpleInjector;

namespace Refactoring
{
    class Program
    {
        static void Main(string[] args)
        {
            var container = new Container();
            var bootstrapper = new Bootstrapper(container);
            bootstrapper.Register();


            Console.WriteLine(" -------------------------------------------------------------------------- ");
            Console.WriteLine("| Greetings and salutations fellow developer :D                            |");
            Console.WriteLine("|                                                                          |");
            Console.WriteLine("| If you are reading this we probably want to know if you know your stuff. |");
            Console.WriteLine("|                                                                          |");
            Console.WriteLine("| How would you improve this code?                                         |");
            Console.WriteLine("| We challenge you to refactor this and show us how awesome you are ;)     |");
            Console.WriteLine("| We also really like trapezoids so could you also implement that for us?  |");
            Console.WriteLine("|                                                                          |");
            Console.WriteLine("|                                                               Good luck! |");
            Console.WriteLine(" --------------------------------------------------------------------------");

            var commandOperations = container.GetInstance<ICommandOperations>();

            commandOperations.ShowCommands();

            do
            {
                commandOperations.ReadString(Console.ReadLine());
            } while (commandOperations.KeepProcess);

            Console.ReadKey();
        }
    }
}
