using System.Collections;
using UnityEngine;

public class CharacBehavior : MonoBehaviour
{

    public Rigidbody2D rb;
    public float x;
    public float speed;
    public float maxJump;
    public int nbrJump;
    public bool canJump;
    private Vector3 velocity = Vector3.zero;
    public Vector2 TirDirection = Vector2.zero;

//    public GameObject helmet;
//    public GameObject armor;
//    public GameObject weapon1;
//    public GameObject weapon2;

//    public int weaponMode;        à suprimer !

    private float horizontalMovement;
    public Joystick joystick;


    void Start()
    {
        speed = 750f;
        maxJump = 15f;
        nbrJump = 0;
        canJump = true;
        TirDirection = Vector2.right;

//        weaponMode = 2;
//        armor.SetActive(false);
//        helmet.SetActive(true);
    }

    private void FixedUpdate()
    {
        MovePlayer(horizontalMovement);
    }

    void Update()
    {
        // Récupère les commandes de contrôle en ordonnée
        //        horizontalMovement = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        horizontalMovement = joystick.Horizontal * speed * Time.deltaTime;
        //        float x = Input.GetAxis("Horizontal");
        x = joystick.Horizontal;

        if (x > 0)
        {
            transform.eulerAngles = new Vector2(0, 0);

            TirDirection = Vector2.right;
//            weapon1.transform.GetComponent<SpriteRenderer>().sortingOrder = 2;    à garder

        }

        if (x < 0)
        {
            transform.eulerAngles = new Vector2(0, 180);

            TirDirection = -Vector2.right;
//            weapon1.transform.GetComponent<SpriteRenderer>().sortingOrder = 0;    à garder
        }


        float verticalMove = joystick.Vertical;

        if (verticalMove >= .5f)
        {
            StartCoroutine(Jumping());
        }

    /*
        if (Input.GetKeyDown("e"))
        {
            if (weaponMode == 1)
            {
                weaponMode = 2;
            }
            else
            {
                weaponMode = 1;
            }
        }
        WeaponMode(weaponMode, weapon1, weapon2);
    */
    }




    void MovePlayer(float _horizontalMovement)
    {
        Vector3 targetVelocity = new Vector2(_horizontalMovement, rb.velocity.y);
        rb.velocity = Vector3.SmoothDamp(rb.velocity, targetVelocity, ref velocity, .05f);
    }

    public void Jump()
    {
        if(nbrJump < 2)
        {
            rb.velocity += new Vector2(0, maxJump);
            nbrJump += 1;
        }
    }

    public IEnumerator Jumping()
    {
        if (canJump)
        {
            Jump();
            canJump = false;
            yield return new WaitForSeconds(0.3f);
            canJump = true;
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Ground"))
        {
            nbrJump = 0;
        }
    }

    /*
    void WeaponMode(int weaponMode, GameObject w1, GameObject w2)
    {
        if (weaponMode == 1)
        {
            w1.SetActive(true);
            w2.SetActive(false);
        }
        else
        {
            w1.SetActive(false);
            w2.SetActive(true);
        }
    }
    */

}
