using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coinPosition : MonoBehaviour {
    public bool ready =false;



    private void DeactivateCoin(int j)
    {
        for (int i = j; i < 5; i++)
        {
            coin[i].gameObject.SetActive(false);
        }
        //for (int i = j-1; i > 0; i--)
        //{
        //    coin[i].gameObject.SetActive(true);
        //    coin[i].GetComponent<SpriteRenderer>().enabled = true;
        //} 
        for (int i = 0; i < j; i++)
        {
            coin[i].gameObject.SetActive(true);
            coin[i].GetComponent<SpriteRenderer>().enabled = true;
        }
    }


    Table tableScript;
    public GameObject[] coin;
    public void ChangeCoinLayout()
    {
        if (!ready)
        {
            coin = new GameObject[5];
            coin[0] = GameObject.Find("CoinClone1");
            coin[1] = GameObject.Find("CoinClone2");
            coin[2] = GameObject.Find("CoinClone3");
            coin[3] = GameObject.Find("CoinClone4");
            coin[4] = GameObject.Find("CoinClone5");
            ready = true;
        }
       
       
        tableScript = GetComponent<Table>();
        if (tableScript.coinType == 1)
        {
            coin[0].transform.position = new Vector2(85, 55);
            tableScript.coinCountText0.transform.position = new Vector2(85, 70);
           
            DeactivateCoin(tableScript.coinType);
           
        }
        else if (tableScript.coinType == 2)
        {
            coin[0].transform.position = new Vector2(60, 55);
            tableScript.coinCountText0.transform.position = new Vector2(60, 70);
            coin[1].transform.position = new Vector2(110, 55);
            tableScript.coinCountText1.transform.position = new Vector2(110, 70);
            DeactivateCoin(tableScript.coinType);
        }
        else if (tableScript.coinType == 3)
        {
            coin[0].transform.position = new Vector2(40, 55);
            tableScript.coinCountText0.transform.position = new Vector2(40, 70);
            coin[1].transform.position = new Vector2(85, 55);
            tableScript.coinCountText1.transform.position = new Vector2(85, 70);
            coin[2].transform.position = new Vector2(130, 55);
            tableScript.coinCountText2.transform.position = new Vector2(130, 70);
            DeactivateCoin(tableScript.coinType);
        }
        else if (tableScript.coinType == 4)
        {
            coin[0].transform.position = new Vector2(35, 55);
            tableScript.coinCountText0.transform.position = new Vector2(35, 70);
            coin[1].transform.position = new Vector2(70, 55);
            tableScript.coinCountText1.transform.position = new Vector2(70, 70);
            coin[2].transform.position = new Vector2(105, 55);
            tableScript.coinCountText2.transform.position = new Vector2(105, 70);
            coin[3].transform.position = new Vector2(140, 55);
            tableScript.coinCountText3.transform.position = new Vector2(140, 70);
            DeactivateCoin(tableScript.coinType);
      

        }
        else if (tableScript.coinType == 5)
        {

            coin[0].transform.position = new Vector2(35, 35);
            tableScript.coinCountText0.transform.position = new Vector2(35, 50);
         
            coin[1].transform.position = new Vector2(60, 60);
            tableScript.coinCountText1.transform.position = new Vector2(60, 75);
            coin[2].transform.position = new Vector2(85, 35);
            tableScript.coinCountText2.transform.position = new Vector2(85, 50);
            coin[3].transform.position = new Vector2(110, 60);
            tableScript.coinCountText3.transform.position = new Vector2(110, 75);
            coin[4].transform.position = new Vector2(135, 35);
            tableScript.coinCountText4.transform.position = new Vector2(135, 50);
            DeactivateCoin(tableScript.coinType);
        }
        for(int i =0;i <5; i++)
        {
            if (coin[i] != null)
            {
                coin[i].GetComponent<Coin>().initialPosition = coin[i].transform.position;
            }
        }

        for (int i = 0; i < 5; i++)
        {
            //Debug.Log(tableScript.GetComponent<Table>().coinValue[i]);
            coin[i].GetComponent<Coin>().value = tableScript.GetComponent<Table>().coinValue[i];
            coin[i].GetComponent<Coin>().ChangeSprite();
        }

    }

    // Use this for initialization
    void Start () {
       // ready = false;
        
       
        
    }
	
	// Update is called once per frame
	void Update () {
        

    }
}
