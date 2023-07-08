using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelPanelManager : MonoBehaviour
{
    public GameObject levelPanel;
    private Button[] levelButton;
    private int unlockedLevelIndex;

    private void Start()
    {
        //PlayerPrefs.SetInt("unlockedLevelIndex", 0);
        unlockedLevelIndex = PlayerPrefs.GetInt("unlockedLevelIndex");
        levelButton = new Button[levelPanel.transform.childCount];
        for (int i = 0; i < levelPanel.transform.childCount; i++)
        {
            levelButton[i] = levelPanel.transform.GetChild(i).GetComponent<Button>();
        }
        for (int i = 0; i < levelButton.Length; i++)
        {
            levelButton[i].interactable = false;
        }
        for (int i = 0; i < unlockedLevelIndex + 1; i++)
        {
            levelButton[i].interactable = true;
        }
    }

    public void LoadLevel01()
    {
        SceneManager.LoadScene(1);
    }

    public void LoadLevel02()
    {
        SceneManager.LoadScene(2);
    }

    public void LoadLevel03()
    {
        SceneManager.LoadScene(3);
    }

    public void LoadLevel04()
    {
        SceneManager.LoadScene(4);
    }
}