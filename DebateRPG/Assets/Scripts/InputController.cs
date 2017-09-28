using UnityEngine;
using System.Collections;

public enum GameButton {
	LEFT,
	RIGHT,
	JUMP
}

public class InputController : MonoBehaviour {
	

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}


	public static bool isButtonDown (GameButton button){
		if (SystemInfo.deviceType == DeviceType.Desktop) {
			switch (button){
				case GameButton.JUMP:
					return Input.GetKey(KeyCode.Space);
				case GameButton.LEFT:
					return Input.GetKey(KeyCode.LeftArrow);
				case GameButton.RIGHT:
					return Input.GetKey(KeyCode.RightArrow);
			}
		}
		return false;
	}

	public static bool isButtonJustDown(GameButton button){
		if (SystemInfo.deviceType == DeviceType.Desktop) {
			switch (button){
			case GameButton.JUMP:
				return Input.GetKeyDown(KeyCode.Space);
			case GameButton.LEFT:
				return Input.GetKeyDown(KeyCode.LeftArrow);
			case GameButton.RIGHT:
				return Input.GetKeyDown(KeyCode.RightArrow);
			}
		}
		return false;
	}
}
