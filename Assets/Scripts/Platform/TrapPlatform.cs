using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapPlatform : MonoBehaviour
{
    [SerializeField] private bool isCanBeTouch = true;
    private SpriteRenderer spriteRenderer;
    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log(other);
        if (other.tag == "Player" && isCanBeTouch == true)
        {
            Player.PlayerDie.PlayerDying.Invoke();
        }
    }

    private void IsChangeColor()
    {
        if (spriteRenderer.color.a == 1)
        {
            isCanBeTouch = true;
        }
        else
        {
            isCanBeTouch = false;
        }
    }

    private void Update()
    {
        IsChangeColor();
    }
}
