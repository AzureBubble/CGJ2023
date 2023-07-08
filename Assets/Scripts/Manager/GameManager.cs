using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;
    private float gameTime;

    private void Awake()
    {
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
        gameTime += Time.deltaTime;
        UIManager.UpdateTimeUI(gameTime);
    }
}