using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    public class PlayerDie : MonoBehaviour
    {
        // Start is called before the first frame update
        public float yCheckLine = -10f;
        private Vector2 initPos;
        public static Action PlayerDying;
        void Start()
        {
            initPos = transform.position;
            PlayerDying += this.onPlayerDie;
        }
        private void OnDestroy()
        {
            PlayerDying -= this.onPlayerDie;
        }
        void onPlayerDie()
        {
            Debug.Log("Player die");
            transform.position = initPos;
            MyGameManager.instance.changeColor(Platform.PlatformColor.WHITE);
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
