using System;
using System.Collections.Generic;
using System.Linq;

namespace Interpolation
{
    /// <summary>
    /// Spline interpolation class.
    /// </summary>
    public class SplineInterpolator
    {
        private readonly double[] a;
        private readonly double[] h;
        private readonly double[] keys;
        private readonly double[] values;

        /// <summary>
        /// Class constructor.
        /// </summary>
        /// <param name="nodes">Collection of known points for further interpolation.
        /// Should contain at least two items.</param>
        public SplineInterpolator(IDictionary<double, double> nodes)
        {
            if (nodes == null)
            {
                throw new ArgumentNullException("nodes");
            }

            var n = nodes.Count;

            if (n < 2)
            {
                throw new ArgumentException("At least two point required for interpolation.");
            }

            keys = nodes.Keys.ToArray();
            values = nodes.Values.ToArray();
            a = new double[n];
            h = new double[n];

            for (int i = 1; i < n; i++)
            {
                h[i] = keys[i] - keys[i - 1];
            }

            if (n > 2)
            {
                var sub = new double[n - 1];
                var diag = new double[n - 1];
                var sup = new double[n - 1];

                for (int i = 1; i <= n - 2; i++)
                {
                    diag[i] = (h[i] + h[i + 1]) / 3;
                    sup[i] = h[i + 1] / 6;
                    sub[i] = h[i] / 6;
                    a[i] = (values[i + 1] - values[i]) / h[i + 1] - (values[i] - values[i - 1]) / h[i];
                }

                SolveTridiag(sub, diag, sup, ref a, n - 2);
            }
        }

        /// <summary>
        /// Gets interpolated value for specified argument.
        /// </summary>
        /// <param name="key">Argument value for interpolation. Must be within 
        /// the interval bounded by lowest ang highest <see cref="keys"/> values.</param>
        public double GetValue(double key)
        {
            int gap = 0;
            var previous = double.MinValue;

            // At the end of this iteration, "gap" will contain the index of the interval
            // between two known values, which contains the unknown z, and "previous" will
            // contain the biggest z value among the known samples, left of the unknown z
            for (int i = 0; i < keys.Length; i++)
            {
                if (keys[i] < key && keys[i] > previous)
                {
                    previous = keys[i];
                    gap = i + 1;
                }
            }

            var x1 = key - previous;
            var x2 = h[gap] - x1;

            return ((-a[gap - 1] / 6 * (x2 + h[gap]) * x1 + values[gap - 1]) * x2 +
                (-a[gap] / 6 * (x1 + h[gap]) * x2 + values[gap]) * x1) / h[gap];
        }


        /// <summary>
        /// Solve linear system with tridiagonal n*n matrix "a"
        /// using Gaussian elimination without pivoting.
        /// </summary>
        private static void SolveTridiag(double[] sub, double[] diag, double[] sup, ref double[] b, int n)
        {
            int i;

            for (i = 2; i <= n; i++)
            {
                sub[i] = sub[i] / diag[i - 1];
                diag[i] = diag[i] - sub[i] * sup[i - 1];
                b[i] = b[i] - sub[i] * b[i - 1];
            }

            b[n] = b[n] / diag[n];
            
            for (i = n - 1; i >= 1; i--)
            {
                b[i] = (b[i] - sup[i] * b[i + 1]) / diag[i];
            }
        }
    }
}