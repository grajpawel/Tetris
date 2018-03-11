using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CameraScript : MonoBehaviour {

	private int camPos = 1;
	public Vector3 upPos;
	public Vector3 upRot;
	public Vector3 downPos;
	public Vector3 downRot;

	public Vector3 topPos;
	public Vector3 topRot;

	// Use this for initialization
	void Start () {
		//downPos = transform.position;
		//downRot = transform.rotation;
		
	}
	
	// Update is called once per frame
	void Update () {

		if (camPos == 1){
				transform.DOMove(upPos, 1);
				transform.DORotate(upRot, 1);
		} else if (camPos == 2) {
				transform.DOMove(downPos, 1);
				transform.DORotate(downRot, 1);
		}  else if (camPos == 3) {
				transform.DOMove(topPos, 1);
				transform.DORotate(topRot, 1);
		}
		
				if (Input.GetKeyDown(KeyCode.Q)){
					camPos++;
					if (camPos >= 4)
					camPos = 1;
			
			}

		}
	}

