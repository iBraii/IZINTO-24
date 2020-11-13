using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireHazard : MonoBehaviour
{
    public float desapearTime;
    public float timeLapse;
    public int naturalDmg;
    public bool boostedFire;
    public float onBoostedMultiplicator;
    public int onBoostedBonusDmg;

    public string targetTag;
    public float timer;
    public float desTimer;
    // Start is called before the first frame update
    void Start()
    {
        timer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        Desapear();
    }

    void CountNHit(GameObject target)
    {
        float maxTime = timeLapse;
        int dmg = naturalDmg;
        if (boostedFire == true)
        {
            maxTime = maxTime * onBoostedMultiplicator;
            dmg += onBoostedBonusDmg;
        }

        timer += Time.deltaTime;

        if (timer >=maxTime)
        {
            target.GetComponent<PlayerController>().DamageItself(dmg);
            Debug.Log("a ver pegale");
            timer = 0;  
        }
    }

    void Desapear()
    {
        desTimer += Time.deltaTime;

        if (desTimer >= desapearTime)
        {
            desTimer = 0;
            gameObject.SetActive(false);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag(targetTag))
        {
            //Debug.Log(". . .");
            CountNHit(other.gameObject);
        }
    }
}
