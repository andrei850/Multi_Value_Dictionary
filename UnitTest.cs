using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using MultiValueDictionary;

namespace MultiValueDictionary_UnitTest
{
    [TestClass]
    public class UnitTest
    {
        Dictionary<string, string> dict = new Dictionary<string, string>
        {
            { "a", "aaa" },
            { "b", "bbb" },
            { "c", "ccc" }
        };

        MVDictionary mv = new MVDictionary();

        [TestMethod]
        public void TestMethod_KEYS()
        {
           string expected = "a, b, c";
           mv.Dictionary = dict;
           string actual = mv.GetAllKeys();
           Assert.AreEqual(expected, actual, "KEYS not matchng");
        }

        [TestMethod]
        public void TestMethod_MEMBERS()
        {
            mv.Dictionary = dict;
            string expected = "a:aaa";
            string actual = mv.GetAllMembers().Substring(0,5);
            Assert.AreEqual(expected, actual, "MEMBERS not matchng");
        }

        [TestMethod]
        public void TestMethod_REMOVE()
        {
            mv.Dictionary = dict;
            string expected = "a:aaa";
            mv.RemoveMember("a");
            string actual = mv.GetAllMembers().Substring(0, 5);
            Assert.AreNotEqual(expected, actual, "Mamber was not Removed");
        }
        [TestMethod]
        public void TestMethod_ADD()
        {
            mv.Dictionary = dict;
            mv.AddMember("d", "ddd");
            string actual = mv.GetAllMembers();
            Assert.IsTrue(actual.Contains("ddd"), "Member was not Added");
        }
        [TestMethod]
        public void TestMethod_REMOVEALL()
        {
            mv.Dictionary = dict;
            mv.Clear();
            string actual = mv.GetAllMembers();
            Assert.IsFalse(actual.Contains("aaa"), "Collection was not cleard");
        }
    }
}
