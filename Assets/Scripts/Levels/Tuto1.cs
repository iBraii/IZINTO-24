using System.Collections;
using System.Collections.Generic;
using System.Threading;
using TMPro;
using UnityEngine;

public class Tuto1 : MonoBehaviour
{
    public float tutoTimer,shieldTimer,lifeTimer,rhinoTimer, durationTimer;
    private PlayerModelo cmp_playerMod;
    private PlayerController cmp_playerCtrl;
    public bool changeIns, timerstart, lionsAwake;
    private LevelStats cmp_lvlSt;
    public GameObject I1, I2, I3, I4, I5, I6,I7, weapons,lion1,lion2,rhino,rhino2;
    // Start is called before the first frame update
    void Start()
    {
        tutoTimer = 0;
        rhinoTimer = 15;
        cmp_playerMod = GameObject.Find("Player").GetComponent<PlayerModelo>();
        cmp_playerCtrl = GameObject.Find("Player").GetComponent<PlayerController>();
        if (GameObject.Find("LevelStat"))
        {
            cmp_lvlSt = GameObject.Find("LevelStat").GetComponent<LevelStats>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
        if (timerstart == true)
        {
            tutoTimer += Time.deltaTime;
            
            if (GameObject.Find("LevelStat"))
            {
                cmp_lvlSt.timerChallenge = tutoTimer;
          
            }
        }
        else
        {
            tutoTimer = 0;
        }
        if (cmp_playerCtrl.shield.activeInHierarchy == true)
        {
            I6.SetActive(true);
            shieldTimer += Time.deltaTime;
            lifeTimer += Time.deltaTime;
            if (shieldTimer >= 5)
            {
                I6.SetActive(false);
            }
            if(lifeTimer >= 3)
            {
                I7.SetActive(true);
            }
            if (lifeTimer >= 8)
            {
                I7.SetActive(false);
            }
        }
        if (cmp_playerMod.weapon != null)

        {
            if (cmp_playerMod.weapon.GetComponent<UseDurationItm>().actualUses < 3)
            {
                I5.SetActive(true);
                durationTimer += Time.deltaTime;
                if (durationTimer >= 5)
                {
                    I5.SetActive(false);
                }
            }
        }
       
    }
    public void Instructions1()
    {
        cmp_lvlSt.challengeActive = true;
        timerstart = true;

        if (tutoTimer >= 2 && tutoTimer < 7)
        {
            I1.SetActive(true);
        }
        else if (tutoTimer >= 7)
        {
            I1.SetActive(false);
            weapons.SetActive(true);
            I2.SetActive(true);
            if (cmp_playerMod.using_weapon == true)
            {
                //Debug.Log("texto explicando ataques");
                if (changeIns == false)
                {
                    tutoTimer = 7;
                    changeIns = true;
                }
                /*if(tutoTimer >= 12)
                {
                    //Debug.Log("desaparecer ataquess");
                    I2.SetActive(false);
                }*/
                if (tutoTimer >= 16)
                {
                    I2.SetActive(false);
                    cmp_lvlSt.challengeActive = false;
                }
            }
        }
    }
    public void Instructions2()
    {
        cmp_lvlSt.challengeActive = true;
        timerstart = true;

        if (tutoTimer >= 2 && tutoTimer < 3)
        {
            I3.SetActive(true);
            lion1.SetActive(true);
            lion2.SetActive(true);
        }
        if (tutoTimer >= 2)
        {
            if (lion1.activeInHierarchy == false && lion2.activeInHierarchy == false)
            {
                cmp_lvlSt.challengeActive = false;
            }
        }

    }
    public void Instructions3()
    {
        
        cmp_lvlSt.challengeActive = true;
        timerstart = true;
        if (tutoTimer >= 2 && tutoTimer < 3)
        {
            I4.SetActive(true);
        }
        if(tutoTimer >= 7)
        {
            rhino.SetActive(true);
            rhino2.SetActive(true);
            rhinoTimer -= Time.deltaTime;
        }
        if(rhinoTimer <= 0)
        {
            rhino.SetActive(false);
            rhino2.SetActive(false);
            cmp_lvlSt.challengeActive = false;
        }

    }
}
