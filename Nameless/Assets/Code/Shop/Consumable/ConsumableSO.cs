using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "Item - Consumable", menuName = " Item/Consumable", order = 0)]

public class ConsumableSO : ScriptableObject {

    public new string name;
    public Sprite itemImage;
    public int healthBoost;
    public int speedBoost;
    public int attackBoost;
    public int cost;

}
