//Author Anton Popov st10090667 group 1
using System;
using System.Globalization;
using System.Threading;

namespace PersonalBudgetAYP
{
    class Program
    {
        static void Main(string[] args)
        {
            App newApp = new App();
            newApp.StartUp();
        }
    }

    class App
    {
        //keeping track of expenses
        public double finalExpenses = 0;

        //delgate for notifying user when expenses exeded 75% of income
        delegate void notifyUser(double expenses, double income);

        //declarations
        EnterExpenses myExpenses = new EnterExpenses();
        HomeLone myHome = new HomeLone();
        Rent myRent = new Rent();
        IncomeTax myIncTac = new IncomeTax();
        Car myCar = new Car();
        

        //start up and greet the user
        public void StartUp()
        {
            Console.WriteLine("Application started!\n" +
                                "Welcome to the personal budget helper! By Anton Popov.\n\n" +
                                "                        $$$$$$\n" +
                                "                  $$$$$$$$$$$$$$$$$\n" +
                                "              $$$$$$$$$$$$$$$$$$$$$$$$\n" +
                                "            $$$$$$$     $$$$$$  $$$$$$$$\n" +
                                "          $$$$$$        $$$$$$     $$$$$$$\n" +
                                "         $$$$$$         $$$$$$       $$$$$$\n" +
                                "         $$$$$$         $$$$$$\n" +
                                "         $$$$$$         $$$$$$\n" +
                                "          $$$$$$        $$$$$$\n" +
                                "           $$$$$$$$     $$$$$$\n" +
                                "              $$$$$$$$$$$$$$$$$$$$\n" +
                                "                  $$$$$$$$$$$$$$$$$$$\n" +
                                "                        $$$$$$$$$$$$$$$$\n" +
                                "                        $$$$$$   $$$$$$$$\n" +
                                "                        $$$$$$     $$$$$$$\n" +
                                "                        $$$$$$      $$$$$$\n" +
                                "                        $$$$$$       $$$$$$\n" +
                                "       $$$$$$$          $$$$$$       $$$$$$\n" +
                                "        $$$$$$          $$$$$$      $$$$$$$\n" +
                                "         $$$$$$$        $$$$$$    $$$$$$$$\n" +
                                "          $$$$$$$$      $$$$$$$$$$$$$$$$$\n" +
                                "            $$$$$$$$$$$$$$$$$$$$$$$$$$$\n" +
                                "               $$$$$$$$$$$$$$$$$$$$$$\n" +
                                "                  $$$$$$$$$$$$$$$$$\n" +
                                "                        $$$$$$\n\n");
            Continue();
        }

        //prompt user, show menu and possible exit
        private void Continue()
        {
            Console.WriteLine("To continue, enter anything, to exit enter a capital 'X':");
            string decision = Console.ReadLine();
            if(decision.Equals("X"))
            {
                Environment.Exit(0); //(Exit Methods in C# Application, 2018)
            } else
            {
                Help();
                Decision();
            }
        }

        public void Decision()
        {
            //command input
            string decision = Console.ReadLine();

            switch (decision)
            {
                case ("HELP"):
                    Help();
                    Decision();
                    break;
                case ("EXIT"):
                    Environment.Exit(0); //(Exit Methods in C# Application, 2018)
                    break;
                case ("CLA"):
                    ClearAll();
                    Continue();
                    break;

                case ("ENTER EXP"):
                    myExpenses.EnterDetails();
                    myExpenses.CalculateTotal();
                    finalExpenses += myExpenses.totalExpenses;
                    Continue();
                    break;
                case ("ENTER HOUSE"):
                    myHome.EnterDetails();
                    myHome.CalculateTotal();
                    finalExpenses += myHome.totalExpenses;
                    Continue();
                    break;
                case ("ENTER INCTAX"):
                    myIncTac.EnterDetails();
                    myIncTac.CalculateTotal();
                    Continue();
                    break;
                case ("ENTER RENT"):
                    myRent.EnterDetails();
                    finalExpenses += myRent.totalExpenses;
                    Continue();
                    break;

                //car details
                case ("ENTER CAR"):
                    myCar.EnterDetails();
                    myCar.CalculateTotal();
                    finalExpenses += myCar.totalExpenses;
                    Continue();
                    break;

                case ("SHOW EXP"):
                    Console.WriteLine($"Your expenses cost: R{myExpenses.Total:N2}");

                    //sort list
                    myExpenses.ExpenseStorage.Sort();
                    myExpenses.ExpenseStorage.Reverse();

                    //display order
                    foreach (int i in myExpenses.ExpenseStorage)
                    {
                        Console.WriteLine($"R{i:N2}");
                    }

                    //delegate
                    notifyUser myDelegate = new notifyUser(expenseWarning);
                    myDelegate(finalExpenses, myIncTac.Total);

                    Continue();
                    
                    break;
                case ("SHOW HOUSE"):
                    Console.WriteLine($"Your house costs: R{myHome.Price:N2}");
                    Console.WriteLine($"Your deposit is: R{myHome.Deposit:N2}");
                    Console.WriteLine($"The interest rate is: {myHome.Interest}%");
                    Console.WriteLine($"The amount of months to repay is: {myHome.Months}");
                    myHome.checkApproval(myIncTac.Total);
                    Continue();
                    break;
                case ("SHOW INCTAX"):
                    Console.WriteLine($"Your monthly income after tax: R{myIncTac.Total:N2}");
                    Continue();
                    break;
                case ("SHOW RENT"):
                    Console.WriteLine($"Your monthly rent: R{myRent.Total:N2}");
                    Continue();
                    break;
                case ("SHOW WAV"):
                    double calcIncome = myIncTac.Total, calcRent = myRent.Total, calcHome = myHome.Total, calcExp = myExpenses.Total, calcTotal = 0;
                    calcTotal = (calcIncome - (calcRent + calcHome + calcExp));
                    Console.WriteLine($"Your monthly avaible funds: R{calcTotal:N2}");
                    Continue();
                    break;
                case ("SHOW WLN"):
                    Console.WriteLine($"Your monthly housing payment: R{myHome.Total:N2}");
                    myHome.checkApproval(myIncTac.Total);
                    Continue();
                    break;

                //car details
                case ("SHOW CAR"):
                    Console.WriteLine($"Your car costs: R{myCar.Price:N2}");
                    Console.WriteLine($"Your deposit is: R{myCar.Deposit:N2}");
                    Console.WriteLine($"The interest rate is: {myCar.Interest}%");
                    Console.WriteLine($"The amount of months to repay is: 60");
                    Console.WriteLine($"Your monthly car payment: R{myCar.Total:N2}");
                    Continue();
                    break;

                case ("HELP CLA"):
                    Console.WriteLine("Availaible commands:\nCLA\nSelf explanatory, write as it says in the menu.");
                    Continue();
                    break;
                case ("HELP ENTER"):
                    Console.WriteLine("Availaible commands:\nENTER EXP\nENTER HOUSE\nENTER INCTAX\nENTER RENT\n Alone, this command wont do anything, needs to be used in conjunction with a detail command.");
                    Continue();
                    break;
                case ("HELP SHOW"):
                    Console.WriteLine("Availaible commands:\nSHOW EXP\nSHOW HOUSE\nSHOW INCTAX\nSHOW RENT\nSHOW WLN\nSHOW WAV\n Alone, this command wont do anything, needs to be used in conjunction with a detail command.");
                    Continue();
                    break;
                case ("HELP EXP"):
                    Console.WriteLine("Availaible commands:\nENTER EXP\nSHOW EXP\nAlone, this command wont do anything, it is a detail command and needs SHOW or ENTER in front of it.");
                    Continue();
                    break;
                case ("HELP HOUSE"):
                    Console.WriteLine("Availaible commands:\nENTER HOUSE\nSHOW SHOUSE\nAlone, this command wont do anything, it is a detail command and needs SHOW or ENTER in front of it.");
                    Continue();
                    break;
                case ("HELP INCTAX"):
                    Console.WriteLine("Availaible commands:\nENTER INCTAX\nSHOW INCTAX\nAlone, this command wont do anything, it is a detail command and needs SHOW or ENTER in front of it.");
                    Continue();
                    break;
                case ("HELP RENT"):
                    Console.WriteLine("Availaible commands:\nENTER RENT\nSHOW RENT\nAlone, this command wont do anything, it is a detail command and needs SHOW or ENTER in front of it.");
                    Continue();
                    break;
                case ("HELP WAV"):
                    Console.WriteLine("Availaible commands:\nSHOW WAV\nAlone, this command wont do anything, it is a detail command and needs SHOW in front of it, this value cannot be entered as it is derived from other values.");
                    Continue();
                    break;
                case ("HELP WLN"):
                    Console.WriteLine("Availaible commands:\nSHOW WLN\nAlone, this command wont do anything, it is a detail command and needs SHOW in front of it, this value cannot be entered as it is derived from other values.");
                    Continue();
                    break;

                default :
                    Console.WriteLine(  "Unknown command, please try again.\n" +
                                        "Make sure you type the command in all CAPS and inclue spaces between command words.");
                    Decision();
                    break;
            }
        }

        //reset all details
        private void ClearAll()
        {
            //reset storage array and array vars to default
            for (int i = 0; i < 20; i++)
            {
                myExpenses.ExpenseStorage[i] = 0;
            }
            myExpenses.otherExpLoop = 1;
            myExpenses.otherArr = 5;

            myHome.price = 0;
            myHome.deposit = 0;
            myHome.interest = 0;
            myHome.months = 0;

            myRent.price = 0;
            myIncTac.income = 0;
            myIncTac.taxDeduct = 0;
        }

        //help menu
        public void Help()
        {
            Console.Write(
          "\n***********************************************************************************************************\n" +
            "HELP MENU:                                                                                                *\n" +
            "***********************************************************************************************************\n" +
            "CLA         Clears all entered details, reverts them back to the value 0.                                 *\n" +
            "EXIT        Exits this application.                                                                       *\n" +
            "HELP        Shows this command list again, put HELP infront of another command to show it's syntax.       *\n" +
            "                                                                                                          *\n" +
            "ENTER       Allows you to enter new or re-enter details.                                                  *\n" +
            "SHOW        Shows the details of the selected.                                                            *\n" +
            "                                                                                                          *\n" +
            "(detail commands bellow need to be used with ENTER and SHOW commands before)                              *\n" +
            "CAR         Enter, clear or show your vehicle details.                                                    *\n" +
            "EXP         Enter, clear or show your expenses.                                                           *\n" +
            "HOUSE       Enter, clear or show your housing details.                                                    *\n" +
            "INCTAX      Enter, clear or show your monthly income and tax.                                             *\n" +
            "RENT        Enter, clear or show your details rent.                                                       *\n" +
            "WAV         Shows your available funds.                                                                   *\n" +
            "WLN         Shows your monthly loan repayment.                                                            *\n" +
            "***********************************************************************************************************\n" +
            "Input: ");
        }

        //method for calculating if expenses are > 75% of income
        public void expenseWarning(double expenses, double income)
        {
            if (expenses > income)
            {
                Console.WriteLine("Warning! Your expenses exede 75% of your income.");
            }
        }
    }
}
//Author Anton Popov st10090667 group 1