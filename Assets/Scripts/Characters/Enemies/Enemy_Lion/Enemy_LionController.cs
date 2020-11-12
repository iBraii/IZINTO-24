using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_LionController : MonoBehaviour
{
    private Life cmp_life;
    public bool EnemyHasHelmet;
    public bool follow;
    public GameObject helmet;
    private Enemy_LionModel cmp_enemyLionMod;
    private Movement cmp_mov;
    private Rotatement cmp_rot;
    public Transform target;


    // Start is called before the first frame update
    void Start()
    {
        cmp_life = GetComponent<Life>();
        EnemyHasHelmet = false;
        cmp_life.protec = EnemyHasHelmet;
        cmp_enemyLionMod = GetComponent<Enemy_LionModel>();
        cmp_mov = GetComponent<Movement>();
        cmp_rot = GetComponent<Rotatement>();
        follow = true;
        cmp_life.life = cmp_enemyLionMod.enemyLife;
    }

    // Update is called once per frame
    void Update()
    {
        cmp_enemyLionMod.enemyLife = cmp_life.life;
        CascoUpdater();
        Die();                   
        if(helmet.gameObject.activeInHierarchy == true)
        {
            Casco();
        }
        else
        {
            cmp_life.protec = false;
        }
        
        DetectIfClose();
        if(follow == true)
        {
            FollowPlayer();
        }    
    }
    void Casco()
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
    void Die()
    {
        if (cmp_enemyLionMod.enemyLife <= 0)
        {
            Debug.Log("Moriste");
            gameObject.SetActive(false);
        }
    }
    public void DamageItself(int dmg)
    {
        cmp_life.LoseLife(dmg);
    }
    void FollowPlayer()
    {
        if(gameObject.activeInHierarchy == true)
        {
            cmp_mov.Move_Towards(target, 3);
            cmp_rot.LookSmt(target, 50);
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
}
