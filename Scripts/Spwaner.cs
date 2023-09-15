using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class Spwaner : MonoBehaviour
{
    bool isAdmission;
    public int spawnNum = 5;
    public int monsterNum = 0;
    public Transform[] points;

    Portal[] portal;
    PoolManager poolManager;

    void Start()
    {
        poolManager = GetComponent<PoolManager>();
    }

    private void OnEnable()
    {
        isAdmission = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        //�÷��̾ �濡 ó��������
        if (!isAdmission)
        {
            if (other.CompareTag("Player"))
            {
                //��Ż ����
                for (int i = 0; i < portal.Length; i++)
                {
                    portal[i].gameObject.SetActive(false);
                }

                isAdmission = true;

                //���� ��ġ�� �� ����
                for (int i = 0; i < spawnNum; i++)
                {
                    int idx = Random.Range(0, points.Length);
                    poolManager.SpwanMonster(points[idx]);
                    monsterNum++;
                }
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Monster"))
        {
            monsterNum--;
            if(monsterNum == 0)
            {
                for (int i = 0; i < portal.Length; i++)
                {
                    portal[i].gameObject.SetActive(true);
                }
            }
        }
    }
}
