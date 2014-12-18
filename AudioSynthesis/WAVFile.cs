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

        public static void addTones(int sampleCount, double[] tone_1, double[] tone_2, out double[] sum)
        {
            sum = new double[sampleCount];

            for (var i = 0; i < sampleCount; i++)
            {
                sum[i] = tone_1[i] + tone_2[i];
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
            int sampleCount = 8000 * 2;

            double[] tone_1, tone_2;
            var func_1 = new Sinusoid();
            func_1.Frequency = 440;
            func_1.Amplitude = 0.5;
            func_1.Phase = 90;

            var func_2 = new Sinusoid();
            func_2.Frequency = 698.46;
            func_2.Amplitude = 0.45;
            func_2.Phase = 0;

            generateTone(sampleRate, func_1, 2.0, out tone_1);
            generateTone(sampleRate, func_2, 2.0, out tone_2);

            double[] data;
            addTones(sampleCount, tone_1, tone_2, out data);
            writeData(sampleRate, "test.wav", data);
        }
    }
}
