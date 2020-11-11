using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_BossController : MonoBehaviour
{
    private Life cmp_life;
    private Enemy_BossModel cmp_enemy_model;


    // Start is called before the first frame update
    void Start()
    {
        cmp_life = GetComponent<Life>();
        cmp_enemy_model = GetComponent<Enemy_BossModel>();
        cmp_life.life = cmp_enemy_model.bosslife;
    }

    // Update is called once per frame
    void Update()
    {
        cmp_enemy_model.bosslife = cmp_life.life;

        Die();

        if (Input.GetKeyDown(KeyCode.Z))
        {
            DamageItself(1);
        }

    }
    public void DamageItself(int dmg)
    {
        cmp_life.LoseLife(dmg);
    }
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.GetComponent<PlayerController>().DamageItself(1);
        }
    }
    void Die()
    {
        if (cmp_enemy_model.bosslife <= 0)
        {
            Debug.Log("Murió el boss");
            gameObject.SetActive(false);
        }
    }
}
