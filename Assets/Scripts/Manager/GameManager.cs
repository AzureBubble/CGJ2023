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
        // 检查是否已经存在UIHolder的实例，如果有则销毁当前对象
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }

        // 保持UIHolder的实例持久性
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