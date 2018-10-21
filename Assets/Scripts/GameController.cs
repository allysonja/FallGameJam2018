using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {
	public List<Vector3> spawnPoints;
	public bool canSpawn;
	public GameObject car;
	public GameObject customerCar;
	float spawnRand;
	// Use this for initialization
	void Start () {
		spawnPoints.Add(new Vector3(0,8,1));
		spawnPoints.Add(new Vector3(-7,8,1));
		spawnPoints.Add(new Vector3(7,8,1));
		spawnPoints.Add(new Vector3(3,8,1));
		canSpawn = true;
	}

	IEnumerator spawnWait(){
		yield return new WaitForSeconds(3f);
		canSpawn = true;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		 spawnRand = Random.value;
		 //Debug.Log(spawnRand);
		 if (spawnRand < .01 && canSpawn){
			int point = Random.Range(0,4);
			Orders orders = GameObject.Find("Orders").GetComponent<Orders>();
			if (Random.Range(0, 10) == 0 && orders.orderList.Count < 1) {
				int orderNum = orders.AddOrder();
				GameObject customer = Instantiate(customerCar, spawnPoints[point] + new Vector3(0,20,0), gameObject.transform.rotation);
				customer.GetComponent<CarScript>().orderNum = orderNum; 
				//Debug.Log("spawn customer car");
			} else {
				Instantiate(car, spawnPoints[point], gameObject.transform.rotation);
				//Debug.Log("spawn car");
			}
			canSpawn = false;
			StartCoroutine(spawnWait());
		 }
	}
}
