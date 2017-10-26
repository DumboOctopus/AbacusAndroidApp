using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

public class MultipleDigitsTutorial : MonoBehaviour {

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
		introTextData.Add (new TextData ("The abacus can also represent numbers larger than 9.", 2f));
		introTextData.Add (new TextData ("Each column represents 1 digit", 3f));

		introTextData.Add (new TextData ("So that means this represents 10", 6f, "10"));
		introTextData.Add (new TextData ("This represents 11", 3f, "11"));
		introTextData.Add (new TextData ("This represents 12", 3f, "12"));
		introTextData.Add (new TextData ("This represents 15", 5f, "15"));
		introTextData.Add (new TextData ("17", 5f, "17"));
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
				state ++;
				startTime = Time.time;
			}
			break;
		case 2:
			tutorialText.text = "Good job! Now try to make the value of the abacus be 6";
			if (abacus.getValue () == 6) {
				tutorialText.text = "Congrats, you have made 6!";
				state ++;
				startTime = Time.time;
			}
			break;
		case 3:
			tutorialText.text = "Good job! Lastly try to make the value of the abacus be 9";
			if (abacus.getValue () == 9) {
				tutorialText.text = "Congrats, you have made 9! You have sucessfully finished this tutorial :)";
				state ++;
				startTime = Time.time;
			}
			break;
		}
	}


	public void performAction(string action){
		if (action.Equals (""))
			return;
		abacus.setValue (Int32.Parse (action));
	}
}
