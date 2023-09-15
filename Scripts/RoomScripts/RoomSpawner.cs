using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomSpawner : MonoBehaviour {

	public int openingDirection;
	//이름은 게이트 위치방향임

	RoomTemplates templates;
	int RD;

	public bool spawned = false;
    public float waitTime = 3f;

    void OnEnable()
	{
        Destroy(gameObject, waitTime);
        templates = GameObject.FindGameObjectWithTag("Rooms").GetComponent<RoomTemplates>();
		StartCoroutine(Spawn());
	}

	//맵 생성전에 스폰 실행되면 프로그램 터짐
	//로딩 시간에 맞춰서 코루틴 시간을 조정해줘야할듯
	IEnumerator Spawn(){
		yield return new WaitForSeconds(0.2f);
		if(spawned == false)
        {
			if (templates.rooms.Count <= 3)
			{
				switch (openingDirection)
				{
					case 1:
						RD = Random.Range(0, templates.UpRooms.Length);
						Instantiate(templates.UpRooms[RD], (transform.position + Vector3.up * 20), templates.UpRooms[RD].transform.rotation);
						break;
					case 2:
						RD = Random.Range(0, templates.RightRooms.Length);
						Instantiate(templates.RightRooms[RD], (transform.position + Vector3.up * 20), templates.RightRooms[RD].transform.rotation); 
						break;
					case 3:
						RD = Random.Range(0, templates.DownRooms.Length);
						Instantiate(templates.DownRooms[RD], (transform.position + Vector3.up * 20), templates.DownRooms[RD].transform.rotation);
						break;
					case 4:
						RD = Random.Range(0, templates.LeftRooms.Length);
						Instantiate(templates.LeftRooms[RD], (transform.position + Vector3.up * 20), templates.LeftRooms[RD].transform.rotation);
						break;
				}
			}
			else
			{
				switch (openingDirection)
				{
					// 아래쪽 문 존재
					case 1:
						Instantiate(templates.lastUpRoom, (transform.position + Vector3.up * 20), templates.lastUpRoom.transform.rotation);
						break;
					case 2:
						// 윗쪽 문 존재
						Instantiate(templates.lastRightRoom, (transform.position + Vector3.up * 20), templates.lastRightRoom.transform.rotation);
						break;
					case 3:
						// 왼쪽 문 존재
						Instantiate(templates.lastDownRoom, (transform.position + Vector3.up * 20), templates.lastDownRoom.transform.rotation);
						break;
					case 4:
						// 오른쪽 문 존재
						Instantiate(templates.lastLeftRoom, (transform.position + Vector3.up * 20), templates.lastLeftRoom.transform.rotation);
						break;
				}
			}
            spawned = true;
        }
	}

	void OnTriggerEnter(Collider other){
		if(other.CompareTag("SpawnPoint")){
			if(other.GetComponent<RoomSpawner>().spawned == false && spawned == false){
				var SP = Instantiate(templates.closedRoom, (transform.position + Vector3.up * 20), Quaternion.identity);
				Destroy(SP);
			} 
			spawned = true;
		}
	}
}
