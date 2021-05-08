using System.Collections;
using UnityEngine;

public class GoShop : MonoBehaviour
{
    public Animator FontainAnimator;
    public bool isOnFontain;
    public GameObject fontainLight;

    public bool isPause = false;
    public GameObject ShopButton;
    public GameObject Store;

    public GameObject musicGestion;
    void Start()
    {
        isOnFontain = false;
        Store.SetActive(false);
    }


    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.name == "PersonnageSystem")
        {
            fontainLight.SetActive(true);
            isOnFontain = true;
            ShopButton.SetActive(true);
        }
    }

    void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.name == "PersonnageSystem")
        {
            fontainLight.SetActive(false);
            isOnFontain = false;
            ShopButton.SetActive(false);
        }
    }


    public IEnumerator GoPause()
    {
        if (!isPause)
        {
            FontainAnimator.SetBool("goBoutique", true);
            isPause = true;
            yield return new WaitForSeconds(1.60f);
            PausePlay();
        }
        else
        {
            FontainAnimator.SetBool("goBoutique", false);
            isPause = false;
            PausePlay();
            yield return new WaitForSeconds(1.60f);
        }
    }

    public void PausePlay()
    {
        MusicBehavior song = musicGestion.transform.GetComponent<MusicBehavior>();
        if (isPause)
        {
            Store.SetActive(true);
            song.MusicChoice(2);
            Time.timeScale = 0;
        }
        else
        {
            Store.SetActive(false);
            song.MusicChoice(0);
            Time.timeScale = 1;
        }
    }

    public void GoPausePause()
    {
        StartCoroutine(GoPause());
    }

}
