using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class NamedSpwaner : MonoBehaviour
{
    bool isAdmission;
    public int namedNum = 0;

    public Transform[] points;
    public GameObject homePortal;

    private void OnEnable()
    {
        isAdmission = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        //플레이어가 방에 처음들어오면
        if (!isAdmission)
        {
            if (other.CompareTag("Player"))
            {
                isAdmission = true;


                int idx = Random.Range(0, points.Length);
                //instantiate
                namedNum++;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Named"))
        {
            namedNum--;
            if (namedNum == 0)
            {
                Instantiate(homePortal);
            }
        }
    }
}
