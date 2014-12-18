using System;
using NAudio.Wave;
using AudioSynthesis;

namespace AudioSynthesis
{
    public class WAVFile
    {
        private static int writeData(int sampleRate, string filename, short[] audioData)
        {
            var waveFormat = new WaveFormat(sampleRate, 8, 1);
            using (var writer = new WaveFileWriter(filename, waveFormat))
            {
                writer.WriteSamples(audioData, 0, audioData.Length);
            }

            return 0;
        }

        private static void generateTone(int sampleRate, double frequency, double time, double amplitude, out short[] samples)
        {
            int sampleCount = (int) Math.Floor((double) sampleRate * time);
            samples = new short[sampleCount];

            var myCos = new Sinusoid();
            myCos.Amplitude = amplitude;
            myCos.Frequency = frequency;

            for (var i = 0; i < sampleCount; i++)
            {
                samples[i] = (short) myCos.sample(i / sampleRate);
            }
        }

        public static void Main()
        {
            int sampleRate = 8000;

            short[] data;
            generateTone(sampleRate, 440.0, 1.0, 0.5, out data);

            writeData(sampleRate, "test.wav", data);
        }
    }
}
