using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NoiseEngine;

namespace SimplexNoiseTest
{
    /// <summary>
    /// This test harness allows you to visualize the generated Simplex Noise in a bitmap.  The following settings are available:
    /// * Seed - Allows a seed to be specified (signed 32-bit integer) for the pseudo-random number generator for generating the noise.
    ///   Leaving the field blank will generate a random seed value.
    /// * X Res / Y Res - Allows you to specify the resolution size of the generated noise.  Leaving either/both blank will use the current 
    ///   dimension of the picture box as the appropriate value.
    /// * Persistence - Basically controls the "fuzziness" of the generated noise.  This is a decimal value, with zero giving you a totally smooth 
    ///   texture (i.e. no noise).  It can be negative or positive, and decent values for use generally fall in the range of -1 to 1.  Anything 
    ///   outside of those ranges degrades to fairly ugly noise.  I used 0.7 as a decent value for my purpose.
    /// * Largest Feature - Controls the range of values that can occur in the noise.  In practice, it feels like a "zoom" function for the noise,
    ///   with values approaching zero providing a "zoomed out" view (smaller looking details in the noise) while larger values provide a "zoomed in" 
    ///   view with more broad variations.  You can see a fair amount of difference just playing with values between 1-1000; 850 provided a good 
    ///   vantage for my purposes.
    /// * Generated Seed - Provided to let you copy a seed that you like to use for generation.
    /// * Invert Results - Basically inverts the noise color, so black becomes white and vice versa.
    /// * Colorize - By default, the noise is rendered as a grayscale image.  This allows the noise to be colorized with colors I approximated for use 
    ///   on a basic world map and provides a good starting point for me to expand upon.  I used a range of values to determine the color to use, with
    ///   zero using blue for water and 255 using white for snow - basically an elevation map.
    /// </summary>
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void butGenerate_Click(object sender, EventArgs e)
        {
            GenerateNoise();
        }

        /// <summary>
        /// Generates a Simplex Noise based on the settings and displays it as a bitmap in the picture box.
        /// </summary>
        private void GenerateNoise()
        {
            // Setup defaults for settings for the simplex noise engine
            int seed = new Random().Next(1, int.MaxValue);
            if (!string.IsNullOrEmpty(txtSeed.Text))
                seed = int.Parse(txtSeed.Text);

            double persistence = 0.7;
            if (!string.IsNullOrEmpty(txtPersistence.Text))
                persistence = double.Parse(txtPersistence.Text);

            int xResolution = pbNoise.Size.Width;
            if (!string.IsNullOrEmpty(txtXResolution.Text))
                xResolution = int.Parse(txtXResolution.Text);

            int yResolution = pbNoise.Size.Height;
            if (!string.IsNullOrEmpty(txtYResolution.Text))
                yResolution = int.Parse(txtYResolution.Text);

            int largestFeature = 850;
            if (!string.IsNullOrEmpty(txtLargestFeature.Text))
            {
                largestFeature = int.Parse(txtLargestFeature.Text);
                if (largestFeature < 1) largestFeature = 1;
            }

            // Display the seed in case it was generated
            txtGeneratedSeed.Text = seed.ToString();

            // Initialize the simplex noise engine
            var noise = new SimplexNoise(largestFeature, persistence, seed);

            double xStart = 0;
            double xEnd = 500;
            double yStart = 0;
            double yEnd = 500;

            var result = new double[xResolution, yResolution];
            for (int i = 0; i < xResolution; i++)
            {
                for (int j = 0; j < yResolution; j++)
                {
                    var x = (int)(xStart + i * ((xEnd - xStart) / xResolution));
                    var y = (int)(yStart + j * ((yEnd - yStart) / yResolution));
                    result[i, j] = 0.5 * (1 + noise.GetNoise(x, y));
                }
            }

            // Generate the results in a bitmap and display in the picture box
            pbNoise.Image = GenerateBitmap(result, xResolution, yResolution);
        }

        /// <summary>
        /// Generates a bitmap to visualize the Simplex Noise.
        /// </summary>
        /// <param name="data">The array containing the generated values for the noise.</param>
        /// <param name="xResolution">The resolution width of the bitmap.</param>
        /// <param name="yResolution">The resolution height of the bitmap.</param>
        /// <returns></returns>
        private Bitmap GenerateBitmap(double[,] data, int xResolution, int yResolution)
        {
            // Create a new bitmap at the specified resolution
            Bitmap bmap = new Bitmap(xResolution, yResolution);

            for (int x = 0; x < xResolution; x++)
            {
                for (int y = 0; y < yResolution; y++)
                {
                    // Restrict the noise point to a value between 0 and 1
                    if (data[x, y] > 1) data[x, y] = 1;
                    if (data[x, y] < 0) data[x, y] = 0;

                    // Get the color of the noise point
                    var col = GetColor(data[x, y]);

                    // Set the noise point into the bitmap
                    bmap.SetPixel(x, y, col);
                }
            }

            // Return the generated bitmap
            return bmap;
        }

        /// <summary>
        /// Gets the color to use for a point in the Simplex Noise.
        /// </summary>
        /// <param name="noisePoint">The value of a point in the noise.</param>
        /// <returns></returns>
        private Color GetColor(double noisePoint)
        {
            Color color = Color.White;

            // Convert the noise point to a value between 0-255
            var grayColor = (int)(noisePoint * 255);

            // See if we're inverting the color
            if (ckInvert.Checked) grayColor = 255 - grayColor;

            if (ckColorize.Checked)
                // Colorize the grayscale value
                color = GetColorized(grayColor);
            else
                // Get the grayscale color
                color = Color.FromArgb(grayColor, grayColor, grayColor);

            return color;
        }

        /// <summary>
        /// Converts a grayscale value to a colorized value.
        /// </summary>
        /// <param name="color">The grayscale value to colorize.</param>
        /// <returns></returns>
        private Color GetColorized(int color)
        {
            Color newColor = Color.FromArgb(0, 0, 100);

            // Determines the range of color that can be used to provide a dithered effect
            int shadeMod = 25;

            // Treat the color as an "elevation" value and determine the base color to use
            if (color < 45)
            {
                // Dark blue
                newColor = Color.FromArgb(0, 0, 100);
                shadeMod = 45;
            }
            else if (color < 50)
            {
                // Sandy brown
                newColor = Color.FromArgb(209, 181, 144);
                shadeMod = 5;
            }
            else if (color < 110)
            {
                // Yellowish green
                newColor = Color.FromArgb(154, 205, 48);
                shadeMod = 60;
            }
            else if (color < 140)
            {
                // Green
                newColor = Color.FromArgb(0, 160, 0);
                shadeMod = 30;
            }
            else if (color < 160)
            {
                // Dark green
                newColor = Color.FromArgb(0, 100, 0);
                shadeMod = 20;
            }
            else if (color < 170)
            {
                // Dirt brown
                shadeMod = 10;
                newColor = Color.FromArgb(161, 128, 96);
            }
            else if (color < 175)
                // Dark gray
                newColor = Color.FromArgb(130, 130, 130);
            else if (color < 200)
                // Medium gray
                newColor = Color.FromArgb(155, 155, 155);
            else if (color < 225)
                // Gray
                newColor = Color.FromArgb(180, 180, 180);
            else
                // Light gray
                newColor = Color.FromArgb(225, 225, 225);

            // Adjust the shade of the color based on the raw elevation
            int colorShade = color % shadeMod;
            newColor = Color.FromArgb(Math.Min(newColor.R + colorShade, 255), Math.Min(newColor.G + colorShade, 255), Math.Min(newColor.B + colorShade, 255));

            return newColor;
        }
    }
}
