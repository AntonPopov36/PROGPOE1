//Author Anton Popov st10090667 group 1
using System;
namespace PersonalBudgetAYP
{
    public class Rent : Expense
    {
        //declarations

        public override void CalculateTotal()
        {
            total = price;

            if (homeCounter < 1)
            {
                totalExpenses += total;
                homeCounter++;
            }
        }

        public override void EnterDetails()
        {
            Console.Write("\n**********************************************************************************************************\n" +
                            "ENTER RENT DETAILS                                                                                       *\n" +
                            "**********************************************************************************************************\n" +
                            "Rent price: R");

            //input and error catching, try parse is used to make sure user doesnt enter a string instead of a double //(Bella, 2022)
            while (validInLoop == 1)
            {
                enterString = Console.ReadLine();
                if (double.TryParse(enterString, out price)) //(Bella, 2022)
                    validInLoop++;
                else
                    Console.WriteLine(errorMess);
            }
            validInLoop = 1;
        }
    }
}
//Author Anton Popov st10090667 group 1