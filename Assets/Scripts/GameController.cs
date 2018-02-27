using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {
	private GameObject currentGameObject;
	public GameObject prefab;
	bool hasSpawned = false;

	// Use this for initialization
	void Start () {
		CreateObject();
	}
	
	// Update is called once per frame
	void Update () {
		CurrentObjectMove();
	}

	public void CreateObject(){


		currentGameObject = Instantiate(prefab, new Vector3(-10, 60, 10), Quaternion.identity);
		currentGameObject.name = "test";

		for (int i = 0; i <= 3; i++){			
			GameObject currentGameObjectCube = currentGameObject.transform.GetChild(i).gameObject;
			currentGameObjectCube.name = "cube" + i;
			
		}
		//hasSpawned = false;

	}

	public void CurrentObjectMove(){
		Vector3 pos = currentGameObject.transform.position;
		Quaternion rot = currentGameObject.transform.rotation;
		
	
		if (Input.GetKeyDown(KeyCode.W)){
			hasSpawned = false;
			bool move = true;

			for (int i = 0; i <= 3; i++){			
			GameObject currentGameObjectCube = currentGameObject.transform.GetChild(i).gameObject;
			if (currentGameObjectCube.transform.position.z >= 24.8){
				move = false;
				}
			}
			if (move == true)
			pos.z += 5;
		}
		if (Input.GetKeyDown(KeyCode.S)){
			bool move = true;

			for (int i = 0; i <= 3; i++){			
			GameObject currentGameObjectCube = currentGameObject.transform.GetChild(i).gameObject;
			if (currentGameObjectCube.transform.position.z <= 0.2f){
				move = false;
				}
			}
			if (move == true)
			pos.z -= 5;
		}
		if (Input.GetKeyDown(KeyCode.A)){

			bool move = true;

			for (int i = 0; i <= 3; i++){			
			GameObject currentGameObjectCube = currentGameObject.transform.GetChild(i).gameObject;
			if (currentGameObjectCube.transform.position.x <= -24.8f){
				move = false;
				}
			}
			if (move == true)
			pos.x -= 5;
		}
		if (Input.GetKeyDown(KeyCode.D)){			
			bool move = true;

			for (int i = 0; i <= 3; i++){			
			GameObject currentGameObjectCube = currentGameObject.transform.GetChild(i).gameObject;
			if (currentGameObjectCube.transform.position.x >= -4.8f){
				move = false;
				}
			}
			if (move == true)
			pos.x += 5;
		}
		if (Input.GetKeyDown(KeyCode.UpArrow)){
			
			//transform.Rotate(new Vector3(90, 0, 0), Space.World);
			//transform.RotateAround(transform.position, transform.right, 90);			
		}
		if (Input.GetKeyDown(KeyCode.DownArrow)){
			currentGameObject.transform.Rotate(new Vector3(0, 90, 0), Space.World);

		}
		if (Input.GetKeyDown(KeyCode.LeftArrow)){
			currentGameObject.transform.Rotate(new Vector3(90, 0, 0), Space.World);		
		}
		if (Input.GetKeyDown(KeyCode.RightArrow)){
			currentGameObject.transform.Rotate(new Vector3(0, 0, 90), Space.World);

		}
		
		currentGameObject.transform.position = pos;
		
	}

	void OnCollisionEnter(Collision collision){
		Debug.Log("collision");

		if (collision.gameObject.name != "wallLeft" && collision.gameObject.name != "wallRight"){
			if (hasSpawned == false){

		currentGameObject.name = "xd";

		Rigidbody rigidbody = gameObject.GetComponent<Rigidbody>();
		rigidbody.useGravity = false;
		float y = currentGameObject.transform.position.y;
		int intY = Mathf.RoundToInt(y/2.5f);
		currentGameObject.transform.position = new Vector3(currentGameObject.transform.position.x, intY * 2.5f, currentGameObject.transform.position.z);
		CreateObject();
		hasSpawned = true;
	}
		


		}
			

	}
}
