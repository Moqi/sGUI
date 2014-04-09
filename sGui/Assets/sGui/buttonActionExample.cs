using UnityEngine;
using System.Collections;


public class buttonActionExample : MonoBehaviour {


	private int clicks;

	void Start () {

		this.GetComponent<sGuiButton>().onClickButton = clickButton;
		clicks = 0;
	}

	public void clickButton(GameObject curr) {
		Debug.Log("button clicked");
		clicks++;
		this.GetComponent<sGuiButton>().Content.text = "clicked " + clicks;
	}
	
	void Update () {
	
	}
}
