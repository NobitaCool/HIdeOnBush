using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private Button[] levelBtns;
    void Start() 
    {
        int curLevel = PlayerPrefs.GetInt("curLevel", 1);
        for (int i = 0; i < levelBtns.Length; i++)
        {
            if (i + 1 > curLevel) levelBtns[i].interactable = false;
        }
    } 

    public void ResetLevel()
    {
        PlayerPrefs.DeleteKey("curLevel");
    }

}
