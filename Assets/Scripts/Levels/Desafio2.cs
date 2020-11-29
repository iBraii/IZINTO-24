using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Desafio2 : MonoBehaviour
{
    private LevelStats cmp_levelSt;
    private Spawning cmp_spwn;

    public float timer;
    public bool timerstart;
    public int enemyCountForEnd;
    public List<float> opcionesTimer;
    public GameObject[] spawner;
    public GameObject[] itmsObj;
    public Vector3 itmPosGen;

    public int enemysBefDesf;
    
    // Start is called before the first frame update
    void Start()
    {
        cmp_spwn = GetComponent<Spawning>();
        if (GameObject.Find("LevelStat"))
        {
            cmp_levelSt = GameObject.Find("LevelStat").GetComponent<LevelStats>();
            enemysBefDesf = cmp_levelSt.enemyKillCounter;
        }
        //EmpezarDesafio2();
        
    }
    // Update is called once per frame
    void Update()
    {
        EnemyChecker();
        if (timerstart == true)
        {      
            Timer();
            if (GameObject.Find("LevelStat"))
            {
                cmp_levelSt.timerChallenge = timer;
            }
        }

        /*if (Input.GetKeyDown(KeyCode.P))
            {
            TerminarDesafio2();
        }
        
        if (Input.GetKeyDown(KeyCode.O))
        {
            EmpezarDesafio2();
        }*/
        
    }
    public void EmpezarDesafio()
    {
        timer = 0;
        timerstart = true;
        cmp_levelSt.challengeActive = true;
        for (int i = 0; i < spawner.Length; i++)
        {
            spawner[i].SetActive(true);
        }
    }
    public void TerminarDesafio2()
    {
        for (int i = 0; i < spawner.Length; i++)
        {
            spawner[i].SetActive(false);
        }
        cmp_levelSt.challengeActive = false;
        timerstart = false;
        if (timer < opcionesTimer[0])
        {
            cmp_spwn.ArraySpawnGeneretor(itmsObj[Random.Range(0,itmsObj.Length)],itmPosGen);
            cmp_spwn.ArraySpawnGeneretor(itmsObj[Random.Range(0, itmsObj.Length)], itmPosGen);
        }
        else if (timer < opcionesTimer[1])
        {
            cmp_spwn.ArraySpawnGeneretor(itmsObj[Random.Range(0, itmsObj.Length)], itmPosGen);
        }
    }
    public void Timer()
    {
        timer += Time.deltaTime;
    }

    public void EnemyChecker()
    {
        if (cmp_levelSt.enemyKillCounter >= enemyCountForEnd + enemysBefDesf && cmp_levelSt.challengeActive == true)
        {
            TerminarDesafio2();
            gameObject.SetActive(false);
        }
    }
}
