using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class Table : MonoBehaviour {
    public int[,] table = new int[,] {
        {0,0,0},
        {0,0,0},
        {0,0,0}
    };
    public int[] row;
    public int[] collumn;
    public int[,] question = new int[,] {
        {0,0,0},
        {0,0,0}
    };
    public GameObject Row;
    public GameObject Collumn;

    //how much coin you can put
    public int norma;
    private int currentNorma;
    private int coinTotal;
    private GameObject normaNumber;
    //how much coin type on the table
    public int coinType;

    //how much coin is left
    public GameObject coinCountText0;
    public GameObject coinCountText1;
    public GameObject coinCountText2;
    public GameObject coinCountText3;
    public GameObject coinCountText4;
    public int[] coinCount;
    public int[,] normaCheck = new int[,] {
        {0,0,0},
        {0,0,0},
        {0,0,0}
    };

    public GameObject saveSystem;
    public GameObject coinRain;
    public GameObject gameClearSprite2;
    public GameObject gameClearSprite;
    public bool gameClear;
    public int stageNumber;
    public int gameMode;
    public List<int> rowNumber;
    public List<int> colNumber;
    public List<int> coinNumber;
    public List<int> coinValue;
    //stage number text
    public GameObject stageText;
    // coin stack hyouji

    private void Check(int id1, int id2, GameObject dropzone, int value, string plusminus)
    {
        if (plusminus == "minus")
        {
            rowNumber[id1] -= value;
            colNumber[id2] -= value;
            normaCheck[id1, id2] += 1;
            dropzone.GetComponent<Dropzone>().addStack(value);
        }
        else
        {
            rowNumber[id1] += value;
            colNumber[id2] += value;
            normaCheck[id1, id2] -= 1;
            dropzone.GetComponent<Dropzone>().reduceStack();
        }
       
      
    }
    public int CoinTypeChk()
    {
        int total =0;
        for(int i = 0; i < 5; i++){
            if (coinNumber[i] > 0)
            {
               total++;
            }
        }
       
        return total;
    }

    public void ReduceNumber(string id, int value, string plusminus)
    {
        GameObject dropzone;
        int id1;
        int id2;
        if (id == "00")
        {
            dropzone = GameObject.Find(id);
            id1 = 0;
            id2 = 0;
            Check(id1,id2,dropzone,value,plusminus);

        } else if (id == "01")
        {
            dropzone = GameObject.Find(id);
            id1 = 0;
            id2 = 1;
            Check(id1, id2, dropzone, value, plusminus);

        }
          else if (id == "02")
        {
            dropzone = GameObject.Find(id);
            id1 = 0;
            id2 = 2;
            Check(id1, id2, dropzone, value, plusminus);
        }
          else if (id == "10")
        {
            dropzone = GameObject.Find(id);
            id1 = 1;
            id2 = 0;
            Check(id1, id2, dropzone, value, plusminus);
        }
          else if (id == "11")
        {
            dropzone = GameObject.Find(id);
            id1 = 1;
            id2 = 1;
            Check(id1, id2, dropzone, value, plusminus);
        }
        else if (id == "12")
        {
            dropzone = GameObject.Find(id);
            id1 = 1;
            id2 = 2;
            Check(id1, id2, dropzone, value, plusminus);
        }
        else if (id == "20")
        {
            dropzone = GameObject.Find(id);
            id1 = 2;
            id2 = 0;
            Check(id1, id2, dropzone, value, plusminus);
        }
        else if (id == "21")
        {
            dropzone = GameObject.Find(id);
            id1 = 2;
            id2 = 1;
            Check(id1, id2, dropzone, value, plusminus);
        }
        else if (id == "22")
        {
            dropzone = GameObject.Find(id);
            id1 = 2;
            id2 = 2;
            Check(id1, id2, dropzone, value, plusminus);
        }
        for(int i =0; i <=2; i++)
        {
            for (int j = 0; j <= 2; j++)
            {
                if (normaCheck[i, j] > 0)
                {
                    coinTotal -= 1;
                } else
                {
                    
                }
            }
  
        }
        currentNorma = norma +coinTotal;
        
        coinTotal = 0;
        normaNumber.GetComponent<Text>().text = currentNorma.ToString();


    }
    private void Awake()
    {
        stageText = GameObject.Find("Stage");
        coinRain = GameObject.Find("Rain");
        normaNumber = GameObject.Find("Norma");
        gameClearSprite = GameObject.Find("Clear");
        gameClearSprite2 = GameObject.Find("Clear_S");
        Row = GameObject.Find("Row");
        Collumn = GameObject.Find("Col");
        coinCountText0 = GameObject.Find("coin1");
        coinCountText1 = GameObject.Find("coin2");
        coinCountText2 = GameObject.Find("coin3");
        coinCountText3 = GameObject.Find("coin4");
        coinCountText4 = GameObject.Find("coin5");
        saveSystem = GameObject.Find("SaveSystem");
    }

    // Use this for initialization
    void Start () {
        //temporary for debug
        stageNumber = 1;
        stageText.GetComponent<Text>().text = "1-" + stageNumber;
        
        coinRain.gameObject.SetActive(false);
      
        gameClearSprite.gameObject.SetActive(false);
        gameClearSprite2.gameObject.SetActive(false);

        Row.GetComponent<Child> ().FindChild ();
		Collumn.GetComponent<Child> ().FindChild ();
    
        stageNumber = saveSystem.GetComponent<SaveSystem>().stage;
        stageText.GetComponent<Text>().text = ""+stageNumber;
        StartCoroutine(ReadConfig());
        //row = new int[3] { 1, 2, 3 };
        //collumn = new int[3] { 1, 2, 3};
       
        //coinCount = new int[5] { 1,1,1,0,0};
        //norma = 3;
   
    }
    public void Coinnumber()
    {        
        if(coinNumber[0] == 0)
        {
            coinCountText0.GetComponent<Text>().text = "";
        }else
        {
            coinCountText0.GetComponent<Text>().text = coinNumber[0].ToString();
        }
        if (coinNumber[1] == 0)
        {
            coinCountText1.GetComponent<Text>().text = "";
        }
        else
        {
            coinCountText1.GetComponent<Text>().text = coinNumber[1].ToString();
        }
        if (coinNumber[2] == 0)
        {
            coinCountText2.GetComponent<Text>().text = "";
        }
        else
        {
            coinCountText2.GetComponent<Text>().text = coinNumber[2].ToString();
        }
        if (coinNumber[3] == 0)
        {
            coinCountText3.GetComponent<Text>().text = "";
        }
        else
        {
            coinCountText3.GetComponent<Text>().text = coinNumber[3].ToString();
        }
        if (coinNumber[4] == 0)
        {
            coinCountText4.GetComponent<Text>().text = "";
        }
        else
        {
            coinCountText4.GetComponent<Text>().text = coinNumber[4].ToString();
        }

    }




    public void WriteText(){
		for (int i = 0; i < 3; i++) {
			question [0, i] = rowNumber[i];
		}
		for (int i = 0; i < 3; i++) {
			question [1, i] = colNumber[i];
		}
		Row.GetComponent<Child> ().q0.GetComponent<Text>().text = question [0,0].ToString();
		Row.GetComponent<Child> ().q1.GetComponent<Text>().text = question [0,1].ToString();
		Row.GetComponent<Child> ().q2.GetComponent<Text>().text = question [0,2].ToString();
		Collumn.GetComponent<Child> ().q0.GetComponent<Text>().text = question [1,0].ToString();
		Collumn.GetComponent<Child> ().q1.GetComponent<Text>().text = question [1,1].ToString();
		Collumn.GetComponent<Child> ().q2.GetComponent<Text>().text = question [1,2].ToString();
	}
    public void GameClear()
    {
        for (int i = 0; i <= 2; i++)
        {
            for (int j = 0; j <= 2; j++)
            {
                normaCheck[i, j] = 0;
            }

        }
        rowNumber[0] = 9;
        if(currentNorma== 0)
        {
            gameClearSprite2.gameObject.SetActive(true);
        } else
        {
            gameClearSprite.gameObject.SetActive(true);
        }
        //gameClearSprite.gameObject.SetActive(true);
        coinRain.gameObject.SetActive(true);
        gameClear = true;
    }


    IEnumerator ReadConfig()
    {
        //while (GetComponent<coinPosition>().ready == false)
        //{
        //    yield return null;
        //}
        rowNumber.Clear();
        colNumber.Clear();
        coinNumber.Clear();
        coinValue.Clear();
        string line;
        

        //filename to be read
        string filename = stageNumber + ".txt";
        //filepath in the project assets
        string path = "";



#if UNITY_EDITOR
        path = Application.streamingAssetsPath + "/stages/" + filename;
        FileStream stream = new FileStream(path, FileMode.Open, FileAccess.Read);
        if (stream == null) { Debug.Log("ERROR"); }
        System.IO.TextReader file = new System.IO.StreamReader(stream);

#elif UNITY_ANDROID

    		path = "jar:file://" + Application.dataPath + "!/assets" + "/stages/" + filename;
    		WWW www = new WWW(path);
    		yield return www;
    		System.IO.TextReader file = new StringReader(www.text);

#endif

        while ((line = file.ReadLine()) != null)
        {
            //Debug.Log(line);

            List<string> row = new List<string>();

            string[] str = line.Split(',');
            //if 3x3
            if (str[0] == "3")
            {
                gameMode = 3;
            }
            else if (str[0] == "rows")
            {
                for (int i = 1; i < str.Length; i++)
                {
                    rowNumber.Add(int.Parse(str[i]));
                }

            }
            else if (str[0] == "cols")
            {
                for (int i = 1; i < str.Length; i++)
                {
                    colNumber.Add(int.Parse(str[i]));
                }

            }
            else if (str[0] == "norma")
            {
                norma = int.Parse(str[1]);
            }
            else if (str[0] == "value")
            {
                for (int i = 1; i < str.Length; i++)
                {
                    coinValue.Add(int.Parse(str[i]));
                }

                for (int i = str.Length; i < 6; i++)
                {
                    coinValue.Add(0);

                }
            }
            else if (str[0] == "coins")
            {
                for (int i = 1; i < str.Length; i++)
                {
                    coinNumber.Add(int.Parse(str[i]));
                }
                
                for (int i = str.Length; i < 6; i++)
                {
                    coinNumber.Add(0);

                }
            }
        }
        file.Close();
        currentNorma = norma;
        normaNumber.GetComponent<Text>().text = currentNorma.ToString();

        WriteText();

        //how much coin left temporary
        Coinnumber();
        coinType = CoinTypeChk();
        GetComponent<coinPosition>().ChangeCoinLayout();
        gameClearSprite.gameObject.SetActive(false);
        gameClearSprite2.gameObject.SetActive(false);
        gameClear = false;
        //for (int i =0; i < row.Length; i++)
        //{
        //    row[i] = rowNumber[i];
        //    collumn[i] = colNumber[i];
        //}
        //for (int i =0; i < coinCount.Length; i++)
        //{
        //    coinCount[i] = coinNumber[i];
        //}



        yield return null;

    }
    public void NextStage()
    {
        stageNumber += 1;
        StartCoroutine(ReadConfig());
        coinRain.gameObject.SetActive(false);
        stageText.GetComponent<Text>().text = "" + stageNumber;

    }
    // Update is called once per frame
    void Update () {
        //Debug.Log(rowNumber[0]);
        //Debug.Log(colNumber[0]);
        //Debug.Log(coinNumber[0]);

     
         WriteText();
       
        if (currentNorma == 0)
        {
            normaNumber.GetComponent<Text>().color = Color.red;
        }
        else { normaNumber.GetComponent<Text>().color = Color.black; }
        if (!gameClear)
        {
            if (rowNumber[0] == 0 && rowNumber[1] == 0 && rowNumber[2] == 0 && colNumber[0] == 0 && colNumber[1] == 0 && colNumber[2] == 0)
            {
                GameClear();

            }
        }
      
        
      
		
	}
}
