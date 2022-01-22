using UnityEngine;

public class PlatformMove : MonoBehaviour
{
    [SerializeField] private float MoveSpeed;               //平台移动速度
    [SerializeField] private Transform[] wayPoints;         //移动点的数组
    [SerializeField] private int index;                     //数组索引

    private void Start()
    {
        index = 0;
    }

    private void Update()
    {
        ///使物体向着目标点移动
        transform.position = Vector2.MoveTowards(transform.position, wayPoints[index].position, MoveSpeed * Time.deltaTime);

        ///当物体离目标点足够近时切换目标点
        if (Vector2.Distance(transform.position,wayPoints[index].position)<= 0.05f)
        {
            index++;
            if(index >=  wayPoints.Length)                  //数组索引越界返回
            {
                index = 0;
            }
        }
    }
}
