using System;

namespace PROG2A_Assignment2_Ismail_Yusuf_Omar_19331746
{
    class Exception //Class to call exception messages 
    {
        public static void Negitive_Exception() //Message to diplay when negitive value is entered 
        {
            Console.WriteLine("ERROR! Amount can not be less than zero.\nPlease enter amount again: ");
        }
        public static void Zero_Negitive_Exception() ////Message to diplay when zero or a negitive value is entered 
        {
            Console.WriteLine("ERROR! Amount can not be equal to zero or less than zero.\nPlease enter amount again: ");
        }
        public static void One_Two_Exception() //Message to diplay when 1 or 2 are the only accepted inputs 
        {
            Console.WriteLine("ERROR!!!!!!!!!!!!!!!!!!!!!!!!!");
            Console.WriteLine("Please only enter 1 or 2 to select an option");
        }
        public static void Percentage_Exception() //Message to diplay when dealing with a percentage input
        {
            Console.WriteLine("ERROR! Amount can not be less than zero or greater than 100.\nPlease enter amount again: ");
        }
    

    }

}