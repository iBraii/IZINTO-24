using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyGameobject : MonoBehaviour
{
    public float contador;
    public float limite;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        contador += Time.deltaTime;
        if (contador >= limite)
        {
            Destroy(gameObject);
        }
    }
}
