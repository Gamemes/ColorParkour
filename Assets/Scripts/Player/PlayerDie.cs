using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    using PlayerController;
    public class PlayerDie : MonoBehaviour
    {
        // Start is called before the first frame update
        public float yCheckLine = -10f;
        public static Action PlayerDying;
        public PlayerController playerController;
        void Start()
        {
            MyGameManager.instance.reBornPos = transform.position;
            playerController = GetComponent<PlayerController>();
            PlayerDying += this.onPlayerDie;
        }
        private void OnDestroy()
        {
            PlayerDying -= this.onPlayerDie;
        }
        void onPlayerDie()
        {
            Debug.Log("Player die");
            transform.position = MyGameManager.instance.reBornPos;
            MyGameManager.instance.changeColor(Platform.PlatformColor.WHITE);
            playerController.reSetSpeed();
        }
        // Update is called once per frame
        void Update()
        {
            if (transform.position.y < yCheckLine)
            {
                PlayerDying.Invoke();
            }
        }
    }
}
