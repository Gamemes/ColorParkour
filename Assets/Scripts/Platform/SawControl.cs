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
            float z = transform.rotation.z - 0.2f * Time.deltaTime;
            if (z <= -1)
                z = 0;
            this.transform.rotation = new Quaternion(0f, 0f, z, transform.rotation.w);
            if (idx < points.Count)
            {
                this.transform.position = Vector3.MoveTowards(transform.position, points[idx].position, speed * Time.deltaTime);
                if ((transform.position - points[idx].position).magnitude <= 1)
                {
                    idx++;
                }
            }
            else
            {
                isRunning = false;
            }
        }
    }
}
