using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private Button[] level_Btns;
    [SerializeField] private Image[] lock_Btns;
    private int curLevel;

    private void Awake() 
    {
        PlayerPrefs.DeleteKey("curLevel");
        PlayerPrefs.SetInt("curLevel", 10);
        curLevel = PlayerPrefs.GetInt("curLevel");
        UpdateLevel();
    } 

    public void UpdateLevel()
    {
        for (int i = 0; i < level_Btns.Length; i++)
        {
            if (i + 1 <= curLevel) continue;

            level_Btns[i].interactable = false;
            lock_Btns[i].enabled = true;
        }
    }

    private void ResetLevel() => PlayerPrefs.DeleteKey("curLevel");

}
