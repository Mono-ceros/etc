using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer : MonoBehaviour {
	//맵 -y지점에 넣어서 다른 애들이랑 안겹치고 맵스폰 트리거만 파괴하게

	void OnTriggerEnter(Collider other)
	{
		Destroy(other.gameObject);
	}
}
