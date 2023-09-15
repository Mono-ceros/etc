using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    public GameObject[] boss;

    int stage = 1;

    private Queue<GameObject> bossPool;

    void Start()
    {
        bossPool = new Queue<GameObject>();
        GameObject bs;

        switch (stage)
        {
            case 1:
                bs = Instantiate(boss[0], transform.position, Quaternion.identity);
                bs.SetActive(false);
                bossPool.Enqueue(bs);
                break;
            case 2:
                bs = Instantiate(boss[1], transform.position, Quaternion.identity);
                bs.SetActive(false);
                bossPool.Enqueue(bs);
                break;
            case 3:
                bs = Instantiate(boss[2], transform.position, Quaternion.identity);
                bs.SetActive(false);
                bossPool.Enqueue(bs);
                break;
        }
    }

    public void GetBoss()
    {
        GameObject monster = bossPool.Dequeue();
        monster.transform.position = gameObject.transform.position;
        monster.SetActive(true);
    }

    public void ReturnBoss(GameObject boss)
    {
        boss.SetActive(false);
        bossPool.Enqueue(boss);
    }
}
