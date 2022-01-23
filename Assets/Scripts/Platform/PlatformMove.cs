using UnityEngine;

namespace Platform
{
    public class PlatformMove : MonoBehaviour
    {
        [SerializeField] private float MoveSpeed;               //平台移动速度
        [SerializeField] private Transform[] wayPoints;         //移动点的数组
        [SerializeField] private int index;                     //数组索引
        private bool isPlayerOnPlatform = false;
        private Transform playerTransform;
        private void Start()
        {
            index = 0;
        }

        private void Update()
        {
            ///使物体向着目标点移动
            Vector2 tarPos = Vector2.MoveTowards(transform.position, wayPoints[index].position, MoveSpeed * Time.deltaTime);
            if (isPlayerOnPlatform)
            {
                Vector2 dpos = new Vector2(tarPos.x - transform.position.x, tarPos.y - transform.position.y);
                playerTransform.position += new Vector3(dpos.x, dpos.y);
            }
            this.transform.position = tarPos;
            ///当物体离目标点足够近时切换目标点
            if (Vector2.Distance(transform.position, wayPoints[index].position) <= 0.05f)
            {
                index++;
                if (index >= wayPoints.Length)                  //数组索引越界返回
                {
                    index = 0;
                }
            }
        }
        private void OnTriggerEnter2D(Collider2D other)
        {
            //Debug.Log("enter");
            if (other.tag.Equals("Player"))
            {
                isPlayerOnPlatform = true;
                playerTransform = other.transform;
            }
        }
        private void OnTriggerExit2D(Collider2D other)
        {
            if (other.tag.Equals("Player"))
            {
                isPlayerOnPlatform = false;
            }
        }
    }
}
