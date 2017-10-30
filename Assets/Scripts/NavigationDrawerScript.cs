using UnityEngine;
using System.Collections;

public class NavigationDrawerScript : MonoBehaviour {

	private bool bDragging;
	private bool bSnapping = false;
	private Vector3 oldMouse;


	public int maxOut = 100;
	public float startX;

	public float widthOfPanel = 200f;

	// Use this for initialization
	void Start () {
		startX = transform.position.x;
	}
	
	// Update is called once per frame
	void Update () {

		if(Input.GetKey(KeyCode.RightArrow)){
			Debug.Log ("hi");
			this.transform.position +=  Vector3.right;
		}

		if (bSnapping) {
			
			Vector3 pos = transform.position;
			pos.x += Time.deltaTime * 1000*(pos.x - startX - widthOfPanel/2f) / (maxOut - startX);
			Debug.Log ("dPos = " + 1000*(pos.x - startX) / (maxOut - startX));

			transform.position = pos;

			if (this.transform.position.x > maxOut) {
				this.transform.position = new Vector3 (
					maxOut,
					transform.position.y,
					transform.position.z
				);
				bSnapping = false;
			}
			if (this.transform.position.x < startX) {
				this.transform.position = new Vector3 (
					startX,
					transform.position.y,
					transform.position.z
				);
				bSnapping = false;
			}

		}


		if (bDragging) {
			Vector3 mouse = Input.mousePosition;
			mouse.y = this.transform.position.y;
			mouse.z = this.transform.position.z;


			this.transform.position += mouse - oldMouse;
			if (this.transform.position.x > maxOut) {
				this.transform.position = new Vector3 (
					maxOut,
					transform.position.y,
					transform.position.z
				);

			}
			if (this.transform.position.x < startX) {
				this.transform.position = new Vector3 (
					startX,
					transform.position.y,
					transform.position.z
				);
			}
			oldMouse = mouse;
		}



		//update b dragging

		#if UNITY_EDITOR

		if (bDragging) {
			Vector3 mouse = Input.mousePosition;
			mouse.y = this.transform.position.y;
			mouse.z = this.transform.position.z;


			this.transform.position += mouse - oldMouse;
			if (this.transform.position.x > maxOut) {
				this.transform.position = new Vector3 (
					maxOut,
					transform.position.y,
					transform.position.z
				);

			}
			if (this.transform.position.x < startX) {
				this.transform.position = new Vector3 (
					startX,
					transform.position.y,
					transform.position.z
				);
			}
			oldMouse = mouse;
		}

		if (Mathf.Abs (transform.position.x + widthOfPanel / 2f - Input.mousePosition.x) < 40f && (Input.touchCount > 0 || Input.GetMouseButton(0))) {
			oldMouse = Input.mousePosition;
			oldMouse.y = this.transform.position.y;
			oldMouse.z = this.transform.position.z;
			bDragging = true;
		}
		if (Input.GetMouseButtonUp(0) && Input.touchCount == 0) {
			bDragging = false;
			//snap to a certain state
			bSnapping = true;
		}
		#elif UNITY_ANDROID
		if(Input.touchCount > 0){
		Touch t = Input.touches[0];
		if(t.phase == TouchPhase.Began){
		if (Mathf.Abs (transform.position.x + widthOfPanel / 2f - t.position.x) < 40f) {
		oldMouse = t.position;
		oldMouse.y = this.transform.position.y;
		oldMouse.z = this.transform.position.z;
		bDragging = true;
		}
		}
		}else {
		bDragging = false;
		//snap to a certain state
		bSnapping = true;
		}
		if (bDragging) {
		Touch t = Input.touches[0];
		Vector3 mouse = t.position;
		mouse.y = this.transform.position.y;
		mouse.z = this.transform.position.z;


		this.transform.position += mouse - oldMouse;
		if (this.transform.position.x > maxOut) {
		this.transform.position = new Vector3 (
		maxOut,
		transform.position.y,
		transform.position.z
		);

		}
		if (this.transform.position.x < startX) {
		this.transform.position = new Vector3 (
		startX,
		transform.position.y,
		transform.position.z
		);
		}
		oldMouse = mouse;
		}
		#endif



	}
}
