using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour {
    

	// Use this for initialization
	void Start () {
       
	}

    public void StageSelect()
    {
        
        SceneManager.LoadScene("StageSelect");
 
    }

  
    public void GameScene()
    {
        SceneManager.LoadScene("Game");
    }
    // Update is called once per frame
    void Update () {
        		
	}
    
}
