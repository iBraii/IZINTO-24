using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundStatsUpdater : MonoBehaviour
{
    
    public bool grounded;
    public float distanceGround;
    public LayerMask groundLayer;



    // Start is called before the first frame update
    void Start()
    {
        
        grounded = false;


    }
    // Update is called once per frame
    void Update()
    {
        CheckGround();
        

    }

    void CheckGround()
    {
        grounded =
        Physics.Raycast(transform.position,
           Vector3.down,
           distanceGround,
           groundLayer
           );
    }
}
