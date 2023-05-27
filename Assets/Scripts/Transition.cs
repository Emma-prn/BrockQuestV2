using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Transition : MonoBehaviour
{
    public Animator animator;
    public Animator MusicAnimator;
    public float transitionDelayTime = 1.0f;
    public string area_to_load;
    
    void Awake()
    {
        animator = GameObject.Find("Transition").GetComponent<Animator>();
    }

    void Update()
    {
        if(Input.GetKey(KeyCode.Space))
        {
            LoadLevel();
        }
    }

    public void LoadLevel()
    {
        StartCoroutine(DelayLoadLevel(area_to_load));
    }

    IEnumerator DelayLoadLevel(string level_to_load)
    {
        animator.SetTrigger("TriggerTransition");
        MusicAnimator.SetTrigger("TriggerTransition");
        yield return new WaitForSeconds(transitionDelayTime);
        SceneManager.LoadScene(level_to_load);
    }
}
