using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class startButton : MonoBehaviour {

	// Use this for initialization

	public float Speed = 0.001f;
	private Button button;
	void Start () {
		button = GetComponent<Button>();

	}
	
	// Update is called once per frame
	void Update () {

		ColorBlock cb = button.colors;
        cb.normalColor = HSBColor.ToColor(new HSBColor( Mathf.PingPong(Time.time * Speed, 1), 1, 1));
		cb.highlightedColor = HSBColor.ToColor(new HSBColor( Mathf.PingPong(Time.time * Speed, 1), 1, 0.9f));
		cb.pressedColor = HSBColor.ToColor(new HSBColor( Mathf.PingPong(Time.time * Speed, 1), 1, 0.8f));
        button.colors = cb;

	}
	public void onClick(){
		startBG.isPressed = true;
	}
}
