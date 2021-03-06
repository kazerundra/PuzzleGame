﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Coin : MonoBehaviour {
	public bool drag = false;
	public bool clone =false;
    //分身
	public GameObject Clone;
    public GameObject CoinBox;
    public GameObject DropObject;
    //テーブル上にある同じ値のベースコイン
    public GameObject basecoin ;
    public Vector2 touchPosition;
    //コインの元の位置
    public Vector3 initialPosition;
    // コインの値
	public int value;
    //分身の順番
    public int coinOrder;
    //置く場所を確認するためのBOOL
    public bool dropAble;
    // where the coin is placed
    public string id;
    private Table table;
    // コインはテーブルの上か、置く場所の上か
    public bool ontable;
    public string coinposition;
    public GameObject touchParticle;
    public GameObject dragParticle;
    //戻せるコインの順番
    public int coinstchk;
    public GameObject drpzn;
    //分身を消す
    public bool destroy;
    //置く場所の外
    public bool outSideTable;

    public Sprite coinSprites;
    void OnMouseDrag(){

        if (table.gameClear == false && !ontable)
        {
            if (table.coinNumber[(coinOrder - 1)] > 0)
            {
                GetComponent<BoxCollider2D>().size = new Vector2(8.0f, 8.0f);
                drag = true;
                touchPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                transform.position = touchPosition;
               
                dragParticle.GetComponent<ParticleSystem>().Emit(1);
                dragParticle.transform.position = touchPosition;
            }
        }
           
	
    }
    private void TableCount()
    {
        table.coinNumber[coinOrder - 1] += 1;
        table.Coinnumber();
        EnableSprite(coinOrder - 1);
    }
    
    private void OnMouseDown ()
    {
        //置く場所いがいなら呼びません
        if (outSideTable) return;

        if (table.gameClear == false)
        {
            if (ontable)
            {
                Flyback();
                //Destroy(gameObject);
                table.ReduceNumber(coinposition, value, "plus");
                TableCount();
                table.WriteText();
            }
        }
            
      
    }

    private void Flyback()
    {
        destroy = true;
    }
    void OnMouseUp(){
        //置く場所いがいなら呼びません
        if (outSideTable) return;
        if (table.gameClear == false )
        {
            if(drag) Destroy(Clone);
            drag = false;
            clone = false;
            
            transform.position = initialPosition;
            //コライダーサイズを変更
            GetComponent<BoxCollider2D>().size = new Vector2(10.0f, 10.0f);
            //置く場所以内なら分身を出す
            if (DropObject != null && dropAble == true && !ontable)
            {
                touchPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

               // stackPlus = true;
                GameObject go;
                string coinclone = "Prefabs/CoinClone1";
                go = Instantiate(Resources.Load(coinclone)) as GameObject;
                go.GetComponent<Coin>().value = value;
                go.GetComponent<Coin>().coinOrder = coinOrder;
                go.GetComponent<Coin>().basecoin = gameObject;
               
                if (DropObject.GetComponent<Dropzone>().cointSt == 0)
                {
                    go.transform.position = DropObject.transform.position;
                }
                else
                {
                    go.transform.position = DropObject.transform.position + new Vector3(0f, (DropObject.GetComponent<Dropzone>().cointSt), 0);
                }
                go.GetComponent<SpriteRenderer>().sortingOrder = DropObject.GetComponent<Dropzone>().cointSt + 2;
                id = DropObject.gameObject.transform.name;
                table.ReduceNumber(id, value, "minus");
                go.GetComponent<Coin>().coinstchk = DropObject.GetComponent<Dropzone>().cointSt;
                DropObject = null;
              
                go.GetComponent<Coin>().coinposition = id;
                go.GetComponent<Coin>().ontable = true;
                go.GetComponent<Coin>().drpzn = GameObject.Find(id);

                string coinN = "Images/coin" + value;

                go.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>(coinN);
                touchParticle.transform.position = go.transform.position;
                touchParticle.GetComponent<ParticleSystem>().Emit(10);
                table.coinNumber[coinOrder - 1] -= 1;
                table.Coinnumber();
                EnableSprite(coinOrder - 1);
                table.WriteText();
                if(table.soundController.GetComponent<SoundController>().sfxOn ==true)
                {
                    table.soundController.GetComponent<SoundController>().PlayCoinset();
                }
                
            }
        }
   
       
	}
    private void Awake()
    {      
        dragParticle = GameObject.Find("Tparticlezz");
        touchParticle = GameObject.Find("Tparticle");
        coinOrder = value;
        table = GameObject.Find("GameController").GetComponent<Table>();
        string coinclone = "CoinClone" + coinOrder;
        basecoin = GameObject.Find(coinclone);

    }
    // Use this for initialization
    void Start () {
        
        ChangeSprite();       
        initialPosition = transform.position;
        touchPosition = transform.position;        
    }
   //最後のコインの場合、コインを隠す
    public void EnableSprite(int i)
    {
        if (table.coinNumber[i] == 0)
        {
            basecoin.GetComponent<SpriteRenderer>().enabled = false;
        }
        else
        {
            basecoin.GetComponent<SpriteRenderer>().enabled = true;
        }
    }
    //コインの分身のスプライトがドラグされたコインの値によって変更します
    public void ChangeSprite()
    {
       // string coinclone = "Prefabs/CoinClone1" ;
        Clone = Resources.Load("Prefabs/CoinClone1") as GameObject;
        string coinN = "Images/coin" + value;
        coinSprites = Resources.Load<Sprite>(coinN);
        GetComponent<SpriteRenderer>().sprite = coinSprites;
    }

    // Update is called once per frame
    void Update () {
       //コインを戻す時、コイン飛ぶのアニメション
        if (destroy)
        {
            float speed = 1000 * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, basecoin.transform.position, speed);
            if (transform.position == basecoin.transform.position)
            {

                Destroy(gameObject);
            }
        }
        if (ontable)
        {
            if (drpzn.GetComponent<Dropzone>().cointSt != coinstchk)
            {
                GetComponent<BoxCollider2D>().enabled = false;
            }
            else
            {
                GetComponent<BoxCollider2D>().enabled = true;
            }
        }
       
       
        if (table.gameClear == false)
        {
            if (drag == true)
            {
                //分身を出す
                if (!clone)
                {                    
                    clone = true;
                    Clone = Instantiate(Resources.Load("Prefabs/CoinClone1")) as GameObject;
                    Clone.GetComponent<Coin>().value = value;
                    string coinN = "Images/coin" + value;
                    Clone.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>(coinN);
                    Clone.transform.position = initialPosition;
                    Clone.GetComponent<SpriteRenderer>().sortingOrder = 1;
                    if (table.coinNumber[coinOrder - 1] == 1)
                    {
                        Clone.GetComponent<SpriteRenderer>().enabled = false;
                    }
                }
            }
        }
        else
        {
            if (ontable)
            {
                Destroy(gameObject);
            }
        }
           
    
		
	}
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (table.gameClear == false)
        {   //置く場所を決めるため
            if (collision.gameObject.tag == "DropZone")
            {
                dropAble = true;
                DropObject = collision.gameObject;
            }
        }
         
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (table.gameClear == false)
        {
            if (collision.gameObject.tag == "DropZone")
            {
                //Debug.Log("test2");
                dropAble = false;
                DropObject = null;

            }
        }
            
    }
  
}
