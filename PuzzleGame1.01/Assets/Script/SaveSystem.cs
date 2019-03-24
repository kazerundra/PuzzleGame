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

    // Use this for initialization
	static Save startSave(int Stage)
	{
		Save save = new Save ();
		save.clearedStage.Add(Stage);
		return save;
	}
	public void saveClearStage(int Stage)
	{
		Save save = startSave (Stage);
		BinaryFormatter bf = new BinaryFormatter ();
		FileStream file = File.Create (Application.persistentDataPath + "/gamesave.save");
		bf.Serialize (file, save);
		file.Close ();
		Debug.Log ("SaveOk");
	}
	public void Loadgame()
	{
		if (File.Exists ((Application.persistentDataPath + "/gamesave.save"))) {
			BinaryFormatter bf = new BinaryFormatter ();
			FileStream file = File.Open ((Application.persistentDataPath + "/gamesave.save"), FileMode.Open);
			Save save = (Save)bf.Deserialize (file);
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
        if (clearedStage.Contains(STN))
        {

        }else
        {
            clearedStage.Add(STN);
			saveClearStage(STN);
        }     
       if(STN == 1)
        {
            t1 = true;
        }
       else if (STN == 2)
        {
            t2 = true;
        }
       else if (STN == 3)
        {
            t3 = true;
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
