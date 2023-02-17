using Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{
    public interface IExerciseProvider
    {
        void Add(ExerciseFlow flow);
        void Add(List<ExerciseFlow> flows);
        List<ExerciseFlow> Load();
    }
}
