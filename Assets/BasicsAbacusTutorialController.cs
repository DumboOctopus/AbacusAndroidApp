using UnityEngine;
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

	}

	public Text tutorialText;
	public AbacusScript abacus;

	private int state = 0;
	private float startTime = 0f;
	private List<TextData> introTextData;

	// Use this for initialization
	void Start () {
		startTime = Time.time;
		introTextData = new List<TextData> ();
		introTextData.Add (new TextData ("Hello, welcome to this tutorial", 5f));
		introTextData.Add (new TextData ("An abacus is a device used to do arithmatic", 2f));

		introTextData.Add (new TextData ("Each column of beads in the abacus represents 1 digit", 2f));
		introTextData.Add (new TextData ("The leftmost column, represents the first digit in a number", 2f));
		introTextData.Add (new TextData ("The lower beads represents 1 if they are pushed up.", 2f));
		introTextData.Add (new TextData ("In other words, if 1 lower bead is pushed up, the digit is 1", 4f, "1"));
		introTextData.Add (new TextData ("If 2 lower beads are pushed up, the digit is 2", 4f, "2"));
		introTextData.Add (new TextData ("This represents 3", 2f, "3"));
		introTextData.Add (new TextData ("This represents 4", 2f, "4"));
		introTextData.Add (new TextData ("The top bead represents 5 if it is pushed down", 2f));
		introTextData.Add (new TextData ("This represents 5", 2f, "5"));
		introTextData.Add (new TextData ("In order to get values higher than 5, you move the bottom and top beads.", 2f));
		introTextData.Add (new TextData ("This represents 6", 2f, "6"));
		introTextData.Add (new TextData ("This represents 7", 2f, "7"));
		introTextData.Add (new TextData ("This represents 9", 2f, "9"));


	}

	// Update is called once per frame
	void Update () {
		float dTime = Time.time - startTime;
		switch (state) {
		case 0:
			if (dTime < 5f) {
				tutorialText.text = "Hello, welcome to this tutorial";
			} else if (dTime < 7f) {
				tutorialText.text = "An abacus is a device used to do arithmatic";
			} else if (dTime < 13f) {
				tutorialText.text = "Each column represents one digit";
			} else if (dTime < 16f) {
				tutorialText.text = "The left most column represents the leftmost digit";
			} else if (dTime < 20f) {
				tutorialText.text = "The second from the left represents the second to left most digit";
			} else if (dTime < 25f) {
				tutorialText.text = "The lower beads represent 1 if they are all they way up, ";
			} else if (dTime < 30f) {
				tutorialText.text = "For example, this represents 1";
				abacus.setValue (1);
			} else if (dTime < 35f) {
				tutorialText.text = "This represents 2";
				abacus.setValue (2);
			} else if (dTime < 37f) {
				tutorialText.text = "This represents 3";
				abacus.setValue (3);
			}else if (dTime < 39f) {
				tutorialText.text = "This represents 4";
				abacus.setValue (4);
			}else if (dTime < 43f) {
				tutorialText.text = "5 is represented by the top bead. ";
			} else if (dTime < 47f) {
				tutorialText.text = "This is 5";
				abacus.setValue (5);
			} else if (dTime < 49f) {
				tutorialText.text = "In order to get values higher than 5, you move the bottom and top beads.";
			} else if (dTime < 52f) {
				tutorialText.text = "This is 6.";
				abacus.setValue (6);
			} else if (dTime < 56f) {
				tutorialText.text = "This is 7.";
				abacus.setValue (7);
			} else if (dTime < 60f) {
				tutorialText.text = "This is 9.";
				abacus.setValue (9);
				state = 1;
				startTime = Time.time;
			}
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
			if (dTime > 5f) {
				tutorialText.text = "Here try it ourselve now. Try and make the value of the abacus be 6";
				if (abacus.getValue () == 6) {
					tutorialText.text = "Congrats, you have made it 6!";
					state = 2;
				}

			}
			break;
		}
	}
}
