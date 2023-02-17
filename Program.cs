using System;
using Providers;
using Classes;
using Classes.Common;
using U = Classes.Common.Utils;
using P = Classes.Common.Parser;

namespace Playground
{
    public static class Program {
        public static List<ExerciseFlow> Exercises {get; set;} = new();

        public static void Main(string[] args) 
        {
            var flows = ExerciseProvider.Load();

            foreach(ExerciseFlow flow in flows)            
                AddExercise(flow);
            
            LoadMenu();
        }

        public static void LoadMenu()
        {
            int selectedOption, exercisesCount = Exercises.Count, exitOption = exercisesCount + 1;

            do
            {
                U.BreakLine(" Playground Program ");
                U.EmptyLine();

                foreach (ExerciseFlow flow in Exercises)
                {
                    U.PrintMsg($"{flow.Id}.- {flow.Name}");
                }

                U.PrintMsg($"{exitOption}.- Exit");
                U.EmptyLine();

                selectedOption = U.ReadLine<int>("Select an option");
                U.EmptyLine();

                var exercise = FindExercise(selectedOption);

                if (exercise != null)
                {
                    Console.Clear();
                    ExerciseFlow.ExecuteFlow(exercise);                    
                } else
                {
                    U.PrintMsg("No exercise founded!");
                }

                U.EmptyLine();
                U.WaitLine();
                Console.Clear();

            } while (selectedOption != exitOption);

            U.PrintMsg("Sayonara Bye Bye!");
        }

        public static void AddExercise(ExerciseFlow flow) => Exercises.Add(flow);

        public static ExerciseFlow? FindExercise(int? id) => Exercises.Find(x => x.Id == id);        

    }

}