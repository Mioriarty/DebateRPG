using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour {

	protected enum NPCState {
		IDLE, ENTERED, DEBATING
	}

	protected NPCState state = NPCState.IDLE;

	protected GameObject enteredSprite;
	protected DialogueData dialogue;

	// Use this for initialization
	void Start () {
		enteredSprite = transform.GetChild (0).gameObject;

		dialogue = new DialogueData (new string[]{ "Franz: ", "Du: ", "Franz: ", "Du: " }, new string[] {
			"Ich liebe dich!",
			"Ich hasse dich!",
			"Oh. Ich hasse dich eigentlich auch! :((",
			"Dann haue ich jetzt ab!!"
		});
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnMouseDown(){
		if (state == NPCState.ENTERED) {
			state = NPCState.DEBATING;
			Dialogue.i.resetDialogue (dialogue);
			Dialogue.i.showDialogue (onDialogueEnd);
		}
	}

	void onDialogueEnd(){
		if (state == NPCState.DEBATING)
			state = NPCState.ENTERED;
	}


	public void playerEnters(){
		enteredSprite.SetActive (true);
		state = NPCState.ENTERED;

	}

	public void playerExits(){
		enteredSprite.SetActive (false);
		state = NPCState.IDLE;
	}
}
