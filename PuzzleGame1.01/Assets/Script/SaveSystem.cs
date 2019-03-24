using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;

public class SaveSystem : MonoBehaviour {
    public int stage;
    //list of stage that has been cleared
    public List<int> clearedStage;
    //turn off all tutorial
    public bool tutorial;
    //which tutorial is done
    public bool t1, t2, t3;
    Save save = new Save();

    // Use this for initialization
	
	public void saveClearStage(List<int> Stage)
	{
        // FileStream fs = new FileStream("save.dat", FileMode.Create);
        //BinaryFormatter bf = new BinaryFormatter();
        // bf.Serialize(fs, yourList);
        // fs.Close(); 
        save.clearedStage = Stage;

        BinaryFormatter bf = new BinaryFormatter ();
		FileStream file = File.Create (Application.persistentDataPath + "/gamesave.save");
		bf.Serialize (file, save.clearedStage);
		file.Close ();
		Debug.Log ("SaveOk:");

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
			Debug.Log ("loadOk");
		} else {
			Debug.Log ("noSAve");
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
    void Start () {
		Loadgame ();
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
