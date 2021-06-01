using System;

namespace PROG2A_Assignment2_Ismail_Yusuf_Omar_19331746
{
    class Property
    {
        double purchase_Price;
        double deposit;
        double interest_Rate;
        int repay_Months;

        //get and set values for user input values for buying property values
        public void Set_Property_Price()
        {
            try
            {
                //ask user to input values for property cost 
                Console.Write("\n\t\tEnter Purchase the price of property: ");
                purchase_Price = Convert.ToInt32(Console.ReadLine());
                //added validation for negative values and zero
                while (purchase_Price <= 0)
                {
                    Exception.Zero_Negitive_Exception();
                    purchase_Price = Convert.ToInt32(Console.ReadLine());
                }
            }
            catch (System.Exception ex) //added validation for incorrect input format, null input and special charcters 
            {
                Console.WriteLine(ex.Message);
                Set_Property_Price();
            }
        }
        public void Set_Property_Deposit()
        {
            try
            {
                Console.Write("\t\tEnter total deposit: ");
                deposit = Convert.ToInt32(Console.ReadLine());
                //added validation for negative values and zero
                while (deposit <= 0)
                {
                    Exception.Zero_Negitive_Exception();
                    deposit = Convert.ToInt32(Console.ReadLine());
                }
                while (deposit > purchase_Price) //deposit can not be greater than purchase_Price
                {
                    Console.Write("ERROR! Deposit amount can not be greater than the purchase price.Please enter amount again: "); 
                    deposit = Convert.ToInt32(Console.ReadLine());
                }
            }
            catch (System.Exception ex)
            {
                Console.WriteLine(ex.Message); //added validation for incorrect input format, null input and special charcters 
                Set_Property_Deposit();
            }
        }
        public void Set_Property_Interest()
        {
            try
            {
                Console.Write("\t\tEnter Interest rate (percentage) : ");
                interest_Rate = Convert.ToDouble(Console.ReadLine());
                //added validation for negative values and zero
                while (interest_Rate <= 0 || interest_Rate > 100) //percentage must be between 0 and 100
                {
                    Exception.Percentage_Exception();
                    interest_Rate = Convert.ToDouble(Console.ReadLine());
                }
            }
            catch (System.Exception ex)
            {
                Console.WriteLine(ex.Message); //added validation for incorrect input format, null input and special charcters 
                Set_Property_Interest();
            }
        }
        public void Set_Property_Buying_Terms()
        {
            try
            {
                Console.Write("\t\tEnter Number of months to repay (between 240 and 360): ");
                repay_Months = Convert.ToInt32(Console.ReadLine());
                //added validation for buying terms between 240 and 360 months
                while (repay_Months < 240 || repay_Months > 360)
                {
                    Console.Write("The number of months must be between 240 and 360.Please enter the value again: ");
                    repay_Months = Convert.ToInt32(Console.ReadLine());
                }
            }
            catch (System.Exception ex)//added validation for incorrect input format, null input and special charcters 
            {
                Console.WriteLine(ex.Message);
                Set_Property_Buying_Terms();
            }
        }

        public double Get_Property_Price()
        {
            return purchase_Price; //  returns purchase_Price when called
        }
            public double Get_Property_Deposit()
        {
            return deposit; //  returns deposit when called
        }
        public double Get_Property_Interest()
        {
            return interest_Rate; //  returns interest_Rate when called
        }
        public double Get_Property_Buying_Terms()
        {
            return repay_Months; //  returns repay_Months when called 
        }
    }
}