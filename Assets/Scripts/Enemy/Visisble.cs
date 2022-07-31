using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Visisble : MonoBehaviour
{
    #region Variable
        #region event
            public UnityEvent DetectedPlayer;
        #endregion
        #region const
            private const string PLAYER_TAG = "Player";
        #endregion
    #endregion
   

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(!other.gameObject.CompareTag(PLAYER_TAG)) return;
               
        DetectedPlayer.Invoke();
    }
}
