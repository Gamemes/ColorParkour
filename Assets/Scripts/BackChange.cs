using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackChange : MonoBehaviour
{
    // Start is called before the first frame update
    public Sprite whiteSprite;
    public Sprite drakSprite;
    public Transform cameraPos;
    public Vector3 prePos;
    private SpriteRenderer spriteRenderer;
    public Vector3 offsetPos = new Vector3(0, 0, 0);
    void Start()
    {
        if (whiteSprite == null || drakSprite == null)
        {
            Debug.LogError("drakSprite | whiteSprite error");
        }
        spriteRenderer = GetComponent<SpriteRenderer>();
        prePos = cameraPos.position;
        MyGameManager.changeCurrentColor += this.onChangeColor;
    }

    void onChangeColor(Platform.PlatformColor color)
    {
        if (color == Platform.PlatformColor.WHITE)
        {
            this.spriteRenderer.sprite = whiteSprite;
        }
        else
        {
            this.spriteRenderer.sprite = drakSprite;
        }
    }
    private void OnDestroy()
    {
        MyGameManager.changeCurrentColor -= this.onChangeColor;
    }
    // Update is called once per frame
    void Update()
    {
        Vector3 cpos = cameraPos.position;
        offsetPos += (cpos - prePos) / 60;
        prePos = cpos;
        offsetPos.Set(offsetPos.x, offsetPos.y, 0);
        this.transform.position = cpos + offsetPos + new Vector3(0, 0, 10);
    }
}
