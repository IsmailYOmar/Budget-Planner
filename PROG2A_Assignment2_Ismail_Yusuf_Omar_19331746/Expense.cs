namespace PROG2A_Assignment2_Ismail_Yusuf_Omar_19331746
{
    abstract class Expense //decalration of abstrsact class 
    {
        //abstract method to be inherted later
        abstract public double Home_Loan(double repay_Months, double purchase_Price, double deposit, double interest_Rate);

        abstract public double Monthly_Excess(double gross_Income);

    }
}