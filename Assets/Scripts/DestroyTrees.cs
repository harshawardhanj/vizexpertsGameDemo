using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class DestroyTrees : MonoBehaviour
{
    public GameObject endGame;
    
    private void OnCollisionEnter(Collision collision)
    {

        //  AudioSource audioSource = GetComponent<AudioSource>();
        //  audioSource.Play(0);
        Text destroy = GameObject.Find("Destroy").GetComponent<Text>();
        destroy.text = (int.Parse(destroy.text) - 1) + "";

        if ((int.Parse(destroy.text)) <= 0 )
        {
            endGame.SetActive(true);
            Time.timeScale = 0;
        }
        Destroy(gameObject);

    }
}
