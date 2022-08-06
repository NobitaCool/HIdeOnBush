using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    #region Variable
        #region UI
            [SerializeField] private GameObject gameOverUI;
        #endregion
        #region const
            private const int TOTAL_LEVEL = 10;
        #endregion
        #region bla blab al
            private bool isPause = false;
        #endregion
    #endregion
    
   

    public void LoadGameScene(int level) => SceneManager.LoadScene(level, LoadSceneMode.Single);

    public void LoadLevelScene() => SceneManager.LoadScene("LevelScene", LoadSceneMode.Single);

    public void LoadMainMenuScene() => SceneManager.LoadScene("MainMenuScene", LoadSceneMode.Single);

    public void LoadCurrentScene() => SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex, LoadSceneMode.Single);

    public void LoadNextLevel()
    {
        int nextLevel = PlayerPrefs.GetInt("curLevel") + 1;

        if(nextLevel > TOTAL_LEVEL)
        {
            // DO SOMETHING 
            return;
        }

        if(nextLevel > PlayerPrefs.GetInt("curLevel"))
        {
            PlayerPrefs.SetInt("curLevel", nextLevel);
        }
    }

    public void Pause()
    {
        isPause = !isPause;

        Time.timeScale = isPause ? 0 : 1;
    }

    public void GameOver()
    {
        gameOverUI.SetActive(true);
    }

    public void Victory()
    {
        LoadGameScene(SceneManager.GetActiveScene().buildIndex + 1); 
    }
}
