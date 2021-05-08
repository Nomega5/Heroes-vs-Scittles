using System.Collections.Generic;
using UnityEngine;

public class BackGroundBehavior : MonoBehaviour
{
    public List<GameObject> BackGround;
    public GameObject comingSoon;
    void Start()
    {
        ChangeBG();
    }


    public void ChangeBG()
    {
        int i = 0;
        foreach (GameObject BG in BackGround)
        {
            BackGround[i].SetActive(false);
            i += 1;
        }
        int x = Random.Range(0, i);
        BackGround[x].SetActive(true);
        Debug.Log(x);
    }

    public void ComingSoon()
    {
        GameObject cPref = GameObject.Instantiate(comingSoon, Vector3.zero, Quaternion.identity, GameObject.FindGameObjectWithTag("Canvas").transform);
    }
}
