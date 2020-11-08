using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundStatsUpdater : MonoBehaviour
{
    
    public bool grounded;
    public bool overEnemy;
    public bool overHazard;

    public float distanceGround;
    public LayerMask groundLayer;
    public LayerMask enemyLayer;
    public LayerMask hazardLayer;



    // Start is called before the first frame update
    void Start()
    {

        grounded = false;
        overEnemy = false;
        overHazard = false;


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

        overEnemy =
        Physics.Raycast(transform.position,
           Vector3.down,
           distanceGround,
           enemyLayer
           );

        overHazard =
        Physics.Raycast(transform.position,
           Vector3.down,
           distanceGround,
           hazardLayer
           );
    }
}
