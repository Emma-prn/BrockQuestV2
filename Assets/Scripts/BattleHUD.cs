using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BattleHUD : MonoBehaviour
{
    public TMP_Text nameText;
    public TMP_Text currentHPText;
    public TMP_Text maxHPText;

    public void SetHUD(Unit unit)
    {
        nameText.text = unit.unitName;
        currentHPText.text = unit.currentHP.ToString();
        maxHPText.text = " / " + unit.maxHP.ToString();
    }

    public void SetHP(int hp)
    {
        currentHPText.text = hp.ToString();
    }
}
