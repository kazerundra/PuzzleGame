using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveSystem : MonoBehaviour {
    public int stage;
    //list of stage that has been cleared
    public List<int> clearedStage;
    //turn off all tutorial
    public bool tutorial;
    //which tutorial is done
    public bool t1, t2, t3;

    // Use this for initialization

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
		
	}
    public void ClearedStage(int STN)
    {
        if (clearedStage.Contains(STN))
        {

        }else
        {
            clearedStage.Add(STN);
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
