using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DropdownScript : MonoBehaviour {

	public Dropdown myDropdown;

	// Use this for initialization
	void Start () {
		myDropdown.onValueChanged.AddListener(delegate {
			myDropdownValueChangedHandler(myDropdown);
		});
	}

	void Destroy() {
		myDropdown.onValueChanged.RemoveAllListeners ();
	}
	private void myDropdownValueChangedHandler(Dropdown target) {
		Debug.Log ("selected: " + target.value);
	}

	// Update is called once per frame
	void Update () {
	
	}
}
