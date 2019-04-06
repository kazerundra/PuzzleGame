using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveclick : MonoBehaviour {
	float speed = 10f;
	//Rigidbody2D rigid;
	KeyCode moveUp = KeyCode.UpArrow;
	KeyCode moveDown = KeyCode.DownArrow;
	KeyCode moveLeft = KeyCode.LeftArrow;
	KeyCode moveRight = KeyCode.RightArrow;
	bool movestatus = false;
	Vector3 Target;
	private Plane plane = new Plane(Vector3.up, Vector3.zero);

	// Use this for initialization
	void Start () {
		//rigid = this.GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonUp(0)) {
			movestatus = true;
			Target = Input.mousePosition;
			Target.z= transform.position.z - Camera.main.transform.position.z;
			Target = Camera.main.ScreenToWorldPoint(Target);
		}
	
//		if (Input.GetKey(moveUp))
//			//GetComponent<Rigidbody2D>().AddForce(Vector2.up* speed);
//
//		if (Input.GetKey(moveDown))
//			//GetComponent<Rigidbody2D>().AddForce(-Vector2.up * speed);
//
//		if (Input.GetKey (moveLeft))
//			//GetComponent<Rigidbody2D> ().AddForce (-Vector2.right * speed);
//
//		if (Input.GetKey (moveRight))
			//GetComponent<Rigidbody2D> ().AddForce (Vector2.right * speed);
		
	}
	void FixedUpdate(){
		if(movestatus){

			Vector2 currentposition = transform.position;
			Vector2 Target2;
			Target2.x = Target.x;
			Target2.y = Target.y;
			Vector2 diff = Target2- currentposition;

			Vector2 movement = diff.normalized * speed * Time.deltaTime;
			if (movement.magnitude > diff.magnitude) {
				movement = diff;
				movestatus = false;
			}				
			GetComponent<CharacterController> ().Move (movement);

		}
	}
}
