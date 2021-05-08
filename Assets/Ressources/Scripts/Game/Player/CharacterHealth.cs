using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CharacterHealth : MonoBehaviour
{
    public int maxHealth = 100;
    public bool isAlive = true;
    public int currentHealth;
    public bool isInvicible = false;

    public HealthBar healthBar;
    public GameObject stage;

    public SpriteRenderer graphics;
    public List<SpriteRenderer> myGraphics = new List<SpriteRenderer>();
//    public List<GameObject> myBody = new List<GameObject>();

    public float invincibilityFlashDelay;
    public float invincibilityDelay;

    void Start()
    {
        healthBar = GameObject.Find("HealthBar").GetComponent<HealthBar>();
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        invincibilityFlashDelay = 0.15f;
        invincibilityDelay = 0.75f;

    }

    void Update()
    {
        if (Input.GetKeyDown("h"))
        {
            TakeDamage(-10);
        }

        if (currentHealth <= 0 && isAlive)
        {
            StageFunction s = stage.transform.GetComponent<StageFunction>();
            s.GetStage();
            IsDead();
//            Destroy(gameObject);
            isAlive = false;
        }
    }


    public void GetHealth(int life)
    {
        currentHealth += life;
        healthBar.SetHealth(currentHealth);
    }
    public void TakeDamage(int damage)
    {
        if (!isInvicible)
        {
            currentHealth -= damage;
            healthBar.SetHealth(currentHealth);
            isInvicible = true;
            StartCoroutine(InvincibilityFlash());
            StartCoroutine(InvincibilityDelay());
        }
    }

    public IEnumerator InvincibilityFlash()
    {
        while (isInvicible)
        {
            InvulnerableRefresh(0f);
            yield return new WaitForSeconds(invincibilityFlashDelay);
            InvulnerableRefresh(1f);
            yield return new WaitForSeconds(invincibilityFlashDelay);
        }
    }

    public IEnumerator InvincibilityDelay()
    {
        yield return new WaitForSeconds(invincibilityDelay);
        isInvicible = false;
    }

    private void InvulnerableRefresh(float alpha)
    {
        for (int i = 0; i < myGraphics.Count; i++)
        {
            myGraphics[i].color = new Color(1f, 1f, 1f, alpha);
        }
    }

    private void IsDead()
    {
        for (int i = 0; i < myGraphics.Count; i++)
        {
            myGraphics[i].color = new Color(1f, 1f, 1f, 0f);
        }
    }
}
