using System;
using Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes
{
    public class ExercisesAssembly : IExercisesAssembly
    {
        private IExercisesAssembly.CbExercises _cbExercises { get; set; }
        public IExercisesAssembly.CbExercises GetExercises => _cbExercises;

        public ExercisesAssembly(IExercisesAssembly.CbExercises cb) => _cbExercises = cb;
    }
}
