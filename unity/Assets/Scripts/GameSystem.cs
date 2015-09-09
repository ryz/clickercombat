using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameSystem : MonoBehaviour {

    public Text goldCounter;
	public Text dpsCounter;

	public Text castleHealthText;
	public Text castlesDestroyedText;

    public Archer[]	archers;
    public Castle castle;
	
    public Slider castleHealthSlider;

    [HideInInspector] public float gold = 0;
    [HideInInspector] public float damagePerSecond = 0;

    // Use this for initialization
    void Start () {
        goldCounter.text = "Gold: " + gold;
        dpsCounter.text = "DPC: " + damagePerSecond;

        SetUICastleHealth();

    }
	
	// Update is called once per frame
	void Update () {

		float archerTotalDmg = 0;
		goldCounter.text = "Gold: " + gold;

		foreach (var archer in archers) {
			if (archer.isActive) {
				archerTotalDmg += archer.CalcDamage(archer.level, archer.initialDamage);
				archer.cycleSlider.value += 0.005f;

				if (archer.cycleSlider.value == 1) {
					archer.cyclesCompleted++;
					Debug.Log (archer.name + " has cycles completed: " + archer.cyclesCompleted);
					archer.cycleSlider.value = 0;
					//Debug.Log(archer.CalcDamage(archer.level, archer.damage));
					//castle.castleHealth -= archer.CalcDamage(archer.level, archer.damage);
					castle.GetDamage(archer.CalcDamage (archer.level, archer.initialDamage));
				}
			}
		}
		dpsCounter.text = "DPC: " + archerTotalDmg;

        if(Input.GetKeyDown("p")) 
        {
            gold += 10000;
        }
	}

    public void SetUICastleHealth()
    {
        castleHealthSlider.maxValue = castle.health;
        castleHealthSlider.value = castle.health;
        castleHealthText.text = "" + Mathf.RoundToInt(castle.health);
    }

    // Custon version of Math.Round, because Unity does not support rounding to decimal places
    public static float RoundDecimal(float value, int digits)
    {
        float mult = Mathf.Pow(10.0f, (float)digits);
        return Mathf.Round(value * mult) / mult;
    }
}
