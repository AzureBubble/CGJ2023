using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OtterMovement : MonoBehaviour
{
    public Transform[] waypoints; // 四个定点的Transform组件数组
    public float speed = 2f; // 移动速度

    private int currentWaypointIndex = 0; // 当前目标定点的索引

    private void Update()
    {
        // 检查是否已到达当前目标定点
        if (transform.position == waypoints[currentWaypointIndex].position)
        {
            // 切换到下一个目标定点
            currentWaypointIndex = (currentWaypointIndex + 1) % waypoints.Length;
        }

        // 使用插值函数平滑移动物体到目标定点
        transform.position = Vector3.MoveTowards(transform.position, waypoints[currentWaypointIndex].position, speed * Time.deltaTime);
    }
}