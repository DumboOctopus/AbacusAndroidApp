using UnityEngine;
using System.Collections;

public class BeadScript : MonoBehaviour {

	public int beadNumber;
	public static float FORCE_MULTIPLIER = 20.0f;

	private Vector3 screenPoint;
	private Vector3 offset;
	private Rigidbody2D rb;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (rb.velocity.y == 0 || Mathf.Abs(1/rb.velocity.y) > 10f)
			rb.drag = 10f;
		else
			rb.drag = Mathf.Abs(1.5f/rb.velocity.y);
	}

	void OnMouseDown()
	{
		rb.drag = 0f;
		screenPoint = Camera.main.WorldToScreenPoint(gameObject.transform.position);
		offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
	}

	void OnMouseDrag()
	{
		Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
		Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint) + offset;

		rb.AddForce( (curPosition - transform.position)*FORCE_MULTIPLIER);
	}

	void OnMouseUp(){
		rb.drag = 1f;
	}
}
