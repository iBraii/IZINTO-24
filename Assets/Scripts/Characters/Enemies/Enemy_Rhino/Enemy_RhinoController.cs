using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_RhinoController : MonoBehaviour
{
    private Enemy_RhinoModel cmp_RhinoMod;
    private Movement cmp_mov;
    private Rotatement cmp_rot;

    public float random_rot;

    // Start is called before the first frame update
    void Start()
    {
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
        cmp_mov.Move_in_transform(-25);
    }
    private void OnCollisionEnter(Collision other)
    {
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
    }
}
