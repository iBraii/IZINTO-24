using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UseDurationItm : MonoBehaviour
{
    public int maxUses;
    public int actualUses;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnEnable()
    {
        if(actualUses <= 0)
        {
            actualUses = maxUses;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
