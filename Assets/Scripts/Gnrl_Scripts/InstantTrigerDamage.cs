using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantTrigerDamage : MonoBehaviour
{
    public string tag_name_obj;
    public int itm_dmg;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag(tag_name_obj))
        {
            if(other.GetComponent<PlayerController>())
            {
                if (GameObject.Find("Player").GetComponent<PlayerController>().inmune == false)
                {
                    other.GetComponent<PlayerController>().DamageItself(itm_dmg);
                }                   
            }
            if (other.GetComponent<Enemy_BossController>())
            {
                other.GetComponent<Enemy_BossController>().DamageItself(itm_dmg);
            }
            if (other.GetComponent<Enemy_LionController>())
            {
                other.GetComponent<Enemy_LionController>().DamageItself(itm_dmg);
            }
            if (other.GetComponent<Dummy>())
            {
                other.GetComponent<Dummy>().DamageDummy(itm_dmg);
            }
        }
    }
}
