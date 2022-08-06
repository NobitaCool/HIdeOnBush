using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private const int TOTAL_LEVEL = 10;

    public void LoadGameScene(int level) => SceneManager.LoadScene(level, LoadSceneMode.Single);

    public void LoadLevelScene() => SceneManager.LoadScene("LevelScene", LoadSceneMode.Single);

    public void LoadMainMenuScene() => SceneManager.LoadScene("MainMenuScene", LoadSceneMode.Single);

    public void LoadCurentScene() => SceneManager.LoadScene(PlayerPrefs.GetInt("curLevel"), LoadSceneMode.Single);

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

        LoadGameScene(nextLevel);
    }

    public void GameOver()
    {
        // DO SOMETHING
    }

    public void Victory()
    {
        LoadNextLevel();
    }
}
