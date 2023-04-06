using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceAdventure.Shared.Tests.Extensions
{
    [TestClass]
    public class ExtensionsTest
    {
        [TestMethod]
        public void TestObjectClone()
        {
            var testObject = new TestObject { Id = 1, Name = "test" };
            var clonedObject = testObject.Clone();
            Assert.IsNotNull(clonedObject);
            Assert.AreEqual(testObject, clonedObject);
        }

        public record TestObject
        {
            public int Id { get; set; }
            public string Name { get; set; }
        }
    }
}
