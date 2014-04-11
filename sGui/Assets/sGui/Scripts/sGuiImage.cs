using UnityEngine;
using System.Collections;



[ExecuteInEditMode]
public class sGuiImage : sGuiBase
{

	public Texture _image;
	public ScaleMode _scaleMode;

	public override void DrawGUI(Rect position, GUIStyle style) {
		if (_image != null) {
			GUI.DrawTexture(position, _image, _scaleMode, true);
		}
	}

	public override void DrawChildGUI(Rect position, GUIStyle style) {
		if (_image != null) {
			GUI.DrawTexture(position, _image, _scaleMode, true);
		}
	}

}
