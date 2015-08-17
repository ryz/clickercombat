using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ClickCastle : MonoBehaviour {

	public Renderer rend;

	public GameSystem gameSystem;

	public Text goldCounter;

	public float gold = 0;


	// Use this for initialization
	void Start () {
		rend = GetComponent<Renderer>();
		goldCounter.text = "Gold: " + gold;

	}
	
	// Update is called once per frame
	void Update () {

	}

	void OnMouseEnter() {
		rend.material.color = Color.red;
		transform.localScale = new Vector3(2.9f, 2.9f, 1f);
	}

	void OnMouseOver() {
		if(Input.GetMouseButtonDown(0)) {

			transform.localScale = new Vector3(2.3f, 2.3f, 1f);
		}

		if(Input.GetMouseButtonUp(0)) {
			gold += 1;
			goldCounter.text = "Gold: " + gold;
			transform.localScale = new Vector3(2.7f, 2.7f, 1f);
		}
	}

	void OnMouseExit() {
		rend.material.color = Color.white;
		transform.localScale = new Vector3(3f, 3f, 1f);
	}


}
