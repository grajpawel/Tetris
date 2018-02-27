using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CubeMove : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 pos = transform.position;
		Quaternion rot = transform.rotation;
		if (Input.GetKeyDown(KeyCode.W)){
			pos.z += 5;
		}
		if (Input.GetKeyDown(KeyCode.S)){
			pos.z -= 5;
		}
		if (Input.GetKeyDown(KeyCode.A)){
			pos.x -= 5;
		}
		if (Input.GetKeyDown(KeyCode.D)){
			pos.x += 5;
		}
		if (Input.GetKeyDown(KeyCode.UpArrow)){
			
			//transform.Rotate(new Vector3(90, 0, 0), Space.World);
			//transform.RotateAround(transform.position, transform.right, 90);			
		}
		if (Input.GetKeyDown(KeyCode.DownArrow)){
			transform.Rotate(new Vector3(0, 90, 0), Space.World);

		}
		if (Input.GetKeyDown(KeyCode.LeftArrow)){
			transform.Rotate(new Vector3(90, 0, 0), Space.World);		
		}
		if (Input.GetKeyDown(KeyCode.RightArrow)){
			transform.Rotate(new Vector3(0, 0, 90), Space.World);

		}
		transform.position = pos;
		
	}

	public void CurrentObjectMove(){
		Vector3 pos = gameObject.transform.position;
		Quaternion rot = gameObject.transform.rotation;
		if (Input.GetKeyDown(KeyCode.W)){
			pos.z += 5;
		}
		if (Input.GetKeyDown(KeyCode.S)){
			pos.z -= 5;
		}
		if (Input.GetKeyDown(KeyCode.A)){
			pos.x -= 5;
		}
		if (Input.GetKeyDown(KeyCode.D)){
			pos.x += 5;
		}
		if (Input.GetKeyDown(KeyCode.UpArrow)){
			
			//transform.Rotate(new Vector3(90, 0, 0), Space.World);
			//transform.RotateAround(transform.position, transform.right, 90);			
		}
		if (Input.GetKeyDown(KeyCode.DownArrow)){
			gameObject.transform.Rotate(new Vector3(0, 90, 0), Space.World);

		}
		if (Input.GetKeyDown(KeyCode.LeftArrow)){
			gameObject.transform.Rotate(new Vector3(90, 0, 0), Space.World);		
		}
		if (Input.GetKeyDown(KeyCode.RightArrow)){
			gameObject.transform.Rotate(new Vector3(0, 0, 90), Space.World);

		}
		gameObject.transform.position = pos;
		
	}
	
}
