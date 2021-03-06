﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour {

	public static int startHP = 100;	//player's starting hp
	public static int currentHP;        //player's hp after being damaged

    private GameObject healthtick;  //where the health loss sound comes from
    private AudioSource thud;

	private PlayerController playerMovement;
	private GameObject player;
    private GameObject Heart4;
    private GameObject Heart3;
    private GameObject Heart2;
    private GameObject Heart;
    private Animator playerAnim;
    public static GameObject pickup;
	PopUpMenu gameOver;


	void Start()
	{
		currentHP = startHP;
		player = GameObject.FindGameObjectWithTag ("Player");
        Heart4 = GameObject.Find("Heart4");
        Heart3 = GameObject.Find("Heart3");
        Heart2 = GameObject.Find("Heart2");
        Heart = GameObject.Find("Heart");
        pickup = GameObject.FindGameObjectWithTag("HealthPickUp");
        playerMovement = player.GetComponent <PlayerController>();
		gameOver = player.GetComponent<PopUpMenu>();
		playerAnim = player.GetComponent<Animator> ();

        //instanstiate healthtick audio
        healthtick = GameObject.Find("HealthTick");
        thud = healthtick.GetComponent<AudioSource>();
	}

	void Update()
	{

	}

    //this function detect when the player trigger a damage event 
    // **(See PlayerController OnTriggerEnter2D for health and heart restore)**
    void OnTriggerEnter2D(Collider2D other)
    {

        if (other.gameObject == player)
        {
            currentHP -= 25;

            //play health loss sound "healthtick"
            thud.Play();

			//Deactivates the heart on the HUD
            if (currentHP == 75)
            {
                Heart4.SetActive(false);
            }
            if (currentHP == 50)
            {
                Heart3.SetActive(false);
            }
            if (currentHP == 25)
            {
                Heart2.SetActive(false);
            }
            if (currentHP == 0)
            {
                Heart.SetActive(false);
                Death();
            }
        }
        
    }

	//this function disable the player movement script
	void Death ()
	{
		playerMovement.movements = false;
		playerAnim.enabled = false;
		gameOver.isDead = true;
	}
}
