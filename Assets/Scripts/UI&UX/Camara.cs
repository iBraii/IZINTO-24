using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camara : MonoBehaviour
{
    public Transform player;
    public Vector3 offset, position;
    // Start is called before the first frame update
    void Start()
    {
        position.y = 13.7f;
        position.x = player.position.x;
        position.z = player.position.z - offset.z;
    }

    // Update is called once per frame
    void Update()
    {
        FollowPlayer();
    }
    void FollowPlayer()
    {
        position.y = 13.7f;
        position.x = player.position.x;
        position.z = player.position.z - offset.z;    
        if (position.z <= -50)
        {
            position.z = -50;
        }
        if (position.x <= 18)
        {
            position.x = 18;
        }
        else if (position.x >= 38f)
        {
            position.x = 38f;
        }
        
        transform.position = position;
    }
}
