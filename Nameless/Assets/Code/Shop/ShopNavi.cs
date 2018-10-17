using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopNavi : MonoBehaviour {

    public GameObject mainSection;
    public GameObject consumablesSection;

    public void openMain ()
    {
        mainSection.SetActive(true);
        consumablesSection.SetActive(false);
    }

    public void openConsumables ()
    {
        mainSection.SetActive(false);
        consumablesSection.SetActive(true);
    }

}
