﻿using UnityEngine;
using System.Collections;

public class RocketShooter : MonoBehaviour {

	public GameObject bomb;
	public GameObject explosion;
	public GameObject power;
	public Vector3 speed;
	public bool flag;
	public Vector3 centerpositon;

	private CardboardHead _head;
	private PowerController _power;
	private AudioSource _audio;

	// Use this for initialization
	void Start () {
		_head = Camera.main.GetComponent<StereoController>().Head;
		_power = power.GetComponent<PowerController>();
		_audio = gameObject.GetComponent<AudioSource>();

		// preload prefabs
		GameObject p = Instantiate(bomb, transform.position, Quaternion.identity) as GameObject;
		Destroy(p);
		p = Instantiate(explosion, transform.position, Quaternion.identity) as GameObject;
		Destroy(p);
		p = null;
	}
	
	// Update is called once per frame
	void Update () {
		flag = false;
		if (Input.GetMouseButtonDown (0))
			flag = true;
		if (Cardboard.SDK.CardboardTriggered || flag ) {
			if (!_power.available) {
				if (Debug.isDebugBuild)
					Debug.Log ("Not enough power.");
				return;
			}
			if (Debug.isDebugBuild)
				Debug.Log ("Fire!");
			_power.Fire ();
			_audio.Play ();
			GameObject newbomb = Instantiate(bomb, transform.position, _head.transform.rotation * transform.rotation) as GameObject;
			//GameObject newbomb = Instantiate(bomb, transform.position, centerpositon * transform.rotation) as GameObject;
			newbomb.transform.Rotate(centerpositon);
			Rigidbody rigidbody = newbomb.GetComponent<Rigidbody>();
			rigidbody.velocity = newbomb.transform.TransformVector(speed);
		}
	}

}
