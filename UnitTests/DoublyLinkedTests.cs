using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SimpleLists.Lists;

namespace UnitTests
{
    [TestClass]
    public class DoublyLinkedTests
    {
        [TestMethod]
        public void DoublyLinkedKataTests()
        {
            var list = new SimpleLists.Lists.DoublyLinkedList();
            Assert.IsNull(list.Find("fred"));
            list.Add("fred");
            Assert.AreEqual(true, list.Find("fred").Equals("fred"));
            Assert.IsNull(list.Find("wilma"));
            list.Add("wilma");
            Assert.IsTrue(list.Find("fred").Equals("fred"));
            Assert.IsTrue(list.Find("wilma").Equals("wilma"));
            Assert.IsFalse(list.Find("wilma").Equals("fred"));
            Assert.IsNull(list.Find("dave"));
            CollectionAssert.AreEqual(list.Values(), (new string[] { "fred", "wilma" }));

            list = new SimpleLists.Lists.DoublyLinkedList();
            list.Add("fred");
            list.Add("wilma");
            list.Add("betty");
            list.Add("barney");
            CollectionAssert.AreEqual(new string[] { "fred", "wilma", "betty", "barney" }, list.Values());
            CollectionAssert.AreEqual(new Node[] { new Node("betty"), new Node("barney") }, list.GetNextNodes("wilma"));
            CollectionAssert.AreEqual(new Node[] { new Node("wilma") , new Node("fred") }, list.GetPreviousNodes("betty"));
            list.Remove(list.Find("wilma"));
            CollectionAssert.AreEqual(new string[] { "fred", "betty", "barney" }, list.Values());
            list.Remove(list.Find("barney").Value);
            CollectionAssert.AreEqual(new string[] { "fred", "betty" }, list.Values());
            list.Remove(list.Find("fred").Value);
            CollectionAssert.AreEqual(new string[] { "betty" }, list.Values());
            list.Remove(list.Find("betty").Value);
            CollectionAssert.AreEqual(new string[] { }, list.Values());
        }

        [TestMethod]
        public void DoublyLinkedTestDuplicates()
        {
            var list = new SimpleLists.Lists.DoublyLinkedList();
            list.Add("pete");
            list.Add("pete");
            CollectionAssert.AreEqual(list.Values(), (new string[] { "pete", "pete" }));
            list.Remove("pete");
            CollectionAssert.AreEqual(list.Values(), (new string[] { "pete" }));


            list = new SimpleLists.Lists.DoublyLinkedList();
            list.Add("pete");
            list.Add("glen");
            list.Add("pete");
            Node pete = new Node("pete");
            CollectionAssert.AreEqual(list.Values(), (new string[] { "pete", "glen", "pete" }));
            list.Remove("pete");
            CollectionAssert.AreEqual(list.Values(), (new string[] { "glen" ,"pete" }));
        }
    }
}
