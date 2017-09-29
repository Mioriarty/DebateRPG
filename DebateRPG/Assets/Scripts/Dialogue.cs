﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public sealed class DialogueData {

	private string[] speaker;
	private string[] speaches;

	public DialogueData (string[] speaker, string[] speaches){
		this.speaker = speaker;
		this.speaches = speaches;
	}

	public string[] getSpeach(int index){
		return new string[]{speaker[index], speaches[index]};
	}

	public int getMaxCurserPos(){
		return speaker.Length;
	}

}

public sealed class DialogueGuide {

	private int curser;
	private DialogueData data;

	public DialogueGuide(DialogueData data){
		this.data = data;
		this.curser = -1;
	}

	public string[] getNextSpeach(){
		return data.getSpeach (++curser);
	}

	public bool nextFinished(){
		return curser + 1 >= data.getMaxCurserPos ();
	}

	public void reset(){
		curser = -1;
	}
}

public sealed class DialogueManager {

	private static Dictionary<string, DialogueData> dialogues = new Dictionary<string, DialogueData> ();

	public static void importDialogue(string title, DialogueData data){
		dialogues.Add (title, data);
	}

	public static DialogueData getDialogue(string title){
		return dialogues [title];
	}

}

public class Dialogue : MonoBehaviour {

	private Text text;
	private Animator animator;

	[SerializeField]
	private float timeForCharacter = 0.3f;
	private string textToShow = "";
	private int textToShowPtr = 0;
	private bool textIsAppearing = false;
	private bool isVisible = false;

	private DialogueGuide guide;

	public static Dialogue i;
	void Awake(){
		i = this;
	}

	// Use this for initialization
	void Start () {
		text = GetComponentInChildren<Text> ();
		animator = GetComponentInChildren<Animator> ();

		DialogueData dd = new DialogueData (new string[]{ "Hund: ", "Besitzer: ", "Hund: ", "Besitzer: " }, new string[] {
			"Ich liebe dich!",
			"Ich hasse dich!",
			"Oh. Ich hasse dich eigentlich auch",
			"sodunv sourvnowrnv rwoweunv woweu onvpw epwei pöwrifvpiwnv rwin pwrn pwrnvip pwe pwivnip pewi owevnpw piwv pwefnpiew es fpirwbgw pirgn eipw oprwgh psfigjpwri prw owpe ipgnpiwgfhpwe gipwe eipwgnwpeh epg gepw "
		});

		resetDialogue (dd);
		showDialogue ();

	}
	

	void setText(string[] speach){
		textToShow = speach[0] + speach[1];
		textToShowPtr = speach[0].Length-1;
	}

	public void resetDialogue(DialogueData newDialogue = null){
		if (newDialogue == null)
			guide.reset ();
		else
			guide = new DialogueGuide (newDialogue);
		
		animator.Play ("IdleClosed");
		
	}
		

	public void showDialogue(){
		isVisible = true;
		animator.Play ("PopUp");
	}

	public void disappear(){
		text.text = "";
		isVisible = false;
		animator.Play ("Disappear");
	}

	public void requestClick(){
		if (!textIsAppearing && isVisible) {
			if (guide.nextFinished()) {
				disappear ();
			} else {
				setText (guide.getNextSpeach ());
				startTextShowing ();
			}

		}
	}

	void startTextShowing(){
		textIsAppearing = true;
		StartCoroutine ("showNextCharacter");
		
	}

	IEnumerator showNextCharacter(){
		yield return new WaitForSeconds (timeForCharacter);
		text.text = textToShow.Substring (0, ++textToShowPtr);
		if (textToShowPtr < textToShow.Length)
			StartCoroutine ("showNextCharacter");
		else
			textIsAppearing = false;
	}
}
