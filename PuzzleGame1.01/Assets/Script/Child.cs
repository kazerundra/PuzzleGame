using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Child : MonoBehaviour {
	public GameObject q0,q1,q2,q3;
	private Table table;

	// Use this for initialization
	void Start () {
		
	}
	public void FindChild(){
		table = GameObject.Find("GameController").GetComponent<Table>();
		q0 = this.transform.Find("C1").gameObject;
		q1 = this.transform.Find("C2").gameObject;
		q2 = this.transform.Find("C3").gameObject;
        if(table.gameMode == 4)
        {
            q3 = this.transform.Find("C4").gameObject;
        }
       
    }

}
