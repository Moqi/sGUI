using UnityEngine;
using System.Collections;



[ExecuteInEditMode]
public class sGuiImage : MonoBehaviour
{

	public int _depth = 1;
	public Rect _position;
	public Texture _image;

	public ScaleMode _scaleMode;

	public GUIStyle _style = new GUIStyle();

	public bool isChild = false;

	void Start() {

		updateStyles();

	}

	public void updateStyles() {
		if (_style == null) {
			_style = new GUIStyle();
		}

	}


	void OnValidate() {
		updateStyles();
	}

	public void childGUI(bool isModal) {

		if (!this.gameObject.activeSelf) {
			return;
		}

		isChild = true;
		GUI.depth = _depth;

		if (_image != null) {
			GUI.DrawTexture(_position, _image, _scaleMode, true);
		}
		//GUILayout.Label (_content, _style, GUILayout.Width (_position.width), GUILayout.Height (_position.height));

	}

	public void childGUI() {

		if (!this.gameObject.activeSelf) {
			return;
		}

		isChild = true;
		//GUI.depth = _depth;
		//GUILayout.Label(_content, _style, GUILayout.Width(_position.width), GUILayout.Height(_position.height));
	}

	void OnGUI() {

		if (!this.gameObject.activeSelf) {
			return;
		}

		if (!isChild) {
			GUI.depth = _depth;
			if (_image != null) {
				GUI.DrawTexture(_position, _image, _scaleMode, true);
			}
		}
	}
}
