using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f; // �ƶ��ٶ�
    public float maxRotationAngle = 45f; // �����ת�Ƕ�
    public float rotationSpeed = 90f; // �Ƕȱ仯�ٶ�

    private bool isMoving = true; // �Ƿ������ƶ�
    private bool isMousePressed = false; // ����Ƿ���
    private float mousePressedTime = 0f; // ��갴�µ�ʱ��
    private float initialAngle = 0f; // ��ʼ�Ƕ�

    private void Update()
    {
        if (isMoving)
        {
            // ��������ƶ����������ҷ����ƶ�
            transform.Translate(Vector2.right * speed * Time.deltaTime);
        }

        if (Input.GetMouseButtonDown(0))
        {
            // �������ʱֹͣ�ƶ�����¼����ʱ��ͳ�ʼ�Ƕ�
            isMoving = false;
            isMousePressed = true;
            mousePressedTime = Time.time;
            initialAngle = transform.rotation.eulerAngles.z;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            // �ɿ����ʱ���ݰ��µ�ʱ������ƶ���������ʱ�����Ƕ�����
            isMoving = true;
            isMousePressed = false;
            float elapsedPressTime = Time.time - mousePressedTime;
            float angleIncrement = rotationSpeed * elapsedPressTime;
            transform.rotation = Quaternion.Euler(0f, 0f, initialAngle + angleIncrement);
        }

        if (isMousePressed)
        {
            // ��ѹ���ʱ���ݰ��µ�ʱ�����Ƕ�����
            float elapsedPressTime = Time.time - mousePressedTime;
            float angleIncrement = rotationSpeed * elapsedPressTime;
            transform.rotation = Quaternion.Euler(0f, 0f, initialAngle + angleIncrement);
        }
    }
}