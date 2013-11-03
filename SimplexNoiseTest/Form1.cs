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

        private void GenerateNoise()
        {
            // Setup defaults for parameters for the simplex noise engine
            int seed = new Random().Next(1, int.MaxValue);
            if (!string.IsNullOrEmpty(txtSeed.Text))
                seed = int.Parse(txtSeed.Text);

            double persitence = 0.1;
            if (!string.IsNullOrEmpty(txtPersistence.Text))
                persitence = double.Parse(txtPersistence.Text);

            int xResolution = pbNoise.Size.Width;
            if (!string.IsNullOrEmpty(txtXResolution.Text))
                xResolution = int.Parse(txtXResolution.Text);

            int yResolution = pbNoise.Size.Height;
            if (!string.IsNullOrEmpty(txtYResolution.Text))
                yResolution = int.Parse(txtYResolution.Text);

            int largestFeature = 100;
            if (!string.IsNullOrEmpty(txtLargestFeature.Text))
                largestFeature = int.Parse(txtLargestFeature.Text);

            // Display the seed in case it was generated
            txtGeneratedSeed.Text = seed.ToString();

            // Initialize the simplex noise engine
            var noise = new SimplexNoise(largestFeature, persitence, seed);

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

            // Generated the results in a bitmap and display in the picture box
            pbNoise.Image = GenerateBitmap(result, xResolution, yResolution);
        }

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

        private Color GetColorized(int color)
        {
            Color newColor = Color.FromArgb(0, 0, 100);

            int shadeMod = 25;

            // Use the specified color as a factor of elevation and set it appropriately
            if (color < 45)
            {
                newColor = Color.FromArgb(0, 0, 100);
                shadeMod = 45;
            }
            else if (color < 50)
            {
                newColor = Color.FromArgb(209, 181, 144);
                shadeMod = 5;
            }
            else if (color < 125)
            {
                newColor = Color.FromArgb(154, 205, 48);
                shadeMod = 75;
            }
            else if (color < 150)
                newColor = Color.FromArgb(0, 160, 0);
            else if (color < 160)
            {
                newColor = Color.FromArgb(0, 100, 0);
                shadeMod = 10;
            }
            else if (color < 170)
            {
                shadeMod = 10;
                newColor = Color.FromArgb(161, 128, 96);
            }
            else if (color < 175)
                newColor = Color.FromArgb(130, 130, 130);
            else if (color < 200)
                newColor = Color.FromArgb(155, 155, 155);
            else if (color < 225)
                newColor = Color.FromArgb(180, 180, 180);
            else
                newColor = Color.FromArgb(225, 225, 225);

            // Adjust the shade of the color based on the raw elevation
            int colorShade = color % shadeMod;
            newColor = Color.FromArgb(Math.Min(newColor.R + colorShade, 255), Math.Min(newColor.G + colorShade, 255), Math.Min(newColor.B + colorShade, 255));

            return newColor;
        }
    }
}
