using TMPro;
using UnityEngine;

namespace Code.Scenes.BattleScene.Experimental
{
    public class HealthInfoObject : MonoBehaviour
    {
        [SerializeField] private Color shieldLineColor;
        [SerializeField] private Color shieldTextColor;
        [SerializeField] private SpriteRenderer topLine;
        [SerializeField] private SpriteRenderer background;
        [SerializeField] private Transform mask;
        [SerializeField] private TextMeshPro healthPoints;
        private ushort currentPoints = ushort.MaxValue;
        private ushort maxPoints = ushort.MaxValue;

        private void Start()
        {
            var parent = transform.parent;
            var parentRenderer = parent.GetComponent<Renderer>();
            var scale = 1f;
            if (parentRenderer != null)
            {
                var size = parentRenderer.bounds.size;
                scale = Mathf.Min(size.x, size.y);
            }

            transform.localScale = new Vector3(scale, Mathf.Sqrt(scale), 1f);
        }

        public void SetShieldStyle()
        {
            topLine.color = shieldLineColor;
            healthPoints.color = shieldTextColor;
        }

        public void SetMaxHealthPoints(ushort maxHp)
        {
            maxPoints = maxHp;
            UpdateHealthPoints();
        }

        public void SetHealthPoints(ushort hp)
        {
            currentPoints = hp;
            UpdateHealthPoints();
        }

        public void SetTransparency(float percentage)
        {
            if (percentage > 0f)
            {
                if(!gameObject.activeSelf) gameObject.SetActive(true);
                var color = healthPoints.color;
                color.a = percentage;
                healthPoints.color = color;
                SetTransparency(topLine, percentage);
                SetTransparency(background, percentage);
            }
            else
            {
                gameObject.SetActive(false);
            }
        }

        private static void SetTransparency(SpriteRenderer spriteRenderer, float percentage)
        {
            var color = spriteRenderer.color;
            color.a = percentage;
            spriteRenderer.color = color;
        }

        private void UpdateHealthPoints()
        {
            var percentage = (float)currentPoints / maxPoints;
            mask.localScale = new Vector3(percentage, 1f, 1f);
            healthPoints.text = currentPoints + "/" + maxPoints;
        }
    }
}