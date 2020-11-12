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
                other.GetComponent<PlayerController>().DamageItself(itm_dmg);
                Debug.Log("Player: auch");
            }
            if (other.GetComponent<Enemy_BossController>())
            {
                other.GetComponent<Enemy_BossController>().DamageItself(itm_dmg);
                Debug.Log("Boss: auch");
            }
            if (other.GetComponent<Enemy_LionController>())
            {
                other.GetComponent<Enemy_LionController>().DamageItself(itm_dmg);
                Debug.Log("Lion: auch");
            }
        }
    }
}
