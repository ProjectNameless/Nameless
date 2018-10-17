using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayCosumables : MonoBehaviour {

    public ConsumableSO item;

    public Image sprite;
    public Text nameValue;
    public Text attackValue;
    public Text healthValue;
    public Text speedValue;
    public Text costValue;

	// Use this for initialization
	void Start () {
        sprite.sprite = item.itemImage;
        nameValue.text = item.name;
        attackValue.text = item.attackBoost.ToString();
        speedValue.text = item.speedBoost.ToString();
        healthValue.text = item.healthBoost.ToString();
        costValue.text = item.cost.ToString();
	}
	
}
