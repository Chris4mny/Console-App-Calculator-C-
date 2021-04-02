using System;
using System.Collections.Generic;
using System.Text;

namespace app01
{
    class SixFunctionCalculator
    {
        private double numberOne;
        private double numberTwo;
        private double results;
        private char calcFunction;
        private string useAgain;

        public SixFunctionCalculator()
        {
            WelcomeToCalculatorMessage();

            numberOne = ObtainAnIntegerOrADoubleToUse("\nEnter number 1: "); // Enter an Integer or doublr

            calcFunction = PickAFunctionToUse(); // decide which math function to use

            numberTwo = ObtainAnIntegerOrADoubleToUse("\nEnter number 2: "); // Enter an Integer or double

            results = Calculator(numberOne, numberTwo, calcFunction); // sends to proper calculation 

            DisplayCalculatorResults(numberOne, numberTwo, results, calcFunction); // displays results

            useAgain = ContinueUsingCalculator(); // question to continue using calculator

            DetermineToContinue(useAgain); // if continue is yes run again, if no end program 
        }
        
        public void WelcomeToCalculatorMessage() // welcome message to calculator program
        {
            Console.WriteLine("Welcome to the Six Function Calculator Program");

        }
        
        public double Calculator(double numberOne, double numberTwo, char calcFunction) // pick one of six functions to use
        {
            if (calcFunction == '+')
            {
                double adding = AdditionFunction(numberOne, numberTwo);

                return adding;
            }

            else if (calcFunction == '-')
            {
                double subtracting = SubtractionFunction(numberOne, numberTwo);

                return subtracting;
            }

            else if (calcFunction == '*')
            {
                double multiplying = MultiplicationFunction(numberOne, numberTwo);

                return multiplying;
            }

            else if (calcFunction == '/')
            {
                double nonIntDiv = NonIntegerdivisionFunction(numberOne, numberTwo);

                return nonIntDiv;
            }

            else if (calcFunction == '\\')
            {
                double intDiv = IntegerDivisionFunction(numberOne, numberTwo);

                return (int)intDiv;
            }

            else if (calcFunction == '%')
            {
                double mod = ModulusFunction(numberOne, numberTwo);

                return (int)mod;
            }
            else
            {
                Console.WriteLine("Invalid entry, End of Program\n");

                System.Environment.Exit(1);
            }

            return 0;
        }
        
        public double ObtainAnIntegerOrADoubleToUse(String theQuestion) // obtain an int or double 
        {
            String tempInputString;
            double theNumber;

            do
            {
                Console.Write(theQuestion);

                tempInputString = Console.ReadLine();

            } while (!CanBeDouble(tempInputString));

            theNumber = Convert.ToDouble(tempInputString);

            return theNumber;
        }
        
        public char PickAFunctionToUse() // pick a char then send it to display function and calculator
        {
            String function;
            char functionType = (char)0;

            Console.Write("\nChoose a function: \nEnter (+) for ADDITION\nEnter (-) for SUBTRACTION\nEnter (*) for MULTIPLICATION\nEnter (/) for DIVISION\nEnter (%) for MODULUS\nEnter (\\) for INTEGER DIVISION\nEnter Function:  ");

            function = Console.ReadLine();

            for (int i = 0; i < function.Length; i++)
            {
                functionType = function[i];
            }

            return functionType;
        }
        
        public bool CanBeDouble(String tempInputString) // doc taught/ wrote in class
        {
            int lookAtCharAt = 0;
            bool decimalPointFound = false;

            if (tempInputString[0] == '+' || tempInputString[0] == '-')
            {
                lookAtCharAt = 1;
            }

            for (; lookAtCharAt < tempInputString.Length; lookAtCharAt++)
            {
                if (!decimalPointFound && tempInputString[lookAtCharAt] == '.')
                {
                    lookAtCharAt++;
                    decimalPointFound = true;
                }

                if (tempInputString[lookAtCharAt] < '0' || tempInputString[lookAtCharAt] > '9')
                {
                    return false;
                }
            }

            return true;
        }
        
        public double AdditionFunction(double numberOne, double numberTwo) // performs addition
        {
            double result;

            result = (numberOne + numberTwo);

            return result;
        }
        
        public double SubtractionFunction(double numberOne, double numberTwo) // performs subtraction
        {
            double result;

            result = (numberOne - numberTwo);

            return result;
        }
        
        public double MultiplicationFunction(double numberOne, double numberTwo) // performs multiplication
        {
            double result;

            result = (numberOne * numberTwo);

            return result;
        }
        
        public double NonIntegerdivisionFunction(double numberOne, double numberTwo) // performs regular division 
        {
            CheckDenominatorForZero(numberTwo);

            double result;

            result = numberOne / numberTwo;

            return result;
        }
        
        public double IntegerDivisionFunction(double numberOne, double numberTwo) // performs integer division
        {
            CheckDenominatorForZero(numberTwo);

            double result;

            result = (numberOne / numberTwo);

            return result;

        }
        
        public double ModulusFunction(double numberOne, double numberTwo) // performs modulus division 
        {
            CheckDenominatorForZero(numberTwo);

            double result;

            result = (numberOne % numberTwo);

            return result;
        }
        
        public void CheckDenominatorForZero(double numberTwo) // checks denominator for zero and exits program
        {
            string tryAgain;

            if (numberTwo == 0)
            {
                Console.WriteLine("\nDenominator cannot be zero");

                tryAgain = ContinueUsingCalculator();

                DetermineToContinue(tryAgain);
            }
        }
        
        public void DisplayCalculatorResults(double numberOne, double numberTwo, double results, char functionType) // displays the results
        {
            Console.WriteLine("\nThe results of " + numberOne + " " + functionType + " " + numberTwo + " is: " + results);
        }
        
        public String ContinueUsingCalculator() // question and decision to continue
        {
            String tempString;

            Console.Write("\nDo you want to continue using the calculator?\nEnter \"yes\" or \"no\":  ");

            tempString = Console.ReadLine();

            return tempString;
        }
        
        public void DetermineToContinue(String choice) // if yes calculate again, if no exit
        {
            if (choice == ("yes"))
            {
                double numberOne;
                double numberTwo;
                double results;
                char calcFunction;
                String useAgain;

                numberOne = ObtainAnIntegerOrADoubleToUse("Enter number 1: ");

                calcFunction = PickAFunctionToUse();

                numberTwo = ObtainAnIntegerOrADoubleToUse("Enter number 2: ");

                results = Calculator(numberOne, numberTwo, calcFunction);

                DisplayCalculatorResults(numberOne, numberTwo, results, calcFunction);

                useAgain = ContinueUsingCalculator();

                DetermineToContinue(useAgain);

            }
            else if (choice == ("no"))
            {
                ExitTheCalculatorProgram();
            }
            else
            {
                Console.WriteLine("\nInvalid entry, End of Program");

                System.Environment.Exit(1);
            }
        }
        
        public void ExitTheCalculatorProgram()
        {
            Console.WriteLine("\nEnd of program");

            System.Environment.Exit(1);
        }
    }
}
