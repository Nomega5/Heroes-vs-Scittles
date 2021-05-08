using TMPro;
using UnityEngine;

public class GetDammageMonsterBehavior : MonoBehaviour
{
    public bool isDegats;
    public float hitMonster;
    public float kickPuissanceMonster;
    void Start()
    {
        isDegats = false;
    }


    public void GetDammageMonster(float dammage, float kickPuissance)
    {
        isDegats = true;
        hitMonster = dammage;
        kickPuissanceMonster = kickPuissance;
    }
}
