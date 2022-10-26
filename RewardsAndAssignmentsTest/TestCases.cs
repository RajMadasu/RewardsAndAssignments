using Microsoft.VisualStudio.TestTools.UnitTesting;
using RewardsAndAssignments.Repositories;
using RewardsAndAssignments.Model;
using System.Linq;

namespace RewardsAndAssignmentsTest
{
    [TestClass]
    public class UnitTests
    {
        #region Test Cases
        Repo repo = new Repo();
        [TestMethod]
        public void TransactionTest()
        {
            int Price = 556;

            repo.addTransaction(Price);

            Assert.IsTrue(repo.getAllTransactions().ToList().Count > 0); // Transactions should be more than 0

            // Compare the Expected value and Actual value
            Assert.AreEqual(repo.getAllTransactions().FirstOrDefault(c => c.price == Price).price, // Expected Value
                            Price); //Actual Value
        }


        [TestMethod]
        public void AddedTransactionsTest()
        {
            int totalTransactions = 20;
            for (int i = 1; i <= totalTransactions; i++) // Addidng Ten Transactions.
            {
                repo.addTransaction(i);
            }
            // Check Added Transactions and Give Transactions are same or not.
            Assert.AreEqual(repo.getAllTransactions().Count, totalTransactions);
        }

        [TestMethod]
        public void GetTotalRewardsTest()
        {
            for (int i = 11; i <= 20; i++) // Addidng Transactions.
            {
                repo.addTransaction(i);
            }
            // Check NULL VALUES
            Assert.IsNotNull(repo.getAllTransactions());

            //Total Rewards Always Greated Than 0
            Assert.IsTrue(repo.getTotalRewards() > 0);
        }

        [TestMethod]
        public void CalculateRewardTest()
        {
            int CalculatedReward = repo.calculateRewards(20);
            //Calculated Values Contains Value
            Assert.IsTrue(CalculatedReward==0);
        }

        [TestMethod]
        public void RewardPermonthTest()
        {
            int totalTransactions = 20;
            for (int i = 1; i <= totalTransactions; i++) // Addidng Ten Transactions.
            {
                repo.addTransaction(i);
            }// adding the transactions
            int[] results= repo.rewardPerMonth();
            Assert.IsTrue(results[0] > 0); // check whether all the transactions added or not.
            Assert.AreEqual(results[0], totalTransactions); // check whether added transactions and requested transactions are same or not.
        }

        #endregion

    }
}
