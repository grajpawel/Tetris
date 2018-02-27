using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CameraScript : MonoBehaviour {

	private bool isSide = true;
	public Vector3 upPos;
	public Vector3 upRot;
	public Vector3 downPos;
	public Vector3 downRot;

	// Use this for initialization
	void Start () {
		//downPos = transform.position;
		//downRot = transform.rotation;
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Q)){
			if (isSide == true){
				transform.DOMove(upPos, 1);
				transform.DORotate(upRot, 1);
				isSide = false;
			} else {
				transform.DOMove(downPos, 1);
				transform.DORotate(downRot, 1);
				isSide = true;
			}

		}
	}
}
