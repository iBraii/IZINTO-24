using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Desafio2 : MonoBehaviour
{
    private LevelStats cmp_levelSt;

    public float timer;
    public bool timerstart;
    public List<float> opcionesTimer;
    public GameObject[] spawner;
    // Start is called before the first frame update
    void Start()
    {
        if (GameObject.Find("LevelStat"))
        {
        cmp_levelSt = GameObject.Find("LevelStat").GetComponent<LevelStats>();
        }
        EmpezarDesafio2();
    }
    // Update is called once per frame
    void Update()
    {
        if (timerstart == true)
        {      
            Timer();
            if (GameObject.Find("LevelStat"))
            {
                cmp_levelSt.timerChallenge = timer;
            }
        }

        if (Input.GetKeyDown(KeyCode.P))
            {
            TerminarDesafio2();
        }
        
        if (Input.GetKeyDown(KeyCode.O))
        {
            EmpezarDesafio2();
        }
        
    }
    public void EmpezarDesafio2()
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
            Debug.Log("2 armas");
        }
        else if (timer < opcionesTimer[1])
        {
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
}
