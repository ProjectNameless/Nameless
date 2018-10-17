using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayCosumables : MonoBehaviour {

    public Text moneyText;
    string moneyString;
    int moneyValue;

    public ConsumableSO item;
    public GameObject buyCard;

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

    private void Update()
    {
        moneyString = moneyText.text;
        moneyValue = int.Parse(moneyString);
    }

    public void buyItem ()
    {
        if(moneyValue >= item.cost)
        {
            buyCard.SetActive(false);
            moneyText.text = (moneyValue - item.cost).ToString();
            //add inventory code, ect here
        }
    }

}
