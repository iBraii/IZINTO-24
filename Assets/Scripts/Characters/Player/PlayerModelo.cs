﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerModelo : MonoBehaviour
{
    public float spd_mov;
    public float jmp_force;
    public int atk_damage;
    public int playerLife;
    public bool grounded;
    public bool atk_active;
    public bool walk_active;

    // Start is called before the first frame update
    void Start()
    {
        atk_active = false;
        walk_active = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
