using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using System;
using System.Linq;


[System.Serializable]
public class TextData
{
	private string text;
	private string action;

	public TextData(string text, string action = ""){
		this.text = text;
		this.action = action;
	}


	public string GetAction(){
		return action;
	}
	public string GetText(){
		return text;
	}

}

[System.Serializable]
public class PracticeData{
	private string text;
	private int target;

	public PracticeData(string text, int target){
		this.text = text; 
		this.target = target;
	}

	public string GetText(){
		return text;
	}
	public int GetTarget(){
		return target;
	}
}

public class MultipleDigitsTutorial : MonoBehaviour {



	public Text tutorialText;
	public AbacusScript abacus;
	public Button nextButton;

	private int oldState = -1;
	private int state = 0;
	private int indexOfTextData = 0;
	private List<TextData> introTextData;
	private List<PracticeData> practiceProblems;

	// Use this for initialization
	void Start () {

		introTextData = new List<TextData> ();
		introTextData.Add (new TextData ("The abacus can also represent numbers larger than 9."));
		introTextData.Add (new TextData ("Each column represents 1 digit"));
		introTextData.Add (new TextData ("So that means this represents 10", "10"));
		introTextData.Add (new TextData ("This represents 11", "11"));
		introTextData.Add (new TextData ("This represents 12", "12"));
		introTextData.Add (new TextData ("This represents 15", "15"));
		introTextData.Add (new TextData ("17", "17"));
		introTextData.Add (new TextData ("Similarly this represents 20", "20"));
		introTextData.Add (new TextData ("This represents 21", "21"));
		introTextData.Add (new TextData ("And you can make even bigger numbers"));
		introTextData.Add (new TextData ("51",  "51"));
		introTextData.Add (new TextData ("71",  "71"));
		introTextData.Add (new TextData ("And your not limited to 2 digits. Here is 107",  "107"));
		introTextData.Add (new TextData ("Here is 163",  "163"));
		introTextData.Add (new TextData ("Lastly, here is 3263",  "3263"));



		practiceProblems = new List<PracticeData> ();
		practiceProblems.Add (new PracticeData ("Practice: Try and make the value of the abacus be 11", 11));
		practiceProblems.Add (new PracticeData ("Good job! Now try to make the value of the abacus be 51", 51));
		practiceProblems.Add (new PracticeData ("Good job! Now try to make the value of the abacus be 87", 87));
		practiceProblems.Add (new PracticeData ("WOW! Now try to make the value of the abacus be 105", 105));
		practiceProblems.Add (new PracticeData ("SUGIO! What about 2759?", 2759));
		practiceProblems.Add (new PracticeData ("Woho! Lastly try to make the value of the abacus be 79", 79));



		nextButton.onClick.AddListener (nextText);
	}

	// Update is called once per frame
	void Update () {
		if (state == 0) {
			tutorialText.text = introTextData [indexOfTextData].GetText ();
			performAction (introTextData [indexOfTextData].GetAction ());

		} else{
			nextButton.interactable = false;
			int index = state - 1;
			if (index < practiceProblems.Count) {

				tutorialText.text = practiceProblems [index].GetText ();
				
				if (practiceProblems [index].GetTarget () == abacus.getValue ()) {
					state++;
				}
			} else {
				
				tutorialText.text = "Congrats! You have sucessfully finished this tutorial :)";
				
			}
		}

		oldState = state;
	}	



	public void performAction(string action){
		if (action.Equals (""))
			return;
		abacus.setValue (Int32.Parse (action));
	}

	public void nextText(){
		indexOfTextData += 1;
		if (indexOfTextData >= introTextData.Count) {
			indexOfTextData = 0;
			state++;
		}
	}
}
