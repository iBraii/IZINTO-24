using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Desafio1 : MonoBehaviour
{
    private LevelStats cmp_levelSt;
    private Spawning cmp_spwn;
    private PlayerModelo cmp_plyMod;

    public float timer;
    public bool timerstart;
    public float maxChallengeTime;
    public GameObject[] spawner;
    public GameObject[] itmsObj;
    public Vector3 itmPosGen;


    // Start is called before the first frame update
    void Start()
    {
        cmp_spwn = GetComponent<Spawning>();
        if (GameObject.Find("Player"))
        {
            cmp_plyMod = GameObject.Find("Player").GetComponent<PlayerModelo>();
        }
        if (GameObject.Find("LevelStat"))
        {
            cmp_levelSt = GameObject.Find("LevelStat").GetComponent<LevelStats>();
        }

    }
    // Update is called once per frame
    void Update()
    {
        TimeChecker();
        if (timerstart == true)
        {
            Timer();
            if (GameObject.Find("LevelStat"))
            {
                cmp_levelSt.timerChallenge = timer;
            }
        }

        /*if (Input.GetKeyDown(KeyCode.M))
        {
            TerminarDesafio3();
        }*/

        if (Input.GetKeyDown(KeyCode.M))

        {
            EmpezarDesafio1();
        }
        if (Input.GetKeyDown(KeyCode.K))
        {
            TerminarDesafio1();
        }

    }
    public void EmpezarDesafio1()
    {
        timer = 0;
        timerstart = true;
        cmp_levelSt.challengeActive = true;
        for (int i = 0; i < spawner.Length; i++)
        {
            spawner[i].SetActive(true);
        }
    }
    public void TerminarDesafio1()
    {
        for (int i = 0; i < spawner.Length; i++)
        {
            spawner[i].SetActive(false);
            Debug.Log(i);
        }
        cmp_levelSt.challengeActive = false;
        timerstart = false;
        if (cmp_plyMod.playerLife >= 3)
        {
            cmp_spwn.ArraySpawnGeneretor(itmsObj[Random.Range(0, itmsObj.Length)], itmPosGen);
            cmp_spwn.ArraySpawnGeneretor(itmsObj[Random.Range(0, itmsObj.Length)], itmPosGen);
            Debug.Log("2 armas");
        }
        else if (cmp_plyMod.playerLife == 2)
        {
            cmp_spwn.ArraySpawnGeneretor(itmsObj[Random.Range(0, itmsObj.Length)], itmPosGen);
            Debug.Log("1 arma");
        }
        else
        {
            Debug.Log("ninguna arma");
        }
    }
    public void Timer()
    {
        timer += Time.deltaTime;
    }
    public void TimeChecker()
    {
        if (timer >= maxChallengeTime & cmp_levelSt.challengeActive == true)
        {
            TerminarDesafio1();
            gameObject.SetActive(false);
        }
    }
}


