using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

	private float zPos;

	void Start(){
		zPos = transform.position.z;
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = Utils.vec2To3( Vector2.Lerp (Utils.vec3To2(transform.position), Utils.vec3To2(Player.i.transform.position), 0.1f), zPos);



	}
}
