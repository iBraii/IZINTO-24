using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RhinoSpawner : MonoBehaviour
{
    private Spawning cmp_spwn;
    public GameObject[] rhinos_obj;

    public Vector3 generate_pos;
    float timer = 0;
    public float max_timer = 4;
    // Start is called before the first frame update
    void Start()
    {
        cmp_spwn = GetComponent<Spawning>();
        cmp_spwn.obj_spwn_Array = rhinos_obj;

    }

    // Update is called once per frame
    void Update()
    {
        SpawnRhyno();
    }

    //---Falta personalizar segun el desafio---//
    void SpawnRhyno()
    {
        /*
        if (Input.GetKeyDown(KeyCode.R))
        {
            cmp_spwn.ArraySpawnGeneretor(rhinos_obj[0], generate_pos);
        }

        if (Input.GetKeyDown(KeyCode.T))
        {
            cmp_spwn.ArrayDespawn();
        }
        */
        
        timer += Time.deltaTime;
        if (timer >= max_timer)
        {
            cmp_spwn.ArraySpawnGeneretor(rhinos_obj[0], generate_pos);
            timer = 0;
        }
    }
}
