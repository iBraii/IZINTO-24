using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LionSpawner : MonoBehaviour
{
    private Spawning cmp_spwn;
    public GameObject[] lion_obj;
    public int maxSceneObjs;

    float timer = 0;
    public float max_timer = 4;

    public Vector3[] spawnPositions;
    // Start is called before the first frame update
    void Start()
    {
        cmp_spwn = GetComponent<Spawning>();
        cmp_spwn.obj_spwn_Array = lion_obj;
    }

    // Update is called once per frame
    void Update()
    {
        cmp_spwn.CounterUpdater();
        if (cmp_spwn.objActiveCounter < maxSceneObjs)
        {
            SpawnLion();
        }

    }

    void SpawnLion()
    {
        timer += Time.deltaTime;
        if (timer >= max_timer)
        {
            RechargeLife();
            cmp_spwn.ArraySpawnGeneretor(lion_obj[0], spawnPositions[Random.Range(0, spawnPositions.Length)]);

            timer = 0;
        }
    }

    void RechargeLife()
    {
        for (int i = 0; i < cmp_spwn.obj_spwn_Array.Length; i++)
        {
            if (cmp_spwn.obj_spwn_Array[i].activeSelf == false)
            {
                cmp_spwn.obj_spwn_Array[i].GetComponent<Enemy_LionModel>().enemyLife = 1;
            }
        }
    }
}
