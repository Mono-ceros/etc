using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomTemplates : MonoBehaviour {

    //이름은 게이트 위치방향임
    //위쪽 게이트가 있는 방에는 아랫쪽 게이트가 있는 방을 붙여줘야하니까
    //프리팹 넣을때 헷갈리면 안됌

    public GameObject[] UpRooms;
	public GameObject[] RightRooms;
	public GameObject[] DownRooms;
	public GameObject[] LeftRooms;

    public GameObject closedRoom;

    public GameObject lastUpRoom;
    public GameObject lastRightRoom;
    public GameObject lastDownRoom;
    public GameObject lastLeftRoom;

    public List<GameObject> rooms;

	//네임드스포너 소환해줄때 쓸 코드

	//public float waitTime;
	//private bool spawnedBoss;
	//public GameObject bossspawner;

 //   void Update(){

	//	if(waitTime <= 0 && spawnedBoss == false){
	//		for (int i = 0; i < rooms.Count; i++) {
	//			if(i == rooms.Count-1){
	//				Instantiate(bossspawner, rooms[i].transform.position, Quaternion.identity);
	//				spawnedBoss = true;
	//			}
	//		}
	//	} else {
	//		waitTime -= Time.deltaTime;
	//	}
	//}
}
