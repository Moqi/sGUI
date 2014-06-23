using UnityEngine;
using System.Collections;



[ExecuteInEditMode]
public class sGuiToggle : sGuiBase {
	
	public int FontSize = 10;
	
	public TextAnchor TextAlign;
	
	public Color FontColor = Color.gray;

	public Texture2D BackgroundTexturePressed;
	public GUIContent ContentPressed;
	public Color FontColorPressed = Color.red;

	public Vector2 ContentOffset;
	public ImagePosition ContentImagePosition;


	private bool _pressed = false;
	
	private OnClickFunc _onButtonClick;
	
	public delegate void OnClickFunc();



	public override void updateStyles() {

		base.updateStyles();
		
		Style.onNormal.background = BackgroundTexturePressed;

		Style.contentOffset = ContentOffset;
		Style.imagePosition = ContentImagePosition;

		Style.alignment = TextAlign;
		Style.fontSize = FontSize;
		Style.font = FontFamily;
		Style.richText = true;
		Style.wordWrap = true;
		Style.normal.textColor = FontColor;
		Style.onNormal.textColor = FontColorPressed;

	}


	public override void DrawGUI(Rect position, GUIStyle style) {

		Pressed = GUI.Toggle(position, _pressed, (_pressed) ? ContentPressed : Content, style);

		if (GUI.changed && _onButtonClick != null) {
			_onButtonClick();
		}
	}

	public override void DrawChildGUI(Rect position, GUIStyle style) {

		Pressed = GUI.Toggle(position, _pressed, (_pressed) ? ContentPressed : Content, style);

		if (GUI.changed && _onButtonClick != null) {
			_onButtonClick();
		}

		// _pressed = GUILayout.Toggle (_pressed, _content, _style, GUILayout.Width (_position.width), GUILayout.Height (_position.height));
	}


	public bool Pressed {
		set {
			_pressed = value;

		}
		get { return _pressed; }
	}

	public OnClickFunc onButtonClick
	{
		get { return _onButtonClick; }
		set { _onButtonClick = value; }
	}
}
