//Author Anton Popov st10090667 group 1
using System;
namespace PersonalBudgetAYP
{
    public class HomeLone : Expense
    {
        //declarations

        public override void EnterDetails()
        {
            Console.Write("\n***********************************************************************************************************\n" +
                            "ENTER HOME DETAILS                                                                                        *\n" +
                            "***********************************************************************************************************\n");

            //input and error catching, try parse is used to make sure user doesnt enter a string instead of a double (Bella, 2022)
            Console.Write("Home price: R");
            while (validInLoop == 1)
            {
                enterString = Console.ReadLine();
                if (double.TryParse(enterString, out price))
                    validInLoop++;
                else
                    Console.WriteLine(errorMess);
            }
            validInLoop = 1;


            Console.Write("Deposit: R"); 
            while (validInLoop == 1)
            {
                enterString = Console.ReadLine();
                if (double.TryParse(enterString, out deposit)) //(Bella, 2022)
                    validInLoop++;
                else
                    Console.WriteLine(errorMess);
            }
            validInLoop = 1;


            Console.Write("Interest (a number without a % sign): "); 
            while (validInLoop == 1)
            {
                enterString = Console.ReadLine();
                if (double.TryParse(enterString, out interest)) //(Bella, 2022)
                    validInLoop++;
                else
                    Console.WriteLine(errorMess);
            }
            validInLoop = 1;


            Console.Write("Amount of months to repay: ");
            while (validInLoop == 1)
            {
                enterString = Console.ReadLine();
                if (double.TryParse(enterString, out months)) //(Bella, 2022)
                    validInLoop++;
                else
                    Console.WriteLine(errorMess);
            }


        }

        public override void CalculateTotal()
        {
            total = 0;
            total = (price*(1+(interest/100)*(months/12)))/months;

            if (homeCounter < 1)
            {
                totalExpenses += total;
                homeCounter++;
            }
        }

        public void checkApproval(double income)
        {
            if (total > income / 3)
                Console.WriteLine("Please note that your income is likely not great enough to be approved for this loan.");
                Console.WriteLine("Please make sure you did enter your gross monthly income correctly.");
        }
    }
}
//Author Anton Popov st10090667 group 1