using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

enum UIButton
{
    PauseBtn = 0,
    PlayBtn = 1,
}

public class GameManager : MonoBehaviour
{
    #region Variable
        #region UI
            [SerializeField] private GameObject gameOverUI;
            [SerializeField] private GameObject[] generateUI;
            [SerializeField] private GameObject levelPanel;
            [SerializeField] private TextMeshProUGUI levelValue;
        #endregion
        #region Level
            [SerializeField] private int curLevel;
            [SerializeField] private GameObject[] levelScenes;
        #endregion
        #region Audio
            [SerializeField] private AudioSource backgroundSound;
        #endregion
        #region const
            private const int TOTAL_LEVEL = 10;
        #endregion
        #region condition
            private bool isPause = false;
            private bool enableSound = true;
        #endregion
        #region Event
            public UnityEvent ResetCamTarget;
        #endregion
    #endregion

    private void Awake()
    {
        levelScenes = GameObject.FindGameObjectsWithTag("Level"); 

        if(levelScenes.Length <= 0) return;

        LoadLevelScene();
    }

    private void LoadLevelScene()
    {
        for(int i = 0; i < levelScenes.Length; i++)
        {
            levelScenes[i].SetActive(false);
        }

        levelScenes[curLevel-1].SetActive(true);

        ResetCamTarget.Invoke();

        Debug.Log("Level: " + curLevel);
    }

    public void LoadGameScene(int level) 
    {
        SceneManager.LoadScene("GameScene", LoadSceneMode.Single);

        curLevel = level;
    } 

    public void LoadLevelPanel() 
    {
        
    }

    public void LoadMainMenuScene() => SceneManager.LoadScene("MainMenuScene", LoadSceneMode.Single);

    public void LoadCurrentLevel() => LoadGameScene(curLevel);

    public void LoadNextLevel()
    {
        if(curLevel < PlayerPrefs.GetInt("curLevel")) return;

        int nextLevel = PlayerPrefs.GetInt("curLevel") + 1;

        if(nextLevel > TOTAL_LEVEL)
        {
            // DO SOMETHING 
            return;
        }

        PlayerPrefs.SetInt("curLevel", nextLevel);
    }

    public void Pause()
    {
        isPause = !isPause;

        generateUI[(int) UIButton.PlayBtn].SetActive(isPause);

        Time.timeScale = isPause ? 0 : 1;
    }

    public void EnableSound()
    {
        enableSound = !enableSound;
        
        backgroundSound.enabled = enableSound;
    }


    public void GameOver()
    {
        gameOverUI.SetActive(true);
        levelValue.text = "0" + curLevel;
    }

    public void Victory()
    {
        curLevel++;
        LoadLevelScene();
        LoadNextLevel(); 
    }
}
