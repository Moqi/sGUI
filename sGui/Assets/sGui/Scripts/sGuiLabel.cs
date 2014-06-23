using UnityEngine;
using System.Collections;


[ExecuteInEditMode]
public class sGuiLabel : sGuiBase {


	public int FontSize = 10;
	public Color FontColor = Color.gray;
	public TextAnchor TextAlign;

	public Vector2 ContentOffset;
	public ImagePosition ContentImagePosition;
	public RectOffset Margin;

	public override void updateStyles() {

		base.updateStyles();
	
		Style.contentOffset = ContentOffset;
		Style.imagePosition = ContentImagePosition;
		Style.padding = Margin;

		Style.alignment = TextAlign;
		Style.fontSize = FontSize;
		Style.font = FontFamily;
		Style.richText = true;
		Style.wordWrap = true;
		Style.normal.textColor = FontColor;

	}

	public override void DrawGUI(Rect position, GUIStyle style) {
		GUI.Label (position, Content, style);
	}

	public override void DrawChildGUI(Rect position, GUIStyle style) {
		GUI.Label(position, Content, style);
		//GUI.Label (Content, style, GUILayout.Width (position.width), GUILayout.Height (position.height));
	}


}
