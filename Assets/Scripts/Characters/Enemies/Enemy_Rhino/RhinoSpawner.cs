using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RhinoSpawner : MonoBehaviour
{
    private Spawning cmp_spwn;
    public GameObject[] rhino_obj;
    public int maxSceneObjs;

    float timer = 0;
    public float max_timer = 4;

    public Vector3[] spawnPositions;
    // Start is called before the first frame update
    void Start()
    {
        cmp_spwn = GetComponent<Spawning>();
        cmp_spwn.obj_spwn_Array = rhino_obj;
    }

    // Update is called once per frame
    void Update()
    {
        cmp_spwn.CounterUpdater();
        if (cmp_spwn.objActiveCounter < maxSceneObjs)
        {
            SpawnRhino();
        }

    }
    /*public Vector3 RhinoDir(int dirRhino)
    {

        return
    }*/
    void SpawnRhino()
    {
        timer += Time.deltaTime;
        if (timer >= max_timer)
        {
            
            cmp_spwn.ArraySpawnGeneretor(rhino_obj[0], spawnPositions[Random.Range(0, spawnPositions.Length)]);
            timer = 0;
        }
    }

}
