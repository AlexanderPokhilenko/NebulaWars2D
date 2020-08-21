using TMPro;
using UnityEngine;

namespace Code.Scenes.BattleScene.Experimental
{
    public class HealthInfoObject : MonoBehaviour
    {
        [SerializeField] private Transform mask;
        [SerializeField] private TextMeshPro healthPoints;
        private const float DefaultPoints = 1000f;
        private float currentPoints = DefaultPoints;
        private float maxPoints = DefaultPoints;

        private void Start()
        {
            var parent = transform.parent;
            var parentRenderer = parent.GetComponent<SpriteRenderer>();
            var scale = 1f;
            if (parentRenderer != null)
            {
                var parentSprite = parentRenderer.sprite;
                var size = parentSprite.rect.size;
                scale = Mathf.Min(size.x, size.y) / parentSprite.pixelsPerUnit;
            }
            else
            {
                var parentLine = parent.GetComponent<LineRenderer>();
                if (parentLine != null)
                {
                    scale = parentLine.GetPosition(0).x * 2f;
                }
            }

            transform.localScale = new Vector3(scale, Mathf.Sqrt(scale), 1f);
        }

        public void SetMaxHealthPoints(float maxHp)
        {
            maxPoints = maxHp;
            UpdateHealthPoints();
        }

        public void SetHealthPoints(float hp)
        {
            currentPoints = hp;
            UpdateHealthPoints();
        }

        private void UpdateHealthPoints()
        {
            var percentage = currentPoints / maxPoints;
            mask.localScale = new Vector3(percentage, 1f, 1f);
            healthPoints.text = currentPoints.ToString("F0") + '/' + maxPoints.ToString("F0");
        }
    }
}