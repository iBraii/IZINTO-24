using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombSpawner : MonoBehaviour
{
    private Spawning cmp_spwn;
    public GameObject[] bomb_obj;
    public int maxSceneObjs;

    float timer = 0;
    public float max_timer = 4;

    public Vector3[] spawnPositions;
    // Start is called before the first frame update
    void Start()
    {
        cmp_spwn = GetComponent<Spawning>();
        cmp_spwn.obj_spwn_Array = bomb_obj;
    }

    // Update is called once per frame
    void Update()
    {
        if (cmp_spwn.objActiveCounter < maxSceneObjs)
        {
            SpawnBomb();
        }

    }

    void SpawnBomb()
    {
        timer += Time.deltaTime;
        if (timer >= max_timer)
        {
            //RechargePosition();
            cmp_spwn.ArraySpawnGeneretor(bomb_obj[0], spawnPositions[Random.Range(0, spawnPositions.Length)]);
            cmp_spwn.latestGen.GetComponent<BombScript>().goplayerPosition1 = GameObject.FindWithTag("Player").transform.position;
            timer = 0;
        }
    }

    void RechargePosition()
    {
        for (int i = 0; i < cmp_spwn.obj_spwn_Array.Length; i++)
        {
            if (cmp_spwn.obj_spwn_Array[i].activeSelf == false)
            {
                if (cmp_spwn.obj_spwn_Array[i].GetComponent<SpearProyectil>().target != null)
                {
                    cmp_spwn.obj_spwn_Array[i].GetComponent<SpearProyectil>().RotToPlayer();
                }
            }
        }
    }
}
