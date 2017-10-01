using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGroop : MonoBehaviour {

	public enum AggressiveState {
		PEACEFUL, PASSIV, AGGRESSIV
	}

	DialogueData aggressiveDialogue;
	DialogueData matureDialogue;
	DialogueData depressantDialogue;

	[SerializeField]
	private AggressiveState aggressiveState;

	// Use this for initialization
	void Start () {
		matureDialogue = new DialogueData (new string[]{ "Gegner: ", "Du: ", "Gegner: ", "Du; " }, new string[] {
			"Na lange nicht gesehen",
			"Kenne ich dich. Warum greifst du mich nicht an. Du bist doch ein gegner?",
			"Wießt du nicht mehr. 1988, San Franzisko, in der Disko",
			"Ich glaube ich war zu betrunken. Ich haue jetzt ab lieber ab. Tschau",
			"Tschüss. Hoffentlich sehehn wir uns baldf wieder"
		});

		depressantDialogue = new DialogueData (new string[]{ "Gegner: ", "Du: ", "Du: ", "Genger: ", "Du: " }, new string[] {
			"Hey, hey, hey. Fahr' mal 'n bissl' runta. Chill ma. Willste ne Kippe.",
			"ARggeregr #!äe#.,::,y,c+#+*ow ......",
			"Warum eigentlich nicht?. Ein bissl Frieden kann nie Schaden",
			"Yo erwitere deinenen Horizont",
			"Hier nicht!"
		});

		aggressiveDialogue = new DialogueData (new string[]{ "Gegner: ", "Du: ", "Gegner: ", "Du: ", "Gegner: ", "Du: ", "Du: " }, new string[] {
			"Der böse Spieler zum Angriff",
			"Jawohl zum Angriff",
			"Mit gebrüll [Hier Gebrüll einsetzen]",
			"Jawohl mit Gebrüll",
			"Fallen wir über ihn her",
			"Jawohl falllen wir über eu....",
			"Ich bin ja aller. ich habe keine Freunde. Warum habe ich eigentlich keine Freunde. Egal zum Angriff!!!"
		});
	}

	void talkAggressively(){
		Debug.Log ("Attack");
		Dialogue.i.resetDialogue (aggressiveDialogue);
		Dialogue.i.showDialogue ();
	}

	void talkMaturely(){
		Debug.Log ("Hey Boy what's up");
		Dialogue.i.resetDialogue (matureDialogue);
		Dialogue.i.showDialogue ();
	}

	void talkDepressantly(){
		Debug.Log ("Calm down");
		Dialogue.i.resetDialogue (depressantDialogue);
		Dialogue.i.showDialogue ();
	}


	public void playerEnters(bool swordEquipped){
		switch (aggressiveState) {
		case AggressiveState.PEACEFUL:
			if (swordEquipped)
				talkDepressantly ();
			else
				talkMaturely ();
			break;
		case AggressiveState.PASSIV:
			if (swordEquipped)
				talkAggressively();
			else
				talkMaturely();
			break;
		case AggressiveState.AGGRESSIV:
			talkAggressively ();
			break;
		}
	}
}
