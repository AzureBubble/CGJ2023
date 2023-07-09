using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;
    private float gameTime = 120f;
    public static bool GameOver = false;

    private void Awake()
    {
        gameTime = 120f;
        // ����Ƿ��Ѿ�����UIHolder��ʵ��������������ٵ�ǰ����
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }

        // ����UIHolder��ʵ���־���
        instance = this;
        DontDestroyOnLoad(gameObject);
    }

    private void Update()
    {
        gameTime -= Time.deltaTime;
        UIManager.UpdateTimeUI(gameTime);

        if (gameTime <= 0f)
        {
            GameOver = true;
        }
    }
}