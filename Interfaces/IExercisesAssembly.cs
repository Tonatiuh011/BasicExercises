using Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{
    public interface IExercisesAssembly
    {
        delegate List<ExerciseFlow> CbExercises();

        List<ExerciseFlow> Exercises => GetExercises();
        CbExercises GetExercises { get; }
    }
}
