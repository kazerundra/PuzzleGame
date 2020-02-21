using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextPage : MonoBehaviour {
	public GameObject left,right;
	public int maxPage;
	public GameObject page;
	public int currentPage=0;
	private string dir;
	float x;
	Vector2 nextPos;
	bool moving;
	public void Start(){		
		//page = new GameObject[maxPage];
	}


	public void flipRight()
	{
		if (moving)
			return;
		currentPage += 1;
		if (currentPage == maxPage) {
			right.SetActive (false);
		} else {
			left.SetActive(true);
		}
		dir ="right";

		if (dir == "left") {
			x = 700f;
		} else {
			x = -700f;
		}
		nextPos = new Vector2(page.transform.localPosition.x+x,0f);
		moving = true;

	}
	public void flipLeft()
	{
		if (moving)
			return;
		currentPage -= 1;
		if (currentPage == 0) {
			left.SetActive (false);
		} else {
			right.SetActive (true);
		}
		dir ="left";
		if (dir == "left") {
			x = 700f;
		} else {
			x = -700f;
		}
		nextPos = new Vector2(page.transform.localPosition.x+x,0f);
		moving = true;
	}
	void move(){
		if (dir == "left") {
			if (page.transform.localPosition.x>= nextPos.x) {
				moving = false;
			}
		} else {
			if (page.transform.localPosition.x<= nextPos.x)
				moving = false;
		}

		if (moving) {
			page.transform.localPosition = Vector2.MoveTowards (page.transform.localPosition, nextPos, 1000f* Time.deltaTime); 
			
		}

	}
	void Update(){
		move ();
	}

}
