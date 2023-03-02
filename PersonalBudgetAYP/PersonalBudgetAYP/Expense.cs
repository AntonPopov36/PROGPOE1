//Author Anton Popov st10090667 group 1
using System;
namespace PersonalBudgetAYP
{
    public abstract class Expense
    {
        //declarations
        public double[] storageArr;
        public double total = 0, price = 0, deposit = 0, interest = 0, months = 0;
        //counters to make sure expenses dont get added twice
        public double carCounter = 0, homeCounter = 0, expenseCounter = 0;
        //calculate all expenses
        public double totalExpenses = 0;
        public int validInLoop = 1;
        public string enterString, errorMess = "Invlad input, please enter a number or decimal using a full stop -> '.' , without any letters or special charcters.";

        //properties
        public double Total
        {
            get { return total; }
        }

        public double Price
        {
            get { return price; }
        }

        public double Deposit
        {
            get { return deposit; }
        }

        public double Interest
        {
            get { return interest; }
        }

        public double Months
        {
            get { return months; }
        }

        //abstract methods to override
        public abstract void EnterDetails();

        public abstract void CalculateTotal();

    }
}
//Author Anton Popov st10090667 group 1