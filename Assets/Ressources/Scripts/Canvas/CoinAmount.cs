using TMPro;
using UnityEngine;

public class CoinAmount : MonoBehaviour
{
    public GameObject Player;
    private bool saved = false;
    void Start()
    {
        gameObject.GetComponent<TextMeshProUGUI>().text = PlayerPrefs.GetInt("CoinsAmount") + "";
    }

    void Update()
    {
        if (Player.GetComponent<CharacterHealth>().isAlive == false && !saved)
        {
            Debug.Log("Trésore Sauvegardé");
            PlayerPrefs.SetInt("CoinsAmount", int.Parse(gameObject.GetComponent<TextMeshProUGUI>().text));
            saved = true;
        }
    }
}
