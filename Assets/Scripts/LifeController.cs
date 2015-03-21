﻿// README
// 
// after been attacked
// public void loselife()

using UnityEngine;
using System.Collections;

public class LifeController : MonoBehaviour {
	public int lifenumber;
	public float delta;
	private GameObject danger;
	private GameObject enemy;
	public int sstatus;
	private int timer;

	void Start(){
		danger = GameObject.Find("Dangerous");
		danger.SetActive (false);

		enemy = GameObject.Find("Enemy");
		sstatus = enemy.GetComponent<EnemyAppear> ().status;
		timer = 0;
	}

	void Update(){
		sstatus = enemy.GetComponent<EnemyAppear> ().status;
		//been hit
		if (sstatus != 0) {
			timer++;
			if (timer == 500) {
				timer = 0;
				loselife ();
			}
		} else {
			timer = 0;
			danger.SetActive (false);
		}
	}

	public void loselife(){
		Debug.Log ("lose a life");
		if (lifenumber > 0) {
			transform.localScale += new Vector3 (delta, 0, 0);
			lifenumber --;
			if(lifenumber == 0) Application.LoadLevel(1);
		}

		danger.SetActive (true);
	}
}
