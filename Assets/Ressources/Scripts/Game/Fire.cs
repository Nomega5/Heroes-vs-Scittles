using UnityEngine;

public class Fire : MonoBehaviour
{
    public GameObject Projectil;
    public int Force;

    void Update()
    {
        if (Input.GetKeyDown("e"))
        {
            GameObject Bullet = Instantiate(Projectil, transform.position, Quaternion.identity) as GameObject;
            Bullet.GetComponent<Rigidbody2D>().velocity = GameObject.Find("PersonnageSystem").GetComponent<CharacBehavior>().TirDirection * Force * Time.deltaTime;
            Destroy(Bullet, 1f);
        }
    }
}
