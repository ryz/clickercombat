using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameSystem : MonoBehaviour {

    public Text goldCounter;
    public Text dpsCounter;

    public Archer archer;
    public ClickCastle clickCastle;

    public Slider archerCycleSlider;
    public int archerCyclesCompleted = 0;

    public Slider castleHealthSlider;



    [HideInInspector] public float gold = 0;
    [HideInInspector] public float damagePerSecond = 0;

    // Use this for initialization
    void Start () {
        goldCounter.text = "Gold: " + gold;
        dpsCounter.text = "DPS: " + damagePerSecond;
        archerCycleSlider.value = 0;
        castleHealthSlider.maxValue = clickCastle.castleHealth;
        castleHealthSlider.value = clickCastle.castleHealth;

    }
	
	// Update is called once per frame
	void Update () {
        if (archer.isActive)
        {
            archerCycleSlider.value += 0.005f;

            if(archerCycleSlider.value == 1)
            {
                archerCyclesCompleted++;
                Debug.Log("Cycles completed: " + archerCyclesCompleted);
                archerCycleSlider.value = 0;
                Debug.Log(archer.CalcDamage(archer.level, archer.damage));
                clickCastle.castleHealth -= archer.CalcDamage(1, 1);
                castleHealthSlider.value = clickCastle.castleHealth;
            }
        }
        
	}
}
