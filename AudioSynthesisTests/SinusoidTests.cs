using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AudioSynthesis;

namespace AudioSynthesisTests
{
    [TestClass]
    public class SinusoidTests
    {
        [TestMethod]
        public void TestDefaultConstructor()
        {
            var myCos = new Sinusoid();
            Assert.AreEqual(1, myCos.Amplitude, 0.001, "Default amplitude not calculated correctly.");
            Assert.AreEqual(2 * Math.PI, myCos.Frequency, 0.001, "Default frequency not calculated correctly.");
            Assert.AreEqual(0, myCos.Phase, 0.001, "Default phase shift not calculated correctly.");
            Assert.AreEqual(0, myCos.Offset, 0.001, "Default vertical offset not calculated correctly.");
        }

        [TestMethod]
        public void TestConstructor()
        {
            double A, w, phi, y_offset;
            A        = 0.5;
            w        = 20.5;
            phi      = 0.25;
            y_offset = 0.1;

            double amplitude, frequency, phase, offset;
            amplitude = 0.5;
            frequency = 128.80529; // Hz
            phase     = 14.32394; // deg
            offset    = 0.1;

            var myCos = new Sinusoid(A, w, phi, y_offset);
            
            Assert.AreEqual(amplitude, myCos.Amplitude, 0.001, "Amplitude not calculated correctly.");
            Assert.AreEqual(frequency, myCos.Frequency, 0.001, "Frequency not calculated correctly.");
            Assert.AreEqual(phase, myCos.Phase, 0.001, "Phase shift not calculated correctly.");
            Assert.AreEqual(offset, myCos.Offset, 0.001, "Vertical offset not calculated correctly.");
        }

        [TestMethod]
        public void TestDefaultSample()
        {
            var myCos = new Sinusoid();
            Assert.AreEqual(1, myCos.sample(0), 0.001, "Sample failed -- default cosine -- t = 0.");
            Assert.AreEqual(0, myCos.sample((1.0/2) * Math.PI), 0.001, "Sample failed -- default cosine -- t = pi.");
            Assert.AreEqual(-1, myCos.sample(1 * Math.PI), 0.001, "Sample failed -- default cosine -- t = 3/2 * pi.");
            Assert.AreEqual(0, myCos.sample((3.0/2) * Math.PI), 0.001, "Sample failed -- default cosine -- t = 2 * pi");
        }

        [TestMethod]
        public void TestSample()
        {
            // A, w, phi, y_offset
            var myCos = new Sinusoid(0.5, 20.5, 0.25, 0.1);
            double[] t = {0.012195122, 0.088819333, 0.165443544, 0.242067755};

            Assert.AreEqual(0.6, myCos.sample(t[0]), 0.001, "Sample failed -- example cosine -- t = 0");
            Assert.AreEqual(0.1, myCos.sample(t[1]), 0.001, "Sample failed -- example cosine -- t = 1/4 period");
            Assert.AreEqual(-0.4, myCos.sample(t[2]), 0.001, "Sample failed -- example cosine -- t = 1/2 period");
            Assert.AreEqual(0.1, myCos.sample(t[3]), 0.001, "Sample failed -- example cosine -- t = 3/4 period");
        }

        [TestMethod]
        public void TestSetAmplitude()
        {
            var myCos = new Sinusoid();
            myCos.Amplitude = 0.1337;
            Assert.AreEqual(0.1337, myCos.Amplitude, 0.001, "Failed to set amplitude.");
        }

        [TestMethod]
        public void TestSetFrequency()
        {
            var myCos = new Sinusoid();
            myCos.Frequency = 440; // Hz.
            Assert.AreEqual(440, myCos.Frequency, 0.001, "Failed to set frequency.");
            Assert.AreEqual(-1, myCos.sample(0.044861838), 0.001, "Sampled value of 440 Hz wave not expected.");
        }

        [TestMethod]
        public void TestSetPhase()
        {
            var myCos = new Sinusoid();
            myCos.Phase = 90; // degrees
            Assert.AreEqual(90, myCos.Phase, 0.001, "Failed to set phase.");
            Assert.AreEqual(0, myCos.sample((1 / 2) * Math.PI), 0.001, "Sampled value of 90 deg shifted wave not expected.");
        }

        [TestMethod]
        public void TestSetOffset()
        {
            var myCos = new Sinusoid();
            myCos.Offset = 2;
            Assert.AreEqual(2, myCos.Offset, 0.001, "Failed to set offset.");
            Assert.AreEqual(3, myCos.sample(0), 0.001, "Sampled value of offset wave not expected.");
        }
    }
}
