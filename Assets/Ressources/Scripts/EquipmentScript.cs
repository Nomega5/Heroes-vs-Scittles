using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentScript : MonoBehaviour
{
    public List<GameObject> equipmentWeapon;

    private int saveChoice;
    void Start()
    {
        saveChoice = PlayerPrefs.GetInt("WeaponChoice");
        EquipmentWeaponChoice(saveChoice);
    }

    public void EquipmentWeaponChoice(int choice)
    {
        int i = 0;
        foreach (GameObject g in equipmentWeapon)
        {
            equipmentWeapon[i].SetActive(false);

            i += 1;
        }
        equipmentWeapon[choice].SetActive(true);
    }
}
