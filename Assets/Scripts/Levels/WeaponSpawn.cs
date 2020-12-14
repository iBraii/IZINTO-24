using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class WeaponSpawn : MonoBehaviour
{
    private Spawning cmp_spawn;
    public GameObject[] weapons;
    public Vector3 weaponsPosGen;
    public float spawnTimer, maxSpawnTimer;
    // Start is called before the first frame update
    void Start()
    {
        cmp_spawn = GetComponent<Spawning>();
    }

    // Update is called once per frame
    void Update()
    {
        spawnTimer += Time.deltaTime;
        if(spawnTimer >= maxSpawnTimer)
        {
            cmp_spawn.ArraySpawnGeneretor(weapons[Random.Range(0, weapons.Length)], weaponsPosGen);
            //cmp_spawn.ArraySpawnGeneretor(weapons[Random.Range(0, weapons.Length)], weaponsPosGen);
            spawnTimer = 0;
        }    
    }
}
