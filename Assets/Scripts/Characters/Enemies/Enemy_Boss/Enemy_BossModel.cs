using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_BossModel : MonoBehaviour
{
    public int bosslife;
    public bool bossOnAtack;
    public bool throwAtack;
    public bool meleAtack;
    private BossHealthBar bossHPBar;
    // Start is called before the first frame update
    void Start()
    {
        bossHPBar = GameObject.Find("BossHealthBar").GetComponent<BossHealthBar>();
    }

    // Update is called once per frame
    void Update()
    {
        bossHPBar.SetHealth(bosslife);
    }
}
