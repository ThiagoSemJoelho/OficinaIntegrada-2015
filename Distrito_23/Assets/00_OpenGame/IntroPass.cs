﻿using UnityEngine;
using System.Collections;

public class IntroPass : MonoBehaviour {

	public GameObject Fade;

	void Start () {
		PlayerPrefs.SetString("hasTakenBag", "false");
		PlayerPrefs.SetString("HasKey?", "false");
	}

	void Update (){
		if(Input.anyKey)
			StartCoroutine (helloworld());
	}
		
	IEnumerator helloworld(){
		Instantiate (Fade);
		yield return new WaitForSeconds (3);
		Application.LoadLevel (1);
	}

}
