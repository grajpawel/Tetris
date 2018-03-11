using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.SceneManagement;


public class replayButton : MonoBehaviour {

	public static bool isReplay;

	// Use this for initialization
	void Start () {
		isReplay = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (!GameController.isPlaying && isReplay == false){
			transform.DOMove(new Vector3(Screen.width/2, Screen.height/7, 0), 1);
		} else {
						transform.DOMove(new Vector3(Screen.width/2, -Screen.height/5, 0), 1);
						if (transform.position.y <= -Screen.height/6 && isReplay){
							SceneManager.LoadScene("Game");
						}
		}
	}

	public void OnClick(){
		isReplay = true;

	}
}
