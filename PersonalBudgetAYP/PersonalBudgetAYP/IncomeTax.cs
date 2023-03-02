//Author Anton Popov st10090667 group 1
using System;
namespace PersonalBudgetAYP
{
    public class IncomeTax : Expense
    {
        //declarations
        public double income, taxDeduct;

        public override void EnterDetails()
        {
            Console.Write("\n***********************************************************************************************************\n" +
                            "ENTER EXPENSE DETAILS                                                                                     *\n" +
                            "***********************************************************************************************************\n" +
                            "Gross monthly income: R");

            //input and error catching, try parse is used to make sure user doesnt enter a string instead of a double //(Bella, 2022)
            while (validInLoop == 1)
            {
                enterString = Console.ReadLine();
                if (double.TryParse(enterString, out income)) //(Bella, 2022)
                    validInLoop++;
                else
                    Console.WriteLine(errorMess);
            }
            validInLoop = 1;

            Console.Write("Estimated tax deduction (a number without a % sign): ");

            while (validInLoop == 1)
            {
                enterString = Console.ReadLine();
                if (double.TryParse(enterString, out taxDeduct)) //(Bella, 2022)
                    validInLoop++;
                else
                    Console.WriteLine(errorMess);
            }
            validInLoop = 1;
        }

        public override void CalculateTotal()
        {
            total = 0;
            total = income - (income*(taxDeduct/100));
        }
    }
}
//Author Anton Popov st10090667 group 1