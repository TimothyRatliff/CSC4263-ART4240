﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpPopUp : MonoBehaviour {

	PopUpMenu jumpShowing;
	private GameObject player;

	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player");
		jumpShowing = player.GetComponent<PopUpMenu> ();
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject == player) {
			jumpShowing.jumpShowing = true;
		}
	}

	void OnTriggerExit2D(Collider2D other)
	{
		if (other.gameObject == player) {
			jumpShowing.jumpShowing = false;
		}
	}
}
