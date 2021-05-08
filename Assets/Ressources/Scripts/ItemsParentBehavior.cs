using System.Collections.Generic;
using UnityEngine;

public class ItemsParentBehavior : MonoBehaviour
{
    public List<GameObject> weaponSlot;
    private int slotSave;
    void Start()
    {
        slotSave = PlayerPrefs.GetInt("WeaponChoice");
        DisplayWeaponSlot(slotSave);
    }



    public void DisplayWeaponSlot(int slot)
    {
        int i = 0;
        foreach(GameObject g in weaponSlot)
        {
            weaponSlot[i].SetActive(true);

            i += 1;
        }
        weaponSlot[slot].SetActive(false);
        PlayerPrefs.SetInt("WeaponChoice", slot);
    }
}
