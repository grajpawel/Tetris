using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class startBG : MonoBehaviour {
	public static bool isPressed;

	// Use this for initialization
	void Start () {
		isPressed = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (isPressed){
			transform.DOMove(new Vector3(Screen.width, Screen.height/2, 0), 2);
			if (transform.position.x >= Screen.width/2.1f){
				SceneManager.LoadScene("Game");
				
			}
		}
	}
}
