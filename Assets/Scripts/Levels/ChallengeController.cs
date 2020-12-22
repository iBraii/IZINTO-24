using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChallengeController : MonoBehaviour
{
    private LevelStats cmp_lvlSts;
    private SceneChange cmp_scnChng;
    private TransitionInScene cmp_scnCh;

    private TXTGeneral cmp_showText;
    public GameObject baseDesTxt;
    public float timer;
    public int numPivotChallenge;
    public GameObject dsfOne;
    public GameObject dsfTwo;
    public GameObject dsfThree, T1,T2,T3;
    public bool partStart;

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
        cmp_scnCh = GetComponent<TransitionInScene>();
        
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
            if (numPivotChallenge == 1)
            {
                cmp_scnCh.transition = GameObject.Find("DeepToB1").GetComponent<Animator>();
                cmp_scnCh.Change(3);
            }
            else if(numPivotChallenge == 2)
            {
                cmp_scnCh.transition = GameObject.Find("DeepToB2").GetComponent<Animator>();
                cmp_scnCh.Change(3);
            }
            else if(numPivotChallenge == 3)
            {
                cmp_scnCh.transition = GameObject.Find("DeepToB3").GetComponent<Animator>();
                cmp_scnCh.Change(3);
            }
            StartChallenge();
            partStart = true;
            nextChallTimer = 0;
        }
    }

    void StartChallenge()
    {
        if (numPivotChallenge == 1)
        {
            dsfOne.GetComponent<Desafio1>().EmpezarDesafio();
            timer += Time.deltaTime;
            
        }
        else if (numPivotChallenge == 2)
        {
            dsfTwo.GetComponent<Desafio2>().EmpezarDesafio();
        }
        else if(numPivotChallenge == 3)
        {
            dsfThree.GetComponent<Desafio3>().EmpezarDesafio();
        }
        else if (numPivotChallenge >=4)
        {
            cmp_scnChng.Change("Nivel 3");
        }

    }

    
}
