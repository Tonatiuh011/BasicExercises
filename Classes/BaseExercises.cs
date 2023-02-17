using Classes;
using Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes
{
    public class BaseExercises<T> : IExerciseProvider where T : IExercisesAssembly
    {
        protected List<ExerciseFlow> _exerciseFlows = new();

        protected BaseExercises(T assembly) => Add(assembly.Exercises);

        public void Add(ExerciseFlow flow) => _exerciseFlows.Add(flow);
        public void Add(List<ExerciseFlow> flows) => _exerciseFlows.AddRange(flows);
        public List<ExerciseFlow> Load() => _exerciseFlows;
    }
}
