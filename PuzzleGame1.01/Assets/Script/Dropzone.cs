using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dropzone : MonoBehaviour {
    public List<int> coinStack;
    public int cointSt;
    public Table table;

    public void addStack(int value)
    {
        coinStack.Add(value);
       // Debug.Log(coinStack);
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
        coinStack = new List<int>();
        cointSt = 0;
        table = GameObject.Find("GameController").GetComponent<Table>();
		
	}
	
	// Update is called once per frame
	void Update () {
        if(table.gameClear == true)
        {
            cointSt = 0;
            coinStack.Clear();
        }
	}
}
