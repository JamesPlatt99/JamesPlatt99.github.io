using Microsoft.VisualStudio.TestTools.UnitTesting;
using SimpleLists.Lists;

namespace UnitTests
{
    [TestClass]
    public class ArrayListTests
    {
        [TestMethod]
        public void KataTests()
        {
            var list = new SimpleLists.Lists.ArrayList();
            Assert.IsNull(list.Find("fred"));
            list.Add("fred");
            list.Remove("fred");
            list.Add("fred");
            Assert.AreEqual(true, list.Find("fred").Equals("fred"));
            Assert.IsNull(list.Find("wilma"));
            list.Add("wilma");
            Assert.IsTrue(list.Find("fred").Equals("fred"));
            Assert.IsTrue(list.Find("wilma").Equals("wilma"));
            Assert.IsFalse(list.Find("wilma").Equals("fred"));
            Assert.IsNull(list.Find("dave"));
            CollectionAssert.AreEqual(list.Values(), (new string[] { "fred", "wilma" }));

            list = new SimpleLists.Lists.ArrayList();
            list.Add("fred");
            list.Add("wilma");
            list.Add("betty");
            list.Add("barney");
            CollectionAssert.AreEqual(new string[] { "fred", "wilma", "betty", "barney" }, list.Values());
            list.Remove(list.Find("wilma").Value);
            CollectionAssert.AreEqual(new string[] { "fred", "betty", "barney" }, list.Values());
            list.Remove(list.Find("barney").Value);
            CollectionAssert.AreEqual(new string[] { "fred", "betty" }, list.Values());
            list.Remove(list.Find("fred"));
            CollectionAssert.AreEqual(new string[] { "betty" }, list.Values());
            list.Remove(list.Find("betty"));
            CollectionAssert.AreEqual(new string[] { }, list.Values());
        }
    }
}
