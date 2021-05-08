using UnityEngine;

public class ColBullet : MonoBehaviour
{

    private void OnCollisionEnter(Collision Col)
    {
        Destroy(gameObject);
    }
}
