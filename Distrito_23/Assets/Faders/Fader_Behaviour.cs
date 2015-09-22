﻿using UnityEngine;
using System.Collections;

public class Fader_Behaviour : MonoBehaviour {

	public float fadeSpeed = 1.23f;
	public string FadeTo;
	public GameObject instantiateNext;
	
	
	void Awake () {

		if(PlayerPrefs.HasKey(Application.loadedLevelName + "x")){
			float positionX = PlayerPrefs.GetFloat (Application.loadedLevelName + "x");
			float positionY = PlayerPrefs.GetFloat (Application.loadedLevelName + "y");
			GameObject bg = GameObject.FindGameObjectWithTag("Background");
			bg.transform.position = new Vector2(positionX, positionY);
		}

		guiTexture.pixelInset = new Rect(0f, 0f, Screen.width, Screen.height);
		if (FadeTo == "Black") {
			guiTexture.color = Color.clear;
		} else if (FadeTo == "Clear") {
			guiTexture.color = Color.black;
		}
	}
	
	
	void Update () {
		if (FadeTo == "Black") {
			FadeToBlack();
		} else if (FadeTo == "Clear") {
			FadeToClear();
		}

	}
	
	
	void FadeToClear () {
		guiTexture.color = Color.Lerp(guiTexture.color, Color.clear, fadeSpeed * Time.deltaTime);

		if (guiTexture.color.a <= 0.0005f) {
			guiTexture.color = Color.clear;
			guiTexture.enabled = false;
			Destroy(gameObject);
		}
	}
	
	
	void FadeToBlack () {

		guiTexture.enabled = true;
		guiTexture.color = Color.Lerp (guiTexture.color, Color.black, fadeSpeed * Time.deltaTime);

		if (guiTexture.color.a >= 0.9999f) {
			guiTexture.color = Color.black;
			if(instantiateNext != null)
				Instantiate(instantiateNext);
			Destroy(gameObject);
		}
	}	
}
