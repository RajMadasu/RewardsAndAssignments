using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RewardsAndAssignments.Model;
using RewardsAndAssignments.Repositories;

namespace RewardsAndAssignments.Repositories
{
    public class Repo
    {
        #region Transactions Methods

        List<RewardAssignmentModel> TotalTransactions = new List<RewardAssignmentModel>();

        public List<RewardAssignmentModel> getAllTransactions()
        {
            return TotalTransactions.ToList();
        }
        public void addTransaction(int price)
        {
            // Add New Transaction
            RewardAssignmentModel transaction = new RewardAssignmentModel{ 
            price=price,
            Rewards=calculateRewards(price),
            Date=DateTime.Today
            };
            TotalTransactions.Add(transaction);
        }
       


        #endregion


        #region Computational Methods

        public int getTotalRewards()
        {
            return TotalTransactions.ToList().Count > 0 ?
                   TotalTransactions.GroupBy(c => c.Rewards).ToDictionary(x => x.Key, x => x.Count()).Count : 0;
        }
        public int calculateRewards(int price)
        {
            if (price >= 50 && 
                price <= 100)
            {
                return price - 50;
            }
            else if (price > 100)
            {
                return (2 * (price - 100) + 50);
            }
            return 0;
        }

        public int[] rewardPerMonth()
        {
            int[] monthlist = new int[2];
            for (int i = 0; i < monthlist.Count(); i++)
            {
                List<RewardAssignmentModel> result = TotalTransactions.Where(trans => trans.Date.Month == DateTime.Today.AddMonths(-i).Month).ToList();
                monthlist[i] = result.Count;
            }
            return monthlist;
        }

        #endregion

    }
}
