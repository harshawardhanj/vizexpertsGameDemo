using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class DestroyEnemies : MonoBehaviour
{
   
    private void OnCollisionEnter(Collision collision)
    {
        //  AudioSource audioSource = GetComponent<AudioSource>();
        //  audioSource.Play(0);
        Text kills = GameObject.Find("Kill").GetComponent<Text>();
        Text destroy = GameObject.Find("Destroy").GetComponent<Text>();

        kills.text = (int.Parse( kills.text) +1)+"";
        
        Destroy(gameObject);
    }
}
