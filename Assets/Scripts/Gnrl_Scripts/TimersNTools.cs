using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class TimersNTools : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    } 

    //---Timer en reparacion---
    public bool Timer_for_bools(bool actual_bool, float max_timer)
    {
        bool rtrn_bool = actual_bool;
        float timer = 0;

        /*for (timer = 0; timer <= max_timer; timer +=Time.deltaTime)
        {
            if (rtrn_bool == true)
            {
                rtrn_bool = false;
            }
            else
            {
                rtrn_bool = true;
            }
        }*/
        while(timer <= max_timer)
        {
            timer += Time.deltaTime;
            if (rtrn_bool == true)
            {
                rtrn_bool = false;
            }
            else
            {
                rtrn_bool = true;
            }
        }
        
        return rtrn_bool;
    }

}
