using System.Collections;
using TMPro;
using UnityEngine;


public class StageFunction : MonoBehaviour
{
    public int stage;
    public GameObject stageView;
    public GameObject endGamePanel;
    public Animator nextStageAnimator;
    public int monsterInLevel = 1;
    public int nbMonster;
    public int nbPieces;

    public GameObject scitlse;
    public GameObject goldCoin;
    public GameObject scitlseBoss1;

    public GameObject UI;

    private GameObject[] tabEnnemies;
    private TextMeshProUGUI displayNbMonster;
    public bool inTransition = false;
    public int bonusLvl;

    public GameObject musicGestion;


    void Start()
    {
        endGamePanel.SetActive(false);
        displayNbMonster = GameObject.Find("NbMonster").GetComponent<TextMeshProUGUI>();
        stage = 0;
        nbMonster = 10;
        nbPieces = 30;
        bonusLvl = 4;

        UI = GameObject.FindGameObjectWithTag("StageLVL");
        tabEnnemies = GameObject.FindGameObjectsWithTag("Monster");

        foreach(GameObject ennemie in tabEnnemies)
        {
            monsterInLevel += 1;
        }
        displayNbMonster.text = "Ennemi : " + monsterInLevel;
    }

    void Update()
    {
        monsterInLevel = 0;
        tabEnnemies = GameObject.FindGameObjectsWithTag("Monster");
        foreach (GameObject ennemie in tabEnnemies)
        {
            monsterInLevel += 1;
        }
        displayNbMonster.text = "Ennemi : " + monsterInLevel;
        

        if (monsterInLevel == 0 && stage == bonusLvl && !inTransition)
        {
            StartCoroutine(BonusLVL());
        }

        if (monsterInLevel == 0 && !inTransition)
        {
            //  Go next stage
            StartCoroutine(NextStage());
            if(stage == 10)
            {
                CreateBoss1();
            }
            //  Permet de ne pas passer à la scene suivante pendant la pause :)
            StartCoroutine(PauseScene());
            //  Créer les monstres
            StartCoroutine(CreateMonster());
        }


    }


    //  Méthodes
    IEnumerator NextStage()
    {
        stage += 1;
        UI.GetComponent<TextMeshProUGUI>().text = stage + "";
        nextStageAnimator.SetBool("nextStage", true);
        inTransition = true;
        yield return new WaitForSeconds(6f);
        nextStageAnimator.SetBool("nextStage", false);
        inTransition = false;
    }


    IEnumerator PauseScene()
    {
        inTransition = true;
        yield return new WaitForSeconds(20f);
        inTransition = false;
    }

    IEnumerator CreateMonster()
    {
        for (int i = 0; i < nbMonster; i++)
        {
            float x = Random.Range(-7.0f, 60.0f);
            Vector3 vec = new Vector3(x, 10f, 0f);
            GameObject S = Instantiate(scitlse, vec, Quaternion.identity) as GameObject;
            monsterInLevel += 1;
            yield return new WaitForSeconds(3);
        }
    }

    IEnumerator BonusLVL()
    {
        inTransition = true;

        UI.GetComponent<TextMeshProUGUI>().text = stage + "";
        nextStageAnimator.SetBool("nextStage", true);
        yield return new WaitForSeconds(6f);
        nextStageAnimator.SetBool("nextStage", false);

        //  Modifie la musique 
        MusicBehavior song = musicGestion.transform.GetComponent<MusicBehavior>();
        song.MusicChoice(1);

        for (int j = 0; j < nbPieces; j++)
        {
            float x = Random.Range(-7.0f, 60.0f);
            Vector3 vec = new Vector3(x, 10f, 0f);
            GameObject Gold = Instantiate(goldCoin, vec, Quaternion.identity) as GameObject;
            yield return new WaitForSeconds(0.5f);
        }
        yield return new WaitForSeconds(10f);
        song.MusicChoice(0);
        nbPieces += 25;
        bonusLvl += 10;
        inTransition = false;
    }

    public void GetStage()
    {
        endGamePanel.SetActive(true);
        stageView.GetComponent<TextMeshProUGUI>().text = stage + " waves";
    }

    public void CreateBoss1()
    {
        float x = Random.Range(-7.0f, 60.0f);
        Vector3 vec = new Vector3(x, 10f, 0f);
        GameObject sB1 = Instantiate(scitlseBoss1, vec, Quaternion.identity) as GameObject;
        monsterInLevel += 1;
    }
}