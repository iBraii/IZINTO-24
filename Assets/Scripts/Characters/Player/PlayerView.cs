using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PlayerView : MonoBehaviour
{
    private GameObject heart1;
    private GameObject heart2;
    private GameObject heart3;
    private GameObject spearImage1, spearImage2, spearImage3;
    private GameObject swordImage1, swordImage2, swordImage3;
    private GameObject shieldImage;
    public GameObject damageIndicator;

    private PlayerController cmp_ctrl;
    private PlayerModelo cmp_playerMod;
    public Attacks cmp_atk;
    
    
    public GameObject spearObj;
    public GameObject swordObj;

    // Start is called before the first frame update
    void Start()
    {
        cmp_ctrl = GetComponent<PlayerController>();
        cmp_playerMod = GetComponent<PlayerModelo>();
        cmp_atk = GetComponent<Attacks>();

        heart1 = GameObject.Find("Heart1");
        heart2 = GameObject.Find("Heart2");
        heart3 = GameObject.Find("Heart3");

        swordImage1 = GameObject.Find("SwordImage1");
        swordImage2 = GameObject.Find("SwordImage2");
        swordImage3 = GameObject.Find("SwordImage3");

        spearImage1 = GameObject.Find("SpearImage1");
        spearImage2 = GameObject.Find("SpearImage2");
        spearImage3 = GameObject.Find("SpearImage3");

        shieldImage = GameObject.Find("Shield1");

        
    }

    // Update is called once per frame
    void Update()
    {
        LiveChecker();
        if (cmp_atk.atacking == false)
        {
            WeaponChecker();
        }
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
                swordObj.SetActive(true);
                spearObj.SetActive(false);
                if (cmp_playerMod.weapon.GetComponent<UseDurationItm>().actualUses >= 3)
                {
                    swordImage1.SetActive(true);
                    swordImage2.SetActive(true);
                    swordImage3.SetActive(true);

                    spearImage1.SetActive(false);
                    spearImage2.SetActive(false);
                    spearImage3.SetActive(false);
                }
                else if (cmp_playerMod.weapon.GetComponent<UseDurationItm>().actualUses == 2)
                {
                    swordImage1.SetActive(true);
                    swordImage2.SetActive(true);
                    swordImage3.SetActive(false);

                    spearImage1.SetActive(false);
                    spearImage2.SetActive(false);
                    spearImage3.SetActive(false);
                }
                else if (cmp_playerMod.weapon.GetComponent<UseDurationItm>().actualUses == 1)
                {
                    swordImage1.SetActive(true);
                    swordImage2.SetActive(false);
                    swordImage3.SetActive(false);

                    spearImage1.SetActive(false);
                    spearImage2.SetActive(false);
                    spearImage3.SetActive(false);
                }
                else if (cmp_playerMod.weapon.GetComponent<UseDurationItm>().actualUses > 1)
                {
                    swordImage1.SetActive(false);
                    swordImage2.SetActive(false);
                    swordImage3.SetActive(false);

                    spearImage1.SetActive(false);
                    spearImage2.SetActive(false);
                    spearImage3.SetActive(false);

                    swordObj.SetActive(false);
                    spearObj.SetActive(false);
                }

            }
            else if (cmp_playerMod.weapon.CompareTag("Spear"))
            {
                swordObj.SetActive(false);
                spearObj.SetActive(true);
                if (cmp_playerMod.weapon.GetComponent<UseDurationItm>().actualUses >= 3)
                {
                    swordImage1.SetActive(false);
                    swordImage2.SetActive(false);
                    swordImage3.SetActive(false);

                    spearImage1.SetActive(true);
                    spearImage2.SetActive(true);
                    spearImage3.SetActive(true);
                }
                else if (cmp_playerMod.weapon.GetComponent<UseDurationItm>().actualUses == 2)
                {
                    swordImage1.SetActive(false);
                    swordImage2.SetActive(false);
                    swordImage3.SetActive(false);

                    spearImage1.SetActive(true);
                    spearImage2.SetActive(true);
                    spearImage3.SetActive(false);
                }
                else if (cmp_playerMod.weapon.GetComponent<UseDurationItm>().actualUses == 1)
                {
                    swordImage1.SetActive(false);
                    swordImage2.SetActive(false);
                    swordImage3.SetActive(false);

                    spearImage1.SetActive(true);
                    spearImage2.SetActive(false);
                    spearImage3.SetActive(false);
                }
                else if (cmp_playerMod.weapon.GetComponent<UseDurationItm>().actualUses > 1)
                {
                    swordImage1.SetActive(false);
                    swordImage2.SetActive(false);
                    swordImage3.SetActive(false);

                    spearImage1.SetActive(false);
                    spearImage2.SetActive(false);
                    spearImage3.SetActive(false);

                    swordObj.SetActive(false);
                    spearObj.SetActive(false);
                }
            }
        }
        else
        {
            spearImage1.SetActive(false);
            spearImage2.SetActive(false);
            spearImage3.SetActive(false);

            swordImage1.SetActive(false);
            swordImage2.SetActive(false);
            swordImage3.SetActive(false);

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
