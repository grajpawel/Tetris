using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class GameController : MonoBehaviour {
	private GameObject currentGameObject;
	public GameObject prefab2x2;
	public GameObject prefabL;

	public GameObject prefabS;

	public GameObject prefabT;

	public GameObject prefabI;

	private Rigidbody currentRigidBody;
	private bool isLocked;

	public static float drag;


	public Vector3 pos;
	int cubesCreated;

	public static bool isPlaying;
	public static int score;

	public static string[] level1Cubes = new string[36];
	public static string[] level2Cubes = new string[36];
	public static string[] level3Cubes = new string[36];
	public static string[] level4Cubes = new string[36];
	public static string[] level5Cubes = new string[36];
	public static string[] level6Cubes = new string[36];

	public Text scoreText;
	public Text finalscoreText;
	public Text finalscoreHeadline;
	public Text highscoreHeadline;
	public Text highscoreText;


	private Vector3 startPos;


	private Vector3 finalscoreTextPos;
	private Vector3 finalscoreHeadlinePos;
	private Vector3 highscoreHeadlinePos;
	private Vector3 highscoreTextPos;




	// Use this for initialization
	void Start () {
		drag = 10;
		finalscoreHeadlinePos = finalscoreHeadline.transform.position;
		finalscoreTextPos = finalscoreText.transform.position;
		highscoreHeadlinePos = highscoreHeadline.transform.position;
		highscoreTextPos = highscoreText.transform.position;
		isPlaying = true;	
		isLocked = false;
		score = 0;
		cubesCreated = 0;

		startPos = scoreText.transform.position;
		scoreText.transform.position = new Vector3(-Screen.width/10, scoreText.transform.position.y, 0);

		for (int i = 0; i <= 35; i++){
			level1Cubes[i] = null;
			level2Cubes[i] = null;
			level3Cubes[i] = null;
			level4Cubes[i] = null;
			level5Cubes[i] = null;
			level6Cubes[i] = null;		
					
		}
		CreateObject();
	}
	
	// Update is called once per frame
	void Update () {
		CurrentObjectMove();
		scoreText.text = score.ToString();
		if (!GameController.isPlaying){

			Physics.gravity = Vector3.zero;			
			scoreText.transform.DOMove(new Vector3(-Screen.width/10, scoreText.transform.position.y, 0), 10);
			finalscoreText.text = score.ToString();
			if (!replayButton.isReplay){
			finalscoreText.transform.DOMove(new Vector3(Screen.width/2, Screen.height/1.45f, 0), 1);
			highscoreHeadline.transform.DOMove(new Vector3(Screen.width/2, Screen.height/2, 0), 1);
			finalscoreHeadline.transform.DOMove(new Vector3(Screen.width/2, Screen.height/1.1f, 0), 1);
			highscoreText.transform.DOMove(new Vector3(Screen.width/2, Screen.height/3f, 0), 1);
			}
			if (replayButton.isReplay){
			finalscoreText.transform.DOMove(finalscoreTextPos, 0.5f);
			highscoreHeadline.transform.DOMove(highscoreHeadlinePos, 0.5f);
			finalscoreHeadline.transform.DOMove(finalscoreHeadlinePos, 0.5f);
			highscoreText.transform.DOMove(highscoreTextPos, 0.5f);
			}



		} else {

			Physics.gravity = new Vector3(0, -50, 0);
			scoreText.transform.DOMove(startPos, 0.5f);
			int highscore = PlayerPrefs.GetInt("highscore", 0);
			if (score > highscore){
				PlayerPrefs.SetInt("highscore", score);
				highscoreText.text = score.ToString();
			} else {				
				highscoreText.text = highscore.ToString();

			}
		}
		
	}

	public void CreateObject(){
		Debug.Log("Cube created");
		if (GameController.isPlaying){
		isLocked = false;
		GameObject prefab;		

		switch(Random.Range(0,5)){
			case 0:
			prefab = prefab2x2;
			break;
			
			case 1:
			prefab = prefabI;
			break;

			case 2:
			prefab = prefabL;
			break;

			case 3:
			prefab = prefabS;
			break;

			case 4:
			prefab = prefabT;
			break;

			default:
			prefab = prefab2x2;
			break;

		}

		currentGameObject = Instantiate(prefab, new Vector3(-10, 70, 10), Quaternion.identity);
		currentGameObject.name = "test";
		Rigidbody rb = currentGameObject.GetComponent<Rigidbody>();
		rb.drag = drag;
		drag -= 0.1f;


		for (int i = 0; i <= 3; i++){			
			GameObject currentGameObjectCube = currentGameObject.transform.GetChild(i).gameObject;
			int cubeNum = cubesCreated + i;
			currentGameObjectCube.name = "cube" + cubeNum;
			
		}

		cubesCreated += 4;
		}


	}

	public void CurrentObjectMove(){
		pos = currentGameObject.transform.position;
		Quaternion rot = currentGameObject.transform.rotation;

		if (!isLocked){
		
	
		if (Input.GetKeyDown(KeyCode.W)){
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
			if (isPlaying){
			isLocked = true;
			score += 5;

			currentRigidBody = currentGameObject.GetComponent<Rigidbody>();
			currentRigidBody.drag = 1;
		}

						
		}
		if (Input.GetKeyDown(KeyCode.DownArrow)){

			currentGameObject.transform.Rotate(new Vector3(0, 90, 0), Space.World);
			checkPos();


			
		}
		if (Input.GetKeyDown(KeyCode.LeftArrow)){
			currentGameObject.transform.Rotate(new Vector3(90, 0, 0), Space.World);
			checkPos();		
		}
		if (Input.GetKeyDown(KeyCode.RightArrow)){
			currentGameObject.transform.Rotate(new Vector3(0, 0, 90), Space.World);
			checkPos();
		}

		}
		
		currentGameObject.transform.position = pos;
		
	}


	void checkPos(){
		for (int i = 0; i <= 3; i++){			
			GameObject currentGameObjectCube = currentGameObject.transform.GetChild(i).gameObject;
			if (currentGameObjectCube.transform.position.x >= -5.1f)
			pos.x -= 5;

			if (currentGameObjectCube.transform.position.x <= -25.1f)
			pos.x += 5;

			if (currentGameObjectCube.transform.position.z <= 0.0f)
			pos.z += 5;

			if (currentGameObjectCube.transform.position.z >= 25.1f)
			pos.z -= 5;
				
			}
	}

	

	void OnCollisionEnter(Collision collision){
		
			

	}

}
