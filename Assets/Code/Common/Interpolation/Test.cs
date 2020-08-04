using System;
using TestMySpline;

namespace Code.Common.Interpolation
{
    public class Test
    {
        public void Test1()
        {
            int n = 6;

            // Create the data to be fitted
            float[] x = new float[n];
            float[] y = new float[n];
            Random rand = new Random(1);

            for (int i = 0; i < n; i++)
            {
                x[i] = i;
                y[i] = (float)rand.NextDouble() * 10;
            }

            // Compute the x values at which we will evaluate the spline.
            // Upsample the original data by a const factor.
            int upsampleFactor = 10;
            int nInterpolated = n * upsampleFactor;
            float[] xs = new float[nInterpolated];

            for (int i = 0; i < nInterpolated; i++)
            {
                xs[i] = (float)i * (n - 1) / (nInterpolated - 1);
            }

            float[] ys = CubicSpline.Compute(x, y, xs, 0.0f);
        }
    }
}