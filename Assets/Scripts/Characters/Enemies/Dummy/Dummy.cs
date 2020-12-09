using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.Rendering.UI;

public class Dummy : MonoBehaviour
{
    public Animator Anim;
    private float timer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= 1)
        {
            Anim.SetBool("Golpeado", false);
        }
    }
    public void DamageDummy(int dmg)
    {
        timer = 0;
        Anim.SetBool("Golpeado", true);
    }
}
