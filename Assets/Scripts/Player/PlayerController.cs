using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f; // 移动速度
    public float maxRotationAngle = 45f; // 最大旋转角度
    public float rotationSpeed = 90f; // 角度变化速度

    private bool isMoving = true; // 是否正在移动
    private bool isMousePressed = false; // 鼠标是否按下
    private float mousePressedTime = 0f; // 鼠标按下的时间
    private float initialAngle = 0f; // 初始角度

    private void Update()
    {
        if (isMoving)
        {
            // 如果正在移动，则沿着右方向移动
            transform.Translate(Vector2.right * speed * Time.deltaTime);
        }

        if (Input.GetMouseButtonDown(0))
        {
            // 按下鼠标时停止移动并记录按下时间和初始角度
            isMoving = false;
            isMousePressed = true;
            mousePressedTime = Time.time;
            initialAngle = transform.rotation.eulerAngles.z;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            // 松开鼠标时根据按下的时间继续移动，并根据时间计算角度增量
            isMoving = true;
            isMousePressed = false;
            float elapsedPressTime = Time.time - mousePressedTime;
            float angleIncrement = rotationSpeed * elapsedPressTime;
            transform.rotation = Quaternion.Euler(0f, 0f, initialAngle + angleIncrement);
        }

        if (isMousePressed)
        {
            // 按压鼠标时根据按下的时间计算角度增量
            float elapsedPressTime = Time.time - mousePressedTime;
            float angleIncrement = rotationSpeed * elapsedPressTime;
            transform.rotation = Quaternion.Euler(0f, 0f, initialAngle + angleIncrement);
        }
    }
}