using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class StageSelect : MonoBehaviour {

    public GameObject stageButton;
    string stageNumber = "stage";
    public int s;

    // Use this for initialization
    void Start () {
        string stageNumber = "Stage";
        DontDestroyOnLoad(gameObject);
        
        for(int i =0; i<40; i++)
        {
            stageButton = GameObject.Find(stageNumber + "(" + i + ")");
            stageButton.GetComponentInChildren<Text>().text = i.ToString();
        }
		
	}
    public void StagePlay()
    {

       
        stageNumber = EventSystem.current.currentSelectedGameObject.name;
        stageButton =GameObject.Find(stageNumber );
        s = int.Parse(stageButton.GetComponentInChildren<Text>().text);
        // bikin s nya baca di table pas pindah scene;
        
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
