using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OtterMovement : MonoBehaviour
{
    public Transform[] waypoints; // �ĸ������Transform�������
    public float speed = 2f; // �ƶ��ٶ�

    private int currentWaypointIndex = 0; // ��ǰĿ�궨�������

    private void Update()
    {
        // ����Ƿ��ѵ��ﵱǰĿ�궨��
        if (transform.position == waypoints[currentWaypointIndex].position)
        {
            // �л�����һ��Ŀ�궨��
            currentWaypointIndex = (currentWaypointIndex + 1) % waypoints.Length;
        }

        // ʹ�ò�ֵ����ƽ���ƶ����嵽Ŀ�궨��
        transform.position = Vector3.MoveTowards(transform.position, waypoints[currentWaypointIndex].position, speed * Time.deltaTime);
    }
}