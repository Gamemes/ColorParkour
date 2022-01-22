using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SawControl : MonoBehaviour
{
    // Start is called before the first frame update
    public bool isRunning = false;
    public float speed = 2f;
    public float rotationSpeed = 0.5f;
    public List<Transform> points;
    private Vector3 initPos;
    private int idx = 0;
    void Start()
    {
        initPos = transform.position;
    }
    public void onPlayerDie()
    {
        Debug.Log("back");
        this.transform.position = initPos;
        idx = 0;
    }
    // Update is called once per frame
    void Update()
    {
        if (isRunning)
        {
            this.transform.eulerAngles = new Vector3(0, 0, transform.eulerAngles.z - rotationSpeed * Time.deltaTime);
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
                Player.PlayerDie.PlayerDying -= this.onPlayerDie;
                isRunning = false;
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag.Equals("Player") && isRunning)
        {
            Player.PlayerDie.PlayerDying.Invoke();
        }
    }
}
