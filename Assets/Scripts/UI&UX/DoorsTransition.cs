using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorsTransition : MonoBehaviour
{
    private SceneChange cmp_ChangeSc;
    public string sceneName;
    // Start is called before the first frame update
    void Start()
    {
        cmp_ChangeSc = GetComponent<SceneChange>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            cmp_ChangeSc.Change(sceneName);
        }
    }
}
