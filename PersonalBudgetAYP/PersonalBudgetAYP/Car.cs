using System;
namespace PersonalBudgetAYP
{
    public class Car : Expense
    {
        //declarations
        public string modMake;

        public override void EnterDetails()
        {

            Console.Write("\n***********************************************************************************************************\n" +
                            "ENTER CAR DETAILS                                                                                         *\n" +
                            "***********************************************************************************************************\n");

            Console.Write("Car model and make: ");
            while (validInLoop == 1)
            {
                enterString = Console.ReadLine();
                if (enterString.Equals(""))
                    Console.WriteLine("This field cannot be left blank, please enter a value.");
                else
                    modMake = enterString;
                    validInLoop++;
            }
            validInLoop = 1;

            Console.Write("Car price: R");
            while (validInLoop == 1)
            {
                enterString = Console.ReadLine();
                if (double.TryParse(enterString, out price))
                    validInLoop++;
                else
                    Console.WriteLine(errorMess);
            }
            validInLoop = 1;

            Console.Write("Interest (a number without a % sign): ");
            while (validInLoop == 1)
            {
                enterString = Console.ReadLine();
                if (double.TryParse(enterString, out interest))
                    validInLoop++;
                else
                    Console.WriteLine(errorMess);
            }
            validInLoop = 1;

            Console.Write("Car insurance price: R");
            while (validInLoop == 1)
            {
                enterString = Console.ReadLine();
                if (double.TryParse(enterString, out deposit))
                    validInLoop++;
                else
                    Console.WriteLine(errorMess);
            }
            validInLoop = 1;
        }

        public override void CalculateTotal()
        {
            total = 0;
            total = (price * (1 + (interest / 100) * (60 / 12))) / 60;

            if (carCounter < 1)
            { 
                totalExpenses += total;
                carCounter++;
            }
        }
    }
}