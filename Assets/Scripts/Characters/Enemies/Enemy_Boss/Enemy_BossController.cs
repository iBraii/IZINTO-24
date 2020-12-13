using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_BossController : MonoBehaviour
{
    private Life cmp_life;
    private Enemy_BossModel cmp_enemy_model;
    private Spawning cmp_spwn;
    public GameObject ply;
    public float dieAnimTimer;
    public bool dying;
    public float numForTimer;
    public float atackTimer;
    public float waitAtackTimer;

    public float[] timePatternsArray;

    public GameObject martiloProyectil;
    public GameObject martilloMeleHit;
    private Vector3 boss_pos;
    public GameObject spwnHammPoint;

    public Transform myTransform;
    public Transform playerTransform;

    public List<Transform> martilloPosiciones;
    //public bool golpeAlSuelo;
    /*public int lugarGolpeMartillo;
    public float tMartillo;
    public float tMVolverInicio;
    public float tMSiguienteataque;*/

    // Start is called before the first frame update
    void Start()
    {
        cmp_life = GetComponent<Life>();
        cmp_enemy_model = GetComponent<Enemy_BossModel>();
        cmp_spwn = GetComponent<Spawning>();

        cmp_life.life = cmp_enemy_model.bosslife;       
        GameObject ply = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        //GolpeconMartillo();

        boss_pos = new Vector3(spwnHammPoint.transform.position.x + 3, spwnHammPoint.transform.position.y, spwnHammPoint.transform.position.z);

        Vector3 angl_target = (ply.transform.position - transform.position);
        cmp_enemy_model.bosslife = cmp_life.life;

        Die();
        AtackPatterns();

        /*if (Input.GetKeyDown(KeyCode.Z))
        {
            DamageItself(1);
        }
        if (Input.GetKeyDown(KeyCode.M))
        {
            ThrowAtack();
        }*/

    }
    public void DamageItself(int dmg)
    {
        cmp_life.LoseLife(dmg);
    }
    /*
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.GetComponent<PlayerController>().DamageItself(1);
        }
    }
    */
    void Die()
    {
        if (cmp_enemy_model.bosslife <= 0)
        {
            //cmp_enemy_model.
            dieAnimTimer += Time.deltaTime;
            dying = true;

            if (dieAnimTimer >= 1.5f)
            {
                if (GameObject.Find("LevelStat"))
                {
                    GameObject.Find("LevelStat").GetComponent<LevelStats>().enemyKillCounter++;
                }
                dying = false;
                
                dieAnimTimer = 0;
                //gameObject.SetActive(false);
            }
            //gameObject.SetActive(false);
        }
    }

    void ThrowAtack()
    {
        if (cmp_enemy_model.meleAtack == false)
        {
            cmp_enemy_model.bossOnAtack = true;
            cmp_enemy_model.throwAtack = true;
            cmp_spwn.ArraySpawnGeneretor(martiloProyectil, boss_pos);
            
        }
        
        //cmp_spwn.BasicInstantiate(martiloProyectil, boss_pos.x, boss_pos.y, boss_pos.z);

    }

    void MeleAtack()
    {
        if (cmp_enemy_model.throwAtack == false)
        {
            cmp_enemy_model.bossOnAtack = true;
            cmp_enemy_model.meleAtack = true;
            martilloMeleHit.SetActive(true);
        }
        
    }

    void AtackPatterns()
    {
        if (cmp_enemy_model.bosslife <= 0)
        {

        }
        else if(cmp_enemy_model.bosslife <= (cmp_life.maxlife/4))
        {
            numForTimer = timePatternsArray[3];
            RangeDetectAtk();
        }
        else if (cmp_enemy_model.bosslife <= (cmp_life.maxlife / 2))
        {
            numForTimer = timePatternsArray[2];
            RangeDetectAtk();
        }
        else if (cmp_enemy_model.bosslife <= ((cmp_life.maxlife / 4)*3))
        {
            numForTimer = timePatternsArray[1];
            RangeDetectAtk();
        }
        else if (cmp_enemy_model.bosslife <= cmp_life.maxlife)
        {
            numForTimer = timePatternsArray[0];
            RangeDetectAtk();
        }

    }

    void RangeDetectAtk()
    {
        waitAtackTimer += Time.deltaTime;
        if(waitAtackTimer >= numForTimer)
        {
            
            if (Vector3.Distance(playerTransform.position, transform.position) < 7)
            {
                
                MeleAtack();
            }
            else
            {
                
                ThrowAtack();
            }
            waitAtackTimer = 0;
            
        }

    }

    /*public void Despawn()
    {
        cmp_spwn.ArrayDespawn();
    }*/
    /*void GolpeconMartillo()
    {
        //if (golpeAlSuelo == true & lugarGolpeMartillo <= 5
        if (lugarGolpeMartillo <= 5)
        {
            PosicionMartillo();
            if (tMartillo >= tMVolverInicio)
            {
                myTransform.transform.position = martilloPosiciones[0].transform.position;
            }
        }
        else
        {
            //golpeAlSuelo = false;
            lugarGolpeMartillo = 2;
            //tMartillo = 3;
        }
    }
    void GolpeMartillo()
    {
        myTransform.transform.position = martilloPosiciones[lugarGolpeMartillo].transform.position;
    }
    void PosicionMartillo()
    {
        tMartillo += Time.deltaTime;
        if (tMartillo >= tMSiguienteataque)
        {
            if (lugarGolpeMartillo <= 4)
            {
                GolpeMartillo();
            }
            lugarGolpeMartillo += 1;
            tMartillo = 0;
        }
    }*/
}
