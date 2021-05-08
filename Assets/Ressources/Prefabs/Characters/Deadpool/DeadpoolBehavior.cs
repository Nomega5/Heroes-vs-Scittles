using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadpoolBehavior : MonoBehaviour
{
    public GameObject personnage;
    public Animator animator;

    public int lifeHeal;
    public bool isHealing;


    void Update()
    {
        personnage = GameObject.FindGameObjectWithTag("Player");
        CharacBehavior persB = personnage.GetComponent<CharacBehavior>();
        CharacterHealth persH = personnage.GetComponent<CharacterHealth>();


        if (persB.x == 0)
        {
            animator.SetBool("walk", false);
        }
        else
        {
            animator.SetBool("walk", true);
        }

    }


    public void GoRageMode()
    {
        if (!isHealing)
        {
            StartCoroutine(HealPool());
        }
    }

    public IEnumerator HealPool()
    {
        isHealing = true;
        personnage.GetComponent<CharacterHealth>().TakeDamage(-lifeHeal);
        yield return new WaitForSeconds(5f);
        isHealing = false;
    }

}
