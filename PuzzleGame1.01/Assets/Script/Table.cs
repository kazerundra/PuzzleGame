using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Table : MonoBehaviour {
    //public int[,] table = new int[,] {
    //    {0,0,0},
    //    {0,0,0},
    //    {0,0,0}
    //};
    //public int[,] table2 = new int[,] {
    //    {0,0,0,0},
    //    {0,0,0,0},
    //    {0,0,0,0},
    //    {0,0,0,0}
    //};

    public int[] row;
    public int[] collumn;
    public int[,] question = new int[,] {
        {0,0,0,0},
        {0,0,0,0}
    };
   
    public GameObject Row;
    public GameObject Collumn;

    //how much coin you can put
    public int norma;
    private int currentNorma;
    private int coinTotal;
	private int limit;
	private GameObject limitNumber;
    private GameObject normaNumber;
	private GameObject ok;
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
         {0,0,0,0},
        {0,0,0,0},
        {0,0,0,0},
        {0,0,0,0}
    };
  
       
    // stage cleared or not and what stage is now
    public GameObject saveSystem;
    // stage clear effect
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

    public GameObject x3;
    public GameObject x4;
    //maincamera
    public GameObject main;
    //loadc
    public GameObject loadc;
    private bool load;
    private float loadTime;
    //game clear sfx
    public GameObject soundController;
    //clear screen appear time;
    float clearScreenTime = 1.5f;
    float clear = 0;
    bool clearScreen;


    private void Check(int id1, int id2, GameObject dropzone, int value, string plusminus)
    {
        
        if (plusminus == "minus")
        {
            rowNumber[id1] -= value;
            colNumber[id2] -= value;
            normaCheck[id1, id2] += 1;

            
            dropzone.GetComponent<Dropzone>().addStack(value );
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
      
        dropzone = GameObject.Find(id);
        id1 = int.Parse(id.Substring(0,1));
        id2 = int.Parse(id.Substring(1, 1));
           
        Check(id1,id2,dropzone,value,plusminus);
        RowColAnim(id1, id2);

        for(int i =0; i <=3; i++)
        {
            for (int j = 0; j <= 3; j++)
            {
                if (normaCheck[i, j] > 0)
                {
                    coinTotal += 1;
                } else
                {
                    
                }
            }
  
        }
        //currentNorma = norma +coinTotal;
		currentNorma = 0 +coinTotal;
        coinTotal = 0;
        normaNumber.GetComponent<Text>().text = currentNorma.ToString();


    }
    private void Awake()
    {
       // Input.multiTouchEnabled = false;
        main = GameObject.Find("Main Camera");
        loadc = GameObject.Find("Load Camera");
       
        soundController = GameObject.Find("SoundController");
        
        coinRain = GameObject.Find("Rain");
  //      normaNumber = GameObject.Find("Norma");
		//limitNumber = GameObject.Find ("Limit");
		//ok = GameObject.Find ("Sep");
        gameClearSprite = GameObject.Find("Clear");
        gameClearSprite2 = GameObject.Find("Clear_S");
        //Row = GameObject.Find("Row");
        //Collumn = GameObject.Find("Col");
        coinCountText0 = GameObject.Find("coin1");
        coinCountText1 = GameObject.Find("coin2");
        coinCountText2 = GameObject.Find("coin3");
        coinCountText3 = GameObject.Find("coin4");
        coinCountText4 = GameObject.Find("coin5");
        saveSystem = GameObject.Find("SaveSystem");
    }

    void BlackScreenLoad()
    {
        main.GetComponent<Camera>().enabled = false;
        loadc.GetComponent<Camera>().enabled = true;


        loadTime += Time.deltaTime * 10;
        //Debug.Log(loadTime);
        if (loadTime >= 1.5)
        {
            load = false;
            loadTime = 0;
            loadc.GetComponent<Camera>().enabled = false;
            main.GetComponent<Camera>().enabled = true;
        }
    }

    // Use this for initialization
    void Start () {
        load = true;
       
        coinRain.gameObject.SetActive(false);
      
        gameClearSprite.gameObject.SetActive(false);
        gameClearSprite2.gameObject.SetActive(false);

        
    
        stageNumber = saveSystem.GetComponent<SaveSystem>().stage;
        
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
            coinCountText0.GetComponent<Text>().text = "x" +coinNumber[0].ToString();
        }
        if (coinNumber[1] == 0)
        {
            coinCountText1.GetComponent<Text>().text = "";
        }
        else
        {
            coinCountText1.GetComponent<Text>().text = "x" + coinNumber[1].ToString();
        }
        if (coinNumber[2] == 0)
        {
            coinCountText2.GetComponent<Text>().text = "";
        }
        else
        {
            coinCountText2.GetComponent<Text>().text = "x" + coinNumber[2].ToString();
        }
        if (coinNumber[3] == 0)
        {
            coinCountText3.GetComponent<Text>().text = "";
        }
        else
        {
            coinCountText3.GetComponent<Text>().text = "x" + coinNumber[3].ToString();
        }
        if (coinNumber[4] == 0)
        {
            coinCountText4.GetComponent<Text>().text = "";
        }
        else
        {
            coinCountText4.GetComponent<Text>().text = "x" + coinNumber[4].ToString();
        }

    }




    public void WriteText(){
        
		for (int i = 0; i < gameMode; i++) {
			question [0, i] = rowNumber[i];
            question[1, i] = colNumber[i];
        }
		
		Row.GetComponent<Child> ().q0.GetComponent<Text>().text = question [0,0].ToString();
		Row.GetComponent<Child> ().q1.GetComponent<Text>().text = question [0,1].ToString();
		Row.GetComponent<Child> ().q2.GetComponent<Text>().text = question [0,2].ToString();
        
        Collumn.GetComponent<Child> ().q0.GetComponent<Text>().text = question [1,0].ToString();
		Collumn.GetComponent<Child> ().q1.GetComponent<Text>().text = question [1,1].ToString();
		Collumn.GetComponent<Child> ().q2.GetComponent<Text>().text = question [1,2].ToString();
        if (gameMode == 4)
        {
            Row.GetComponent<Child>().q3.GetComponent<Text>().text = question[0, 3].ToString();
            Collumn.GetComponent<Child>().q3.GetComponent<Text>().text = question[1, 3].ToString();
        }
    }
    public void GameClear()
    {
        if(gameMode == 3)
        {
            for (int i = 0; i <= 2; i++)
            {
                for (int j = 0; j <= 2; j++)
                {
                    normaCheck[i, j] = 0;
                }

            }
        }
        else {
            for (int i = 0; i <= 3; i++)
            {
                for (int j = 0; j <= 3; j++)
                {
                    normaCheck[i, j] = 0;
                }

            }
        }
      
        rowNumber[0] = 9;
       
        //gameClearSprite.gameObject.SetActive(true);
        coinRain.gameObject.SetActive(true);

        clearScreen = true;
        
       

        
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
                x3.SetActive(true);
                x4.SetActive(false);
                gameMode = 3;
                Row = GameObject.Find("Row");
                Collumn = GameObject.Find("Col");
                normaNumber = GameObject.Find("Norma");
                limitNumber = GameObject.Find("Limit");
                stageText = GameObject.Find("Stage");
                ok = GameObject.Find("Sep");
                Row.GetComponent<Child>().FindChild();
                Collumn.GetComponent<Child>().FindChild();
                stageText.GetComponent<Text>().text = "" + stageNumber;
            }
            else if (str[0] == "4")
            {
                x4.SetActive(true);
                x3.SetActive(false);
                gameMode = 4;
                Row = GameObject.Find("Row");
                Collumn = GameObject.Find("Col");
                normaNumber = GameObject.Find("Norma");
                limitNumber = GameObject.Find("Limit");
                stageText = GameObject.Find("Stage");
                ok = GameObject.Find("Sep");
                Row.GetComponent<Child>().FindChild();
                Collumn.GetComponent<Child>().FindChild();
                stageText.GetComponent<Text>().text = "" + stageNumber;
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
		limit = norma;
		limitNumber.GetComponent<Text>().text = limit.ToString();
        currentNorma = 0;
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
    public void ResetStage()
    {
        
        SceneManager.LoadScene("Game");
    }
    public void NextStage()
    {
        load = true;
        if (stageNumber < 30)
        {
            stageNumber += 1;
            saveSystem.GetComponent<SaveSystem>().stage = stageNumber;
        }
        else
        {
            SceneManager.LoadScene("StageSelect");
        }
        
        StartCoroutine(ReadConfig());
        coinRain.gameObject.SetActive(false);
        stageText.GetComponent<Text>().text = "" + stageNumber;
        Row.GetComponent<Child>().q0.GetComponent<Animation>().Play();
        Row.GetComponent<Child>().q1.GetComponent<Animation>().Play();
        Row.GetComponent<Child>().q2.GetComponent<Animation>().Play();
        Collumn.GetComponent<Child>().q0.GetComponent<Animation>().Play();
        Collumn.GetComponent<Child>().q1.GetComponent<Animation>().Play();
        Collumn.GetComponent<Child>().q2.GetComponent<Animation>().Play();

    }
    public void RowColAnim(int id1, int id2)
    {
        Child rowc = Row.GetComponent<Child>();
        Child colc = Collumn.GetComponent<Child>();
        if (id1 == 0)
        {
            rowc.q0.GetComponent<Animation>().Play();
        } else if (id1 == 1)
        {
            rowc.q1.GetComponent<Animation>().Play();
        } else if (id1 == 2)
        {
            rowc.q2.GetComponent<Animation>().Play();
        }
        else if (id1 == 3)
        {
            rowc.q3.GetComponent<Animation>().Play();
        }
        if (id2 == 0)
        {
            colc.q0.GetComponent<Animation>().Play();
        }
        else if (id2 == 1)
        {
            colc.q1.GetComponent<Animation>().Play();
        }
        else if (id2 == 2)
        {
            colc.q2.GetComponent<Animation>().Play();
        }
        else if (id2 == 3)
        {
            colc.q3.GetComponent<Animation>().Play();
        }

    }
    // Update is called once per frame
    void Update () {
        if (clearScreen)
        {
            clear += Time.deltaTime;
            if(clear >= clearScreenTime)
            {
                clearScreen = false;
                clear += Time.deltaTime;
                gameClearSprite2.gameObject.SetActive(true);
                saveSystem.GetComponent<SaveSystem>().ClearedStage(stageNumber);
                gameClear = true;
                clear = 0;
            }
        }
        //Debug.Log(rowNumber[0]);
        //Debug.Log(colNumber[0]);
        //Debug.Log(coinNumber[0]);
        if (load)
        {
            BlackScreenLoad();
        }
     
         //WriteText();
       
		if (currentNorma == limit) 
		{
//			ok.GetComponent<Text>().color = Color.green;
//			ok.GetComponent<Text>().text = "OK";
//			normaNumber.gameObject.SetActive(false);
//			limitNumber.gameObject.SetActive(false);
			normaNumber.GetComponent<Text>().color = Color.green;
			limitNumber.GetComponent<Text>().color = Color.green;
		} 

		else if (currentNorma >= limit) 
		{
			normaNumber.GetComponent<Text>().color = Color.red;
			limitNumber.GetComponent<Text>().color = Color.black;
		}
        
		else 
		{ 
//			ok.GetComponent<Text>().color = Color.black;
//			ok.GetComponent<Text>().text = "/";
//			normaNumber.gameObject.SetActive(true);
//			limitNumber.gameObject.SetActive(true);
			normaNumber.GetComponent<Text>().color = Color.black; 
			limitNumber.GetComponent<Text>().color = Color.black;
		}

        if (!gameClear)
        {
            if(gameMode == 3)
            {
                if (rowNumber[0] == 0 && rowNumber[1] == 0 && rowNumber[2] == 0 && colNumber[0] == 0 && colNumber[1] == 0 && colNumber[2] == 0 && currentNorma == limit)
                {
                    GameClear();
                    soundController.GetComponent<AudioSource>().PlayOneShot(soundController.GetComponent<SoundController>().coinDrop);
                  
                    //soundController.GetComponent<AudioSource>().SetScheduledEndTime(AudioSettings.dspTime + (4.30f - 2.00f));

                }
            }
            else if (gameMode == 4)
            {
                if (rowNumber[0] == 0 && rowNumber[1] == 0 && rowNumber[2] == 0 && colNumber[0] == 0 && colNumber[1] == 0 && colNumber[2] == 0 && rowNumber[3] == 0 && colNumber[3] == 0 &&currentNorma == limit)
                {
                    GameClear();

                }
            }
           
        }
      
        
      
		
	}
}
