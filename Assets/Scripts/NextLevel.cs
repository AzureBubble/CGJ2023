using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour
{
    public int currentLevelIndex;
    public float waitTime = 3f;

    private int unlockLevel;

    private void Start()
    {
        unlockLevel = PlayerPrefs.GetInt("unlockedLevelIndex");
    }

    // Update is called once per frame
    private void Update()
    {
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (currentLevelIndex > unlockLevel)
            {
                unlockLevel = currentLevelIndex;
                PlayerPrefs.SetInt("unlockedLevelIndex", currentLevelIndex);
            }
            if ((SceneManager.GetActiveScene().buildIndex + 1) % SceneManager.sceneCountInBuildSettings == 0)
            {
                UIManager.instance.ShowGameWinMenu();
                Time.timeScale = 0f;
            }
            else
            {
                StartCoroutine(LoadNextSceneAfterDelay((SceneManager.GetActiveScene().buildIndex + 1) % SceneManager.sceneCountInBuildSettings));
            }
        }
    }

    private IEnumerator LoadNextSceneAfterDelay(int index)
    {
        // 等待指定的时间
        yield return new WaitForSeconds(waitTime);

        // 加载下一个场景
        UIManager.instance.ShowGameWin(index);
        Time.timeScale = 0f;
    }
}