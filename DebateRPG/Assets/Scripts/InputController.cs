using UnityEngine;
using System.Collections;

public enum GameButton {
	LEFT,
	RIGHT,
	JUMP
}

public class InputController : MonoBehaviour {

	public HoldButton leftButton;
	public HoldButton rightButton;
	public HoldButton jumpButton;

	private static InputController i;
	void Awake(){
		i = this;
	}

	public static bool isButtonDown (GameButton button){
		if (SystemInfo.deviceType == DeviceType.Desktop && false) {
			switch (button) {
			case GameButton.JUMP:
				return Input.GetKey (KeyCode.Space);
			case GameButton.LEFT:
				return Input.GetKey (KeyCode.LeftArrow);
			case GameButton.RIGHT:
				return Input.GetKey (KeyCode.RightArrow);
			}
		} else {
			switch (button) {
			case GameButton.JUMP:
				return i.jumpButton.pressed;
			case GameButton.LEFT:
				return i.leftButton.pressed;
			case GameButton.RIGHT:
				return i.rightButton.pressed;
			}
		}
		return false;
	}

	public static bool isButtonJustDown(GameButton button){
		if (SystemInfo.deviceType == DeviceType.Desktop && false) {
			switch (button){
			case GameButton.JUMP:
				return Input.GetKeyDown(KeyCode.Space);
			case GameButton.LEFT:
				return Input.GetKeyDown(KeyCode.LeftArrow);
			case GameButton.RIGHT:
				return Input.GetKeyDown(KeyCode.RightArrow);
			}
		} else {
			switch (button) {
			case GameButton.JUMP:
				return i.jumpButton.justPressed;
			case GameButton.LEFT:
				return i.leftButton.justPressed;
			case GameButton.RIGHT:
				return i.rightButton.justPressed;
			}
		}
		return false;
	}
}
