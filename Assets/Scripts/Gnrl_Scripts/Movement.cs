using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public Rigidbody cmp_rb;
    // Start is called before the first frame update
    void Start()
    {
        cmp_rb = GetComponent<Rigidbody>();
        cmp_rb.centerOfMass = new Vector3(0, 50, 0);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Move_in_X(float spd_mov, int dir_mov)
    {
        cmp_rb.velocity = new Vector3(spd_mov * dir_mov * Time.deltaTime, cmp_rb.velocity.y , cmp_rb.velocity.z);
    }

    public void Move_in_Y(float spd_mov, int dir_mov)
    {
        cmp_rb.velocity = new Vector3(cmp_rb.velocity.x,spd_mov * dir_mov * Time.deltaTime, cmp_rb.velocity.z);
    }

    public void Move_in_Z(float spd_mov, int dir_mov)
    {
        cmp_rb.velocity = new Vector3(cmp_rb.velocity.x, cmp_rb.velocity.y, spd_mov * dir_mov * Time.deltaTime);
    }

    public void Jump(float jmp_force)
    {
        cmp_rb.AddForce(new Vector3(0, jmp_force, 0));
    }

    public void Move_in_transform(float speed)
    {
        cmp_rb.velocity = transform.forward * speed;
    }
    public void Move_Towards(Transform target, float distance)
    {
        transform.position = Vector3.MoveTowards(gameObject.transform.position, new Vector3(target.position.x, transform.position.y, target.position.z), distance * Time.deltaTime);
    }

}
