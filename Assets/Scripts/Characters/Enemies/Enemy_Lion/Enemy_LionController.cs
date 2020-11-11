using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_LionController : MonoBehaviour
{
    private Life cmp_life;
    public bool EnemyHasHelmet;
    public GameObject helmet;

    // Start is called before the first frame update
    void Start()
    {
        cmp_life = GetComponent<Life>();
        EnemyHasHelmet = false;
        cmp_life.protec = EnemyHasHelmet;
    }

    // Update is called once per frame
    void Update()
    {
        CascoUpdater();
        if(helmet.gameObject.activeInHierarchy == true)
        {
            Casco();
        }
        else
        {
            cmp_life.protec = false;
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
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.GetComponent<PlayerController>().DamageItself(1);
        }
    }
}
