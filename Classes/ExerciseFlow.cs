using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using U = Classes.Common.Utils;
using P = Classes.Common.Parser;

namespace Classes
{
    public class ExerciseFlow
    {
        public int? Id { get; set; }
        public string? Name { get; set; }
        public Action? Action { get; set; }

        public static void ExecuteFlow(ExerciseFlow? flow)
        {
            var flowName = flow?.Name;

            try
            {

                U.BreakLine($" Flow: {flowName} ");
                U.EmptyLine();
                flow?.Action?.Invoke();

            }
            catch (Exception e)
            {

                U.BreakLine(" Errors on Running ");
                U.EmptyLine();
                U.PrintResult($"Error Processing [{flowName}]", e.Message);
            }

            U.EmptyLine();
            U.BreakLine(" End ");
        }
    }
}
