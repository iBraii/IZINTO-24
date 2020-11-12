using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacks : MonoBehaviour
{
    private Rotatement cmp_rot;
    private Rigidbody cmp_rb;
    private Movement cmp_mov;

    public GameObject sword_obj;
    public GameObject spear_obj;

    public bool atacking;
    // Start is called before the first frame update
    void Start()
    {
        cmp_rot = GetComponent<Rotatement>();
        cmp_rb = GetComponent<Rigidbody>();
        cmp_mov = GetComponent<Movement>();
        atacking = false;

        if (sword_obj && sword_obj.activeSelf == true)
        {
            sword_obj.SetActive(false);
        }
        if (spear_obj && spear_obj.activeSelf == true)
        {
            spear_obj.SetActive(false);
        }

        
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void SwordAtk( int atk_dmg)
    {
        //atacking = true;
        if (sword_obj && sword_obj.activeSelf==false)
        {
            sword_obj.GetComponent<InstantTrigerDamage>().itm_dmg = atk_dmg;
            sword_obj.SetActive(true);
            //StartCoroutine(WaitCounterToFalseATK(time_atk, sword_obj));
        }
        

        if (atacking == true)
        {
            Vector3 strt_ply_rot = transform.eulerAngles;
            cmp_rot.ForLoopRot(0, -1, 0, 2.1f, true);

        }
    }

    public void SpearAtk( int atk_dmg)
    {
        if (spear_obj && spear_obj.activeSelf == false)
        {
            spear_obj.GetComponent<InstantTrigerDamage>().itm_dmg = atk_dmg;
            spear_obj.SetActive(true);
            //cmp_mov.Move_in_transform(-10);
        }

        if (atacking == true)
        {
            Vector3 strt_ply_rot = transform.eulerAngles;
            

        }
        //Debug.Log("insertar funcion que le pega al enemigo" + enemy_detected);
        //Funcion que haga daño al enemigo
    }

    public IEnumerator WaitCounterToFalseATK(float seconds, GameObject desact_obj)
    {
        if (atacking == true)
        {
            Debug.Log("StarCount");
            //cmp_modelo_Ply.walk_active = false;
            yield return new WaitForSeconds(seconds);
            atacking = false;
            if(desact_obj && desact_obj.activeSelf == true)
            {
                desact_obj.SetActive(false);
            }
            //cmp_modelo_Ply.walk_active = true;
            //Debug.Log("EndCount");
        }

    }
    public void WaitCounterCaller(float secs, GameObject dscObj)
    {
        StartCoroutine(WaitCounterToFalseATK(secs, dscObj));
    }
}
