using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Castle : MonoBehaviour {

    public Renderer rend;
	public GameSystem gameSystem;
    public int clickDmg = 10;

    public float healthMax = 100;
    public float health = 100;
	public float currentCastle = 1;
	public float castlesDestroyed = 0;


	// Use this for initialization
	void Start () {
		rend = GetComponent<Renderer>();

		gameSystem.castlesDestroyedText.text = "Castle #" + currentCastle;

	}
	
	// Update is called once per frame
	void Update () {
        gameSystem.castleHealthSlider.value = health;

        if(health <= 0)
        {
            gameSystem.gold += 10;
            gameSystem.goldCounter.text = "Gold: " + gameSystem.gold;
            health = healthMax;

			castlesDestroyed++;
			currentCastle++;
			gameSystem.castlesDestroyedText.text = "Castle #" + currentCastle;

        }
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
			gameSystem.gold += 1;
			gameSystem.goldCounter.text = "Gold: " + gameSystem.gold;
			transform.localScale = new Vector3(2.7f, 2.7f, 1f);
            GetDamage(clickDmg);
		}
	}

	void OnMouseExit() {
		rend.material.color = Color.white;
		transform.localScale = new Vector3(3f, 3f, 1f);
	}

	public void GetDamage(float _damage) 
	{
		health -= _damage;
		gameSystem.castleHealthText.text = "" + health;
		gameSystem.castleHealthSlider.value = health;
	}
}
