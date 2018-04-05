using System;
using GovukRegistersApiClientNet.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GovukRegistersApiClientNet.Test
{
    [TestClass]
    public class ItemTest
    {
        [TestMethod]
        public void GetGeneratedProperty()
        {
            var item = new Item("abc", @"{ ""country"":""GB"",""official-name"":""The United Kingdom of Great Britain and Northern Ireland"",""name"":""United Kingdom"",""citizen-names"":""Briton;British citizen""}");

            Console.WriteLine(item);
        }
    }
}
