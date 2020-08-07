using UnityEngine;

namespace Code.Scenes.BattleScene.Scripts
{
    [RequireComponent(typeof(LineRenderer))]
#if UNITY_EDITOR
    [ExecuteInEditMode]
#endif
    public class ZoneCircleRenderer : MonoBehaviour
    {
        [Min(0)] public float thetaScale = 0.01f;
        [Min(0)] public float radius = 0.5f;
        private int size;
        private LineRenderer lineDrawer;

        private void Start()
        {
            lineDrawer = GetComponent<LineRenderer>();
            RedrawCircle();
        }

        private void RedrawCircle()
        {
            var theta = 0f;
            size = (int)(1f / thetaScale + 1f);
            lineDrawer.positionCount = size;
            for (int i = 0; i < size; i++)
            {
                theta += 2.0f * Mathf.PI * thetaScale;
                var x = radius * Mathf.Cos(theta);
                var y = radius * Mathf.Sin(theta);
                lineDrawer.SetPosition(i, new Vector3(x, y, 0));
            }
        }

#if UNITY_EDITOR
        private void OnValidate()
        {
            if (lineDrawer == null)
            {
                lineDrawer = GetComponent<LineRenderer>();
            }
            RedrawCircle();
        }
#endif
    }
}
