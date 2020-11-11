using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject enemy;
    public float frecuencia;
    public float retardo;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("CrearEnemigo", retardo, frecuencia);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void CrearEnemigo()
    {
        Instantiate(enemy, transform.position, transform.rotation);
    }
}
