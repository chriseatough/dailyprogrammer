using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CSharp;

namespace CSharpTests
{
    [TestClass]
    public class ConcatenatedStringsTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            (string input, long smallest, long largest)[] collection = {
                (input: "5 56 50", smallest: 50556, largest: 56550),
                (input: "79 82 34 83 69", smallest: 3469798283, largest: 8382796934),
                (input: "420 34 19 71 341", smallest: 193413442071, largest: 714203434119),
                (input: "17 32 91 7 46", smallest: 173246791, largest: 917463217),

            };

            foreach (var expected in collection)
            {
                (long smallest, long largest) = ConcatenatedStrings.Get(input: expected.input);

                Assert.AreEqual(expected.smallest, smallest);
                Assert.AreEqual(expected.largest, largest);
            }

        }
    }
}
