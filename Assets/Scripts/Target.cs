using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    public GameObject impactEffect;

    public void PopBalloon()
    {
        GameObject impactGO = Instantiate(impactEffect, transform.position, Quaternion.LookRotation(transform.forward));
        Destroy(impactGO, 2f);
        Destroy(gameObject);
    }

    private void OnCollisionEnter(Collision collision)
    {
        FindObjectOfType<BalloonCount>().score++;
        GameObject impactGO = Instantiate(impactEffect, transform.position, Quaternion.LookRotation(transform.forward));
        Destroy(impactGO, 2f);
        
        Destroy(gameObject);
    }
}
