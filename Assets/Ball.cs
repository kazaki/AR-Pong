using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Ball : MonoBehaviour {
	public Rigidbody rb;
	public bool started;
	public Text countText;
	public Text resultText;
	public bool running;

	private float sx;
	private float sy;

	private Vector3 startPos;
	private Quaternion startRot;
	private int redScore;
	private int blueScore;

	public AudioSource hit_sound;
	public AudioSource score_sound;

	private int maxScore;

	// Use this for initialization
	void Start () {
		redScore = 0;
		blueScore = 0;
		running = false;
		maxScore = 10;
	}

	void Reset() {
		transform.position = startPos;
		transform.rotation = startRot;
		GameReset ();
	}

	void UpdateText() {
		countText.text = "Red " + redScore.ToString() + " - " + blueScore.ToString() + " Blue";
	}

	public void GameReset() {
		startPos = transform.position;
		startRot = transform.rotation;
		sx = Random.Range (0, 2) == 0 ? -1 : 1;
		sy = Random.Range (0, 2) == 0 ? -1 : 1;
		rb.velocity = new Vector3 (Random.Range (1, 1.5f) * sx, Random.Range (1, 1.5f) * sy, 0);
	}

	public void GameFullReset() {
		resultText.text = "";
		redScore = 0;
		blueScore = 0;
		UpdateText ();
		Reset();
		rb.velocity = new Vector3 (0, 0, 0);
	}

	public void GameEnd() {
		Reset();
		rb.velocity = new Vector3 (0, 0, 0);
		if (blueScore >= maxScore) {
			resultText.text = "BLUE WON";
			resultText.color = new Color (0, 0, 255);
		} else if (redScore >= maxScore) {
			resultText.text = "RED WON";
			resultText.color = new Color (255, 0, 0);
		}
	}

	void OnCollisionEnter(Collision col) {
		if (col.gameObject.name == "RedWall") {
			score_sound.Play ();
			Debug.Log ("BLUE SCORED");
			Reset ();
			blueScore++;
			UpdateText ();
		} else if (col.gameObject.name == "BlueWall") {
			score_sound.Play ();
			Debug.Log ("RED SCORED");
			Reset ();
			redScore++;
			UpdateText ();
		} else if (col.gameObject.name != "Invis Wall UP" && col.gameObject.name != "Invis Wall Down") {
			hit_sound.Play ();
		}

		if (blueScore >= maxScore || redScore >= maxScore) {
			GameEnd ();
		}
	}

	// Update is called once per frame
	void Update () {

	}
}
