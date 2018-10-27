using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Money : MonoBehaviour {

    public Text moneyValue;
    public int startMoney;
    public int currentMoney;

	// Use this for initialization
	void Start () {
        startMoney = int.Parse(moneyValue.text);
        currentMoney = startMoney;
    }
	
	// Update is called once per frame
	void Update () {
        currentMoney = int.Parse(moneyValue.text);
	}
}
