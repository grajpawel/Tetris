using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class BGScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		if (!GameController.isPlaying){
			transform.DOMove(new Vector3(Screen.width/2, Screen.height/2, 0), 1);
		} else {
			transform.DOMove(new Vector3(Screen.width*1.6f, Screen.height/2, 0), 2);

		}
	}
}
