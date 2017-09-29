using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PupUpDialogue : StateMachineBehaviour {


	override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
		Dialogue.i.requestClick ();
	}


}
