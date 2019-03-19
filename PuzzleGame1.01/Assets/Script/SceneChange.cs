using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour {
   
     

    public void StageSelect()
    {
        SceneManager.LoadScene("StageSelect");
    }
	public void ExitGame()
	{
		Application.Quit();
	}

  
    public void GameScene()
    {
        SceneManager.LoadScene("Game");
    }

    public void TitleMenu()
    {
        SceneManager.LoadScene("StartScreen");
    }

    // Update is called once per frame
    void Update () {
        		
	}
    
}
