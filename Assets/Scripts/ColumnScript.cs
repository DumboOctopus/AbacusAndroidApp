using UnityEngine;
using System.Collections;

public class ColumnScript : MonoBehaviour {

	private GameObject[] beads;
	private float[] ys;

	private float width = 0.5f;


	// Use this for initialization
	void Start () {
		beads = new GameObject[6];
		beads[1] = transform.FindChild ("Bead1").gameObject;
		beads[2] = transform.FindChild ("Bead2").gameObject;
		beads[3] = transform.FindChild ("Bead3").gameObject;
		beads[4] = transform.FindChild ("Bead4").gameObject;
		beads[5] = transform.FindChild ("Bead5").gameObject;

		ys = new float[6];
		ys[1] = beads[1].transform.position.y;
		ys[2] = beads[2].transform.position.y;
		ys[3] = beads[3].transform.position.y;
		ys[4] = beads[4].transform.position.y;
		ys[5] = beads[5].transform.position.y;
	}
	
	// Update is called once per frame
	void Update () {
		//compute how many beads are above their resting state.

	}

	public int getValue(){
		int sum = 0;
		for (int i = 1; i <= 4; i++) {
			if (beads [i].transform.position.y > ys [i] + width) {
				sum += 1;
			}
		}
		if (beads [5].transform.position.y < ys [5] - width) {
			sum += 5;
		}
		return sum;
	}

	public void setValue(int value){
		if (value > 9)
			return;



		if (value >= 5) {
			beads [5].GetComponent<Rigidbody2D> ().AddForce (new Vector2 (0, -10));
			value -= 5;
		} else {
			beads [5].GetComponent<Rigidbody2D> ().AddForce (new Vector2 (0, 10));
		}

		if (value != 0) {
			beads [value].GetComponent<Rigidbody2D> ().AddForce (new Vector2 (0, value * 10));
			if (value < 4) {
				beads [value + 1].GetComponent<Rigidbody2D> ().AddForce (new Vector2 (0, -value * 10));
			}
		} else {
			beads[1].GetComponent<Rigidbody2D> ().AddForce (new Vector2 (0, -40)); //push all lower beads down
		}
		

	}
}
