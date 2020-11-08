using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Timers : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public bool Timer_for_bools(bool actual_bool, float max_timer)
    {
        bool rtrn_bool = actual_bool;
        float timer = 0;
        timer += Time.deltaTime;        
        if(timer >= max_timer)
        {
            Debug.Log("kou es puto");
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
