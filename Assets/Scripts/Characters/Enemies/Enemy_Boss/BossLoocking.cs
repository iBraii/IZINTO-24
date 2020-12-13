using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossLoocking : MonoBehaviour
{
    public Enemy_BossModel cmp_bossMdl;
    public GameObject bossObj;

    public Transform playerTransform;
    public float aproxRange;
    public float offSetZ;
    private float rangeX;
    private float rangeZ;

    
    // Start is called before the first frame update
    void Start()
    {
        cmp_bossMdl = bossObj.GetComponent<Enemy_BossModel>();
        rangeX = bossObj.transform.position.x + aproxRange;
        rangeZ = bossObj.transform.position.z + offSetZ + aproxRange;
        //cmp_bossMdl
    }

    // Update is called once per frame
    void Update()
    {
        if(cmp_bossMdl.bossOnAtack != true)
        {

            //Eje X
            float newPosX;
            if (playerTransform.position.x >= (rangeX - (aproxRange * 2)) && playerTransform.position.x <= rangeX)
            {
                newPosX = playerTransform.position.x;
            }
            else if(transform.position.x > rangeX)
            {
                newPosX = rangeX;
            }
            else if(transform.position.x < (rangeX - (aproxRange * 2)))
            {
                newPosX = (rangeX - (aproxRange * 2));
            }
            else
            {
                newPosX = transform.position.x;
            }
            transform.position = new Vector3(newPosX, transform.position.y, transform.position.z);

            //Eje Z
            float newPosZ;
            if (playerTransform.position.z >= (rangeZ - (aproxRange * 2)) && playerTransform.position.z <= rangeZ)
            {
                newPosZ = playerTransform.position.z;
            }
            else if (transform.position.z > rangeZ)
            {
                newPosZ = rangeZ;
            }
            else if (transform.position.z < (rangeZ - (aproxRange * 2)))
            {
                newPosZ = (rangeZ - (aproxRange * 2));
            }
            else
            {
                newPosZ = transform.position.z;
            }
            transform.position = new Vector3(newPosX, transform.position.y, newPosZ);

        }
    }
}
