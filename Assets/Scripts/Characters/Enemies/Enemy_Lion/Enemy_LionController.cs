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
    public Animator Anim;
    public bool dying = false;
    public float dieAnimTimer;
    public AudioClip attack;
    public AudioClip die;
    private AudioSource enemy;


    // Start is called before the first frame update
    void Start()
    {
        cmp_life = GetComponent<Life>();
        //EnemyHasHelmet = false;
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
    private void OnEnable()
    {
        EnemyHasHelmet = true;
        cmp_life.protec = EnemyHasHelmet;
        cmp_life.life = 1;
        dying = false;
        dieAnimTimer = 0;
        Shield();
    }

    // Update is called once per frame
    void Update()
    {
        cmp_enemyLionMod.enemyLife = cmp_life.life;
        EnemyHasHelmet = cmp_life.protec;
        CascoUpdater();
        ShieldUpdater();
        Die();
        AttackBoolUpdater();
        /*if (EnemyHasShield == true)
        {
            Shield();
        }
        else
        {
            cmp_life.protec = false;
        }*/

        DetectIfClose();
        if (follow == true)
        {
            if(target != null)
            {
                Anim.SetBool("Walking", true);
                FollowPlayer();
            }
            
        }
        else
        {
            Anim.SetBool("Walking", false);
        }
        if(cmp_atk.cooldownActive == false)
        {
            EnemyAttack();
        }
        else
        {

        }
        
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
    /*private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject == player && EnemyHasHelmet == true)
        {
            Casco();
        }
        else if (collision.gameObject == player && EnemyHasHelmet == false)
        {
            cmp_life.protec = false;
        }
    }*/  //Este colision enter no hacia nada aparentemente util, lo he comentado temporalmente
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
            Anim.SetBool("Die", true);
            dieAnimTimer += Time.deltaTime;
            dying = true;

            if (dieAnimTimer >= 1.5f)
            {
                if (GameObject.Find("LevelStat"))
                {
                    GameObject.Find("LevelStat").GetComponent<LevelStats>().enemyKillCounter++;
                }
                dying = false;
                gameObject.SetActive(false);
                dieAnimTimer = 0;
            }
            //gameObject.SetActive(false);
        }
    }
    public void DamageItself(int dmg)
    {
        cmp_life.LoseLife(dmg);
    }
    void FollowPlayer()
    {
        if(gameObject.activeInHierarchy == true && cmp_enemyLionMod.walk_active == true && dying == false)
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
            Anim.SetBool("Atack", true);
        }
        else
        {
            cmp_enemyLionMod.walk_active = true;
            Anim.SetBool("Atack", false);
        }
    }
    void EnemyAttack()
    {
        if (follow == false && dying == false)
        {
            cmp_atk.atacking = true;
            cmp_atk.WaitCounterCaller(1, cmp_atk.sword_obj);
        }
        if (cmp_enemyLionMod.atk_active == true)
        {
            cmp_atk.SwordAtk(cmp_enemyLionMod.atk_damage);
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
