using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.ProBuilder.MeshOperations;

public class TutorialController : MonoBehaviour
{
    private LevelStats cmp_lvlSts;
    private TransitionInScene cmp_scnChng;
    private SceneChange cmp_scnCh;

    public float timer;
    public int numPivotChallenge;
    public GameObject part1, player;
    /*public GameObject part2;
    public GameObject part3;*/

    public bool partStart, playerMov;
    public float nextPartTimer;
    public float partBreaksTime;
    public float moveTimer;
    public string nxtLvlNameScn;
    // Start is called before the first frame update
    void Start()
    {
        playerMov = true;
        numPivotChallenge = 0;
        nextPartTimer = 0;

        cmp_scnChng = GetComponent<TransitionInScene>();
        cmp_scnCh = GetComponent<SceneChange>();

        if (GameObject.Find("LevelStat"))
        {
            cmp_lvlSts = GameObject.Find("LevelStat").GetComponent<LevelStats>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        PartTimerPass();
        if (partStart == true)
        {
            StartPart();
        }
        if (playerMov == false)
        {
            player.GetComponent<PlayerModelo>().walk_active = false;
            player.GetComponent<PlayerController>().Anim.SetBool("Walking",false);
            moveTimer += Time.deltaTime;
            if (moveTimer > 2)
            {
                player.GetComponent<PlayerModelo>().walk_active = true;
                moveTimer = 0;
                playerMov = true;
            }

        }
    }

    void PartTimerPass()
    {
        if (cmp_lvlSts.challengeActive == false)
        {
            nextPartTimer += Time.deltaTime;
        }
        if (nextPartTimer >= partBreaksTime)
        {
            numPivotChallenge++;
            part1.GetComponent<Tuto1>().tutoTimer = 0;
            if (numPivotChallenge > 1)
            {
                cmp_scnChng.Change(1);          
            }
            playerMov = false;
            partStart = true;
            nextPartTimer = 0;
        }
    }

    void StartPart()
    {
        if (numPivotChallenge == 1)
        {
            part1.GetComponent<Tuto1>().Instructions1();
        }
        else if (numPivotChallenge == 2)
        {
            part1.GetComponent<Tuto1>().Instructions2();
        }
        else if (numPivotChallenge == 3)
        {
            part1.GetComponent<Tuto1>().Instructions3();
        }
        else if (numPivotChallenge >= 4)
        {
            cmp_scnCh.Change("Nivel 1");
        }

    }
}
