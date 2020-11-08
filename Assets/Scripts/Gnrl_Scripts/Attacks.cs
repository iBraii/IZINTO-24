using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacks : MonoBehaviour
{
    private Rotatement cmp_rot;
    // Start is called before the first frame update
    void Start()
    {
        cmp_rot = GetComponent<Rotatement>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SwordAtk()
    {

    }
    public void Shield()
    {

    }
    public void SpearAtk(int atk_dmg, GameObject enemy_detected)
    {
        Debug.Log("insertar funcion que le pega al enemigo" + enemy_detected);
        //Funcion que haga daño al enemigo
    }
}
