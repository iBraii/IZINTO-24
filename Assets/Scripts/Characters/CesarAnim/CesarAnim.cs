using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CesarAnim : MonoBehaviour
{
    public Animator Anim;
    public GameObject bombSpwn;
    public float animTime;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        if(bombSpwn.activeInHierarchy != false)
        {
            animTime = bombSpwn.GetComponent<BombSpawner>().timer;
        }
        
        if (animTime >= 1.78f)
        {
            Anim.SetBool("ThrowBomb", true);
        }
        else
        {
            Anim.SetBool("ThrowBomb", false);
        }
    }
}
