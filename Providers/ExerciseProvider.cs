using System;
using Classes;
using Interfaces;
using Exercises;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Classes.Common;
using U = Classes.Common.Utils;
using P = Classes.Common.Parser;

namespace Providers
{
    public static class ExerciseProvider
    {

        public static List<ExerciseFlow> Load() => PrepareFlows(
            new() { BasicExercises.Instance.GetExercises() }
        );

        public static void ExercisePattern<T>(T data, Action<T> dataOutputCb)
        {
            U.EmptyLine();
            U.BreakLine(" Results ");
            U.EmptyLine();
            dataOutputCb(data);
        }

        private static List<ExerciseFlow> PrepareFlows( List<List<ExerciseFlow>> flows)
        {
            List<ExerciseFlow> temp = new();

            foreach(var list in flows)
                temp.AddRange(list);

            return temp;
        }
    }
}
