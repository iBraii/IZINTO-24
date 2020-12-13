using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_BossView : MonoBehaviour
{
    private Enemy_BossController cmp_bossCtrl;
    private Enemy_BossModel cmp_bossMdl;
    public Animator cmp_animCtrll;

    public GameObject weaponViewObj;
    //private float timeRecharWpn;

    // Start is called before the first frame update
    void Start()
    {
        cmp_bossCtrl = GetComponent<Enemy_BossController>();
        cmp_bossMdl = GetComponent<Enemy_BossModel>();
    }

    // Update is called once per frame
    void Update()
    {
        AtckChecker();
        DieChecker();
    }

    void AtckChecker()
    {
        if (cmp_bossMdl.bossOnAtack)
        {
            if(cmp_bossMdl.throwAtack == false && cmp_bossMdl.meleAtack == false)
            {
                cmp_animCtrll.SetBool("HammerAtk", false);
                cmp_animCtrll.SetBool("MeleeAtk", false);
            }
            if (cmp_bossMdl.throwAtack)
            {
                weaponViewObj.SetActive(false);
                cmp_animCtrll.SetBool("HammerAtk", true);

            }
            else if(cmp_bossMdl.meleAtack)
            {
                cmp_animCtrll.SetBool("MeleeAtk", true);
                cmp_bossCtrl.martilloMeleHit.SetActive(true);

            }

        }
        else
        {
            cmp_animCtrll.SetBool("HammerAtk", false);
            cmp_animCtrll.SetBool("MeleeAtk", false);
            weaponViewObj.SetActive(true);
            cmp_bossCtrl.martilloMeleHit.SetActive(false);
        }
    }

    void DieChecker()
    {
        if (cmp_bossMdl.bosslife <= 0)
        {
            cmp_animCtrll.SetBool("Dying", true);
        }
        else
        {
            cmp_animCtrll.SetBool("Dying", false);
        }

    }
}
