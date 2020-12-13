using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossRotation : MonoBehaviour
{
    private Rotatement cmp_rot;

    public Transform loockRotation;
    // Start is called before the first frame update
    void Start()
    {
        cmp_rot = GetComponent<Rotatement>();
    }

    // Update is called once per frame
    void Update()
    {
        cmp_rot.LookSmt(loockRotation.position,30);
    }
}
