using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI timeText;

    public GameObject menuPanel;
    public GameObject losePanel;
    public GameObject GamePanel;
    public Button nextBtn;

    public static UIManager instance;

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
            UIManager.instance.ShowGameOver();
        }
    }

    public void ShowGameOver()
    {
        //TODO:结束游戏
        losePanel.SetActive(true);
        Time.timeScale = 0f;
    }

    public void ShowGameWin(int index)
    {
        //TODO:win
        //Debug.Log("win");
        menuPanel.SetActive(true);
        nextBtn.onClick.AddListener(() => Next(index));
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        losePanel.SetActive(false);
        menuPanel.SetActive(false);
        Time.timeScale = 1f;
    }

    public void Next(int index)
    {
        SceneManager.LoadScene(index);
        Time.timeScale = 1f;
        menuPanel.SetActive(false);
        losePanel.SetActive(false);
    }

    public void ShowGameWinMenu()
    {
        GamePanel.SetActive(true);
    }
}