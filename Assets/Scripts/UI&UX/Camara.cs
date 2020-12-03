using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camara : MonoBehaviour
{
    public Transform player;
    public Vector3 offset;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 posicion = transform.position;
        posicion.x = player.position.x;
        posicion.z = player.position.z - offset.z;
        transform.position = posicion;
    }
}
