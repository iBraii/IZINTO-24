using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossRotation : MonoBehaviour
{
    private Rotatement cmp_rot;
    public Enemy_BossModel cmp_bossMdl;

    public Transform loockRotation;
    // Start is called before the first frame update
    void Start()
    {
        cmp_rot = GetComponent<Rotatement>();
    }

    // Update is called once per frame
    void Update()
    {
        if (cmp_bossMdl.bosslife > 0)
        {
            cmp_rot.LookSmt(loockRotation.position, 30);
        }
    }
}
