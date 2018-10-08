using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 置く場所に何コイン目を確認するスクリプト
public class Dropzone : MonoBehaviour {

    public int cointSt;
    public Table table;
 

    public void addStack(int value)
    {
        cointSt += 1;
    }
    public void reduceStack()
    {
        cointSt -= 1;
    }
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("test");
 

    }
    // Use this for initialization
    void Start () {
        cointSt = 0;
        table = GameObject.Find("GameController").GetComponent<Table>();
		
	}
	
	// Update is called once per frame
	void Update () {
        if(table.gameClear == true)
        {
            cointSt = 0;
        }
	}
}
