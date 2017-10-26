using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class AdditionTutorialController : MonoBehaviour {

	public Text tutorialText;

	private int state = 0;
	private float startTime = 0f;

	// Use this for initialization
	void Start () {
		startTime = Time.time;
	}
	
	// Update is called once per frame
	void Update () {
		switch (state) {
		case 0:
			if (Time.time - state < 0f) {
				tutorialText.text = "Hello, welcome to this tutorial";
			} else if (Time.time - startTime < 5f) {
				tutorialText.text += "\nAn abacus is a device used to do arithmatic";
			} else if (Time.time - startTime < 10f) {
				tutorialText.text = "Each column represents one digit";
			} else if (Time.time - startTime < 15f) {
				tutorialText.text = "The left most column represents the leftmost digit";
			} else if (Time.time - startTime < 20f) {
				tutorialText.text = "The second from the left represents the second to left most digit";
			} else if (Time.time - startTime < 25f) {
				tutorialText.text = "For example, this represents 1.";
			}
			break;

		}
	}
}
