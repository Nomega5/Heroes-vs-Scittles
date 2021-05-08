using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GuysBehavior : MonoBehaviour
{
    public GameObject personnage;
    public Animator animator;

    public float coolDown = 2f;
    public float startCoolDown;
    public bool isRage = false;
    public Image CoolDownImage;



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

        if (isRage)
        {
            if(coolDown > Time.time - startCoolDown)
            {
                CoolDownImage.fillAmount = (Time.time - startCoolDown) / coolDown;
            }
            else
            {
                isRage = false;
            }
        }

    }


    public void GoRageMode()
    {
        if (!isRage)
        {
            StartCoroutine(RageMode());
            isRage = true;
        }
    }

    public IEnumerator RageMode()
    {
        AttackScript weapon = GameObject.Find("Weapon").GetComponent<AttackScript>();

        animator.SetBool("onRage", true);
        weapon.BonusAttackTimes(2, 2); 
        yield return new WaitForSeconds(10);
        animator.SetBool("onRage", false);
        weapon.BonusAttackTimes(0.5f, 0.5f);
        StartCoolDown();
    }

    public void StartCoolDown()
    {
        startCoolDown = Time.time;
        isRage = true;
    }

}
