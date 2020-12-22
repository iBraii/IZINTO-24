using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.Rendering;

public class BossAliveController : MonoBehaviour
{
    private Enemy_BossModel cmp_enemyBoss;
    private PlayerModelo cmp_PlyMod;
    private SceneChange cmp_scnChng;
    private TransitionInScene cmp_scnCh;
    public float timer;
    public string lvl3Victory;
    public string playerDefeat;

    // Start is called before the first frame update
    void Start()
    {
        cmp_enemyBoss = GameObject.FindGameObjectWithTag("Boss").GetComponent<Enemy_BossModel>();
        cmp_scnChng = GetComponent<SceneChange>();
        cmp_scnCh = GetComponent<TransitionInScene>();
        cmp_PlyMod = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerModelo>();
    }

    // Update is called once per frame
    void Update()
    {
        BossAliveChecker();
        PlayerAliveChecker();
        timer += Time.deltaTime;
        if(timer >= 3 && timer < 3.01)
        {
            cmp_scnCh.Change(3);
        }
    }
    public void BossAliveChecker()
    {
        if(cmp_enemyBoss.bosslife <= 0)
        {
            cmp_scnChng.Change(lvl3Victory);
        }
    }
    public void PlayerAliveChecker()
    {
        if(cmp_PlyMod.playerLife <= 0)
        {
            cmp_scnChng.Change(playerDefeat);
        }
    }
}
