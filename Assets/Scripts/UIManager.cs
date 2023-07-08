using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI timeText;

    private static UIManager instance;

    private void Awake()
    {
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

    public static void UpdateTimeUI(float time)
    {
        int minutes = (int)(time / 60);
        int seconds = (int)(time % 60);
        instance.timeText.text = minutes.ToString("00") + ":" + seconds.ToString("00");

        if (GameManager.GameOver)
        {
            ShowGameOver();
        }
    }

    public static void ShowGameOver()
    {
        //TODO:结束游戏
        Time.timeScale = 0f;
    }

    public static void ShowGameWin()
    {
        //TODO:win
        Debug.Log("win");
    }
}