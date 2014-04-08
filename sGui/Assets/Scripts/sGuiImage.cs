using UnityEngine;
using System.Collections;



[ExecuteInEditMode]
public class sGuiImage : MonoBehaviour
{

	public Texture _image;

	public ScaleMode _scaleMode;


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

		if (this.GetComponent<sGuiBase>() != null) {
			this.GetComponent<sGuiBase>().onGuiFunc = drawGui;
			this.GetComponent<sGuiBase>().onChildGuiFunc = drawChildGui;
		}
	}

	public void drawGui(Rect position, GUIStyle style) {
		if (_image != null) {
			GUI.DrawTexture(position, _image, _scaleMode, true);
		}
	}

	public void drawChildGui(Rect position, GUIStyle style) {
		if (_image != null) {
			GUI.DrawTexture(position, _image, _scaleMode, true);
		}
	}

}
