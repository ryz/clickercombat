using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Archer : MonoBehaviour {

    public GameSystem gameSystem;

    [HideInInspector] public Renderer rend;
    [HideInInspector] public bool isActive = false;

    public int level = 1;
    public int damage = 5;

    public float initialCost; // The cost for the first unit bought each
    public float currentCost;
    public float upgradeCost; // The current cost to upgrade
    public float upgradeCoefficient; // Constant, the price increase with each buy
    public int cyclesCompleted = 0; // Intervals of damage dealing completed

    // UI Stuff
    public Text levelCounter;
    public Text upgradeCostDisplay;
    public Slider cycleSlider;

    // Use this for initialization
    void Start() {
        rend = GetComponent<Renderer>();
 
        // Unit cost init
        //initialCost = 3;
        //upgradeCoefficient = 1.07f;

        upgradeCost = initialCost;

        // UI init
        levelCounter.text = "Lvl: " + level;
        upgradeCostDisplay.text = "Cost: " + initialCost;
        cycleSlider.value = 0;

        // Disable the slider as long as the unit is not unlocked
        cycleSlider.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update() {

        if (level <= 1)
        {
            upgradeCost = initialCost;
        }


        if (isActive)
        {
            rend.material.color = Color.white;
            SetUIUnit();
        }
        else
        {
            rend.material.color = Color.grey;
            gameSystem.goldCounter.text = "Gold: " + gameSystem.gold;
            upgradeCostDisplay.text = "Cost: " + initialCost;
            levelCounter.text = "Unlock";
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

            // Upgrade
            if (isActive && gameSystem.gold >= upgradeCost)
            {
                UpgradeUnit();
            }

            // Activate 
            if (!isActive && gameSystem.gold >= initialCost)
            {
                ActivateUnit();
            }

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

    void ActivateUnit()
    {
        gameSystem.gold -= initialCost;
        cycleSlider.gameObject.SetActive(true);
        isActive = true;
    }

    void UpgradeUnit()
    {
        gameSystem.gold -= upgradeCost;
        level++;

        UpdateUnitCost();
        SetUIUnit();

    }

    void UpdateUnitCost()
    {
        currentCost = upgradeCost;
        upgradeCost = currentCost * upgradeCoefficient;
    }

    void SetUIUnit()
    {
        // Set UI stuff
        gameSystem.goldCounter.text = "Gold: " + gameSystem.gold;
        upgradeCostDisplay.text = "Cost: " + upgradeCost;
        levelCounter.text = "Lvl: " + level;
    }

}
