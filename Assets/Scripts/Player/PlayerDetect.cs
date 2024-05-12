using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDetect : MonoBehaviour
{
    protected virtual void OnTriggerEnter2D(UnityEngine.Collider2D collider2D)
    {
        if (collider2D.CompareTag("Enemy"))
        {
            Destroy(gameObject);
            Debug.Log("Destroy...");
        }
        
        if (collider2D.CompareTag("NPC"))
        {
            LevelChanger.instance.NextLevel();
            Debug.Log("Scene...");
        }
    }
}
