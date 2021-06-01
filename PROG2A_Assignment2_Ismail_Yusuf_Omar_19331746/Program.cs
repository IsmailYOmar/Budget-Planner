using System;
using System.Collections.Generic;
using System.Linq;

namespace PROG2A_Assignment2_Ismail_Yusuf_Omar_19331746
{
    class Siphiwe_Finace
    {

        public static void Total_Exceed_Income(double check_Total) {
            //recevies vaule from delegate. check if value os greater than 75% of income

            if (check_Total > (gross_Income * 0.75))
            {
                Console.WriteLine("\nERROR !!!!!!!!!");
                Console.WriteLine("Your total expenses is greater than 75% of your gross income.");
                Console.WriteLine("Your total expenses are currently equal to {0} your gross income is currently equal to {1}",
                                   check_Total.ToString("R0.##"), gross_Income);

                Console.WriteLine("Would you like to try to create a new budget plan");
                //allows user to create a new budget with different expense values 
                Console.WriteLine("\t\t1. Yes (This will take you back to the start of budget planning process)");
                Console.WriteLine("\t\t2. No ");
                int different_Budget = 0;
                bool test = false;
                while (!test)
                {
                    try
                    {
                        Console.Write("Enter 1 or 2 to select an option : ");
                        different_Budget = Convert.ToInt32(Console.ReadLine());
                        test = true;
                    }
                    catch (System.Exception ex) //validation for incorrect input format, null input and special charcters
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
                if (different_Budget == 1) // if user enters 1 then
                {

                    Main(null); //call main method to restart budget planning process 

                }
                else
                {
                    return;
                }

            }
        }
        public static void Get_Property(Get_Expense Expense, double gross_Income)
        {
            Property Property = new Property();
            //asking user to input weather they will be buying a property or renting 
            Console.WriteLine("\nWill you be buying your own property or renting:");
            Console.WriteLine("\t\t1. Buying");
            Console.WriteLine("\t\t2. Rent");
            int buy_Or_Rent = 0;
            bool isSuccessful = false;
            while (!isSuccessful)
            {
                try
                {
                    Console.Write("Enter 1 or 2 to select an option : ");  
                    buy_Or_Rent = Convert.ToInt32(Console.ReadLine());
                    isSuccessful = true;
                }
                catch (System.Exception ex) //added validation for incorrect input format, null input and special charcters
                {
                    Console.WriteLine(ex.Message);
                }
            }
            if (buy_Or_Rent == 1) // if user enters 1 then
            {
                Console.WriteLine("");
                Property.Set_Property_Price();
                Property.Set_Property_Deposit();
                Property.Set_Property_Interest();
                Property.Set_Property_Buying_Terms();

                Expense.Set_Living(Expense.Home_Loan(Property.Get_Property_Buying_Terms(), Property.Get_Property_Price(), 
                                    Property.Get_Property_Deposit(), Property.Get_Property_Interest())); 
                //sets return value from Home_Loan method to expenses_Array

                if (Expense.Get_Living() > gross_Income / 3) //if home loan cost is greater than a third of gross_Income
                {
                    Console.WriteLine("\nCAUTION!!!!!!!!!!!");
                    Console.WriteLine("With your monthly income a home loan for this property is unlikely");
                    Console.ReadLine();
                    Console.WriteLine("Would you like to try a different property");//allows user to enter a differt property if loan unlikely
                    Console.WriteLine("\t\t1. Yes");
                    Console.WriteLine("\t\t2. No (This will exit the program)");
                    int different_Property = 0;
                    bool test = false;
                    while (!test)
                    {
                        try
                        {
                            Console.Write("Enter 1 or 2 to select an option : ");
                            different_Property = Convert.ToInt32(Console.ReadLine());
                            test = true;
                        }
                        catch (System.Exception ex) //added validation for incorrect input format, null input and special charcters
                        {
                            Console.WriteLine(ex.Message);
                        }
                    }
                    if (different_Property == 1) // if user enters 1 then
                    {

                        Get_Property(Expense, gross_Income);

                    }
                    else
                    {
                        Environment.Exit(1);// exit program
                    }
                }
            }
            else if (buy_Or_Rent == 2) //if user enters 2 then 
            {
                try
                {
                    Console.Write("\nPlease enter the monthly rental amount: ");
                    Expense.Set_Living(Convert.ToDouble(Console.ReadLine())); //sets user input to expenses_Array in GetExpenses method 
                                                                              //added validate for negative values and zero
                    while (Expense.Get_Living() <= 0)

                    {
                        Exception.Zero_Negitive_Exception();
                        Expense.Set_Living(Convert.ToDouble(Console.ReadLine()));

                    }
                }
                catch (System.Exception ex) //added validation for incorrect input format, null input and special charcters
                {
                    Console.WriteLine(ex.Message);
                }
            }
            else //display this error if user inputs wrong value
            {
                Exception.One_Two_Exception();
                Get_Property(Expense, gross_Income); //program does not exit now if user inputs wrong value
            }

            }
        public static void Vehicle(Get_Expense Expense) //method to ask user if they would like to buy a vehicle
        {
            Console.WriteLine("\nWill you be buying a vehicle:");
            Console.WriteLine("\t\t1. Yes");
            Console.WriteLine("\t\t2. No");
            int buy_Vehicle = 0;
            bool isSuccessful = false;
            while (!isSuccessful)
            {
                try
                {
                    Console.Write("Enter 1 or 2 to select an option : ");
                    buy_Vehicle = Convert.ToInt32(Console.ReadLine());
                    isSuccessful = true;
                    Console.WriteLine("");
                }
                catch (System.Exception ex)//validation for incorrect input format, null input and special charcters
                {
                    Console.WriteLine(ex.Message);
                }
            }
            if (buy_Vehicle == 1) // if user enters 1 then
            {
                Vehicle_Monthly_Cost Vehicle = new Vehicle_Monthly_Cost();
                //ask user to input values for Vehicle cost 
                Vehicle.Set_Model();
                Vehicle.Set_Price();
                Vehicle.Set_Deposit();
                Vehicle.Set_Interest();
                Vehicle.Set_Insurance();

                Expense.Set_Vehicle_Cost(Vehicle.Monthly_Cost()); 
                //calculate monthly cost of vehilcle and add it to expenses dictionary 
            }
            else if (buy_Vehicle == 2) //if user enters 2 then 
            {
                return;
            }
            else //display this error if user inputs wrong value
            {
                Exception.One_Two_Exception();
                Vehicle(Expense);
            }
        }
        public static void Expenses_By_Order(Get_Expense Expense) //prints out expense in descending order
        {
            Console.WriteLine("\nList of all expenses");
            Expense.expenses_List = Expense.expenses_List.OrderByDescending(x => x.Value).ToDictionary(x => x.Key, x => x.Value);
            foreach (KeyValuePair<string, double> kvp in Expense.expenses_List)
                Console.WriteLine("\t\t{0}: {1}", kvp.Key, kvp.Value.ToString("R0.##")); 
        }
        public static void Monthly_Excess(Get_Expense Expense, double gross_Income) 
        //output message to be displayed at the end of the program  
        {
            Console.WriteLine("\nYou have {0} available to spend every month", Expense.Monthly_Excess(gross_Income).ToString("R0.##")); 
            //ToString used to display as a currency 
            Console.ReadLine();
        }
        public static double gross_Income;
        public static void Set_Income() //method to ask user for users income
        {
            bool isSuccessful = false;
            while (!isSuccessful)
            {
                try
                {
                    Console.WriteLine("Please enter your gross monthly income");
                    gross_Income = Convert.ToDouble(Console.ReadLine()); //set user input to double gross_Income
                                                                         //added validate for negative values
                    while (gross_Income <= 0)
                    {
                        Exception.Zero_Negitive_Exception();
                        gross_Income = Convert.ToDouble(Console.ReadLine());
                    }
                    isSuccessful = true;
                }
                catch (System.Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
        public static void Set_Expense(Get_Expense Expense) //method to ask user for users estimated expenses 
        {
            Expense.Set_Tax(gross_Income);

            //set user input for expenses to set methods in Get_Expense class which saves the values into expenses_Array
            Console.WriteLine("\nPlease enter your estimated monthly expenditures for the following :");
            Console.WriteLine("");
            Expense.Set_Groceries();
            Expense.Set_Water_Lights();
            Expense.Set_Travel();
            Expense.Set_Phone();
            Expense.Set_Other();

        }
        static void Main(string[] args)
        {
            Console.WriteLine("--------------Budget Planner application version 2.0--------------\n" +
                              "------------------------------------------------------------------\n");

            Get_Expense Expense = new Get_Expense(); // declare the constructor to the Get_Expense class
            Exception Exception = new Exception(); // declare the constructor to the Exception class

            Set_Income();// allows user in input gross_Income
            Set_Expense(Expense);// allows user in input expenses

            Get_Property(Expense, gross_Income); // calls Get_Property method which determines the users living expenses
            Vehicle(Expense); // calls Vehicle method which determines the users cost of a vehicle every month 

            Expense.Get_Sum(Total_Exceed_Income); //checks if total expense is greater than 75% of income
            
            Expenses_By_Order(Expense); //Displays the expenses to the user in descending order by value.

            Monthly_Excess(Expense, gross_Income); //calls Monthly_Excess method which outputs the users monthly excess
        }
    }

}