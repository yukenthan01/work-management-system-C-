using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestProject1
{
    [TestClass]
    //[]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            
            Assert.AreEqual(expectedString, actualString);

            //Assert.IsTrue(ds.Rows.Count > 0);
        }
    }
}
