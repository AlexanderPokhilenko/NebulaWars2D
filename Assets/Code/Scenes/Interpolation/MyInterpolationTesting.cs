using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Code.Scenes.Interpolation
{
    public class MyInterpolationTesting:MonoBehaviour
    {
        private bool loop ;
        private int betweenNodeCount=10; // number of nodes to generate between path nodes, to smooth out the path
        private IEnumerable<Vector3> nodes ;
        [SerializeField] private Transform[] path; // path's control points
        [SerializeField] private GameObject go;
        private void Awake() 
        {
             IEnumerable<Vector3> nodes = Interpolate.NewCatmullRom(path, betweenNodeCount, loop);
        }
 
        private void Update() 
        {
            try
            {
                transform.position = nodes.LastOrDefault();
            }
            catch
            {
                
            }
        }
 
// optional, use gizmos to draw the path in the editor
        private void OnDrawGizmos() 
        {
            if ( path != null && path.Length >= 2) 
            {
                // draw control points
                for (var i = 0; i < path.Length; i++) 
                {
                    Gizmos.DrawWireSphere(path[i].position, 0.15f);
                }
 
                // draw spline curve using line segments
                IEnumerable<Vector3> sequence = Interpolate.NewCatmullRom(path, betweenNodeCount, loop);
                Vector3 firstPoint = path[0].position;
                Vector3 segmentStart = firstPoint;
                // skip the first point
                sequence.GetEnumerator().MoveNext();
                // use "for in" syntax instead of sequence.MoveNext() when convenient
                foreach(Vector3 segmentEnd in sequence)
                {
                    Color color = Color.red;
                    Gizmos.DrawLine(segmentStart, segmentEnd);
                    segmentStart = segmentEnd;
                    // prevent infinite loop, when attribute loop == true
                    if (segmentStart == firstPoint)
                    {
                        break;
                    }
                }
            }
        }
    }
}