using UnityEngine;
using System.Collections;

public class AbacusScript : MonoBehaviour {

	private GameObject[] columns;

	// Use this for initialization
	void Start () {
		columns = new GameObject[6];
		for (int i = 0; i < 6; i++) {
			columns[i] = transform.FindChild ("Column" + i).gameObject;
		}
		Debug.Log (columns [0] + ": " + columns [1]);
	}
	
	// Update is called once per frame
	void Update () {
	
	}


	public void setValue(int value){
		string tmp = value + "";
		char[] kek = tmp.ToCharArray();
		int[] digits = new int[tmp.Length];
		for (int i = 0; i < digits.Length; i++) {
			digits [i] = kek [digits.Length -1 -i] - '0';
			columns [i].GetComponent<ColumnScript> ().setValue (digits [i]);
		}

	}

	public int getValue(){
		int sum = 0;
		for (int i = 0; i < columns.Length; i++) {
			sum += (int)( Mathf.Pow (10, i) * columns [i].GetComponent<ColumnScript> ().getValue ());
		}
		return sum;
	}
}
