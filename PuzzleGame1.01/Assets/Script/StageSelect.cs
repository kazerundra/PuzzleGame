using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class StageSelect : MonoBehaviour {

    public GameObject stageButton;
    string stageNumber = "stage";
    public GameObject Save;

    public int s;


    // Use this for initialization
   
    public void StagePlay()
    {

        Save =GameObject.Find("SaveSystem");
        stageNumber = EventSystem.current.currentSelectedGameObject.name;
        stageButton = GameObject.Find(stageNumber );
        s = int.Parse(stageButton.GetComponentInChildren<Text>().text);
        Save.GetComponent<SaveSystem>().stage = s;
        //Debug.Log(s);
        //DontDestroyOnLoad(gameObject);
        SceneManager.LoadScene("Game");

        // bikin s nya baca di table pas pindah scene;

    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
