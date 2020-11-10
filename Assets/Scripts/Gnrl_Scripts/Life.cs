using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Life : MonoBehaviour
{
    public int life;
    public int maxlife;

    public bool protec;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void LoseLife(int damage)
    {
        if (life > 0)
        {
            if (protec == true & damage > 0)
            {
                damage -= 1;
                protec = false;
            }
            life -= damage;
        }
    }
    public void GainLife(int addlife)
    {
        if(life < maxlife)
        {
            life += addlife;
        }
    }
    public void ProtectLife()
    {
        if (protec == false)
        {
            protec = true;
        }
    }
}
