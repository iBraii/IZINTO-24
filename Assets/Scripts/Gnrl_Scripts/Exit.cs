using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Exit : MonoBehaviour
{

    public Animator transition;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Escape()
    {
        StartCoroutine(TransitionLoadScene());
    }

    IEnumerator TransitionLoadScene()
    {
        transition.SetTrigger("Start");

        yield return new WaitForSeconds(1);

        Application.Quit();
    }
}
