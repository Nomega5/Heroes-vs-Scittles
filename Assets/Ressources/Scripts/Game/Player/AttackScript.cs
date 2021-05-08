using System.Collections.Generic;
using UnityEngine;

public class AttackScript : MonoBehaviour
{
    public bool isAttack;
    public float degatsAttack;
    public float pushCollisionAttack;

    public List<GameObject> weapons;
    public int weaponChoice;
    void Start()
    {
        isAttack = false;

        weaponChoice = PlayerPrefs.GetInt("WeaponChoice");
        WeaponChoice(weaponChoice);
    }


    public void IsAttack()
    {
        isAttack = true;
    }

    public void WeaponChoice(int choice)
    {
        int i = 0;
        foreach(GameObject g in weapons)
        {
            weapons[i].SetActive(false);
        
            i += 1;
        }
        weapons[choice].SetActive(true);
    }

    public void SetAttack(float att, float push)
    {
        degatsAttack = att;
        pushCollisionAttack = push;
    }

    public float GetAtt()
    {
        return degatsAttack;
    }

    public float GetPush()
    {
        return pushCollisionAttack;
    }

    public void BonusAttackplus(float att, float push)
    {
        degatsAttack += att;
        pushCollisionAttack += push;
    }

    public void BonusAttackTimes(float att, float push)
    {
        degatsAttack *= att;
        pushCollisionAttack *= push;
    }
}
