using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_LionController : MonoBehaviour
{
    private Life cmp_life;
    public bool EnemyHasHelmet,EnemyHasShield;
    public bool enemyWeapon;
    public bool follow;
    public GameObject helmet,shield;
    private Enemy_LionModel cmp_enemyLionMod;
    private Movement cmp_mov;
    private Rotatement cmp_rot;
    public Transform target;
    private Attacks cmp_atk;
    private GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        cmp_life = GetComponent<Life>();
        EnemyHasHelmet = false;
        cmp_life.protec = EnemyHasHelmet;
        cmp_enemyLionMod = GetComponent<Enemy_LionModel>();
        cmp_mov = GetComponent<Movement>();
        cmp_rot = GetComponent<Rotatement>();
        cmp_atk = GetComponent<Attacks>();
        follow = true;
        cmp_life.life = cmp_enemyLionMod.enemyLife;
        if (GameObject.Find("Player"))
        {
            target = GameObject.Find("Player").transform;
            player = GameObject.Find("Player");
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        cmp_enemyLionMod.enemyLife = cmp_life.life;
        CascoUpdater();
        ShieldUpdater();
        Die();
        AttackBoolUpdater();
        if (EnemyHasShield == true)
        {
            Shield();
        }
        else
        {
            cmp_life.protec = false;
        }

        DetectIfClose();
        if (follow == true)
        {
            if(target != null)
            {
                FollowPlayer();
            }
            
        }
        EnemyAttack();  
    }
    void Casco()
    {
        cmp_life.ProtectLife();
    }
    void Shield()
    {
        cmp_life.ProtectLife();
    }
    void CascoUpdater()
    {
        if (EnemyHasHelmet == false)
        {
            helmet.gameObject.SetActive(false);
        }

        else
        {
            helmet.gameObject.SetActive(true);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject == player && EnemyHasHelmet == true)
        {
            Casco();
        }
        else if (collision.gameObject == player && EnemyHasHelmet == false)
        {
            cmp_life.protec = false;
        }
    }
    void ShieldUpdater()
    {
        if (EnemyHasShield == false)
        {
            shield.gameObject.SetActive(false);
        }

        else
        {
            shield.gameObject.SetActive(true);
        }
    }
    void Die()
    {
        if (cmp_enemyLionMod.enemyLife <= 0)
        {
            if (GameObject.Find("LevelStat"))
            {
            GameObject.Find("LevelStat").GetComponent<LevelStats>().enemyKillCounter++;
            }
            gameObject.SetActive(false);
        }
    }
    public void DamageItself(int dmg)
    {
        cmp_life.LoseLife(dmg);
    }
    void FollowPlayer()
    {
        if(gameObject.activeInHierarchy == true & cmp_enemyLionMod.walk_active == true)
        {
            cmp_mov.Move_Towards(target, 3);
            cmp_rot.LookSmt(new Vector3(target.transform.position.x, transform.position.y, target.transform.position.z), 50 * Time.deltaTime);
        }
    }
    void DetectIfClose()
    {
        if(Vector3.Distance(target.transform.position, transform.position) < 1.5f)
        {
            follow = false;
        }
        else
        {
            follow = true;
        }
    }
    void AttackBoolUpdater()
    {
        cmp_enemyLionMod.atk_active = cmp_atk.atacking;
        if (cmp_enemyLionMod.atk_active == true)
        {
            cmp_enemyLionMod.walk_active = false;
        }
        else
        {
            cmp_enemyLionMod.walk_active = true;
        }
    }
    void EnemyAttack()
    {
        if (follow == false)
        {
            cmp_atk.atacking = true;
            cmp_atk.WaitCounterCaller(1, cmp_atk.sword_obj);
        }
        if (cmp_enemyLionMod.atk_active == true)
        {
            cmp_atk.SwordAtk(2);
        }
    }

    /*void AtqLanza()
    {
        if (follow == false)
        {
            cmp_atk.atacking = true;
            cmp_mov.Move_in_transform(10);
            cmp_atk.WaitCounterCaller(1, cmp_atk.spear_obj);
            /*if (enemy_detect != null)
            {
                //cmp_atk.SpearAtk(1, enemy_detect);
            }
        }

        if (cmp_enemyLionMod.atk_active == true)
        {
            cmp_atk.SpearAtk(2);
        }
    }*/
}
