using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    //public Transform imageTransform; // 图片的Transform组件
    public float speed = 5f; // 移动速度

    public float maxRotationAngle = 45f; // 最大旋转角度
    public float rotationSpeed = 90f; // 角度变化速度

    private bool isMoving = true; // 是否正在移动
    private bool isMousePressed1 = false; // 鼠标是否按下

    //private bool isMousePressed2 = false; // 鼠标是否按下
    private float mousePressedTime = 0f; // 鼠标按下的时间

    private float initialAngle = 0f; // 初始角度
    private Animator animator;

    public SpriteRenderer spriteRenderer;

    public Sprite originSprite;
    public Sprite newSprite;
    private bool isHamer = false;
    public float destroyRadius = 2f; // 破坏范围
    public string targetTag = "Handrail"; // 目标物体的标签

    private void Awake()
    {
        //spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void ChangeSpriteImage()
    {
        spriteRenderer.sprite = newSprite;
    }

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
            isMoving = true;
            isMousePressed1 = true;
            mousePressedTime = Time.time;
            initialAngle = transform.rotation.eulerAngles.z;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            // 松开鼠标时根据按下的时间继续移动，并根据时间计算角度增量
            isMoving = true;
            isMousePressed1 = false;
            float elapsedPressTime = Time.time - mousePressedTime;
            float angleIncrement = rotationSpeed * elapsedPressTime;
            transform.rotation = Quaternion.Euler(0f, 0f, initialAngle + angleIncrement);
            //imageTransform.rotation = Quaternion.Euler(0f, 0f, initialAngle - angleIncrement);
        }

        /* if (Input.GetMouseButtonDown(1))
         {
             // 按下鼠标时停止移动并记录按下时间和初始角度
             isMoving = true;
             isMousePressed2 = true;
             mousePressedTime = Time.time;
             initialAngle = transform.rotation.eulerAngles.z;
         }
         else if (Input.GetMouseButtonUp(1))
         {
             // 松开鼠标时根据按下的时间继续移动，并根据时间计算角度增量
             isMoving = true;
             isMousePressed2 = false;
             float elapsedPressTime = Time.time - mousePressedTime;
             float angleIncrement = rotationSpeed * elapsedPressTime;
             transform.rotation = Quaternion.Euler(0f, 0f, initialAngle - angleIncrement);
         }*/

        if (isMousePressed1)
        {
            // 按压鼠标时根据按下的时间计算角度增量
            float elapsedPressTime = Time.time - mousePressedTime;
            float angleIncrement = rotationSpeed * elapsedPressTime;
            transform.rotation = Quaternion.Euler(0f, 0f, initialAngle + angleIncrement);
            //imageTransform.rotation = Quaternion.Euler(0f, 0f, initialAngle - angleIncrement);
        }

        /*if (isMousePressed2)
        {
            // 按压鼠标时根据按下的时间计算角度增量
            float elapsedPressTime = Time.time - mousePressedTime;
            float angleIncrement = rotationSpeed * elapsedPressTime;
            transform.rotation = Quaternion.Euler(0f, 0f, initialAngle - angleIncrement);
        }*/
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Otter"))
        {
            isMoving = false;
            speed = 0f;
            animator.SetBool("touch", true);
        }
        if (collision.gameObject.CompareTag("Hamer"))
        {
            isHamer = true;
            spriteRenderer.sprite = newSprite;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        /*if (collision.gameObject.CompareTag("Handrail") && isHamer)
        {
            collision.gameObject.SetActive(false);
        }*/
        if (collision.gameObject.CompareTag("Handrail") && isHamer)
        {
            isHamer = false;
            Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, destroyRadius);
            foreach (Collider2D collider in colliders)
            {
                if (collider.CompareTag(targetTag))
                {
                    Destroy(collider.gameObject);
                }
            }
            spriteRenderer.sprite = originSprite;
        }
        else if (!isHamer && (collision.gameObject.CompareTag("Handrail") || collision.gameObject.CompareTag("Ground") || collision.gameObject.CompareTag("snake")))
        {
            speed = 0;
            isMoving = false;
            animator.SetTrigger("hurt");
            StartCoroutine(OnHurtAnimationEnd());
        }
    }

    private IEnumerator OnHurtAnimationEnd()
    {
        // 等待指定的时间
        yield return new WaitForSeconds(3);

        UIManager.instance.ShowGameOver();
    }
}