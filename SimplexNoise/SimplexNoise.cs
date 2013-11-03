using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoiseEngine
{
    /// <summary>
    /// This class generates several noise "octaves", frequencies, and amplitudes, then combines them to make the final Simplex Noise.
    /// </summary>
    public class SimplexNoise
    {
        private SimplexNoiseOctave[] octaves;
        private double[] frequencys;
        private double[] amplitudes;

        private int largestFeature;
        private double persistence;
        private int seed;

        public SimplexNoise(int largestFeature, double persistence, int seed)
        {
            this.largestFeature = largestFeature;
            this.persistence = persistence;
            this.seed = seed;

            // Recieves a number (eg 128) and calculates what power of 2 it is (eg 2^7)
            int numberOfOctaves = (int)Math.Ceiling(Math.Log10(largestFeature) / Math.Log10(2));

            octaves = new SimplexNoiseOctave[numberOfOctaves];
            frequencys = new double[numberOfOctaves];
            amplitudes = new double[numberOfOctaves];

            Random rand = new Random(seed);

            for (int i = 0; i < numberOfOctaves; i++)
            {
                octaves[i] = new SimplexNoiseOctave(rand.Next());

                frequencys[i] = Math.Pow(2, i);
                amplitudes[i] = Math.Pow(persistence, octaves.Length - i);
            }
        }

        /// <summary>
        /// Combines the separate octaves, frequencies, and amplitudes into a single Simplex Noise value for the specified position.
        /// </summary>
        /// <param name="x">The x position in the noise.</param>
        /// <param name="y">The y position in the noise.</param>
        /// <returns></returns>
        public double GetNoise(int x, int y)
        {
            double result = 0;

            for (int i = 0; i < octaves.Length; i++)
                result = result + octaves[i].Noise(x / frequencys[i], y / frequencys[i]) * amplitudes[i];

            return result;
        }
    }
}
