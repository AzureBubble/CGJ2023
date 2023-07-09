using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    //public Transform imageTransform; // ͼƬ��Transform���
    public float speed = 5f; // �ƶ��ٶ�

    public float maxRotationAngle = 45f; // �����ת�Ƕ�
    public float rotationSpeed = 90f; // �Ƕȱ仯�ٶ�

    private bool isMoving = true; // �Ƿ������ƶ�
    private bool isMousePressed1 = false; // ����Ƿ���

    //private bool isMousePressed2 = false; // ����Ƿ���
    private float mousePressedTime = 0f; // ��갴�µ�ʱ��

    private float initialAngle = 0f; // ��ʼ�Ƕ�
    private Animator animator;

    public SpriteRenderer spriteRenderer;

    public Sprite originSprite;
    public Sprite newSprite;
    private bool isHamer = false;
    public float destroyRadius = 2f; // �ƻ���Χ
    public string targetTag = "Handrail"; // Ŀ������ı�ǩ

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
            // ��������ƶ����������ҷ����ƶ�
            transform.Translate(Vector2.right * speed * Time.deltaTime);
        }

        if (Input.GetMouseButtonDown(0))
        {
            // �������ʱֹͣ�ƶ�����¼����ʱ��ͳ�ʼ�Ƕ�
            isMoving = true;
            isMousePressed1 = true;
            mousePressedTime = Time.time;
            initialAngle = transform.rotation.eulerAngles.z;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            // �ɿ����ʱ���ݰ��µ�ʱ������ƶ���������ʱ�����Ƕ�����
            isMoving = true;
            isMousePressed1 = false;
            float elapsedPressTime = Time.time - mousePressedTime;
            float angleIncrement = rotationSpeed * elapsedPressTime;
            transform.rotation = Quaternion.Euler(0f, 0f, initialAngle + angleIncrement);
            //imageTransform.rotation = Quaternion.Euler(0f, 0f, initialAngle - angleIncrement);
        }

        /* if (Input.GetMouseButtonDown(1))
         {
             // �������ʱֹͣ�ƶ�����¼����ʱ��ͳ�ʼ�Ƕ�
             isMoving = true;
             isMousePressed2 = true;
             mousePressedTime = Time.time;
             initialAngle = transform.rotation.eulerAngles.z;
         }
         else if (Input.GetMouseButtonUp(1))
         {
             // �ɿ����ʱ���ݰ��µ�ʱ������ƶ���������ʱ�����Ƕ�����
             isMoving = true;
             isMousePressed2 = false;
             float elapsedPressTime = Time.time - mousePressedTime;
             float angleIncrement = rotationSpeed * elapsedPressTime;
             transform.rotation = Quaternion.Euler(0f, 0f, initialAngle - angleIncrement);
         }*/

        if (isMousePressed1)
        {
            // ��ѹ���ʱ���ݰ��µ�ʱ�����Ƕ�����
            float elapsedPressTime = Time.time - mousePressedTime;
            float angleIncrement = rotationSpeed * elapsedPressTime;
            transform.rotation = Quaternion.Euler(0f, 0f, initialAngle + angleIncrement);
            //imageTransform.rotation = Quaternion.Euler(0f, 0f, initialAngle - angleIncrement);
        }

        /*if (isMousePressed2)
        {
            // ��ѹ���ʱ���ݰ��µ�ʱ�����Ƕ�����
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
        // �ȴ�ָ����ʱ��
        yield return new WaitForSeconds(3);

        UIManager.instance.ShowGameOver();
    }
}