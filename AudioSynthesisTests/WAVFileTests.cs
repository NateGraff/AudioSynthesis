using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AudioSynthesis;

namespace AudioSynthesisTests
{
    [TestClass]
    public class WAVFileTests
    {
        [TestMethod]
        public void TestGenerateTone()
        {
            double[] data;
            // 1000 samples, 1 Hz, 1 s, 1.0 amplitude
            WAVFile.generateTone(1000, 1.0, 1.0, 1.0, out data);
            Assert.AreEqual(1.0, data[0], 0.001, "Data generation failed at data[0].");
            Assert.AreEqual(-1.0, data[499], 0.001, "Data generation failed at data[499].");

        }
    }
}
