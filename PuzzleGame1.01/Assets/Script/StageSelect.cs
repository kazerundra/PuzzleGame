﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class StageSelect : MonoBehaviour {

    public GameObject stageButton;
    string stageNumber = "Stage";
    public GameObject Save;

    public int s;
    public List<GameObject> stagePanel;


    // Use this for initialization

    public void Awake()
    {
        Save = GameObject.Find("SaveSystem");
        for(int i= 1; i<= 40; i++)
        {
            stagePanel.Add(GameObject.Find("Stage (" + i + ")"));
        }
    }

    public void Start()
    {
        //Debug.Log(Save.GetComponent<SaveSystem>().clearedStage.Count);
        GameObject go;
        for (int i =0; i< Save.GetComponent<SaveSystem>().clearedStage.Count; i++)
        {
            go = Instantiate(Resources.Load("Prefabs/clear m")) as GameObject;
            go.transform.position = stagePanel[Save.GetComponent<SaveSystem>().clearedStage[i]-1].transform.position;
            //Debug.Log("Stage" + Save.GetComponent<SaveSystem>().clearedStage[i] + "Cleared");
        }
    }
    public void StagePlay()
    {

        Save =GameObject.Find("SaveSystem");
        stageNumber = EventSystem.current.currentSelectedGameObject.name;
        stageButton = GameObject.Find(stageNumber );
        s = int.Parse(stageButton.GetComponentInChildren<Text>().text);
        Save.GetComponent<SaveSystem>().stage = s;
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
