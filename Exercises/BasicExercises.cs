using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Classes;
using Classes.Common;
using EP = Providers.ExerciseProvider;
using U = Classes.Common.Utils;
using P = Classes.Common.Parser;
using Interfaces;

namespace Exercises
{
    public class BasicExercises : ExercisesAssembly
    {
        private static readonly List<ExerciseFlow> Exercises = BasicList();
        private static BasicExercises _instance = new(() => Exercises);

        public static BasicExercises Instance => _instance;

        private BasicExercises(IExercisesAssembly.CbExercises cb) : base(cb) { }

        private static List<ExerciseFlow> BasicList() => new()
        {
            new ExerciseFlow()
            {
                Id = 1,
                Name = "Hello World",
                Action = () => U.PrintResult("Says", "Just a greeting")
            },
            new ExerciseFlow()
            {
                Id = 2,
                Name = "Sum of Two Numbers",
                Action = () => EP.ExercisePattern(new {
                    num1 = U.ReadLine<int>("Enter Number 1"),
                    num2 = U.ReadLine<int>("Enter Number 2")
                }, d =>
                {
                    var result = U.MathProcessor(() => d.num1 + d.num2);
                    U.PrintResult("The result of Sum is", result);
                })
            },
            new ExerciseFlow()
            {
                Id = 3,
                Name = "Division of Two Numbers",
                Action = () => EP.ExercisePattern(new
                {
                    num1 = U.ReadLine<decimal>("Enter Number 1"),
                    num2 = U.ReadLine<decimal>("Enter Number 2")
                }, d =>
                {
                    var result = U.MathProcessor(() => d.num1 / d.num2);
                    U.PrintResult("The result of Division is", result);
                })
            },
            new ExerciseFlow()
            {
                Id = 4,
                Name = "Basic Operations",
                Action = () => EP.ExercisePattern(new {
                    math1 = U.MathProcessor(() => -1 + 4 * 6),
                    math2 = U.MathProcessor(() => (35 + 5) % 7),
                    math3 = U.MathProcessor(() => 14 + -4 * 6 / 11),
                    math4 = U.MathProcessor(() => 2 + 15 / 6 * 1 - 7 % 2)
                }, d =>
                {
                    U.PrintResult("Operation 1. ( -1 + 4 * 6 )", d.math1);
                    U.PrintResult("Operation 2. ( (35 + 5) % 7 )", d.math2);
                    U.PrintResult("Operation 3. ( 14 + -4 * 6 / 11 )", d.math3);
                    U.PrintResult("Operation 4. ( 2 + 15 / 6 * 1 - 7 % 2 )", d.math4);
                })
            },
            new ExerciseFlow()
            {
                Id = 5,
                Name = "Swaping Numbers",
                Action = () => EP.ExercisePattern(new
                {
                    num1 = U.ReadLine<int>("Enter first Number"),
                    num2 = U.ReadLine<int>("Enter sencond Number"),
                }, d =>
                {
                    int temp = d.num1;

                    int num1 = d.num2;
                    int num2 = temp;

                    U.PrintResult("This is the first Number", num1.ToString());
                    U.PrintResult("This is the second Number", num2.ToString());
                })
            },
            new ExerciseFlow()
            {
                Id = 6,
                Name = "Multiplication of three numbers",
                Action = () => EP.ExercisePattern(new
                {
                    num1 = U.ReadLine<decimal>("Enter number 1"),
                    num2 = U.ReadLine<decimal>("Enter number 2"),
                    num3 = U.ReadLine<decimal>("Enter number 3")
                }, d =>
                {
                    var result = U.MathProcessor(() => d.num1 * d.num2 * d.num3);
                    U.PrintResult("The product is", result);
                })
            },
            new ExerciseFlow()
            {
                Id = 7,
                Name = "Calculator of Two numbers",
                Action = () => EP.ExercisePattern(new
                {
                    num1 = U.ReadLine<decimal>("Enter number 1"),
                    num2 = U.ReadLine<decimal>("Enter number 2")
                }, d =>
                {
                    var sum = U.MathProcessor(() => d.num1 + d.num2);
                    var substraction = U.MathProcessor(() => d.num1 - d.num2);
                    var product = U.MathProcessor(() => d.num1 * d.num2);
                    var mod = U.MathProcessor(() => d.num1 % d.num2);

                    U.PrintResult("The sum is", sum);
                    U.PrintResult("The substraction is", substraction);
                    U.PrintResult("The product is", product);
                    U.PrintResult("The mod is", mod);
                })
            },
            new ExerciseFlow()
            {
                Id = 8,
                Name = "Multiply Matrix",
                Action = () => EP.ExercisePattern(new {
                    num = U.ReadLine<int>("Enter number"),
                    multTimes = U.ReadLine<int>("Multiply x Times")
                }, d =>
                {
                    for(int i = 1; i <= d.multTimes; i++)
                        U.PrintResult($"{d.num}x{i}", U.MathProcessor(() => d.num * i));
                })
            },
            new ExerciseFlow()
            {
                Id = 9,
                Name = "Average of numbers",
                Action = () => EP.ExercisePattern(new {
                    num1 = U.ReadLine<decimal>("Enter first number"),
                    num2 = U.ReadLine<decimal>("Enter second number"),
                    num3 = U.ReadLine<decimal>("Enter third number")
                }, d => {

                    decimal[] nums = new decimal[] { d.num1, d.num2, d.num3 };
                    U.PrintResult($"The AVG of list ( { string.Join(", ", nums) } )", nums.Average().ToString());
                })
            },
            new ExerciseFlow()
            {
                Id = 10,
                Name = "Algebraic Operations",
                Action = () => EP.ExercisePattern(new
                {
                    x = U.ReadLine<decimal>("Enter X"),
                    y = U.ReadLine<decimal>("Enter Y"),
                    z = U.ReadLine<decimal>("Enter Z")
                }, d =>
                {
                    var operation1 = U.MathProcessor(() => (d.x + d.y) * d.z);
                    var operation2 = U.MathProcessor(() => d.x * d.y + d.z * d.y);

                    U.PrintResult($"Operation 1 -> [ ({d.x} + {d.y}) * {d.z} ]", operation1);
                    U.PrintResult($"Operation 2 -> [ ({d.x} * {d.y}) + ({d.y} * {d.z}) ]", operation2);

                })
            },
            new ExerciseFlow()
            {
                Id = 11,
                Name = "Age message",
                Action = () => EP.ExercisePattern(new
                {
                    age = U.ReadLine<int>("Enter your Age")
                }, d =>
                {
                    U.PrintMsg($"You look younger than {d.age}");
                })
            }
        };
    }
}
