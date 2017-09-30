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
		Dialogue.dialogueEndEvent += onDialogueEnd;

		dialogue = new DialogueData (new string[]{ "Hund: ", "Besitzer: ", "Hund: ", "Besitzer: " }, new string[] {
			"Ich liebe dich!",
			"Ich hasse dich!",
			"Oh. Ich hasse dich eigentlich auch! :((",
			"sodunv sourvnowrnv rwoweunv woweu onvpw epwei pöwrifvpiwnv rwin pwrn pwrnvip pwe pwivnip pewi owevnpw piwv pwefnpiew es fpirwbgw pirgn eipw oprwgh psfigjpwri prw owpe ipgnpiwgfhpwe gipwe eipwgnwpeh epg gepw "
		});
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnMouseDown(){
		if (state == NPCState.ENTERED) {
			state = NPCState.DEBATING;
			Dialogue.i.resetDialogue (dialogue);
			Dialogue.i.showDialogue ();
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
