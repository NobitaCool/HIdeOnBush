using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeBehaviour : MonoBehaviour
{
    #region Variable
        #region private
        // Cây
        [SerializeField] private GameObject tree;

        // Gốc
        [SerializeField] private GameObject stump;

        // Hiệu ứng
        [SerializeField] private ParticleSystem effect;
        #endregion
    #endregion

    #region Function
        void OnTriggerEnter2D(Collider2D other)
        {
            // Condition: !player do nothing
            if (!other.GetComponent<PlayerBehaviour>()) return;

            // Spawn cây 
            Instantiate(effect, transform.position, Quaternion.identity);
            Instantiate(tree, transform.position, Quaternion.identity);

            // Xóa gốc 
            Destroy(stump);
        }
    #endregion

}
