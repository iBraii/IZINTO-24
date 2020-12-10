using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_BossController : MonoBehaviour
{
    private Life cmp_life;
    private Enemy_BossModel cmp_enemy_model;
    private Spawning cmp_spwn;
    public GameObject ply;

    public GameObject martiloProyectil;
    private Vector3 boss_pos;

    public Transform myTransform;
    public List<Transform> martilloPosiciones;
    //public bool golpeAlSuelo;
    public int lugarGolpeMartillo;
    public float tMartillo;
    public float tMVolverInicio;
    public float tMSiguienteataque;

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
        GolpeconMartillo();

        boss_pos = new Vector3(gameObject.transform.position.x + 3, gameObject.transform.position.y, gameObject.transform.position.z);

        Vector3 angl_target = (ply.transform.position - transform.position);
        cmp_enemy_model.bosslife = cmp_life.life;

        Die();

        if (Input.GetKeyDown(KeyCode.Z))
        {
            DamageItself(1);
        }
        if (Input.GetKeyDown(KeyCode.M))
        {
            ThrowAtack();
        }

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
            gameObject.SetActive(false);
        }
    }

    void ThrowAtack()
    {

        cmp_spwn.ArraySpawnGeneretor(martiloProyectil, boss_pos);
        //cmp_spwn.BasicInstantiate(martiloProyectil, boss_pos.x, boss_pos.y, boss_pos.z);

    }

    public void Despawn()
    {
        cmp_spwn.ArrayDespawn();
    }
    void GolpeconMartillo()
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
    }
}
