using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public Rigidbody cmp_rb;
    public int energy;
    public bool AtqGiratorio;
    // Start is called before the first frame update
    void Start()
    {
        cmp_rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        AtaqueGiratorio();
    }
    void AtaqueGiratorio()
    {
        if (Input.GetKey(KeyCode.X))
        {
            gameObject.transform.Rotate(0.0f, 5.0f, 0.0f, Space.Self);
            AtqGiratorio = true;
        }
        if (Input.GetKeyUp(KeyCode.X))
        {
            AtqGiratorio = false;
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            if (AtqGiratorio == false)
            {
                energy -= 1;
            }
            else if (AtqGiratorio == true)
            {
                Destroy(other.gameObject);
            }
        }
    }



}
