using UnityEngine;
using System.Collections;



[ExecuteInEditMode]
public class sGuiToggle : MonoBehaviour {
	
	public Font FontFamily;
	public int FontSize = 10;
	
	public TextAnchor TextAlign;
	
	public GUIContent Content;
	public Color FontColor = Color.gray;

	public Texture2D BackgroundTexturePressed;
	public GUIContent ContentPressed;
	public Color FontColorPressed = Color.red;

	public Vector2 ContentOffset;
	public ImagePosition ContentImagePosition;


	private bool _pressed = false;
	
	private OnClickFunc _onButtonClick;
	
	public delegate void OnClickFunc();

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

		if (this.GetComponent<sGuiBase>() == null) {
			return;
		}

		GUIStyle _style = this.GetComponent<sGuiBase>().Style;
		
		_style.onNormal.background = BackgroundTexturePressed;
		
		_style.contentOffset = ContentOffset;
		_style.imagePosition = ContentImagePosition;
		
		_style.alignment = TextAlign;
		_style.fontSize = FontSize;
		_style.font = FontFamily;
		_style.richText = true;
		_style.wordWrap = true;
		_style.normal.textColor = FontColor;
		_style.onNormal.textColor = FontColorPressed;


		this.GetComponent<sGuiBase>().Style = _style;
	}


	public void drawGui(Rect position, GUIStyle style) {

		Pressed = GUI.Toggle(position, _pressed, (_pressed) ? ContentPressed : Content, style);

		if (GUI.changed && _onButtonClick != null) {
			_onButtonClick();
		}
	}

	public void drawChildGui(Rect position, GUIStyle style) {

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
