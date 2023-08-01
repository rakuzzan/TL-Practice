using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Calculator.Pages
{
    public class CalculateModel : PageModel
    {
        public long FirstNumber { get; set; }
        public long SecondNumber { get; set; }
        public string Operation { get; set; }

        public long Result { get; set; }
        public List<int> FirstNumberDigits { get; set; }
        public List<int> SecondNumberDigits { get; set; }
        public List<int> ResultDigits { get; set; }
        public bool IsMinus { get; set; } = false;

        public List<int> PlusExtraIndexes { get; set; }

        public List<int> DotsIndexes { get; set; }
        public List<int> TensIndexes { get; set; }

        public void OnGet(long firstNumber, long secondNumber, string operation)
        {
            Operation = operation;

            if (Operation == "-" && (firstNumber < secondNumber))
            {
                FirstNumber = secondNumber;
                SecondNumber = firstNumber;
                IsMinus = true;

                Result = -1 * CalculateResult(SecondNumber, FirstNumber, Operation);

            }
            else
            {
                FirstNumber = firstNumber;
                SecondNumber = secondNumber;
                Result = CalculateResult(FirstNumber, SecondNumber, Operation);
            }

            FirstNumberDigits = GetDigits(FirstNumber);
            SecondNumberDigits = GetDigits(SecondNumber);
            ResultDigits = GetDigits(Result);

            if (Operation == "+")
            {
                PlusExtraIndexes = GetPlusExtraIndexes();
            }

            if (Operation == "-")
            {
                (DotsIndexes, TensIndexes) = GetMinusExtraIndexes();
            }

        }

        private long CalculateResult(long firstNumber, long secondNumber, string operation)
        {
            switch (operation)
            {
                case "+":
                    return firstNumber + secondNumber;
                case "-":
                    return firstNumber - secondNumber;
                default:
                    return 0;
            }
        }

        public List<int> GetDigits(long number)
        {
            List<int> digits = new List<int>();

            if (number == 0)
            {
                digits.Add(0);
            }
            else 
            {
                do
                {
                    int digit = (int)(number % 10);
                    digits.Add(digit);
                    number /= 10;
                } while (number > 0);
            }

            digits.Reverse();
            return digits;
        }

        public List<int> GetPlusExtraIndexes()
        {
            List<int> indexes = new List<int>();

            List<int> longestDigitsReversed = new List<int>(FirstNumberDigits.Count > SecondNumberDigits.Count ? FirstNumberDigits : SecondNumberDigits);
            longestDigitsReversed.Reverse();

            List<int> smallestDigitsReversed = new List<int>(FirstNumberDigits.Count < SecondNumberDigits.Count ? FirstNumberDigits : SecondNumberDigits);
            smallestDigitsReversed.Reverse();

            int maxSize = longestDigitsReversed.Count;
            int minSize = smallestDigitsReversed.Count;

            for (int i = 0; i < longestDigitsReversed.Count; i++)
            {
                if (i < minSize)
                {
                    if (longestDigitsReversed[i] + smallestDigitsReversed[i] >= 10 ||
                        indexes.Count != 0 && (indexes[indexes.Count - 1] == maxSize - i - 1))
                    {
                        indexes.Add(maxSize - 2 - i);
                    }
                }
                else
                {
                    if (indexes.Count != 0 && (indexes[indexes.Count - 1] == maxSize - i - 1))
                    {
                        if (longestDigitsReversed[i] + 1 >= 10)
                        {
                            indexes.Add(maxSize - 2 - i);
                        }
                    }
                }
            }

            return indexes;
        }

        public (List<int>, List<int>) GetMinusExtraIndexes()
        {
            List<int> dotsIndexes = new List<int>();
            List<int> tensIndexes = new List<int>();

            List<int> firstNumberDigitsReversed = new List<int>(FirstNumberDigits);
            firstNumberDigitsReversed.Reverse();

            List<int> secondNumberDigitsReversed = new List<int>(SecondNumberDigits);
            secondNumberDigitsReversed.Reverse();

            int maxSize = Math.Max(FirstNumberDigits.Count, SecondNumberDigits.Count);
            int minSize = Math.Min(FirstNumberDigits.Count, SecondNumberDigits.Count);

            for (int i = 0; i < maxSize; i++)
            {
                if (i < minSize)
                {
                    if (firstNumberDigitsReversed[i] - secondNumberDigitsReversed[i] < 0)
                    {
                        dotsIndexes.Add(maxSize - 2 - i);
                        tensIndexes.Add(maxSize - 1 - i);
                    }
                }
                else
                {
                    if (dotsIndexes.Count != 0 && (dotsIndexes[dotsIndexes.Count - 1] == maxSize - i - 1))
                    {
                        if (firstNumberDigitsReversed[i] - 1 < 0)
                        {
                            dotsIndexes.Add(maxSize - 2 - i);
                            tensIndexes.Add(maxSize - 1 - i);
                        }
                    }
                }
            }

            return (dotsIndexes, tensIndexes);
        }
    }
}