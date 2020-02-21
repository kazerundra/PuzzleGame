using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
using UnityEngine.SceneManagement;
using System.Diagnostics;

public class SaveSystem : MonoBehaviour {
    public int stage;
    //list of stage that has been cleared
    public List<int> clearedStage;
    //turn off all tutorial
    public bool tutorial;
    public bool noSave;
    //which tutorial is done
    public bool t1, t2, t3;
    Save save = new Save();
    public  GameObject resetButton;

    // Use this for initialization
	
	public void saveClearStage(List<int> Stage)
	{
        save.clearedStage = Stage;
        BinaryFormatter bf = new BinaryFormatter ();
		FileStream file = File.Create (Application.persistentDataPath + "/gamesave.save");
		bf.Serialize (file, save.clearedStage);
		file.Close ();
        noSave = false;

	}
    private string SaveFilePath
    {
        get { return Application.persistentDataPath + "/gamesave.save"; }
    }

    public void ClearClearedStage()
    {
        
        File.Delete(SaveFilePath);
        SceneManager.LoadScene("StartScreen");
      
    }

    public void Loadgame()
	{
		if (File.Exists ((Application.persistentDataPath + "/gamesave.save"))) {
			BinaryFormatter bf = new BinaryFormatter ();
			FileStream file = File.Open ((Application.persistentDataPath + "/gamesave.save"), FileMode.Open);
            save.clearedStage= (List<int>)bf.Deserialize (file);
			file.Close ();
			for (int i = 0; i < save.clearedStage.Count; i++) {
				clearedStage.Add (save.clearedStage [i]);
			}
			
		} else {
		}

	}
		
    public void Tutorialreset()
    {
        t1 = false;
        t2 = false;
        t3 = false;
    }
    public void Awake()
    {
        DontDestroyOnLoad(this);
        if (FindObjectsOfType(GetType()).Length > 1)
        {
            Destroy(gameObject);
        }
    }
    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        Loadgame();
        if (!File.Exists((Application.persistentDataPath + "/gamesave.save")))
        {
            resetButton.SetActive(false);
            noSave = true;
        }
        else
        {
            resetButton.SetActive(true);
            noSave = false;
        }

    }
    void Start () {

        SceneManager.sceneLoaded += OnSceneLoaded;
        

    }
    public void ClearedStage(int STN)
    {
        if(STN >= 4)
        {
            if (clearedStage.Contains(STN))
            {

            }
            else
            {
                clearedStage.Add(STN);
                saveClearStage(clearedStage);
            }
        }
       
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
