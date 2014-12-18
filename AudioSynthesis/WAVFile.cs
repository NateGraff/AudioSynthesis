using System;
using NAudio.Wave;
using AudioSynthesis;

namespace AudioSynthesis
{
    public class WAVFile
    {
        private int writeData(int sampleRate, string filename, short[] audioData)
        {
            var waveFormat = new WaveFormat(sampleRate, 8, 1);
            using (var writer = new WaveFileWriter(filename, waveFormat))
            {
                writer.WriteSamples(audioData, 0, audioData.Length);
            }

            return 0;
        }

        private void generateTone(int sampleRate, double frequency, double time, double amplitude, out short[] samples)
        {
            int sampleCount = Math.Floor(sampleRate * time);

            var myCos = new Sinusoid();
            myCos.Amplitude = amplitude;
            myCos.Frequency = frequency;

            for (var i = 0; i < sampleCount; i++)
            {
                samples[i] = short(myCos.sample(i / sampleRate));
            }
        }

        public static void Main()
        {
            int sampleRate = 8000;
            int sampleCount = sampleRate * 1;
            short[] data = new short[sampleCount];
            generateTone(sampleRate, 440.0, 1.0, 0.5, data);
            return writeData(sampleRate, "test.wav", data);
        }
    }
}
