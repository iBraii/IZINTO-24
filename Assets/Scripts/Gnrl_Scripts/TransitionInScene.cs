using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransitionInScene : MonoBehaviour
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
    public void Change(int time)
    {
        StartCoroutine(TransitionLoadScene(time));
    }

    IEnumerator TransitionLoadScene(int time)
    {
        transition.SetTrigger("Start");

        yield return new WaitForSeconds(time);

        transition.SetTrigger("End");
    }
}
