using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkEnemies : MonoBehaviour
{

    public Transform target;
    public float speed;
    void Update()
    {
        gameObject.transform.LookAt(target);
        float step = speed * Time.deltaTime;
         transform.position = Vector3.MoveTowards(transform.position, target.position, step);
    }
}
