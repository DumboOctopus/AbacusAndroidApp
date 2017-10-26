using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using System;

public class BasicsAbacusTutorialController : MonoBehaviour {


	public Text tutorialText;
	public AbacusScript abacus;
	public Button nextButton;

	private int state = 0;
	private int indexOfTextData = 0;
	private List<TextData> introTextData;

	// Use this for initialization
	void Start () {
		
		introTextData = new List<TextData> ();
		introTextData.Add (new TextData ("Hello. Use the next button to get to the next slide"));
		introTextData.Add (new TextData ("An abacus is a device used to do arithmatic"));

		introTextData.Add (new TextData ("Each column of beads in the abacus represents 1 digit"));
		introTextData.Add (new TextData ("The leftmost column, represents the first digit in a number"));
		introTextData.Add (new TextData ("The lower beads represents 1 if they are pushed up."));
		introTextData.Add (new TextData ("In other words, if 1 lower bead is pushed up, the digit is 1", "1"));
		introTextData.Add (new TextData ("If 2 lower beads are pushed up, the digit is 2", "2"));
		introTextData.Add (new TextData ("This represents 3", "3"));
		introTextData.Add (new TextData ("This represents 4", "4"));
		introTextData.Add (new TextData ("The top bead represents 5 if it is pushed down"));
		introTextData.Add (new TextData ("This represents 5", "5"));
		introTextData.Add (new TextData ("In order to get values higher than 5, you move the bottom and top beads."));
		introTextData.Add (new TextData ("This represents 6", "6"));
		introTextData.Add (new TextData ("This represents 7", "7"));
		introTextData.Add (new TextData ("This represents 9", "9"));
		nextButton.onClick.AddListener (nextText);
	}

	// Update is called once per frame
	void Update () {
		switch (state) {
		case 0:
			
			tutorialText.text = introTextData [indexOfTextData].GetText ();
			performAction (introTextData [indexOfTextData].GetAction ());
			break;
		case 1:
			nextButton.interactable = false;
			tutorialText.text = "Now its your turn :) Try and make the value of the abacus 1";
			if (abacus.getValue () == 1) {
				state ++;
			}
			break;
		case 2:
			tutorialText.text = "Good job! Now try to make the value of the abacus be 6";
			if (abacus.getValue () == 6) {
				tutorialText.text = "Congrats, you have made 6!";
				state ++;
			}
			break;
		case 3:
			tutorialText.text = "Good job! Lastly try to make the value of the abacus be 9";
			if (abacus.getValue () == 9) {
				tutorialText.text = "Congrats, you have made 9! You have sucessfully finished this tutorial :)";
				state ++;
			}
			break;
		}
	}


	public void performAction(string action){
		if (action.Equals (""))
			return;
		abacus.setValue (Int32.Parse (action));
	}

	public void nextText(){
		if (state == 0) {
			indexOfTextData += 1;
			if (indexOfTextData >= introTextData.Count) {
				state++;
			}
		}
	}
}
