using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundGameBehavior : MonoBehaviour
{
    public List<GameObject> BackGroundGame;
    void Start()
    {
        ChangeBG();
    }


    public void ChangeBG()
    {
        int i = 0;
        foreach (GameObject BG in BackGroundGame)
        {
            BackGroundGame[i].SetActive(false);
            i += 1;
        }
        int x = Random.Range(0, i);
        BackGroundGame[x].SetActive(true);
        Debug.Log(x);
    }
}
