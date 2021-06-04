using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CodingTest2
{
    [TestClass]
    public class OrderProcessingTests
    {
        [TestMethod]
        public void ProcessPhysical()
        {
            PhysicalOrder orderProcess = new PhysicalOrder();
            bool expectedResult = true;
            bool actualResult = orderProcess.ProcessOrder();
            Assert.IsTrue(expectedResult == actualResult);
        }

        [TestMethod]
        public void ProcessBook()
        {
            BookOrder orderProcess = new BookOrder();
            bool expectedResult = true;
            bool actualResult = orderProcess.ProcessOrder();
            Assert.IsTrue(expectedResult == actualResult);
        }

        [TestMethod]
        public void ProcessMembership()
        {
            
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
