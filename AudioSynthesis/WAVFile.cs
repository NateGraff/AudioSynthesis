using System;
using NAudio.Wave;
using AudioSynthesis;

namespace AudioSynthesis
{
    public class WAVFile
    {
        public static int writeData(int sampleRate, string filename, double[] audioData)
        {
            var waveFormat = new WaveFormat(sampleRate, 16, 1);
            using (var writer = new WaveFileWriter(filename, waveFormat))
            {
                foreach(var sample in audioData) {
                    writer.WriteSample((float) sample);
                }
            }

            return 0;
        }

        public static void generateTone(int sampleRate, double frequency, double amplitude, double time, out double[] samples)
        {
            int sampleCount = (int) Math.Floor((double) sampleRate * time);
            samples = new double[sampleCount];

            var myCos = new Sinusoid();
            myCos.Amplitude = amplitude;
            myCos.Frequency = frequency;

            for (var i = 0; i < sampleCount; i++)
            {
                samples[i] = myCos.sample(i / (double) sampleRate);
            }
        }

        public static void generateTone(int sampleRate, Sinusoid func, double time, out double[] samples)
        {
            int sampleCount = (int)Math.Floor((double)sampleRate * time);
            samples = new double[sampleCount];

            for (var i = 0; i < sampleCount; i++)
            {
                samples[i] = func.sample(i / (double)sampleRate);
            }
        }

        public static void Main()
        {
            int sampleRate = 8000;

            double[] data;
            var func = new Sinusoid();
            func.Frequency = 440;
            func.Amplitude = 0.5;
            func.Phase = 90;

            generateTone(sampleRate, func, 2.0, out data);
            writeData(sampleRate, "test.wav", data);
        }
    }
}
