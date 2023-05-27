using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
    public string unitName;
    public int unitAtk;
    public int unitDef;

    public int maxHP;
    public int currentHP;

    public bool TakeDamage(int EnemyAtk)
    {
        if(unitDef < EnemyAtk){
            currentHP -= EnemyAtk - unitDef;
        }

        if(currentHP <= 0){
            return true;
        }
        else {
            return false;
        }
    }

    public void Heal(int amount)
    {
        currentHP += amount;
        if(currentHP > maxHP){
            currentHP = maxHP;
        }
    }
}
