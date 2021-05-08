using TMPro;
using UnityEngine;

public class CoinsBehavior : MonoBehaviour
{
    public int value;
    public GameObject UI;

    void Start()
    {
        UI = GameObject.FindGameObjectWithTag("CoinAmount");
        value = 1;
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.name == "PersonnageSystem")
        {
            int coinUI = int.Parse(UI.GetComponent<TextMeshProUGUI>().text) + value;
            UI.GetComponent<TextMeshProUGUI>().text = coinUI + "";
            PlayerPrefs.SetInt("GameCoinsAmount", PlayerPrefs.GetInt("GameCoinsAmount") + value);
            
            Destroy(gameObject);
        }
    }

}
