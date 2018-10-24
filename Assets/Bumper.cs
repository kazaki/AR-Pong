using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Bumper : MonoBehaviour {

	public Dropdown myDropdown;

	// Use this for initialization
	void Start () {
	}

	private string getMode() {
		return myDropdown.value.ToString();
	}
	
	// Update is called once per frame
	void Update () {
		float ran = Random.Range (GameObject.Find ("Ball").transform.localPosition.z - 0.3f, GameObject.Find ("Ball").transform.localPosition.z + 0.3f);

		float speed = 0.03f;
		if (getMode () == "0") {
			if (gameObject.name == "RedBumper")
				transform.Translate (0, 0, Input.GetAxis ("Horizontal") * speed);
			else
				transform.Translate (0, 0, Input.GetAxis ("Vertical") * speed);
			
		} else if (getMode () == "1") {
			if (gameObject.name == "RedBumper") {
				transform.Translate (0, 0, Input.GetAxis ("Horizontal") * speed);
			} else {
				if (!GameObject.Find ("Ball").GetComponent<Ball> ().running)
					return;
				if (transform.localPosition.z < 0.45 && ran <transform.localPosition.z)
					transform.Translate (0, 0, 0.01f); 
				else if (transform.localPosition.z > -0.45 && ran > transform.localPosition.z)
					transform.Translate (0, 0, -0.01f);
			}
		} else if (getMode () == "2") {
			if (!GameObject.Find ("Ball").GetComponent<Ball> ().running)
				return;
			if (gameObject.name == "RedBumper") {
				if (transform.localPosition.z < 0.45 && ran < transform.localPosition.z)
					transform.Translate (0, 0, 0.01f);
				else if (transform.localPosition.z > -0.45 && ran > transform.localPosition.z)
					transform.Translate (0, 0, -0.01f);
			} else {
				if (transform.localPosition.z < 0.45 && ran <transform.localPosition.z)
					transform.Translate (0, 0, 0.01f); 
				else if (transform.localPosition.z > -0.45 && ran > transform.localPosition.z)
					transform.Translate (0, 0, -0.01f);
			}
		}
	}


}
