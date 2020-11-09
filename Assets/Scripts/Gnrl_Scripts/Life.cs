using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Life : MonoBehaviour
{
    public int life;
    public int maxlife;
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
        if(life > 0)
        {
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

    }
}
