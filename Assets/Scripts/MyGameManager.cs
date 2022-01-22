using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Platform;

public class MyGameManager : MonoBehaviour
{
    // Start is called before the first frame update
    public PlatformColor currentColor { get; private set; } = PlatformColor.WHITE;
    public static MyGameManager instance;
    public static Action<PlatformColor> changeCurrentColor;
    public Vector3 reBornPos;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
    private void Start()
    {
        changeCurrentColor?.Invoke(this.currentColor);
    }
    public PlatformColor changeColor()
    {
        if (currentColor == PlatformColor.WHITE)
            currentColor = PlatformColor.BLACK;
        else
            currentColor = PlatformColor.WHITE;
        changeCurrentColor?.Invoke(this.currentColor);
        return currentColor;
    }
    public PlatformColor changeColor(PlatformColor color)
    {
        currentColor = color;
        changeCurrentColor?.Invoke(currentColor);
        return currentColor;
    }
    // Update is called once per frame
    void Update()
    {

    }
}
