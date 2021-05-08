using TMPro;
using UnityEngine;

public class PlayerPrefControl : MonoBehaviour
{
    public int IsFirst;
    public GameObject gameCoinsAmount;

//    public List<List<PlayerPrefs>> InventoryWeapon;

    void Start()
    {
        PlayerPrefs.SetInt("GameCoinsAmount", 0);

        IsFirst = PlayerPrefs.GetInt("IsFirst");
        /*
        if (IsFirst == 0)
        {
            //Do stuff on the first time
            Debug.Log("first run");
            PlayerPrefs.SetInt("IsFirst", 1);

            PlayerPrefs.SetInt("CoinsAmount", 0);
            PlayerPrefs.SetInt("Guys", 1);
            PlayerPrefs.SetInt("WeaponSword", 1);

        }
        else
        {
            //Do stuff other times
            Debug.Log("welcome again!");
        }
        */

        /*
        PlayerPrefs.SetInt("GameCoinsAmount", 0);
        gameCoinsAmount.GetComponent<TextMeshProUGUI>().text = ": " + PlayerPrefs.GetInt("GameCoinsAmount");
        */
//        PlayerPrefs.SetString("")
//        InventoryWeapon.Add    
    }
    private void Update()
    {
        gameCoinsAmount.GetComponent<TextMeshProUGUI>().text = ": " + PlayerPrefs.GetInt("GameCoinsAmount");
    }

    public void DoubleMoney()
    {
        PlayerPrefs.SetInt("GameCoinsAmount", PlayerPrefs.GetInt("GameCoinsAmount")*2);
        PlayerPrefs.SetInt("CoinsAmount", PlayerPrefs.GetInt("CoinsAmount") + PlayerPrefs.GetInt("GameCoinsAmount"));
    }

    public void UpdateGameCoinsAmount()
    {
        gameCoinsAmount = GameObject.Find("GameCoinsAmount");
        gameCoinsAmount.GetComponent<TextMeshProUGUI>().text = ": " + PlayerPrefs.GetInt("GameCoinsAmount");
    }
}
