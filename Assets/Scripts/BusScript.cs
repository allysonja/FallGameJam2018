using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BusScript : MonoBehaviour {
	Rigidbody2D rb;
	public List<Taco> finishedTacos;
	Orders orders;  
	public GameObject ordersObject;
	public GameObject Counter1;
	public GameObject Counter2;
	public GameObject Counter3;
	public GameObject Counter4;
	float speed;
	float time;
	Renderer rend;
	// Use this for initialization
	void Start () {
		
		speed = 50;
		rb = GetComponent<Rigidbody2D>();
		rend = GetComponent<Renderer>();
		Counter1 = gameObject.transform.Find("Counter1").gameObject;
		Counter2 = gameObject.transform.Find("Counter2").gameObject;
		Counter3 = gameObject.transform.Find("Counter3").gameObject;
		Counter4 = gameObject.transform.Find("Counter4").gameObject;
		orders = ordersObject.GetComponent<Orders>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		//Debug.Log(speed);
		if(Input.GetKey("w")){
			rb.velocity += Vector2.up * .05f;
			speed += .005f;
		}else{
			//speed -= .005f;
			//rb.velocity += Vector2.down * .02f;
		}
		if(Input.GetKey("s")){
			rb.velocity += Vector2.down * .01f;
			speed -= .05f;	
		}
		if(Input.GetKey("a")){
			rb.velocity += Vector2.left * .05f;
		}
		if(Input.GetKey("d")){
			rb.velocity += Vector2.right * .05f;
		}

		RaycastHit2D hitRight = Physics2D.Raycast(transform.position, new Vector2(1,0), 1.2f);
		RaycastHit2D hitLeft = Physics2D.Raycast(transform.position, new Vector2(-1,0), 1.2f);
		Debug.DrawRay(transform.position, new Vector2(1,0) * 1.2f, Color.green);
		Debug.DrawRay(transform.position, new Vector2(-1,0) * 1.2f, Color.green);
		if(hitRight.collider != null){
			if(hitRight.collider.transform.tag.Equals("Customer")){
				int orderID = hitRight.collider.gameObject.GetComponent<CarScript>().orderNum;
			//Debug.Log("hit right");
				time+= Time.deltaTime;
				if (time >= 1f){	
					if(checkAvailableOrder(Counter1.transform.GetChild(0).GetComponent<TacoScript>().taco, orders.orderList.Find(x => x.OrderNum == orderID))){
						orders.RemoveOrder(orders.orderList.FindIndex(x => x.OrderNum == orderID));
					}
					else if((checkAvailableOrder(Counter2.transform.GetChild(0).GetComponent<TacoScript>().taco, orders.orderList.Find(x => x.OrderNum == orderID)))){
						orders.RemoveOrder(orders.orderList.FindIndex(x => x.OrderNum == orderID));
					}
					else if((checkAvailableOrder(Counter3.transform.GetChild(0).GetComponent<TacoScript>().taco, orders.orderList.Find(x => x.OrderNum == orderID)))){
						orders.RemoveOrder(orders.orderList.FindIndex(x => x.OrderNum == orderID));
					}
					else if((checkAvailableOrder(Counter4.transform.GetChild(0).GetComponent<TacoScript>().taco, orders.orderList.Find(x => x.OrderNum == orderID)))){
						orders.RemoveOrder(orders.orderList.FindIndex(x => x.OrderNum == orderID));
					}
					else{
						Debug.Log("COuldnt find a match");
					}
					

					time = 0;
				}
			}
		}
		if(hitLeft.collider != null){
			if(hitLeft.collider.transform.tag.Equals("Customer")){
			int orderID = hitRight.collider.gameObject.GetComponent<CarScript>().orderNum;
			//Debug.Log("hit left");
				time+= Time.deltaTime;
				if (time >= 1f){
					if(checkAvailableOrder(Counter1.transform.GetChild(0).GetComponent<TacoScript>().taco, orders.orderList.Find(x => x.OrderNum == orderID))){
						orders.RemoveOrder(orders.orderList.FindIndex(x => x.OrderNum == orderID));
					}
					else if((checkAvailableOrder(Counter2.transform.GetChild(0).GetComponent<TacoScript>().taco, orders.orderList.Find(x => x.OrderNum == orderID)))){
						orders.RemoveOrder(orders.orderList.FindIndex(x => x.OrderNum == orderID));
					}
					else if((checkAvailableOrder(Counter3.transform.GetChild(0).GetComponent<TacoScript>().taco, orders.orderList.Find(x => x.OrderNum == orderID)))){
						orders.RemoveOrder(orders.orderList.FindIndex(x => x.OrderNum == orderID));
					}
					else if((checkAvailableOrder(Counter4.transform.GetChild(0).GetComponent<TacoScript>().taco, orders.orderList.Find(x => x.OrderNum == orderID)))){
						orders.RemoveOrder(orders.orderList.FindIndex(x => x.OrderNum == orderID));
					}
					else{
						Debug.Log("COuldnt find a match");
					}
					

					time = 0;
				}
			}
		}
	}

	bool checkAvailableOrder(Taco prepared, Taco order){
		bool found;
		
		
				if(prepared.Beans == order.Beans && prepared.Shell == order.Shell && prepared.Lettuce == order.Lettuce && prepared.Meat == order.Meat && prepared.Tomato == order.Tomato){
					found = true;
					Debug.Log("taco found");
				}else{
					found = false;
					Debug.Log("taco missing");
				
			
		}

		return found;
	}
}
