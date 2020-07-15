using UnityEngine;

namespace Code.Common
{
    public static class TransformEx 
    {
        public static Transform DestroyAllChildren(this Transform transform)
        {
            foreach (Transform child in transform) 
            {
                Object.Destroy(child.gameObject);
            }
            
            return transform;
        }
    }
}