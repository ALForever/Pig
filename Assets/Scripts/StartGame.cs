using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGame : MonoBehaviour
{    
    void Start()
    {
        Time.timeScale = 0;
    }
        
    public void StartTheGame()
    {
        Time.timeScale = 1;
        gameObject.SetActive(false);
    }
}
