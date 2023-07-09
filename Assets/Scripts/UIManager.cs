using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI timeText;

    public GameObject menuPanel;

    public static UIManager instance;

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
        //TODO:������Ϸ
        Time.timeScale = 0f;
    }

    public void ShowGameWin()
    {
        //TODO:win
        //Debug.Log("win");
        menuPanel.SetActive(true);
    }
}