using System;
using System.Collections.Generic;
using System.Linq;

namespace PROG2A_Assignment2_Ismail_Yusuf_Omar_19331746
{
    class Get_Expense : Expense //Get_Expense inherits from the abstract class Expense
    {
        //double[] expenses_Array = new double[6]; decalration of expenses array that will hold user input values for monthly expenses 

        //array not needed for task 2 dictionary created instead 

        public Dictionary<string, double> expenses_List = new Dictionary<string, double>(); // creation of Dictionary expenses_List

        //get and set values for user input values for monthly expenses that are saved to expenses_List
        public void Set_Tax(double gross_Income)
        {
            try
            {
                double t;
                Console.WriteLine("\nPlease enter your estimated  monthly tax");
                t = Convert.ToInt32(Console.ReadLine()); //set user input to double tax
                                                         //added validate for negative values
                while (t < 0)
                {
                    Exception.Negitive_Exception();
                    t = Convert.ToInt32(Console.ReadLine());
                }
                while (t > gross_Income) //Tax can not be greater than gross income
                {
                    Console.Write("ERROR! Tax amount can not be greater than the gross income.Please enter amount again: ");
                    t = Convert.ToInt32(Console.ReadLine());
                }
                expenses_List.Add("Tax", t); // saves user input to index 0 in Dictionary 
            }
            catch (System.Exception ex)  //added validation for incorrect input format, null input and special charcters 
            {
                Console.WriteLine(ex.Message);
                Set_Tax(gross_Income);
            }
        }
        public void Set_Groceries()
        {
            try
            {
                double g;
                Console.Write("\t\tGroceries : ");
                g = Convert.ToDouble(Console.ReadLine());
                //added validate for negative values
                while (g < 0)
                {
                    Exception.Negitive_Exception();
                    g = Convert.ToDouble(Console.ReadLine());
                }
                expenses_List.Add("Groceries expenses", g); //saves user input to index 1 in Dictionary 
            }
            catch (System.Exception ex) //added validation for incorrect input format, null inputs and special charcters 
            {
                Console.WriteLine(ex.Message);
                Set_Groceries();
            }
        }
        public void Set_Water_Lights()
        {
            try
            {
                double w;

                Console.Write("\t\tWater and lights : ");
                w = Convert.ToDouble(Console.ReadLine());
                //added validate for negative values    
                while (w < 0)
                {
                    Exception.Negitive_Exception();
                    w = Convert.ToDouble(Console.ReadLine());
                }
                expenses_List.Add("Water and lights expenses", w); //saves user input to index 2 in Dictionary 
            }
            catch (System.Exception ex) //added validation for incorrect input format, null input and special charcters 
            {
                Console.WriteLine(ex.Message);
                Set_Water_Lights();
            }
        }
        public void Set_Travel()
        {
            try
            {
                double t;
                Console.Write("\t\tTravel costs(including petrol) : ");
                t = Convert.ToDouble(Console.ReadLine());
                //added validate for negative values
                while (t < 0)
                {
                    Exception.Negitive_Exception();
                    t = Convert.ToDouble(Console.ReadLine());
                }
                expenses_List.Add("Travel expenses", t); // saves user input to index 3 in Dictionary 
            }
            catch (System.Exception ex) //added validation for incorrect input format, null input and special charcters 
            {
                Console.WriteLine(ex.Message);
                Set_Travel();
            }
        }
        public void Set_Phone()
        {
            try
            {
                double p;
                Console.Write("\t\tCell phone and telephone : ");
                p = Convert.ToDouble(Console.ReadLine());
                //added validate for negative values
                while (p < 0)
                {
                    Exception.Negitive_Exception();
                    p = Convert.ToDouble(Console.ReadLine());
                }
                expenses_List.Add("Phone expenses", p); // saves user input to index 4 in Dictionary 
            }
            catch (System.Exception ex) //added validation for incorrect input format, null input and special charcters 
            {
                Console.WriteLine(ex.Message);
                Set_Phone();
            }
        }
        public void Set_Other()
        {
            try
            {
                double o;
                Console.Write("\t\tOther expenses : ");
                o = Convert.ToDouble(Console.ReadLine());
                //added validate for negative values
                while (o < 0)
                {
                    Exception.Negitive_Exception();
                    o = Convert.ToDouble(Console.ReadLine());
                }
                expenses_List.Add("Other expenses", o); // saves user input to index 5 in Dictionary 
            }
            catch (System.Exception ex) //added validation for incorrect input format, null input and special charcters 
            {
                Console.WriteLine(ex.Message);
                Set_Other();
            }
        }
        public void Set_Living(double l)
        {
            if (expenses_List.ContainsKey("Living expenses")) //in case where loan is unlikely user has option to enter different property values
            {                                                 //resulting in perviouly entered value needing to be overwriten 
                expenses_List["Living expenses"] = l;
            }
            else { 
               expenses_List.Add("Living expenses", l);// saves user input to index 6 in Dictionary 
            }
        }
        public void Set_Vehicle_Cost(double v)
        {

            expenses_List.Add("Monthly Vehicle Cost", v); // saves user input to index 7 in Dictionary 
        }

        public double Get_Tax()
        {
            return expenses_List.ElementAt(0).Value; // return index 0 in expenses_List 
        }
        public double Get_Groceries()
        {
            return expenses_List.ElementAt(1).Value; // returns the value in expenses_List index 1
        }
        public double Get_Water_Lights()
        {
            return expenses_List.ElementAt(2).Value; // returns the value in expenses_List index 2 
        }
        public double Get_Travel()
        {
            return expenses_List.ElementAt(3).Value; // returns the value in expenses_List index 3 
        }
        public double Get_Phone()
        {
            return expenses_List.ElementAt(4).Value; // returns the value in expenses_List index 4 
        }
        public double Get_Other()
        {
            return expenses_List.ElementAt(5).Value; // returns the value in expenses_List index 5 
        }
        public double Get_Living()
        {
            return expenses_List.ElementAt(6).Value; //returns the value in expenses_List index 6
        }
        public double Get_Vehicle_Cost()
        {
            return expenses_List.ElementAt(7).Value; //returns the value in expenses_List index 7
        }
        public  void Get_Sum(Check_Total check_Total) //calculates the total of all the expenses the user entered 
        {
            double expenses_Sum = expenses_List.Sum(v => v.Value); 
            check_Total(expenses_Sum);//send total back using delegate
        }

        public delegate void Check_Total(double check_Total); //declare delegate pointing to check_Total
       
        public override double Home_Loan(double repay_Months, double purchase_Price, double deposit, double interest_Rate) 
        // overrides abstract method that was defined in the Expenses abstract class 
        {
            double loan_Amount = purchase_Price - deposit;
            interest_Rate /= 100;
            double repayment = loan_Amount * ((interest_Rate / 12) * Math.Pow(1 + (interest_Rate / 12), repay_Months)) / 
                                (Math.Pow(1 + (interest_Rate / 12), repay_Months) - 1);
            // calculates Home Loan repayment based on user inputed terms 
            return repayment;
        }
        public override double Monthly_Excess(double gross_Income) 
        //overrides abstract method that was defined in the Expenses abstract class 
        {
            double excess = gross_Income - expenses_List.Sum(v => v.Value) ;
            // calculates Monthly Excess to be returned in final input 
            return excess;
        }
    }
}