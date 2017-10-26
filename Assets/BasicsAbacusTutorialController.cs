﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class BasicsAbacusTutorialController : MonoBehaviour {

	public class TextData
	{
		private string text;
		private float duration;
		private string action;

		public TextData(string text, float duration, string action = ""){
			this.text = text;
			this.duration = duration;
			this.action = action;
		}
			
		public float GetDuration(){
			return duration;
		}

		public string GetAction(){
			return action;
		}
		public string GetText(){
			return text;
		}

	}

	public Text tutorialText;
	public AbacusScript abacus;

	private int state = 0;
	private int indexOfTextData = 0;
	private float startTime = 0f;
	private List<TextData> introTextData;

	// Use this for initialization
	void Start () {
		
		introTextData = new List<TextData> ();
		introTextData.Add (new TextData ("Hello, welcome to this tutorial", 2f));
		introTextData.Add (new TextData ("An abacus is a device used to do arithmatic", 3f));

		introTextData.Add (new TextData ("Each column of beads in the abacus represents 1 digit", 3f));
		introTextData.Add (new TextData ("The leftmost column, represents the first digit in a number", 3f));
		introTextData.Add (new TextData ("The lower beads represents 1 if they are pushed up.", 3f));
		introTextData.Add (new TextData ("In other words, if 1 lower bead is pushed up, the digit is 1", 5f, "1"));
		introTextData.Add (new TextData ("If 2 lower beads are pushed up, the digit is 2", 5f, "2"));
		introTextData.Add (new TextData ("This represents 3", 3f, "3"));
		introTextData.Add (new TextData ("This represents 4", 2f, "4"));
		introTextData.Add (new TextData ("The top bead represents 5 if it is pushed down", 2f));
		introTextData.Add (new TextData ("This represents 5", 2f, "5"));
		introTextData.Add (new TextData ("In order to get values higher than 5, you move the bottom and top beads.", 5f));
		introTextData.Add (new TextData ("This represents 6", 2f, "6"));
		introTextData.Add (new TextData ("This represents 7", 2f, "7"));
		introTextData.Add (new TextData ("This represents 9", 2f, "9"));

		startTime = Time.time;
	}

	// Update is called once per frame
	void Update () {
		float dTime = Time.time - startTime;
		switch (state) {
		case 0:
			Debug.Log ("indexOfTextData: " + indexOfTextData + " introTextData [indexOfTextData].GetDuration()" + introTextData [indexOfTextData].GetDuration ());

			if (Time.time > startTime + introTextData [indexOfTextData].GetDuration ()) {
				indexOfTextData += 1;
				startTime = Time.time;
				if (indexOfTextData >= introTextData.Count) {
					indexOfTextData = 0;
					state++;
					startTime = Time.time;
					return;
				}
			}
			tutorialText.text = introTextData [indexOfTextData].GetText ();
			performAction (introTextData [indexOfTextData].GetAction ());
			break;
		case 1:
			
			tutorialText.text = "Here try it ourselve now. Try and make the value of the abacus be 1";
			if (abacus.getValue () == 1) {
				tutorialText.text = "Congrats, you have made it 1!";
				state = 2;
				startTime = Time.time;
			}
			break;
		case 2:
			tutorialText.text = "Good job! Now try to make the value of the abacus be 6";
			if (abacus.getValue () == 6) {
				tutorialText.text = "Congrats, you have made 6!";
				state = 3;
				startTime = Time.time;
			}
			break;
		case 3:
			tutorialText.text = "Good job! Lastly try to make the value of the abacus be 9";
			if (abacus.getValue () == 9) {
				tutorialText.text = "Congrats, you have made 9! You have sucessfully finished this tutorial :)";
				state = 3;
				startTime = Time.time;
			}
			break;
		}
	}


	public void performAction(string action){
		switch (action) {
		case "1":
			abacus.setValue (1);
			break;
		case "2":
			abacus.setValue (2);
			break;
		case "3":
			abacus.setValue (3);
			break;
		case "4":
			abacus.setValue (4);
			break;
		case "5":
			abacus.setValue (5);
			break;
		case "6":
			abacus.setValue (6);
			break;
		case "7":
			abacus.setValue (7);
			break;
		case "8":
			abacus.setValue (8);
			break;
		case "9":
			abacus.setValue (9);
			break;
		}
	}
}
