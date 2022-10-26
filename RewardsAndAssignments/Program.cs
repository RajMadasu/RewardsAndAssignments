using System;
using RewardsAndAssignments.Model;
using RewardsAndAssignments.Repositories;

namespace RewardsAndAssignments
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Repo
            Repo model = new Repo();
            Console.WriteLine();
            Console.WriteLine("Rewards Calcualtaions");
            Console.WriteLine("*******---------------*********************--------------*********");
            Console.WriteLine();
            Console.WriteLine("Please enter number of trasactions occured in 3 months period");
            int Transactions = int.Parse(Console.ReadLine());
            Console.WriteLine();
            Console.WriteLine("#########################################################################");
            Console.WriteLine("We are going to process the " + Transactions + " transactions");
            Console.WriteLine("#########################################################################");
            Console.WriteLine();
            #endregion

            #region Add Transactions
            for (int i = 1; i <= Transactions; i++)
            {
                Console.WriteLine("Please Add " + i + " Transaction Amount");
                Console.WriteLine();
                model.addTransaction(int.Parse(Console.ReadLine()));
                Console.WriteLine();
            }
            #endregion

            #region Calculate & Show Transactions
            var list = model.getAllTransactions();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("TotalRewards");
            Console.WriteLine("**************************************************");
            int totalRewards = 0;
            foreach (var item in list)
            {
                totalRewards = totalRewards + item.Rewards;
            }
            Console.WriteLine("Total Rewards for 3 months period: " + totalRewards);
 
            #endregion

        }
    }
}
