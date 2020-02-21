using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class StageSelect : MonoBehaviour {

    public GameObject stageButton;
    string stageNumber = "Stage";
	public GameObject Save, Three, Four,StageSelectButton,title;
	public string currentMenu;
    public int s;
    public List<GameObject> stagePanel;
	public Button fourButton;



    // Use this for initialization

    public void Awake()
    {
		Save = GameObject.Find("SaveSystem");
        Four.SetActive(true);
        Three.SetActive(true);
        //fourButton = GameObject.Find ("4x4Button").GetComponent<Button>();
        //Three = GameObject.Find ("3x3");
        /*
		Four = GameObject.Find ("4x4");
		Tutorial = GameObject.Find ("tutorial");
		StageSelectButton = GameObject.Find("ButtonSet");
*/

        for (int i= 1; i<= 53; i++)
        {
            stagePanel.Add(GameObject.Find("Stage (" + i + ")"));
        }

    }

    public void Start()
    {
		currentMenu = "StageSelect";
        GameObject go;
      
        Four.SetActive (true);
        Three.SetActive (true);


        //クリアスタンプをプリント      
        if (!Save.GetComponent<SaveSystem>().noSave)
        {
            for (int i = 0; i < Save.GetComponent<SaveSystem>().clearedStage.Count; i++)
            {
                Debug.Log(Save.GetComponent<SaveSystem>().clearedStage[i] - 1);
                go = Instantiate(Resources.Load("Prefabs/clear m")) as GameObject;
                go.transform.position = stagePanel[Save.GetComponent<SaveSystem>().clearedStage[i] - 4].transform.position;
                if (Save.GetComponent<SaveSystem>().clearedStage[i] - 1 < 28)
                {
                    go.transform.parent = Three.transform;
                }
                else
                {
                    go.transform.parent = Four.transform;
                }
                go.transform.localScale = new Vector3(6, 6, 6);
            }
        }
        
        if (Save.GetComponent<SaveSystem>().clearedStage.Count <= 5)
        {
            fourButton.interactable = false;
        }
           
       //Four.SetActive(false);
        //Three.SetActive(false);

    }
    //押したステージナンバーがSAVESYSTEMに保存
    public void StagePlay()
    {

        Save =GameObject.Find("SaveSystem");
        stageNumber = EventSystem.current.currentSelectedGameObject.name;
        stageButton = GameObject.Find(stageNumber );
        s = int.Parse(stageButton.GetComponentInChildren<Text>().text);
        Save.GetComponent<SaveSystem>().stage = s;
        SceneManager.LoadScene("Game");
    }
	public void tutorial()
	{
		Save =GameObject.Find("SaveSystem");
		Save.GetComponent<SaveSystem>().stage = 1;
		SceneManager.LoadScene("Game");
	}
	public void Stage3x3()
	{
		currentMenu = "3";
		StageSelectButton.SetActive (false);
		Three.SetActive (true);
		title.GetComponent<Text> ().text = "3X3";
	}
	public void Stage4x4()
	{
		currentMenu ="4";
		StageSelectButton.SetActive (false);
		Four.SetActive (true);
		title.GetComponent<Text> ().text = "4X4";
	}
	public void backButton()
	{
		if (currentMenu == "3") {
			Three.SetActive (false);
			currentMenu = "mainmenu";
		} else if (currentMenu == "4") {
			Four.SetActive (false);
			currentMenu = "mainmenu";
		}
		else 
		{
			SceneManager.LoadScene("StartScreen");
		}
		title.GetComponent<Text> ().text = "STAGE SELECT";
		StageSelectButton.SetActive (true);			
	}

	// Update is called once per frame
	void Update () {
		
	}

}
