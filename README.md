SimplexNoise
============
This application was born out of a desire to make a random map generator for a game that I'm working on.  After searching the internets for possible ideas for map generation algorithms, I settled on a version using Simplex Noise, the big brother to Perlin Noise, both created by Ken Perlin back in the day.  The following resources were used in creating this code (you can find plenty of others with some Google-Fu):

http://webstaff.itn.liu.se/~stegu/simplexnoise/simplexnoise.pdf - A fairly detailed explanation of the mechanics behind both Perlin Noise and Simplex Noise.

http://stackoverflow.com/questions/18279456/any-simplex-noise-tutorials-or-resources - The second answer on this Stack Overflow question provided the meat of the code for this application.  The code presented was in Java, which I ported over to C# fairly easily.  My thanks to Richard Tingle for his post.

This application only utilizes a 2D Simplex Noise for it's needs.  The Java code also included 3D and 4D implementations, but I didn't port it over as I didn't have a need for it (and honestly because I was feeling lazy).  Utilizing the post above, it would be a fairly simple matter to port the rest of it over and I may do this at some point in the future... or feel free to branch and port away. :)

I will say up front that I don't pretend to know the math behind Perlin/Simplex Noise that well, I just wanted to use it for my particular application... the "black box" does the heavy lifting for me and meets my needs, so I'm happy.  The general concepts seem fairly straightforward, but when it comes to the details, it's pretty fuzzy to me as I was never a math genius.  So if you're looking for explanations on the details, I'm probably not much help to you.  The first link above to Mr. Gustavson's excellent work can explain the black devil magic far better than I.

With that said, I was able to build a test harness application (quick & dirty WinForm application) with some tweakable settings to visualize the Simplex Noise.  The details are documented in the code, but I'll provide a quick fly-by here.

* <b>Seed</b> - Allows a seed to be specified (signed 32-bit integer) for the pseudo-random number generator for generating the noise.  Leaving the field blank will generate a random seed value.
* <b>X Res / Y Res</b> - Allows you to specify the resolution size of the generated noise.  Leaving either/both blank will use the current dimension of the picture box as the appropriate value.
* <b>Persistence</b> - Basically controls the "fuzziness" of the generated noise.  This is a decimal value, with zero giving you a totally smooth texture (i.e. no noise).  It can be negative or positive, and decent values for use generally fall in the range of -1 to 1.  Anything outside of those ranges degrades to fairly ugly noise.  I used 0.7 as a decent value for my purpose.
* <b>Largest Feature</b> - Controls the range of values that can occur in the noise.  In practice, it feels like a "zoom" function for the noise, with values approaching zero providing a "zoomed out" view (smaller looking details in the noise) while larger values provide a "zoomed in" view with more broad variations.  You can see a fair amount of difference just playing with values between 1-1000; 850 provided a good vantage for my purposes.
* <b>Generated Seed</b> - Provided to let you copy a seed that you like to use for generation.
* <b>Invert Results</b> - Basically inverts the noise color, so black becomes white and vice versa.
* <b>Colorize</b> - By default, the noise is rendered as a grayscale image.  This allows the noise to be colorized with colors I approximated for use on a basic world map and provides a good starting point for me to expand upon.  I used a range of values to determine the color to use, with zero using blue for water and 255 using white for snow - basically an elevation map.

That's about it.  If you've stumbled across this code on your exploration of Perlin/Simplex Noise, I hope you find it useful.
