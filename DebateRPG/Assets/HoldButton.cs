using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class HoldButton : MonoBehaviour, IPointerDownHandler, IPointerEnterHandler, IPointerExitHandler, IPointerUpHandler {

	public bool pressed { get; private set;}
	public bool justPressed { get; private set;}

	private bool waitForFrame = false;

	void LateUpdate(){
		if (waitForFrame)
			waitForFrame = false;
		else
			justPressed = false;
	}

	public void OnPointerDown(PointerEventData eventData) {
		pressed = true;
		justPressed = true;
		waitForFrame = true;
	}

	public void OnPointerExit(PointerEventData eventData) {
		pressed = false;
	}

	public void OnPointerUp(PointerEventData eventData) {
		pressed = false;
	}

	public void OnPointerEnter(PointerEventData eventData) {
		if (SystemInfo.deviceType != DeviceType.Desktop)
			pressed = true;
	}
}
