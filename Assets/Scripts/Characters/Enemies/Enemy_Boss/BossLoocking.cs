using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossLoocking : MonoBehaviour
{
    public Enemy_BossModel cmp_bossMdl;
    public GameObject bossObj;

    public Transform playerTransform;
    public float aproxRange;
    private float range;

    
    // Start is called before the first frame update
    void Start()
    {
        cmp_bossMdl = bossObj.GetComponent<Enemy_BossModel>();
        range = bossObj.transform.position.x + aproxRange;
        //cmp_bossMdl
    }

    // Update is called once per frame
    void Update()
    {
        if(cmp_bossMdl.bossOnAtack != true)
        {

            //Eje X
            float newPosX;
            if (playerTransform.position.x >= (range - (aproxRange * 2)) && playerTransform.position.x <= range)
            {
                newPosX = playerTransform.position.x;
            }
            else if(transform.position.x > range)
            {
                newPosX = range;
            }
            else if(transform.position.x < (range - (aproxRange * 2)))
            {
                newPosX = (range - (aproxRange * 2));
            }
            else
            {
                newPosX = transform.position.x;
            }
            transform.position = new Vector3(newPosX, transform.position.y, transform.position.z);

            //Eje Z
            float newPosZ;
            if (playerTransform.position.z >= (range - (aproxRange * 2)) && playerTransform.position.z <= range)
            {
                newPosZ = playerTransform.position.z;
            }
            else if (transform.position.z > range)
            {
                newPosZ = range;
            }
            else if (transform.position.z < (range - (aproxRange * 2)))
            {
                newPosZ = (range - (aproxRange * 2));
            }
            else
            {
                newPosZ = transform.position.z;
            }
            transform.position = new Vector3(newPosX, transform.position.y, newPosZ);

        }
    }
}
