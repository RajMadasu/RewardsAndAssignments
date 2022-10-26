using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RewardsAndAssignments.Model;

namespace RewardsAndAssignments.Repositories
{
    public interface IRepo
    {
        // Reward Assignment Interfacce
      
            // Add  Transaction
            public void addTransaction(int price);

            //Get All Transactions
            public List<RewardAssignmentModel> getTransactions();

            // Get Total
            public int getRewards();

            // Calculate Rewards
            public int calculateRewards(int price);

            //Per Month
            public int[] rewardPerMonth();
    }
}
