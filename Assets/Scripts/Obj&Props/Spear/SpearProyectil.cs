using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpearProyectil : MonoBehaviour
{
    private Movement cmp_mov;
    private Rotatement cmp_rot;
    private InstantTrigerDamage cmp_trgrDmg;

    public Transform target;
    public float movSpd;
    // Start is called before the first frame update
    void Start()
    {
        cmp_mov = GetComponent<Movement>();
        cmp_rot = GetComponent<Rotatement>();
        cmp_trgrDmg = GetComponent<InstantTrigerDamage>();

        if (GameObject.Find("Player"))
        {
            target = GameObject.Find("Player").transform;
            RotToPlayer(); //owo
        }
    }
    
    // Update is called once per frame
    void Update()
    {
        Move();
    }
    
    void Move()
    {
        cmp_mov.Move_in_transform(movSpd);
    }

    public void RotToPlayer()
    {
        if (GameObject.Find("Player"))
        {
            target = GameObject.Find("Player").transform;
        }
        //cmp_rot.InstantRotation(target.position.x, target.position.y, target.position.z, Space.World);
        cmp_rot.LookSmt(target.transform.position, 180);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag != cmp_trgrDmg.tag_name_obj)
        {
            gameObject.SetActive(false);
        }
    }
}
