﻿using UnityEngine;
using System.Collections;

public class AutoSpin : MonoBehaviour {
	public Vector3 rate;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.Rotate (rate);
	}
}