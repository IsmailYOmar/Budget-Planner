using System;


namespace PROG2A_Assignment2_Ismail_Yusuf_Omar_19331746
{
    class Vehicle_Monthly_Cost  // class get and calclate monthly cost of buying a vehicle 
    { 

        double[] vehicle = new double[4];
        //get and set values for user input values for monthly expenses that are saved to vehicle
        public void Set_Model()
        {
            Console.Write("\t\tEnter the vehicle model and make:");
            String value = Console.ReadLine();
            if (String.IsNullOrEmpty(value))
            {
                Console.WriteLine("ERROR!\nVehicle model and make cannot be null or empty.");
                Set_Model();
            }
            String vehicle_Model = value;
        }
        public void Set_Price()
        {
            try
            {
                Console.Write("\t\tEnter the vehicle purchase price:");
                vehicle[0] = Convert.ToDouble(Console.ReadLine());
                //added validation for negative values and zero
                while (vehicle[0] <= 0)
                {
                    Exception.Zero_Negitive_Exception();
                    vehicle[0] = Convert.ToDouble(Console.ReadLine());
                }
            }
            catch (System.Exception ex) // validation for incorrect input format, null input and special charcters 
            {
                Console.WriteLine(ex.Message);
                Set_Price();
            }
        }
        public void Set_Deposit()
        {
            try
            {
                Console.Write("\t\tEnter the deposit amount:");
                vehicle[1] = Convert.ToDouble(Console.ReadLine());
                //added validation for negative values and zero
                while (vehicle[1] <= 0)
                {
                    Exception.Zero_Negitive_Exception();
                    vehicle[1] = Convert.ToDouble(Console.ReadLine());
                }
                while (vehicle[1] > vehicle[0]) //deposit can not be greater than vehicle purchase price
                {
                    Console.Write("ERROR! Deposit amount can not be greater than the vehicle purchase price.Please enter amount again: ");
                    vehicle[1] = Convert.ToDouble(Console.ReadLine());
                }
            }
            catch (System.Exception ex)
            {
                Console.WriteLine(ex.Message);// validation for incorrect input format, null input and special charcters 
                Set_Deposit();
            }
        }
        public void Set_Interest()
        {
            try
            {
                Console.Write("\t\tEnter Interest rate (percentage) : ");
                vehicle[2] = Convert.ToDouble(Console.ReadLine());
                //added validation for negative values and zero
                while (vehicle[2] <= 0 || vehicle[2] > 100) 
                //added validation for incorrect input format, null input and special charcters 
                {
                    Exception.Percentage_Exception();
                    vehicle[2] = Convert.ToDouble(Console.ReadLine());
                }
            }
            catch (System.Exception ex)
            {
                Console.WriteLine(ex.Message);
                // validation for incorrect input format, null input and special charcters 
                Set_Interest();
            }
        }
        public void Set_Insurance()
        {
            try
            {
                Console.Write("\t\tEnter estimated insurance premium : ");
                vehicle[3] = Convert.ToDouble(Console.ReadLine());
                //added validation for negative values and zero
                while (vehicle[3] <= 0)
                {
                    Exception.Zero_Negitive_Exception();
                    vehicle[3] = Convert.ToDouble(Console.ReadLine());
                }
            }
            catch (System.Exception ex)
            {
                Console.WriteLine(ex.Message);
                // validation for incorrect input format, null input and special charcters 
                Set_Insurance();
            }
        }

        public double Get_Price()
        {
            return vehicle[0]; //  returns vehicle price when called
        }
        public double Get_Deposit()
        {
            return vehicle[1];//  returns vehicle deposit when called
        }
        public double Get_Interest()
        {
            return vehicle[2];//  returns vehicle interest when called
        }
        public double Get_Insurance()
        {
            return vehicle[3];//  returns vehicle insurance when called
        }

        public double Monthly_Cost() // calculates Monthly_Cost repayment of vehicle based on user inputed terms 
        {
            double vehicle_Loan = Get_Price() - Get_Deposit();
            double vehicle_Interest = Get_Interest()/ 100;
            double monthly_Cost = Get_Insurance() + ( vehicle_Loan * ((vehicle_Interest / 12) * Math.Pow(1 + (vehicle_Interest / 12), (5 * 12))
                                  /(Math.Pow(1 + (vehicle_Interest / 12), (5 * 12)) - 1)));

            return monthly_Cost;
        }
    }
}
