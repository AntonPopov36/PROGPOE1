//Author Anton Popov st10090667 group 1
using System;
using System.Collections.Generic;
namespace PersonalBudgetAYP
{
    public class EnterExpenses : Expense
    {
        //declarations
        public List<double> ExpenseStorage = new List<double>();
        public double addtolist;
        public int otherExpLoop = 1, otherArr = 5;

        public override void EnterDetails()
        {
            Console.Write("\n***********************************************************************************************************\n" +
                            "ENTER EXPENSE DETAILS                                                                                     *\n" +
                            "***********************************************************************************************************\n" +
                            "Grocieries: R");

            //input and error catching, try parse is used to make sure user doesnt enter a string instead of a double
            while (validInLoop == 1)
            {
                enterString = Console.ReadLine();
                if (double.TryParse(enterString, out addtolist))
                {
                    ExpenseStorage.Add(addtolist);
                    validInLoop++;
                }
                else
                    Console.WriteLine(errorMess);
            }
            validInLoop = 1;

            Console.Write("Water: R");

            while (validInLoop == 1)
            {
                enterString = Console.ReadLine();
                if (double.TryParse(enterString, out addtolist))
                {
                    ExpenseStorage.Add(addtolist);
                    validInLoop++;
                }
                else
                    Console.WriteLine(errorMess);
            }
            validInLoop = 1;

            Console.Write("Electricity: R");

            while (validInLoop == 1)
            {
                enterString = Console.ReadLine();
                if (double.TryParse(enterString, out addtolist))
                {
                    ExpenseStorage.Add(addtolist);
                    validInLoop++;
                }
                else
                    Console.WriteLine(errorMess);
            }
            validInLoop = 1;

            Console.Write("Travel: R");

            while (validInLoop == 1)
            {
                enterString = Console.ReadLine();
                if (double.TryParse(enterString, out addtolist))
                {
                    ExpenseStorage.Add(addtolist);
                    validInLoop++;
                }
                else
                    Console.WriteLine(errorMess);
            }
            validInLoop = 1;

            Console.Write("Cellphone: R");

            while (validInLoop == 1)
            {
                enterString = Console.ReadLine();
                if (double.TryParse(enterString, out addtolist))
                {
                    ExpenseStorage.Add(addtolist);
                    validInLoop++;
                }
                else
                    Console.WriteLine(errorMess);
            }
            validInLoop = 1;

            //other expenses loop
            Console.Write("Keep entering expense values till finished, to stop enter a '#'.\n");

            while (otherExpLoop == 1)
            {
                Console.Write("Other Expense: R");
                enterString = Console.ReadLine();
                if (enterString.Equals("#"))
                {
                    otherExpLoop++;
                }
                else if (double.TryParse(enterString, out addtolist)) //(Bella, 2022)
                {
                    ExpenseStorage.Add(addtolist);
                }
                else
                {
                    Console.WriteLine(errorMess);
                }
            }
        }

        public override void CalculateTotal()
        {
            total = 0;
            foreach (int i in ExpenseStorage)
            {
                total += i;
            }

            if (expenseCounter < 1)
            {
                totalExpenses += total;
                expenseCounter++;
            }
        }
    }
}
//Author Anton Popov st10090667 group 1