using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ResetBtnScript : MonoBehaviour {
	public Button btn;

	// Use this for initialization
	void Start () {
		btn.onClick.AddListener (TaskOnClick);
	}

	void TaskOnClick() {
		Debug.Log ("Game Reset!");
		GameObject.Find ("Ball").GetComponent<Ball> ().GameFullReset ();
		GameObject.Find ("Ball").GetComponent<Ball> ().running = false;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
