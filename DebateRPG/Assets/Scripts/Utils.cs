using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class Utils {

	public static Vector2 vec3To2(Vector3 v){
		return new Vector2 (v.x, v.y);
	}

	public static Vector3 vec2To3(Vector2 v, float z){
		return new Vector3 (v.x, v.y, z);
	}
}
