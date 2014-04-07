using UnityEngine;
using UnityEditor;

[CustomPropertyDrawer (typeof (AlphaSlider))]
public class sGuiEditorBase : PropertyDrawer {

	const float min = 0;
	const float max = 1;
	public override void OnGUI (Rect pos, SerializedProperty prop, GUIContent label) {
		SerializedProperty alpha = prop.FindPropertyRelative ("value");
		
		// Draw scale
		EditorGUI.Slider (new Rect (pos.x, pos.y, pos.width, pos.height), alpha, min, max, label);

	}
}

[CustomPropertyDrawer (typeof (DepthSlider))]
public class DepthSliderCustom : PropertyDrawer {
	
	const int min = -100;
	const int max = 100;
	public override void OnGUI (Rect pos, SerializedProperty prop, GUIContent label) {
		SerializedProperty alpha = prop.FindPropertyRelative ("value");

		EditorGUI.IntSlider (new Rect (pos.x, pos.y, pos.width, pos.height), alpha, min, max, label);
	}
}