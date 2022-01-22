using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SawTrigger : MonoBehaviour
{
    // Start is called before the first frame update
    public SawControl sawControl;
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag.Equals("Player"))
        {
            if (!sawControl.isRunning)
            {
                sawControl.isRunning = true;
                Player.PlayerDie.PlayerDying += sawControl.onPlayerDie;
            }
        }
    }
}
