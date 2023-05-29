using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public enum BattleState {
    START,
    PLAYERTURN,
    ENEMYTURN,
    WON,
    LOST
}

public class BattleSystem : MonoBehaviour
{
    public BattleState state;

    public GameObject monsterPrefab;
    public GameObject playerPrefab;

    private Unit playerUnit;
    private Unit monsterUnit;

    public Transform monsterSpawn;

    public BattleHUD playerHUD;
    public BattleHUD monsterHUD;

    public TMP_Text dialogueText;

    void Start()
    {
        state = BattleState.START;
        StartCoroutine(SetUpBattle());
    }

    IEnumerator SetUpBattle()
    {
        GameObject monsterGO = Instantiate(monsterPrefab, monsterSpawn);
        monsterUnit = monsterGO.GetComponent<Unit>();
        playerUnit = playerPrefab.GetComponent<Unit>();

        dialogueText.text = monsterUnit.unitName + " apparait !";

        playerHUD.SetHUD(playerUnit);
        monsterHUD.SetHUD(monsterUnit);

        yield return new WaitForSeconds(2f);

        state = BattleState.PLAYERTURN;
        PlayerTurn();
    }

    IEnumerator PlayerAttack()
    {
        bool isDead = monsterUnit.TakeDamage(playerUnit.unitAtk);

        monsterHUD.SetHP(monsterUnit.currentHP);
        if(monsterUnit.unitDef > playerUnit.unitAtk) {
            dialogueText.text = "L'attaque n'a eu aucun effet !";
        } else {
            dialogueText.text = "L'attaque a été efficace !";
        }

        yield return new WaitForSeconds(2f);

        if(isDead){
            state = BattleState.WON;
            EndBattle();
        }
        else {
            state = BattleState.ENEMYTURN;
            StartCoroutine(MonsterTurn());
        }
    }

    IEnumerator MonsterTurn()
    {
        dialogueText.text = monsterUnit.unitName + " attaque !";

        yield return new WaitForSeconds(1f);

        bool isDead = playerUnit.TakeDamage(monsterUnit.unitAtk);

        playerHUD.SetHP(playerUnit.currentHP);

        yield return new WaitForSeconds(1f);

        if(isDead){
            state = BattleState.LOST;
            EndBattle();
        }
        else {
            state = BattleState.PLAYERTURN;
            PlayerTurn();
        }

    }

    void EndBattle()
    {
        if(state == BattleState.WON){
            dialogueText.text = "Brock a vaincu " + monsterUnit.unitName;
        }
        else if(state == BattleState.LOST){
            dialogueText.text = "Brock a perdu face au "+ monsterUnit.unitName;
        }
    }

    void PlayerTurn()
    {
        dialogueText.text = "Que faire ?";
    }

    IEnumerator PlayerHeal()
    {
        playerUnit.Heal(5);

        playerHUD.SetHP(playerUnit.currentHP);
        dialogueText.text = "Brock s'est soigné !";

        yield return new WaitForSeconds(2f);
        state = BattleState.ENEMYTURN;
        StartCoroutine(MonsterTurn());
    }

    public void OnAttackBtn()
    {
        if(state != BattleState.PLAYERTURN) {
            return;
        }

        StartCoroutine(PlayerAttack());
    }

    public void OnHealBtn()
    {
        if(state != BattleState.PLAYERTURN) {
            return;
        }

        StartCoroutine(PlayerHeal());
    }
}
