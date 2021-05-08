using System.Collections;
using UnityEngine;

public class EndBlood : MonoBehaviour
{

    private void Start()
    {
        StartCoroutine(BloodDisapair());
        Destroy(gameObject);
    }


    IEnumerator BloodDisapair()
    {
        yield return new WaitForSeconds(0f);
        Destroy(gameObject);
    }
}
