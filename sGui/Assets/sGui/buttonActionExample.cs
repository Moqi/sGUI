using UnityEngine;
using System.Collections;


public class buttonActionExample : MonoBehaviour {


	private int clicks;

	void Start () {

		this.GetComponent<sGuiButton>().onClickButton = clickButton;
		this.GetComponent<sGuiButton>().onHoverButton = hoverButton;
		this.GetComponent<sGuiButton>().onOutButton = outButton;
		clicks = 0;
	}

	public void hoverButton(GameObject curr) {
		Debug.Log("hover");
		this.GetComponent<sGuiButton>().Content.text = "hover " + clicks;
	}
	public void outButton(GameObject curr) {
		Debug.Log("out");
		this.GetComponent<sGuiButton>().Content.text = "clicked " + clicks;
	}

	public void clickButton(GameObject curr) {
		Debug.Log("button clicked");
		clicks++;
		this.GetComponent<sGuiButton>().Content.text = "clicked " + clicks;
	}
	
	void Update () {
	
	}
}
