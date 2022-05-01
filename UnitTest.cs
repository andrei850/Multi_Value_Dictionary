using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using MultiValueDictionary;

namespace MultiValueDictionary_UnitTest
{
    [TestClass]
    public class UnitTest
    {
        List<string> bigCities1 = new List<string>()
                    {
                        "London",
                        "Mumbai",
                        "Chicago"
                    };
        List<string> bigCities2 = new List<string>()
                    {
                        "Lincoln",
                        "Omaha",
                        "New York"
                    };
        MVDictionary md = new MVDictionary();

        [TestMethod]
        public void TestMethod_ADD()
        {
            PopulateCollation();
            Assert.IsTrue(md.Dictionary.Count == 2, "Member was not Added");
        }

        [TestMethod]
        public void TestMethod_GetAllKeys()
        {
            PopulateCollation();

            List<string> actual = md.GetAllKeys();
            Assert.IsTrue(actual.Contains("a") && actual.Contains("b"), "GetAllKeys method is not working correct");
        }

        [TestMethod]
        public void TestMethod_GetMembersByKey()
        {
            PopulateCollation();

            List<string> actual = md.GetMembersByKey("a");
            Assert.IsTrue(actual.Contains("London") && actual.Contains("Mumbai") && actual.Contains("Chicago"), "GetMembersByKey method is not working correct");
        }

        [TestMethod]
        public void TestMethod_RemoveMember()
        {
            PopulateCollation();
            md.RemoveMember("a", "London");
            List<string> actual = md.GetMembersByKey("a");
            Assert.IsFalse(actual.Contains("London"), "RemoveMember method is not working correct");
        }

        [TestMethod]
        public void TestMethod_RemoveAll()
        {
            PopulateCollation();
            md.RemoveAll("a");
            List<string> actual = md.GetAllKeys();

            Assert.IsFalse(actual.Contains("a"), "RemoveAll method is not working correct");
        }

        [TestMethod]
        public void TestMethod_Clear()
        {
            md.Add("a", bigCities1);
            md.Add("b", bigCities2);
            md.Clear();
            Assert.IsTrue(md.Dictionary.Count == 0, "Clear method is not working correct");
        }

        public void PopulateCollation()
        {
            md.Add("a", bigCities1);
            md.Add("b", bigCities2);
        }
    }
}
