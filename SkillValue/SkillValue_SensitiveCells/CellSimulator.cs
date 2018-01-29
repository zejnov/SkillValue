using System;

namespace SkillValue_SensitiveCells
{
    public class CellSimulator
    {
        private int _count;
        public CellSimulator(int numberOfSimulations)
        {
            _count = numberOfSimulations;
        }

        public int[] Execute(bool[] inputArray)
        {
            for (int i = 0; i < _count; i++)
            {
                inputArray = CalculateStates(inputArray);
            }
            
            foreach (var field in inputArray)
            {
                Console.Write(field ? $"1 " : $"0 ");
            }

            return new[] {1};
        }

        private bool[] CalculateStates(bool[] inputArray)
        {
            var length = inputArray.Length;
            var calculatedArray = new bool[length];

            for (var i = 0; i < length; i++)
            {
                calculatedArray[i] = CalculateNewState(inputArray, i);
            }

            return calculatedArray;
        }

        private bool CalculateNewState(bool[] inputArray, int i)
        {
            var lengh = inputArray.Length - 1;
            var calculatedElement = false;

            if (!inputArray.IsFirst(i) && !inputArray.IsLast(i))
            {
                calculatedElement = (inputArray[i - 1] || inputArray[i + 1])
                                    && inputArray[i - 1] != inputArray[i + 1];
            }

            if (inputArray.IsFirst(i))
            {
                calculatedElement = (inputArray[lengh] || inputArray[i + 1])
                                    && inputArray[lengh] != inputArray[i + 1];
            }

            if (inputArray.IsLast(i))
            {
                calculatedElement = (inputArray[i - 1] || inputArray[0])
                                    && inputArray[i - 1] != inputArray[0];
            }

            return calculatedElement;
        }

    }

    internal static class ArrayExtensions
    {
        public static bool IsFirst(this bool[] array, int index)
        {
            return index == 0;
        }

        public static bool IsLast(this bool[] array, int index)
        {
            return index == array.Length - 1;
        }
    }
}
