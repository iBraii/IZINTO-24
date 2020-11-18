using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelStats : MonoBehaviour
{
    public int enemyKillCounter;
    public float timerChallenge;
    public bool challengeActive;
    public GameObject[] enemyArray;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timerChallenge += Time.deltaTime;
        EnemysCall();
    }
    public void EnemysCall()
    {
        if (challengeActive == false)
        {
            enemyArray = GameObject.FindGameObjectsWithTag("Enemy");
            for (int i = 0; i < enemyArray.Length; i++)
            {
                enemyArray[i].SetActive(false);
            }
        }
    }

}
