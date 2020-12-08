using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PlayerView : MonoBehaviour
{
    private GameObject heart1;
    private GameObject heart2;
    private GameObject heart3;
    private GameObject spearImage;
    private GameObject swordImage;
    private GameObject shieldImage;
    public GameObject damageIndicator;

    private PlayerController cmp_ctrl;
    private PlayerModelo cmp_playerMod;
    
    
    public GameObject spearObj;
    public GameObject swordObj;
    // Start is called before the first frame update
    void Start()
    {
        cmp_ctrl = GetComponent<PlayerController>();
        cmp_playerMod = GetComponent<PlayerModelo>();
        heart1 = GameObject.Find("Heart1");
        heart2 = GameObject.Find("Heart2");
        heart3 = GameObject.Find("Heart3");
        swordImage = GameObject.Find("SwordImage");
        spearImage = GameObject.Find("SpearImage");
        shieldImage = GameObject.Find("Shield1");
        

    }

    // Update is called once per frame
    void Update()
    {
        LiveChecker();
        WeaponChecker();
        ShieldChecker();
    
    }
    void LiveChecker ()
    {
        if (cmp_playerMod.playerLife >= 3)
        {
            heart1.SetActive(true);
            heart2.SetActive(true);
            heart3.SetActive(true);
        }
        else if (cmp_playerMod.playerLife ==2)
        {
            heart1.SetActive(true);
            heart2.SetActive(true);
            heart3.SetActive(false);
        }
        else if (cmp_playerMod.playerLife ==1)
        {
            heart1.SetActive(true);
            heart2.SetActive(false);
            heart3.SetActive(false);
        }
        else if (cmp_playerMod.playerLife < 1)
        {
            heart1.SetActive(false);
            heart2.SetActive(false);
            heart3.SetActive(false);
        }
    }
    public void WeaponChecker()
    {
        if (cmp_playerMod.weapon != null)
        {
            if (cmp_playerMod.weapon.CompareTag("Sword"))
            {
                swordImage.SetActive(true);
                spearImage.SetActive(false);

                swordObj.SetActive(true);
                spearObj.SetActive(false);

            }
            else if (cmp_playerMod.weapon.CompareTag("Spear"))
            {
                spearImage.SetActive(true);
                swordImage.SetActive(false);

                spearObj.SetActive(true);
                swordObj.SetActive(false);
            }
            else
            {
                swordImage.SetActive(false);
                spearImage.SetActive(false);

                swordObj.SetActive(false);
                spearObj.SetActive(false);
            }
        }
        else
        {
            swordImage.SetActive(false);
            spearImage.SetActive(false);

            swordObj.SetActive(false);
            spearObj.SetActive(false);
        }
    }
    void ShieldChecker()
    {
        if(cmp_ctrl.protecting == true)
        {
            shieldImage.SetActive(true);
        }
        else
        {
            shieldImage.SetActive(false);
        }
    }
}
