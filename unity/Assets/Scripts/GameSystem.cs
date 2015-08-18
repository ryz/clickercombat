using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameSystem : MonoBehaviour {

    public Text goldCounter;
	public Text dpsCounter;

	public Text castleHealthText;
	public Text castlesDestroyedText;

    public Archer[]	 archers;
    public ClickCastle clickCastle;
	
    public Slider castleHealthSlider;

    [HideInInspector] public float gold = 0;
    [HideInInspector] public float damagePerSecond = 0;

    // Use this for initialization
    void Start () {
        goldCounter.text = "Gold: " + gold;
        dpsCounter.text = "DPC: " + damagePerSecond;
        
        castleHealthSlider.maxValue = clickCastle.health;
        castleHealthSlider.value = clickCastle.health;
		castleHealthText.text = "" + clickCastle.health;

    }
	
	// Update is called once per frame
	void Update () {

		int archerTotalDmg = 0;
		goldCounter.text = "Gold: " + gold;

		foreach (var archer in archers) {
			if (archer.isActive) {
				archerTotalDmg += archer.CalcDamage(archer.level, archer.damage);
				archer.cycleSlider.value += 0.005f;

				if (archer.cycleSlider.value == 1) {
					archer.cyclesCompleted++;
					Debug.Log ("Cycles completed: " + archer.cyclesCompleted);
					archer.cycleSlider.value = 0;
					//Debug.Log(archer.CalcDamage(archer.level, archer.damage));
					//clickCastle.castleHealth -= archer.CalcDamage(archer.level, archer.damage);
					clickCastle.GetDamage (archer.CalcDamage (archer.level, archer.damage));
				}
			}
		}
		dpsCounter.text = "DPC: " + archerTotalDmg;
        
	}
}
