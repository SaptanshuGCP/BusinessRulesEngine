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
            Assert.IsTrue(physicalProduct.RulesProcessed, "Payment for physical product processed.");
        }

        [TestMethod]
        public void ProcessBook()
        {
            BookOrder orderProcess = new BookOrder();
            orderProcess.ProcessOrder();
            Assert.IsTrue(orderProcess.RulesProcessed, "Payment for Book processed.");
        }

        [TestMethod]
        public void ProcessMembership()
        {
            MembershipOrder orderProcess = new MembershipOrder();
            orderProcess.ProcessOrder();
            Assert.IsTrue(orderProcess.RulesProcessed, "Membership activated.");
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
