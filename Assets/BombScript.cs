using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombScript : MonoBehaviour
{
    public float speed;
    public Transform playerPosition1;
    private Vector3 goplayerPosition1;
    public GameObject explosion;
    public bool spawnexplosion = true;
    // Start is called before the first frame update
    void Start()
    {
        goplayerPosition1 = playerPosition1.position;

    }

    // Update is called once per frame
    void Update()
    {
        float step = speed * Time.deltaTime; // calculate distance to move
        transform.position = Vector3.MoveTowards(transform.position, goplayerPosition1, step);
    }
    public void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Ground") & spawnexplosion == true)
        {
            spawnexplosion = false;
            Instantiate(explosion, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }
}
