using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReverseTime : MonoBehaviour
{
    public GameObject desf1;
    public GameObject desf2;
    public GameObject desf3;

    private float timerDef1;
    private float timerDef3;

    public GameObject lvlSt;
    public GameObject chllCtrl;

    public float showTime;
    // Start is called before the first frame update
    void Start()
    {
        timerDef1 = desf1.GetComponent<Desafio1>().maxChallengeTime;
        timerDef3 = desf3.GetComponent<Desafio3>().maxChallengeTime;
    }

    // Update is called once per frame
    void Update()
    {
        TimeView();
    }

    void TimeView()
    {
        if (lvlSt.GetComponent<LevelStats>().challengeActive == true)
        {
            if (chllCtrl.GetComponent<ChallengeController>().numPivotChallenge == 1)
            {
                showTime = timerDef1;
                timerDef1 -= Time.deltaTime;
            }
            else if (chllCtrl.GetComponent<ChallengeController>().numPivotChallenge == 2)
            {

            }
            else if (chllCtrl.GetComponent<ChallengeController>().numPivotChallenge == 3)
            {
                showTime = timerDef3;
                timerDef3 -= Time.deltaTime;
            }
            else
            {

            }

        }


    }
}
