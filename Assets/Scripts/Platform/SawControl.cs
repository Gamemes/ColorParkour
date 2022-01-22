using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SawControl : MonoBehaviour
{
    // Start is called before the first frame update
    public bool isRunning = false;
    public float speed = 2f;
    public List<Transform> points;
    private int idx = 0;
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (isRunning)
        {

        }
    }
}
