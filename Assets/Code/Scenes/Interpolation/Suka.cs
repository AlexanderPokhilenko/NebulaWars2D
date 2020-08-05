using System;
using System.Collections.Generic;
using System.Linq;
using Interpolation;
using UnityEngine;
using Debug = System.Diagnostics.Debug;

namespace Code.Scenes.Interpolation
{
    public class Suka:MonoBehaviour
    {
        private void OnDrawGizmos()
        {
            Dictionary<double, double> known = new Dictionary<double, double>
            { 
                { 0, 0},
                { 1, 10 },
                { 7, 20 },
                { 14, -1 },
                { 15, 15 },
                { 20, -10 },
                { 25, -1 },
                { 27, -40 },
                { 21, 30 },
            };

            foreach (var pair in known)
            {
                Gizmos.DrawSphere(new Vector3((float) pair.Key, (float) pair.Value,0), 1 );
                // Debug.WriteLine($"{pair.Key:0.000}\t{pair.Value:0.000}");
            }

            SplineInterpolator scaler = new SplineInterpolator(known);
            double start = known.First().Key;
            double end = known.Last().Key;
            double step = (end - start) / 500;

            for (double x = start; x <= end; x += step)
            {
                try
                {
                    double y = scaler.GetValue(x);
                    Gizmos.DrawSphere(new Vector3((float) x, (float) y, 0), 1);
                }
                catch (Exception e)
                {
                    
                }
                
                // Debug.WriteLine($"\t\t{x:0.000}\t{y:0.000}");
            }
        }
    }
}