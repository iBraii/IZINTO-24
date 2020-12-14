using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class AnimDoor : MonoBehaviour
{
    public Animator cmp_anim;
    public bool open;
    public Collider realTimeCollider;
    private GameObject enemyRhino, enemyLion;
    public float timer;
    // Start is called before the first frame update
    void Start()
    {
        cmp_anim = GetComponentInChildren<Animator>();
        realTimeCollider = null;
    }

    // Update is called once per frame
    void Update()
    {
        //ToggleDoor();
        timer += Time.deltaTime;
        if(timer >= 1)
        {
            open = false;
            cmp_anim.SetBool("Open", false);
        }
    }
    void ToggleDoor()
    {
        if(open == true)
        {
            cmp_anim.SetBool("Open", true);
        }
        else
        {
            cmp_anim.SetBool("Open", false);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (/*other.gameObject.CompareTag("Rhino") ||*/ other.gameObject.CompareTag("Enemy"))
        {
            enemyLion = other.gameObject;

            if(enemyLion.GetComponent<Enemy_LionController>().canOpenLion == true)
            { 
                open = true;
                timer = 0;
                realTimeCollider = other.gameObject.GetComponent<Collider>();
                Physics.IgnoreCollision(realTimeCollider, gameObject.GetComponent<Collider>());
                ToggleDoor();
                //Debug.Log("owo");
                enemyLion.GetComponent<Enemy_LionController>().canOpenLion = false;               
            }
        }
        else if (other.gameObject.CompareTag("Rhino") /*|| other.gameObject.CompareTag("Enemy")*/)
        {
            enemyRhino = other.gameObject;
            
            if(enemyRhino.GetComponent<Enemy_RhinoController>().canOpenRhino == true)
            {
                open = true;
                timer = 0;
                realTimeCollider = other.gameObject.GetComponent<Collider>();
                Physics.IgnoreCollision(realTimeCollider, gameObject.GetComponent<Collider>());
                ToggleDoor();
                //Debug.Log("owo");
                enemyRhino.GetComponent<Enemy_RhinoController>().canOpenRhino = false;
            }        
        }

    }
   /* private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Rhino") || other.gameObject.CompareTag("Enemy"))
        {
            open = false;
            ToggleDoor();
        }
    }*/
}
