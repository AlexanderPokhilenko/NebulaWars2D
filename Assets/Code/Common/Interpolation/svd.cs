// using System;
// using System.Collections.Generic;
// using System.Diagnostics;
// using System.Linq;
//
// namespace Code.Common.Interpolation
// {
//     class Test10347
//     {
//         static void Main(string[] args)
//         {
//             Dictionary<double, double> known = new Dictionary<double, double>
//             { 
//                 { 0.0, 0.0 },
//                 { 100.0, 500},
//                 { 300.0, 750},
//                 { 500.0, 1000},
//             };
//
//             SplineInterpolator splineInterpolator = new SplineInterpolator(known);
//             double start = known.First().Key;
//             double end = known.Last().Key;
//             double step = (end - start) / 50;
//
//             for (double x = start; x <= end; x += step)
//             {
//                 double y = splineInterpolator.GetValue((float)x);
//                 Debug.WriteLine(String.Format("\t\t{0:0.000}\t{1:0.000}", x, y));
//             }
//         }
//     }
// }