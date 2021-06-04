using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CodingTest2
{
    [TestClass]
    public class OrderProcessingTests
    {
        [TestMethod]
        public void ProcessPhysical()
        {
            PhysicalProductOrder physicalProduct = new PhysicalProductOrder();
            physicalProduct.ProcessOrder();
            bool correctRulesExecuted = physicalProduct.RulesProcessed.Contains(Rules.GEN_PKG_SLIP.ToString()) &&
                physicalProduct.RulesProcessed.Contains(Rules.COMM_PAYMENT.ToString());
            Assert.IsTrue(correctRulesExecuted, "Payment for physical product processed.");
        }

        [TestMethod]
        public void ProcessBook()
        {
            BookOrder bookOrder = new BookOrder();
            bookOrder.ProcessOrder();
            bool correctRulesExecuted = bookOrder.RulesProcessed.Contains(Rules.GEN_DUP_PKG_SLIP.ToString()) &&
                bookOrder.RulesProcessed.Contains(Rules.COMM_PAYMENT.ToString());
            Assert.IsTrue(correctRulesExecuted, "Payment for Book processed.");
        }

        [TestMethod]
        public void ProcessMembership()
        {
            MembershipOrder memberOrder = new MembershipOrder();
            memberOrder.ProcessOrder();
            bool correctRulesExecuted = memberOrder.RulesProcessed.Contains(Rules.ACT_MEMBERSHIP.ToString()) &&
                memberOrder.RulesProcessed.Contains(Rules.EMAIL_OWNER.ToString());
            Assert.IsTrue(correctRulesExecuted, "Membership activated.");
        }

        [TestMethod]
        public void ProcessMembershipUpgrade()
        {
            
        }

        [TestMethod]
        public void ProcessVideo()
        {
            
        }
    }
}
