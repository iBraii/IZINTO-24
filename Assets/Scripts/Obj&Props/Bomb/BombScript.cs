using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombScript : MonoBehaviour
{
    public float speed;
    public float floorHeigth;
    public Vector3 goplayerPosition1;
    public GameObject explosion;
    public GameObject fire;
    public bool spawnexplosion = true;
    private Movement cmp_mov;

    // Start is called before the first frame update
    void Start()
    {
        goplayerPosition1 = GameObject.FindWithTag("Player").transform.position;
        Debug.Log(Vector3.Distance(goplayerPosition1, transform.position));
        cmp_mov = GetComponent<Movement>();
        
    }
    private void OnEnable()
    {
        cmp_mov.Jump(30 * Vector3.Distance(goplayerPosition1, transform.position) /*+ (Vector3.Distance(goplayerPosition1, transform.position) * 0.5f)*/);
    }

    // Update is called once per frame
    void Update()
    {

        float step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, new Vector3(goplayerPosition1.x, transform.position.y, goplayerPosition1.z), step);

    }

    public void OnCollisionEnter(Collision other)
    {
        /*if (other.gameObject & spawnexplosion == true)
        {*/
        spawnexplosion = false;
        Instantiate(explosion, transform.position, transform.rotation);

        GameObject instantFire = Instantiate(fire);
        instantFire.transform.position = new Vector3(transform.position.x, floorHeigth, transform.position.z);

        gameObject.SetActive(false);

        /*}*/
    }
}
