using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveSystem : MonoBehaviour {
    public int stage;
    //list of stage that has been cleared
    public List<int> clearedStage;

    // Use this for initialization
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
      
       
       
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
