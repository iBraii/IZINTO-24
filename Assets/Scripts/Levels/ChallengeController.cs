using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChallengeController : MonoBehaviour
{
    private LevelStats cmp_lvlSts;
    private SceneChange cmp_scnChng;

    private TXTGeneral cmp_showText;
    public GameObject baseDesTxt;
    public float timer;
    public int numPivotChallenge;
    public GameObject dsfOne;
    public GameObject dsfTwo;
    public GameObject dsfThree;


    public float nextChallTimer;
    public float challengeBreaksTime;
    public string nxtLvlNameScn;
    // Start is called before the first frame update
    void Start()
    {
        cmp_showText = GetComponent<TXTGeneral>();
        numPivotChallenge = 0;
        nextChallTimer = 0;

        cmp_scnChng = GetComponent<SceneChange>();

        if (GameObject.Find("LevelStat"))
        {
            cmp_lvlSts = GameObject.Find("LevelStat").GetComponent<LevelStats>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        ChallengeTimerPass();
        
    }

    void ChallengeTimerPass()
    {
        if (cmp_lvlSts.challengeActive == false)
        {
            nextChallTimer += Time.deltaTime;
        }
        if (nextChallTimer >= challengeBreaksTime)
        {
            numPivotChallenge++;
            StartChallenge();
            nextChallTimer = 0;
        }
    }

    void StartChallenge()
    {
        if (numPivotChallenge == 1)
        {
            dsfOne.GetComponent<Desafio1>().EmpezarDesafio();
            timer += Time.deltaTime; 
            cmp_showText.WriteSthTemporal("Desafio 1" /*10*/);
            baseDesTxt.SetActive(true);
        }
        else if (numPivotChallenge == 2)
        {
            dsfTwo.GetComponent<Desafio2>().EmpezarDesafio();
            cmp_showText.WriteSthTemporal("Desafio 2"/* 10*/);
            baseDesTxt.SetActive(true);
        }
        else if(numPivotChallenge == 3)
        {
            dsfThree.GetComponent<Desafio3>().EmpezarDesafio();
            cmp_showText.WriteSthTemporal("Desafio 3"/*, 10*/);
            baseDesTxt.SetActive(true);
        }
        else if (numPivotChallenge >=4)
        {
            cmp_scnChng.Change(nxtLvlNameScn);
        }

    }

    
}
