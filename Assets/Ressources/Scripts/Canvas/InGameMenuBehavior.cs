using UnityEngine;

public class InGameMenuBehavior : MonoBehaviour
{
    public GameObject shop;
    public GameObject inventory;

    public GameObject shopSkin;
    public GameObject shopWeapon;

    public void OpenShop()
    {
        shop.SetActive(true);
        inventory.SetActive(false);
    }

    public void OpenInventory()
    {
        inventory.SetActive(true);
        shop.SetActive(false);
    }

    public void OpenShopSkin()
    {
        shopSkin.SetActive(true);
        shopWeapon.SetActive(false);
    }

    public void OpenShopWeapon()
    {
        shopWeapon.SetActive(true);
        shopSkin.SetActive(false);
    }


}
