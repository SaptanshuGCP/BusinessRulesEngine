using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace CodingTest2
{
    [TestClass]
    public class OrderProcessingTests
    {
        [TestMethod]
        public void ProcessPhysical()
        {
            IOrder physicalProduct = new PhysicalProductOrder();
            OrderProcessing orderProcess = new OrderProcessing(physicalProduct);
            List<String> rulesProcessed = orderProcess.ProcessOrder();
            //If the list of rules processed contains the required ones, then it is a success.
            bool correctRulesExecuted = rulesProcessed.Contains(Rules.GEN_PKG_SLIP.ToString()) &&
                rulesProcessed.Contains(Rules.COMM_PAYMENT.ToString());
            Assert.IsTrue(correctRulesExecuted, "Payment for physical product processed.");
        }

        [TestMethod]
        public void ProcessBook()
        {
            IOrder bookOrder = new BookOrder();
            OrderProcessing orderProcess = new OrderProcessing(bookOrder);
            List<String> rulesProcessed = orderProcess.ProcessOrder();
            //If the list of rules processed contains the required ones, then it is a success.
            bool correctRulesExecuted = rulesProcessed.Contains(Rules.GEN_DUP_PKG_SLIP.ToString()) &&
                rulesProcessed.Contains(Rules.COMM_PAYMENT.ToString());
            Assert.IsTrue(correctRulesExecuted, "Payment for Book processed.");
        }

        [TestMethod]
        public void ProcessMembership()
        {
            IOrder memberOrder = new MembershipOrder();
            OrderProcessing orderProcess = new OrderProcessing(memberOrder);
            List<String> rulesProcessed = orderProcess.ProcessOrder();
            //If the list of rules processed contains the required ones, then it is a success.
            bool correctRulesExecuted = rulesProcessed.Contains(Rules.ACT_MEMBERSHIP.ToString()) &&
                rulesProcessed.Contains(Rules.EMAIL_OWNER.ToString());
            Assert.IsTrue(correctRulesExecuted, "Membership activated.");
        }

        [TestMethod]
        public void ProcessMembershipUpgrade()
        {
            IOrder upgradeOrder = new UpgradeMembershipOrder();
            OrderProcessing orderProcess = new OrderProcessing(upgradeOrder);
            List<String> rulesProcessed = orderProcess.ProcessOrder();
            //If the list of rules processed contains the required ones, then it is a success.
            bool correctRulesExecuted = rulesProcessed.Contains(Rules.UPGRD_MEMBERSHIP.ToString()) &&
                rulesProcessed.Contains(Rules.EMAIL_OWNER.ToString());
            Assert.IsTrue(correctRulesExecuted, "Membership updated and email sent.");
        }

        [TestMethod]
        public void ProcessVideo()
        {
            IOrder videoOrder = new ProcessVideoOrder();
            OrderProcessing orderProcess = new OrderProcessing(videoOrder);
            List<String> rulesProcessed = orderProcess.ProcessOrder();
            //If the list of rules processed contains the required ones, then it is a success.
            bool correctRulesExecuted = rulesProcessed.Contains(Rules.ADD_VIDEO.ToString());
            Assert.IsTrue(correctRulesExecuted, "Video succesfully added.");
        }
    }
}
