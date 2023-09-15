using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Pool;

public class PoolManager : MonoBehaviour
{
    [Header("Stage1 Monster")]
    public MonsterData[] s1MonsterDatas; // 몬스터 셋업 데이터
    public Monster[] s1MonsterPrefabs; // 몬스터 원본 프리팹
    [Header("Stage2 Monster")]
    public MonsterData[] s2MonsterDatas;
    public Monster[] s2MonsterPrefabs;
    [Header("Stage3 Monster")]
    public MonsterData[] s3MonsterDatas;
    public Monster[] s3MonsterPrefabs;

    private ObjectPool<Monster> monsterPool;
    public Monster monsterPrefab;
    MonsterData monsterData;

    NavMeshSurface surfaces;
    List<Monster> mon;


    int stage = 1; // 현재 스테이지 참조해오기

    private void Start()
    {
        monsterPool = new ObjectPool<Monster>(
            createFunc: () =>
            {
                //스테이지별 랜덤 몹 생성
                switch (stage)
                {
                    case 1:
                        int num = Random.Range(0, s1MonsterPrefabs.Length);
                        monsterData = s1MonsterDatas[num];
                        monsterPrefab = Instantiate(s1MonsterPrefabs[num]);
                        break;
                    case 2:
                        num = Random.Range(0, s2MonsterPrefabs.Length);
                        monsterData = s2MonsterDatas[num];
                        monsterPrefab = Instantiate(s2MonsterPrefabs[num]);
                        break;
                    case 3:
                        num = Random.Range(0, s3MonsterPrefabs.Length);
                        monsterData = s3MonsterDatas[num];
                        monsterPrefab = Instantiate(s3MonsterPrefabs[num]);
                        break;
                    default:
                        Debug.Log("스테이지 값이 이상함");
                        break;
                }
                monsterPrefab.Setup(monsterData);
                var createdMonster = monsterPrefab;
                createdMonster.poolToReturn = monsterPool;
                return createdMonster;
            },
            actionOnGet: (monster) => {monster.gameObject.SetActive(true); monster.Setup(monsterData); },
            actionOnRelease: (monster) => {monster.gameObject.SetActive(false);},
            actionOnDestroy: (monster) => {Destroy(monster.gameObject);},
            maxSize: 20);

        CreatMonster();
    }

    void CreatMonster() {
        for (int i = 0; i < 20; i++)
        {
            var ms = monsterPool.Get();
            ms.transform.position = transform.position;
            ms.transform.rotation = Quaternion.identity;
            ms.navMeshAgent.isStopped = false;

            mon[i] = ms;
        }

        for (int i = 0; i < 20; i++)
        {
            mon[i].navMeshAgent.isStopped = true;
            monsterPool.Release(mon[i]);
        }
    }


    public void SpwanMonster(Transform transform)
    {
        var mon = monsterPool.Get();
        mon.transform.position = transform.position;
        mon.transform.rotation = Quaternion.identity;
        mon.navMeshAgent.isStopped = false;
    }

}
