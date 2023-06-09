using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadLevel : MonoBehaviour
{
    public string area_to_load;
    public Transition transition;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player") && !other.isTrigger)
        {
            //SceneManager.LoadScene(area_to_load);
            transition.LoadLevel(area_to_load);
        }
    }
}
