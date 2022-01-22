using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Platform
{
    public enum PlatformColor
    {
        WHITE, BLACK
    }
    public class PlatformBase : MonoBehaviour
    {
        // Start is called before the first frame update
        public PlatformColor platformColor = PlatformColor.WHITE;
        private SpriteRenderer spriteRenderer;
        void Awake()
        {
            MyGameManager.changeCurrentColor += this.onChangeColor;
            spriteRenderer = GetComponent<SpriteRenderer>();
        }
        private void OnDestroy()
        {
            MyGameManager.changeCurrentColor -= this.onChangeColor;
        }
        void onChangeColor(PlatformColor color)
        {
            if (color == this.platformColor)
            {
                Color preColor = spriteRenderer.color;
                this.spriteRenderer.color = new Color(preColor.r, preColor.g, preColor.b, 0.4f);
            }
            else
            {
                Color preColor = spriteRenderer.color;
                this.spriteRenderer.color = new Color(preColor.r, preColor.g, preColor.b, 1);
            }
        }
        // Update is called once per frame
        void Update()
        {

        }
    }
}
