using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapPlatform : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private bool isCanBeTouch;
    private void Start()
    {
        player = GameObject.Find("Player");
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log(other);
        if(other.gameObject == player && isCanBeTouch == true)
        {
            Player.PlayerDie.PlayerDying.Invoke();
        }
    }

    private void IsChangeColor()
    {
        if (gameObject.GetComponent<SpriteRenderer>().color.a ==1)
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
