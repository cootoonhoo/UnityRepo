using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Inimigo : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D outroObj){
        if(outroObj.gameObject.CompareTag("Player")){
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
