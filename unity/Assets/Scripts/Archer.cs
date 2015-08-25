using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Archer : MonoBehaviour {

	public GameSystem gameSystem;

    [HideInInspector] public Renderer rend;
	
    public bool isActive = false;

    public int level = 1;
    public int damage = 5;
    public int upgradeCost;
	public int cyclesCompleted = 0;

	// UI Stuff
	public Text levelCounter;
	public Text upgradeCostDisplay;
	public Slider cycleSlider;
	
    // Use this for initialization
    void Start () {
        rend = GetComponent<Renderer>();
        upgradeCost = level * 10;

		levelCounter.text = "Lvl: " + level;
		upgradeCostDisplay.text = "Cost: " + upgradeCost;
		cycleSlider.value = 0;
    }
	
	// Update is called once per frame
	void Update () {
        upgradeCost = level * 10;
        upgradeCostDisplay.text = "Cost: " + upgradeCost;
        levelCounter.text = "Lvl: " + level;


        // If the unit is deactivated, grey them out
        if (!isActive)
        {
            rend.material.color = Color.grey;
        }
        else {
            rend.material.color = Color.white;
        }

    }

    void OnMouseEnter()
    {
        rend.material.color = Color.red;
        transform.localScale = new Vector3(0.9f, 0.9f, 1f);
    }

    void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {

            transform.localScale = new Vector3(0.7f, 0.7f, 1f);
        }

        if (Input.GetMouseButtonUp(0))
        {
            transform.localScale = new Vector3(0.9f, 0.9f, 1f);

            if (isActive && gameSystem.gold >= upgradeCost)
            {
                gameSystem.gold -= upgradeCost;
                level++;

                gameSystem.goldCounter.text = "Gold: " + gameSystem.gold;
                upgradeCostDisplay.text = "Cost: " + upgradeCost;
                levelCounter.text = "Lvl: " + level;
            }

            isActive = true;
        }
    }

    void OnMouseExit()
    {
        rend.material.color = Color.white;
        transform.localScale = new Vector3(1f, 1f, 1f);
    }

    public int CalcDamage(int level, int damage)
    {
        int dmg = level * damage;
        return dmg;
    }
}
