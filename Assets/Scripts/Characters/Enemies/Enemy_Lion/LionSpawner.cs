using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LionSpawner : MonoBehaviour
{
    private Spawning cmp_spwn;
    public GameObject[] Lions_obj;

    public Vector3 generate_pos;
    // Start is called before the first frame update
    void Start()
    {
        cmp_spwn = GetComponent<Spawning>();
        cmp_spwn.obj_spwn_Array = Lions_obj;

    }

    // Update is called once per frame
    void Update()
    {
        SpawnLion();
    }

    //---Falta personalizar segun el desafio---//
    void SpawnLion()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            cmp_spwn.ArraySpawnGeneretor(Lions_obj[0], generate_pos);
        }

        if (Input.GetKeyDown(KeyCode.K))
        {
            cmp_spwn.ArrayDespawn();
        }
    }
}
