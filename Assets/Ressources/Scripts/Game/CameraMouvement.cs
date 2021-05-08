using UnityEngine;
/*
public class CameraMouvement : MonoBehaviour
{
    public GameObject character;
    void Start()
    {
        
    }

    void Update()
    {
        transform.position = new Vector3(character.transform.position.x, 0, -10);
    }
}

public class CameraMouvement : MonoBehaviour
{
    public GameObject player;
    public float timeOffset;
    public Vector3 posOffset;

    private Vector3 velocity;
    public GameObject character;

    void Update()
    {

        transform.position = Vector3.SmoothDamp(transform.position, player.transform.position + posOffset, ref velocity, timeOffset);

        if (character.transform.position.x < -8 && character.transform.position.x > -14)
        {
            float posxCharacter = Convert.ToSingle(character.transform.position.x);
            float posx = 13 + posxCharacter;
            posOffset.x = posx;
        }
        else
        {
            posOffset.x = 0;
        }
    }
}
*/


public class CameraMouvement : MonoBehaviour
{
    public GameObject player;
    public GameObject boss;
    public float timeOffset;
    public Vector3 posOffset;

    private Vector3 velocity;



    void Update()
    {
       if (player.GetComponent<CharacterHealth>().isAlive)
        {
            Vector3 target = player.transform.position;
            if (player.transform.position.x <= -3.98111f)
            {
                target = new Vector3(-3.98111f, player.transform.position.y, player.transform.position.z);
            }
            else if (player.transform.position.x >= 52.60686f)
            {
                target = new Vector3(52.60686f, player.transform.position.y, player.transform.position.z);
            }
            else
            {
                target = player.transform.position;
            }
            transform.position = Vector3.SmoothDamp(transform.position, target + posOffset, ref velocity, timeOffset);
        }

    }

}