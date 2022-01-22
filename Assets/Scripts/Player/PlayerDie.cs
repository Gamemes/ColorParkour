using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDie : MonoBehaviour
{
    // Start is called before the first frame update
    public float yCheckLine = -10f;
    private Vector2 initPos;
    void Start()
    {
        initPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < yCheckLine)
            transform.position = initPos;
    }
}
