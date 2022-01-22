using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    // Start is called before the first frame update
    private bool isChecked = false;
    private SpriteRenderer spriteRenderer;
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag.Equals("Player") && !isChecked)
        {
            Debug.Log("check point");
            float h, s, v;
            Color.RGBToHSV(spriteRenderer.color, out h, out s, out v);
            MyGameManager.instance.reBornPos = this.transform.position;
            spriteRenderer.color = Color.HSVToRGB(h, s, 0.3f);
            isChecked = true;
        }
    }
}
