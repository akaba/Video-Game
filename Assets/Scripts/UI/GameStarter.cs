using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStarter : MonoBehaviour
{
   
    //load scene during runtime
    public void StartGame()
    {
        SceneManager.LoadScene("demo");    
    }
   
}