using System;

namespace SkillValue_SensitiveCells
{
    class Program
    {
        static void Main(string[] args)
        {
            var exampleArray = new[] {true, false, true, true,};
            new CellSimulator(2).Execute(exampleArray);


            
            Console.ReadKey();
        }
    }
}
