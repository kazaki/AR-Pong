using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class Exit : MonoBehaviour {

	public Button btn;

	// Use this for initialization
	void Start () {
		btn.onClick.AddListener (TaskOnClick);
	}

	void TaskOnClick() {
		Application.Quit();
	}
		
	// Update is called once per frame
	void Update () {
	
	}
}
