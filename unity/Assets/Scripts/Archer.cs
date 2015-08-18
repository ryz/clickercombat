using UnityEngine;
using System.Collections;

public class Archer : MonoBehaviour {

    [HideInInspector] public Renderer rend;
    public GameSystem gameSystem;
    public bool isActive = false;
    public int level = 1;
    public int damage = 5;
    public int upgradeCost;

    // Use this for initialization
    void Start () {
        rend = GetComponent<Renderer>();
        upgradeCost = level * 10;
    }
	
	// Update is called once per frame
	void Update () {
        upgradeCost = level * 10;
        gameSystem.goldCounter.text = "Gold: " + gameSystem.gold;
        gameSystem.archerUpgradeCost.text = "Cost: " + upgradeCost;
        gameSystem.archerLevelCounter.text = "Lvl: " + level;
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

            if (gameSystem.gold >= upgradeCost)
            {
                gameSystem.gold -= upgradeCost;
                level++;

                gameSystem.goldCounter.text = "Gold: " + gameSystem.gold;
                gameSystem.archerUpgradeCost.text = "Cost: " + upgradeCost;
                gameSystem.archerLevelCounter.text = "Lvl: " + level;
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
