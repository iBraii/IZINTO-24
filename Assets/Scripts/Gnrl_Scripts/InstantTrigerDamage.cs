using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

public class InstantTrigerDamage : MonoBehaviour
{
    public string tag_name_obj;
    public int itm_dmg;
    private PlayerModelo cmp_playerMod;
    public bool atkUses = false;
    // Start is called before the first frame update
    void Start()
    {
        cmp_playerMod = GameObject.Find("Player").GetComponent<PlayerModelo>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnEnable()
    {
        atkUses = true;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (tag_name_obj == "Enemy")
        {
            if (other.gameObject.CompareTag(tag_name_obj) || other.gameObject.CompareTag("Boss"))
            { 
                if (other.GetComponent<Enemy_BossController>())
                {
                    other.GetComponent<Enemy_BossController>().DamageItself(itm_dmg);
                    if (cmp_playerMod.weapon != null)

                    {
                        if (atkUses == true)
                        {
                            cmp_playerMod.weapon.GetComponent<UseDurationItm>().actualUses--;
                            atkUses = false;
                        }
                    }
                }
                if (other.GetComponent<Enemy_LionController>())
                {
                    other.GetComponent<Enemy_LionController>().DamageItself(itm_dmg);
                    if (cmp_playerMod.weapon != null)

                    {
                        if (atkUses == true)
                        {
                            cmp_playerMod.weapon.GetComponent<UseDurationItm>().actualUses--;
                            atkUses = false;
                        }
                    }
                }
            }
        }
        else if (other.gameObject.CompareTag(tag_name_obj))
        {
            if(other.GetComponent<PlayerController>())
            {
                if (GameObject.Find("Player").GetComponent<PlayerController>().inmune == false && GameObject.Find("Player").GetComponent<PlayerController>().atkInmune == false)
                {
                    other.GetComponent<PlayerController>().DamageItself(itm_dmg);
                }                   
            }
            if (other.GetComponent<Enemy_BossController>())
            {
                other.GetComponent<Enemy_BossController>().DamageItself(itm_dmg);
                if (cmp_playerMod.weapon != null)

                {
                    if (atkUses == true)
                    {
                        cmp_playerMod.weapon.GetComponent<UseDurationItm>().actualUses--;
                        atkUses = false;
                    }
                }
            }
            if (other.GetComponent<Enemy_LionController>())
            {
                other.GetComponent<Enemy_LionController>().DamageItself(itm_dmg);
                if (cmp_playerMod.weapon != null)

                {
                    if (atkUses == true)
                    {
                        cmp_playerMod.weapon.GetComponent<UseDurationItm>().actualUses--;
                        atkUses = false;
                    }
                }
            }
            if (other.GetComponent<Dummy>())
            {
                other.GetComponent<Dummy>().DamageDummy(itm_dmg);
            }
        }
    }
}
