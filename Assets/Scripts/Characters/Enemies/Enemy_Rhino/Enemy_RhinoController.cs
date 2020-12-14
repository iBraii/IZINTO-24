using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_RhinoController : MonoBehaviour
{
    private Enemy_RhinoModel cmp_RhinoMod;
    private Movement cmp_mov;
    private Rotatement cmp_rot;
    private AudioSource audiorhino;

    public float random_rot;
    public AudioClip wall;
    public bool canOpenRhino;

    public float onStayTimer;


    // Start is called before the first frame update
    void Start()
    {
        canOpenRhino = true;
        cmp_RhinoMod = GetComponent<Enemy_RhinoModel>();
        cmp_mov = GetComponent<Movement>();
        cmp_rot = GetComponent <Rotatement>();
    }

    // Update is called once per frame
    void Update()
    {

            Move();
        
    }
    void Move()
    {
        cmp_mov.Move_in_transform(-cmp_RhinoMod.spd_mov);
    }
    private void OnCollisionEnter(Collision other)
    {
        onStayTimer = 0;
        if (other.gameObject.CompareTag("Wall"))
        {
            random_rot = Random.Range(135f, 225f);
            cmp_rot.InstantRotation(0, random_rot, 0, Space.Self);
        }
        if (other.gameObject.CompareTag("Rhino"))
        {
            random_rot = Random.Range(135f, 225f);
            cmp_rot.InstantRotation(0, random_rot, 0, Space.Self);
        }
        if (other.gameObject.CompareTag("Boss"))
        {
            random_rot = Random.Range(135f, 225f);
            cmp_rot.InstantRotation(0, random_rot, 0, Space.Self);
        }
        if (other.gameObject.CompareTag("Player"))
        {
            if(GameObject.Find("Player").GetComponent<PlayerController>().inmune == false)
            {
                other.gameObject.GetComponent<PlayerController>().DamageItself(1);
                //Physics.IgnoreCollision(other.gameObject.GetComponent<Collider>(), gameObject.GetComponent<Collider>(), true);
            }     
            //random_rot = Random.Range(135f, 225f);
            //cmp_rot.InstantRotation(0, random_rot, 0, Space.Self);
        }
        if (other.gameObject.CompareTag("Enemy"))
        {
            random_rot = Random.Range(135f, 225f);
            cmp_rot.InstantRotation(0, random_rot, 0, Space.Self);
        }
    }
 
    private void OnCollisionStay(Collision other)
    {
        onStayTimer += Time.deltaTime;

        if (onStayTimer >= 3.5f)
        {
            /*if (other.gameObject.CompareTag("Wall"))
            {*/
                random_rot = Random.Range(135f, 225f);
                cmp_rot.InstantRotation(0, random_rot, 0, Space.Self);
            /*}
            if (other.gameObject.CompareTag("Rhino"))
            {
                random_rot = Random.Range(135f, 225f);
                cmp_rot.InstantRotation(0, random_rot, 0, Space.Self);
            }*/
        }
    }
}
