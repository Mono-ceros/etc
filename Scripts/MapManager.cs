using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MapManager : MonoBehaviour
{
    public GameObject _mapPrefab;

    private void Start()
    {
        StartCoroutine(GenerateNavmesh());
    }

    IEnumerator GenerateNavmesh()
    {
        yield return new WaitForSeconds(2.5f);

        GameObject obj = Instantiate(_mapPrefab, Vector3.zero, Quaternion.identity, transform);
        NavMeshSurface[] surfaces = gameObject.GetComponentsInChildren<NavMeshSurface>();

        foreach (var s in surfaces)
        {
            s.BuildNavMesh();
        }
    }
}
