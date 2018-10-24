using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UI : MonoBehaviour {
	public Button btn;

	// Use this for initialization
	void Start () {
		btn.onClick.AddListener (TaskOnClick);
	}

	void TaskOnClick() {
		if (!GameObject.Find ("Ball").GetComponent<Ball> ().running) {
			Debug.Log ("Game Started!");
			GameObject.Find ("Ball").GetComponent<Ball> ().GameReset ();
			GameObject.Find ("Ball").GetComponent<Ball> ().running = true;
		}
	}

	// Update is called once per frame
	void Update () {
	
	}
}
