using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Orders : MonoBehaviour {
	public int yBase =150;
	public List<Taco> orderList = new List<Taco>();
	public int yOffset = 110;
	int orderNum = 1;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public int AddOrder () {

		GameObject newOrder = new GameObject("Order" + orderNum);
		newOrder.transform.SetParent(this.transform);
		newOrder.transform.localPosition = new Vector3(350, yBase + (yOffset * orderList.Count),0);
		newOrder.transform.localScale = new Vector3(1,1,1);

		Text orderText = newOrder.AddComponent<Text>();
		orderText.color = new Color(1f, 1f, 1f, 1f);
		orderText.text = "Order " + orderNum + ":";
		
		orderText.font = Resources.GetBuiltinResource(typeof(Font), "Arial.ttf") as Font;

		Taco taco = ScriptableObject.CreateInstance<Taco>();
		taco.OrderNum = orderNum;
		orderText.text += "\nShell: ";
		if (Random.Range(0,2) == 1) {
			taco.Shell = Shell.HARD;
			orderText.text += "Hard";
		} else {
			taco.Shell = Shell.SOFT;
			orderText.text += "Soft";
		}
		
		int[] toppings = new int[4];
		for (int i = 0; i < toppings.Length; i++) {
			toppings[i] = Random.Range(0,2);
		}

		bool hasToppings = false;
		foreach (int topping in toppings) {
			if (topping == 1) {
				hasToppings = true;
			}
		}
		if (!hasToppings) {
			toppings[Random.Range(0,4)] = 1;
		}

		orderText.text += "\nToppings: \n";
		if (toppings[0] == 1) {
			taco.Beans = true;
			orderText.text += "Beans\n";
		}
		if (toppings[1] == 1) {
			taco.Meat = true;
			orderText.text += "Meat\n";
		}
		if (toppings[2] == 1) {
			taco.Lettuce = true;
			orderText.text += "Lettuce\n";
		}
		if (toppings[3] == 1) {
			taco.Tomato = true;
			orderText.text += "Tomato\n";
		}

		orderText.text += "\n";
		orderList.Add(taco);
		orderNum++;
		return orderNum - 1;
	}

	public void RemoveOrder(int index) {
		Destroy(GameObject.Find("Order" + (index)));
		bool removedOrder = false;
		for (int i = 0; i < orderList.Count; i++) {
			if (orderList[i].OrderNum == index) {
				orderList.RemoveAt(i);
				removedOrder = true;
			}
			if (removedOrder) {
				GameObject shiftOrder = GameObject.Find("Order" + orderList[i].OrderNum);
				shiftOrder.transform.localPosition = new Vector3(shiftOrder.transform.localPosition.x,
				shiftOrder.transform.localPosition.y + yOffset,
				shiftOrder.transform.localPosition.z);	
			}
		}
	}
}
