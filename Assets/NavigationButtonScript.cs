using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class NavigationButtonScript : MonoBehaviour {

	public int sceneNumber;

	// Use this for initialization
	void Start () {
		this.gameObject.GetComponent<Button>().onClick.AddListener(TaskOnClick);
	}

	void TaskOnClick(){
		SceneManager.LoadScene (sceneNumber);
	}
}
