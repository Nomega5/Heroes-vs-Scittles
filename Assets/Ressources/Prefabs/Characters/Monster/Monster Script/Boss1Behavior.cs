using TMPro;
using UnityEngine;

public class Boss1Behavior : MonoBehaviour
{
    public Rigidbody2D rbPlayer;
    public Rigidbody2D rbMonster;
    public GameObject Player;

    public float maxJump;
    public int nbrJump;
    public float speed = 5f;
    public int direction;
    public float MP;
    public Animator animator;


    public int damageInCollision;

    public ParticleSystem particle;
    public GameObject canvas;
    public GameObject uiDegats;
    public float life;
    public GameObject coin;

    public bool bloodDelete = false;

    //    public TextMeshProUGUI displayNbMonster;




    private void Start()
    {
        //        displayNbMonster = GameObject.Find("NbMonster").GetComponent<TextMeshProUGUI>();
        maxJump = 10f;
        damageInCollision = 25;
        life = 1000;
        Player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        if (Player.GetComponent<CharacterHealth>().isAlive)
        {
            MP = rbMonster.GetComponent<Transform>().position.x - Player.GetComponent<Transform>().position.x;
        }

        if (MP < 100 && MP > -100)
        {
            speed = 1f;
            animator.SetBool("detected", true);
            if (MP > 0)
            {
                direction = -1;
            }
            else
            {
                direction = 1;
            }
        }
        else
        {
            speed = 0;
            animator.SetBool("detected", false);
        }


        if (nbrJump == 0)
        {
            Jump(direction);
            nbrJump += 1;
        }


        if (life <= 0)
        {
            ParticleSystem Blood = Instantiate(particle, transform.position, Quaternion.identity) as ParticleSystem;
            for (int i = 0; i < 30; i++)
            {
                GameObject Coin = Instantiate(coin, transform.position, Quaternion.identity) as GameObject;
            }
            Destroy(gameObject);
        }

        if (gameObject.GetComponent<GetDammageMonsterBehavior>().isDegats)
        {
            GetDammageMonster1(gameObject.GetComponent<GetDammageMonsterBehavior>().hitMonster, gameObject.GetComponent<GetDammageMonsterBehavior>().kickPuissanceMonster);
            gameObject.GetComponent<GetDammageMonsterBehavior>().isDegats = false;
        }

    }


    void Jump(int direction)
    {
        rbMonster.velocity += new Vector2(direction * speed, maxJump);
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Ground"))
        {
            nbrJump = 0;
        }

        if (col.gameObject.CompareTag("Player"))
        {
            CharacterHealth characterHealth = Player.transform.GetComponent<CharacterHealth>();
            characterHealth.TakeDamage(damageInCollision);
            nbrJump = 0;
        }
    }


    public void GetDammageMonster1(float dammage, float kickPuissance)
    {
        life -= dammage;
        KickJump(direction, kickPuissance);
        GameObject displayDegats = GameObject.Instantiate(uiDegats, Vector3.zero, Quaternion.identity, GameObject.FindGameObjectWithTag("Canvas").transform);

        displayDegats.transform.GetComponent<TextMeshProUGUI>().text = dammage + "";
    }

    void KickJump(int direction, float kickPuissance)
    {
        rbMonster.velocity += new Vector2(-direction * kickPuissance, 10);
    }

}
