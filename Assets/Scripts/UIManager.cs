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
            UIManager.instance.ShowGameOver();
        }
    }

    public void ShowGameOver()
    {
        //TODO:������Ϸ
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