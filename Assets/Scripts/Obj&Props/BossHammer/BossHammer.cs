using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHammer : MonoBehaviour
{
    private Movement cmp_mov;
    private TimersNTools cmp_tools;
    private Rotatement cmp_rot;
    public float time_to_up;
    private float timer;
    public float up_spd;
    public bool to_down;
    private GameObject bossCollider;
    // Start is called before the first frame update
    void Start()
    {
        cmp_mov = GetComponent<Movement>();
        cmp_tools = GetComponent<TimersNTools>();
        cmp_rot = GetComponent<Rotatement>();

        to_down = false;
        timer = 0;
        //cmp_tools.Timer_for_bools()
    }
    private void OnEnable()
    {
        to_down = false;
        timer = 0;
        //cmp_rot.InstantRotation(180, 0, 0, Space.World);
        transform.eulerAngles = new Vector3(0,0,0);

    }

    // Update is called once per frame
    void Update()
    {
        Proyectile();
        
    }

    public void Proyectile()
    {
        
        timer += Time.deltaTime;

        if (timer >= time_to_up && to_down == false)
        {
            transform.position = new Vector3(GameObject.Find("Player").transform.position.x, transform.position.y, GameObject.Find("Player").transform.position.z);
            cmp_rot.InstantRotation(180, 0, 0, Space.World);
            cmp_mov.Move_in_Y(up_spd * 0.7f, -1);
            to_down = true;
        }
        else if (timer < time_to_up)
        {

            cmp_mov.Move_in_Y(up_spd, 1);
        }

    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player")&&to_down==true)
        {
            other.gameObject.GetComponent<PlayerController>().DamageItself(1);
        }
        /*else if (other.gameObject.CompareTag("Boss") && to_down == true)
        {
            bossCollider = other.gameObject;
            Physics.IgnoreCollision(gameObject.GetComponent<Collider>(), bossCollider.GetComponent<Collider>(), true);
        }*/
    }
    
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Boss"))
        {
            bossCollider = collision.gameObject;
            Physics.IgnoreCollision(gameObject.GetComponent<Collider>(), bossCollider.GetComponent<Collider>(), true);
        }
        else if (to_down == true)
        {
            //GameObject.Find("Boss").GetComponent<Enemy_BossController>().Despawn();
            gameObject.SetActive(false);
        }
    }
}
