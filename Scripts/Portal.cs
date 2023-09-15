using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    GameObject child;



    private void Start()
    {
        child = GetComponentInChildren<GameObject>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            StartCoroutine(ParticleOn());
            other.transform.position = transform.position + Vector3.forward * 180f;
        }
    }

    IEnumerator ParticleOn()
    {
        child.SetActive(true);
        yield return new WaitForSeconds(1.5f);
        child.SetActive(false);
        yield return new WaitForSeconds(0.2f);
    }
}
