using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using System;
using System.Linq;

public class BasicAdditionTutorialScript : MonoBehaviour {


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
		introTextData.Add (new TextData ("Now we can get to the fun stuff: addition :)."));
		introTextData.Add (new TextData ("With small numbers, its simple"));
		introTextData.Add (new TextData ("Lets say we wanted to do 1 + 1", "1"));
		introTextData.Add (new TextData ("All we would do is add 1", "2"));
		introTextData.Add (new TextData ("However, what if we wanted to do 3 +4"));
		introTextData.Add (new TextData ("We would start with 3", "3"));
		introTextData.Add (new TextData ("And then add 5 subtract 1", "7"));
		introTextData.Add (new TextData ("If you think about it, adding 5 to 3 would give us 8."));
		introTextData.Add (new TextData ("Then subtracting 1 would 7 which is the answer :)"));
		introTextData.Add (new TextData ("Lets try another one: 3+3"));
		introTextData.Add (new TextData ("We would start with 3",  "3"));
		introTextData.Add (new TextData ("3 + 5 = 8",  "8"));
		introTextData.Add (new TextData ("3 + 5 -2 = 6",  "6"));



		practiceProblems = new List<PracticeData> ();
		practiceProblems.Add (new PracticeData ("Practice: 3+3\nPut 3 on the abacus", 3));
		practiceProblems.Add (new PracticeData ("Practice: 3+3\nNow add 5", 8));
		practiceProblems.Add (new PracticeData ("Practice: 3+3\nNow subtract 2", 6));
		practiceProblems.Add (new PracticeData ("Good job! Now lets do 1+2. Set the value of the abacus to 1", 1));
		practiceProblems.Add (new PracticeData ("Now add 2", 3));
		practiceProblems.Add (new PracticeData ("Lastly, just as review, put the abacus at 42", 42));



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
