using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    using Platform;
    using PlayerController;
    public class PlayerColorControl : MonoBehaviour
    {
        // Start is called before the first frame update
        private PlayerController playerController;
        public LayerMask whiteGround;
        public LayerMask blackGround;
        void Start()
        {
            playerController = GetComponent<PlayerController>();
            MyGameManager.changeCurrentColor += this.changeColor;
            changeColor(MyGameManager.instance.currentColor);
        }
        void changeColor(PlatformColor color)
        {
            if (color == PlatformColor.WHITE)
            {
                playerController._groundLayer = blackGround;
            }
            else
            {
                playerController._groundLayer = whiteGround;
            }
        }
        // Update is called once per frame
        void Update()
        {
            if (Input.GetMouseButtonDown(1))
            {
                Debug.Log("change color");
                PlatformColor color = MyGameManager.instance.changeColor();
            }
        }
    }

}
