using UnityEngine;
using System.Collections;
using System.Linq;
using System.Collections.Generic;



[ExecuteInEditMode]
public class sGuiBox : MonoBehaviour {

	// TODO
	public bool Scroller;
	public DirectionBox ScrollerOverflow;
	public TextAnchor ChildLocation;

	public bool AlphaToChild;


	void Start() {

		updateStyles();
	}
	void OnValidate() {
		updateStyles();
	}
	void Awake() {
		updateStyles();
	}
	void OnEnable() {
		updateStyles();
	}
	
	public void updateStyles() {

		Scroller = false;

		if (this.GetComponent<sGuiBase>() != null) {
			this.GetComponent<sGuiBase>().onGuiFunc = drawGui;
			this.GetComponent<sGuiBase>().onChildGuiFunc = drawChildGui;
		}

		if (this.GetComponent<sGuiBase>() == null) {
			return;
		}

		GUIStyle _style = this.GetComponent<sGuiBase>().Style;

		if (AlphaToChild) {
			foreach (Transform child in transform.Cast<Transform>().OrderBy(t => t.GetComponent<sGuiBase>().Depth.value)) {
				if (child.GetComponent<sGuiBase>() != null) {
					child.GetComponent<sGuiBase>().Alpha = this.GetComponent<sGuiBase>().Alpha;
				}
			}
		}


		this.GetComponent<sGuiBase>().Style = _style;
	}

	public void drawGui(Rect position, GUIStyle style) {
		
		GUI.BeginGroup(position, style);
		onGuiContent();
		GUI.EndGroup();

	}

	public void drawChildGui(Rect position, GUIStyle style) {

		GUILayout.BeginArea(new Rect(position.x, position.y, position.width, position.height), style);
		onGuiContent();
		GUILayout.EndArea();

	}
	
	void onGuiContent() {
		//Vector2 p = new Vector2();
		foreach(Transform child in transform.Cast<Transform>().OrderBy(t=>t.GetComponent<sGuiBase>().Depth.value)) {
			
			if(child.GetComponent<sGuiBase>() != null) {
				/*
				switch (Overflow) {
					case OverflowBox.Vertical:
						p.x = 0;
						break;
					case OverflowBox.Horizontal:
						p.y = 0;
						break;
				}*/
				child.GetComponent<sGuiBase>().childGUI(this.GetComponent<sGuiBase>().Position);
			}
		}
	}
}
