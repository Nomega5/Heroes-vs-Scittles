using System.Collections;
using UnityEngine;

public class SwordBehavior : MonoBehaviour
{
    public float degats;
    public float pushCollision;
    public AttackScript weapon;    // this
    public Animator hit1Animator;
    public bool getDegats;

    public float timeOffsetHit;
    public bool canAttack;

    public AudioSource audioSource;
    public AudioClip hitSwordSoundEffect;

    private void Awake()
    {
        degats = 20f;
        pushCollision = 2f;
        timeOffsetHit = 0.15f;

        weapon = GameObject.Find("Weapon").GetComponent<AttackScript>();
        weapon.SetAttack(degats, pushCollision);
        canAttack = true;
    }

    void Update()
    {
        weapon = GameObject.Find("Weapon").GetComponent<AttackScript>();
        bool isAttackScript = weapon.isAttack;
        if (isAttackScript && canAttack)
        {
            canAttack = false;
            degats = weapon.GetAtt();
            pushCollision = weapon.GetPush();
            StartCoroutine(HitTime());
        }
        /*
        if (Input.GetKeyDown("w"))
        {
            StartCoroutine(HitTime());
        }*/
    }


    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Monster"))
        {
            //Monster1Behavior monster1Behavior = col.transform.GetComponent<Monster1Behavior>();
            GetDammageMonsterBehavior dammageMonster = col.transform.GetComponent<GetDammageMonsterBehavior>();
            if (getDegats)
            {
                //monster1Behavior.GetDammageMonster1(degats, pushCollision);
                dammageMonster.GetDammageMonster(degats, pushCollision);
            }
        }

    }

    IEnumerator HitTime()
    {
        hit1Animator.SetBool("goHit", true); // annimation
        getDegats = true;
        PlayHitSoundEffect(); // son
        yield return new WaitForSeconds(timeOffsetHit);
        hit1Animator.SetBool("goHit", false);   // animation
        getDegats = false;
        GameObject.Find("Weapon").GetComponent<AttackScript>().isAttack = false;
        canAttack = true;
    }

    public void PlayHitSoundEffect()
    {
        if(audioSource != null && hitSwordSoundEffect != null)
        {
            audioSource.PlayOneShot(hitSwordSoundEffect);
        }

        Debug.Log("one one bro");
    }

}
