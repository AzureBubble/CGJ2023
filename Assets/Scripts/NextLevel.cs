using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour
{
    public int currentLevelIndex;

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
            SceneManager.LoadScene((SceneManager.GetActiveScene().buildIndex + 1) % SceneManager.sceneCountInBuildSettings);
        }
    }
}