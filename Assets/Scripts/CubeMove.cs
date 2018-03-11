using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CubeMove : MonoBehaviour {
	private Rigidbody cubeRigidbody;
	

	public float gameTime;


	// Use this for initialization
	void Start () {
		gameTime = 0;
			cubeRigidbody = gameObject.GetComponent<Rigidbody>();

	}
	
	// Update is called once per frame
	void Update () {

		if (gameObject.GetComponent<Rigidbody>().velocity.y == 0){
		int intY = Mathf.RoundToInt(gameObject.transform.position.y/2.5f);
		int intX = Mathf.RoundToInt(gameObject.transform.position.x/2.5f);
		int intZ = Mathf.RoundToInt(gameObject.transform.position.z/2.5f);

		transform.position = new Vector3(intX * 2.5f, intY * 2.5f, intZ * 2.5f);
	}

	

		gameTime += Time.deltaTime;
		if (cubeRigidbody.velocity.y >= -0.1f && gameTime >= 1 && cubeRigidbody.velocity.y <= 0.1f){
		

		if (gameObject.name == "test"){


		cubeRigidbody.useGravity = true;
		int intY = Mathf.RoundToInt(gameObject.transform.position.y/2.5f);
		int intX = Mathf.RoundToInt(gameObject.transform.position.x/2.5f);
		int intZ = Mathf.RoundToInt(gameObject.transform.position.z/2.5f);

		gameObject.transform.position = new Vector3(intX * 2.5f, intY * 2.5f, intZ * 2.5f);
		GameObject plane = GameObject.Find("Plane");
		plane.GetComponent<GameController>().CreateObject();

		




		for (int i = 0; i <= 3; i++){			
			GameObject currentGameObjectCube = gameObject.transform.GetChild(i).gameObject;
			Vector3 currentCubePos = currentGameObjectCube.transform.position;
			if (currentCubePos.y >= 45){
				GameController.isPlaying = false;
			}
			int cubePosY = Mathf.RoundToInt(currentGameObjectCube.transform.position.y/2.5f);
			int cubePosX = Mathf.RoundToInt(currentGameObjectCube.transform.position.x/2.5f);
			int cubePosZ = Mathf.RoundToInt(currentGameObjectCube.transform.position.z/2.5f);

			//Debug.Log("pos: " + cubePosX + " : "+ cubePosY + " : "+ cubePosZ);

			switch (cubePosY){

				case 1:
				placeArrayFill(GameController.level1Cubes, currentGameObjectCube.name, cubePosX, cubePosZ);
				//Debug.Log("Level1");
				break;

				
				case 3:
				//Debug.Log("Level2");
				placeArrayFill(GameController.level2Cubes, currentGameObjectCube.name, cubePosX, cubePosZ);
				break;

				case 5:
				//Debug.Log("Level2");
				placeArrayFill(GameController.level3Cubes, currentGameObjectCube.name, cubePosX, cubePosZ);
				break;

				case 7:
				//Debug.Log("Level2");
				placeArrayFill(GameController.level4Cubes, currentGameObjectCube.name, cubePosX, cubePosZ);
				break;

				case 9:
				//Debug.Log("Level2");
				placeArrayFill(GameController.level5Cubes, currentGameObjectCube.name, cubePosX, cubePosZ);
				break;

				case 11:
				//Debug.Log("Level2");
				placeArrayFill(GameController.level6Cubes, currentGameObjectCube.name, cubePosX, cubePosZ);
				break;


				
			}			
		}
					
		//Debug.Log(GameController.level1Cubes[35]);

		

		

		gameObject.name = "xd";
		
		
		}

			
	


	/*int cubeNum = GameObject.FindGameObjectsWithTag("Cube").Length;
		for (int i = 0; i <= cubeNum; i++){
			string cubeString = "cube" + i.ToString();
			Debug.Log(cubeString);

			GameObject cube = GameObject.Find(cubeString);	


			if (cube != null){	
				Debug.Log("working");

			int cubePosY = Mathf.RoundToInt(cube.transform.position.y/2.5f);
			int cubePosX = Mathf.RoundToInt(cube.transform.position.x/2.5f);
			int cubePosZ = Mathf.RoundToInt(cube.transform.position.z/2.5f);

			//Debug.Log("pos: " + cubePosX + " : "+ cubePosY + " : "+ cubePosZ);

			switch (cubePosY){

				case 1:
				placeArrayFill(GameController.level1Cubes, cube.name, cubePosX, cubePosZ);
				//Debug.Log("Level1");
				break;

				
				case 3:
				//Debug.Log("Level2");
				placeArrayFill(GameController.level2Cubes, cube.name, cubePosX, cubePosZ);
				break;

				case 5:
				//Debug.Log("Level2");
				placeArrayFill(GameController.level3Cubes, cube.name, cubePosX, cubePosZ);
				break;

				case 7:
				//Debug.Log("Level2");
				placeArrayFill(GameController.level4Cubes, cube.name, cubePosX, cubePosZ);
				break;

				case 9:
				//Debug.Log("Level2");
				placeArrayFill(GameController.level5Cubes, cube.name, cubePosX, cubePosZ);
				break;

				case 11:
				//Debug.Log("Level2");
				placeArrayFill(GameController.level6Cubes, cube.name, cubePosX, cubePosZ);
				break;
			
			
			}
			}
			}/* */
		}		
	}
	

	void OnCollisionEnter(Collision collision){
		if (collision.gameObject.name != "wallLeft" && collision.gameObject.name != "wallRight"){

		}
			

	}

	public void placeArrayFill(string[] arrayName, string cubeName, int cubeX, int cubeZ){

		switch (cubeX){
					case -10:
					switch (cubeZ){
						case 10:
						arrayName[0] = cubeName;
						break;
						case 8:
						arrayName[6] = cubeName;
						break;
						case 6:
						arrayName[12] = cubeName;
						break;
						case 4:
						arrayName[18] = cubeName;
						break;
						case 2:
						arrayName[24] = cubeName;
						break;
						case 0:
						arrayName[30] = cubeName;
						break;
					}
					break;

					case -8:
					switch (cubeZ){
						case 10:
						arrayName[1] = cubeName;
						break;
						case 8:
						arrayName[7] = cubeName;
						break;
						case 6:
						arrayName[13] = cubeName;
						break;
						case 4:
						arrayName[19] = cubeName;
						break;
						case 2:
						arrayName[25] = cubeName;
						break;
						case 0:
						arrayName[31] = cubeName;
						break;
					}

					break;


					case -6:
					switch (cubeZ){
						case 10:
						arrayName[2] = cubeName;
						break;
						case 8:
						arrayName[8] = cubeName;
						break;
						case 6:
						arrayName[14] = cubeName;
						break;
						case 4:
						arrayName[20] = cubeName;
						break;
						case 2:
						arrayName[26] = cubeName;
						break;
						case 0:
						arrayName[32] = cubeName;
						break;
					}

					break;


					case -4:
					switch (cubeZ){
						case 10:
						arrayName[3] = cubeName;
						break;
						case 8:
						arrayName[9] = cubeName;
						break;
						case 6:
						arrayName[15] = cubeName;
						break;
						case 4:
						arrayName[21] = cubeName;
						break;
						case 2:
						arrayName[27] = cubeName;
						break;
						case 0:
						arrayName[33] = cubeName;
						break;
					}

					break;


					case -2:
					switch (cubeZ){
						case 10:
						arrayName[4] = cubeName;
						break;
						case 8:
						arrayName[10] = cubeName;
						break;
						case 6:
						arrayName[16] = cubeName;
						break;
						case 4:
						arrayName[22] = cubeName;
						break;
						case 2:
						arrayName[28] = cubeName;
						break;
						case 0:
						arrayName[34] = cubeName;
						break;
					}

					break;



					case 0:
					switch (cubeZ){
						case 10:
						arrayName[5] = cubeName;
						break;
						case 8:
						arrayName[11] = cubeName;
						break;
						case 6:
						arrayName[17] = cubeName;
						break;
						case 4:
						arrayName[23] = cubeName;
						break;
						case 2:
						arrayName[29] = cubeName;
						break;
						case 0:
						arrayName[35] = cubeName;
						break;
					}

					break;					


				}

		bool isFull = true;
		for (int i = 0; i <= 35; i++){
			if (arrayName[i] == null){
				Debug.Log("false: " + i);
				isFull = false;
			}					
		}

		if (isFull == true){
			//GameObject.Find("Plane").transform.position += new Vector3 (0, 5, 0);
			//Debug.Log("true");
			GameController.score += 100;
			for (int i = 0; i <= 35; i++){
				Destroy(GameObject.Find(arrayName[i]));
				arrayName[i] = null;
				if (arrayName == GameController.level1Cubes){
					arrayName[i] = GameController.level2Cubes[i];
				} else if (arrayName == GameController.level2Cubes){
					arrayName[i] = GameController.level3Cubes[i];
				} else if (arrayName == GameController.level3Cubes){
					arrayName[i] = GameController.level4Cubes[i];
				} else if (arrayName == GameController.level4Cubes){
					arrayName[i] = GameController.level5Cubes[i];
				} else if (arrayName == GameController.level5Cubes){
					arrayName[i] = GameController.level6Cubes[i];
				}
				

			}
			
		
		}



	}
					
	
}
