using System;
using System.Collections.Generic;
using System.Linq;
using Refactoring.Repository;

namespace Refactoring.Services
{
    public interface ICommandOperations
    {
        bool KeepProcess { get; set; }
        void ReadString(string pCommand);
        void ShowCommands();
    }


    public class CommandOperations : ICommandOperations
    {
        private readonly IShapeRepository shapeRepository;
        private readonly ISelector shapeSelector;
        private readonly ILogger logger;

        public bool KeepProcess { get; set; }

        private readonly IDictionary<OperationTypes, Action<List<string>>> commandDict;

        public CommandOperations(
            IShapeRepository shapeRepository,
            ISelector shapeSelector,
            ILogger logger)
        {
            this.shapeRepository = shapeRepository;
            this.shapeSelector = shapeSelector;
            this.logger = logger;

            KeepProcess = true;

            commandDict = new Dictionary<OperationTypes, Action<List<string>>>
            {
                {OperationTypes.create, Create},
                {OperationTypes.calculate, Calculate},
                {OperationTypes.print, Print},
                {OperationTypes.reset, Reset},
                {OperationTypes.exit, Exit}
            };
        }


        public void ReadString(string pCommand)
        {
            var arrCommands = pCommand.Split(' ').ToList();

            OperationTypes operation;

            if (!Enum.TryParse(arrCommands[0].ToLowerInvariant(), out operation))
            {
                logger.Log("Unknown command!!!");
                ShowCommands();
                return;
            }

            var commandAction = commandDict[operation];
            commandAction.Invoke(arrCommands);
            
        }

        public void Create(List<string> arrCommands)
        {
            try
            {
                var shape = shapeSelector.Get(arrCommands);
                shapeRepository.Add(shape);
                logger.Log($"{shape.Name} created!");
            }
            catch (Exception ex)
            {
                logger.Log(ex.Message);
                ShowCommands();
            }
        }

        public void Calculate(List<string> arrCommands)
        {
            try
            {
                shapeRepository.CalculateSurfaceAreas();
            }
            catch (Exception ex)
            {
                logger.Log(ex.Message);
            }
        }

        public void Print(List<string> arrCommands)
        {
            try
            {
                shapeRepository.Print();
            }
            catch (Exception ex)
            {
                logger.Log(ex.Message);
            }
        }

        public void Reset(List<string> arrCommands)
        {
            shapeRepository.Clear();
            logger.Log("Reset state!!");
        }

        public void Exit(List<string> arrCommands)
        {
            KeepProcess = false;
        }

        public void ShowCommands()
        {
            logger.Log("commands:");
            logger.Log("- create square {double} (create a new square)");
            logger.Log("- create circle {double} (create a new circle)");
            logger.Log("- create rectangle {height} {width} (create a new rectangle)");
            logger.Log("- create triangle {height} {width} (create a new triangle)");
            logger.Log("- create trapezoid {height} {upperWidth} {lowerWidth} (create a new trapezoid)");
            logger.Log("- print (print the calculated surface areas)");
            logger.Log("- calculate (calulate the surface areas of the created shapes)");
            logger.Log("- reset (reset)");
            logger.Log("- exit (exit the loop)");
        }
    }
}
