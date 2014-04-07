using UnityEngine;
using System.Collections;



[ExecuteInEditMode]
public class sGuiToggle : MonoBehaviour {
	
	public int _depth = 1;
	public Rect _position;
	public Font _font;
	public int _fontSize = 10;
	public Color _fontColor = Color.gray;
	public Color _colorPressed = Color.red;
	
	public TextAnchor _textAlign;
	
	public Texture2D _background;
	public Texture2D _backgroundPressed;
	
	public RectOffset _borderBackground;
	
	public GUIContent _content;
	public Vector2 _contentOffset;
	public ImagePosition _contentImagePosition;
	public bool isChild = false;
	
	public GUIStyle _style = new GUIStyle();


	public bool _pressed = false;
	
	private OnClickFunc _funcReturn;
	
	public delegate void OnClickFunc();
	
	void Start () {
		
		updateStyles();
		
	}
	
	public void updateStyles() {
		if(_style == null) {
			_style = new GUIStyle();
		}
		
		if(_background != null) {
			_borderBackground.left = _borderBackground.right = (int)(_background.width * 0.5);
			_borderBackground.top = _borderBackground.bottom = (int)(_background.height * 0.5);
		}
		
		_style.normal.background = _background;

		_style.onNormal.background = _backgroundPressed;
		_style.border = _borderBackground;
		
		_style.contentOffset = _contentOffset;
		_style.imagePosition = _contentImagePosition;
		
		_style.alignment = _textAlign;
		_style.fontSize = _fontSize;
		_style.font = _font;
		_style.richText = true;
		_style.normal.textColor = _fontColor;
		_style.onNormal.textColor = _colorPressed;
	}
	
	
	void OnValidate() {
		updateStyles();
	}
	
	public void childGUI(bool isModal) {
		if (!this.gameObject.activeSelf) {
			return;
		}

		isChild = true;
		_pressed = GUI.Toggle (_position, _pressed, _content, _style);
		
	}
	
	public void childGUI() {
		if (!this.gameObject.activeSelf) {
			return;
		}

		isChild = true;
		_pressed = GUILayout.Toggle (_pressed, _content, _style, GUILayout.Width (_position.width), GUILayout.Height (_position.height));

		
	}
	
	void OnGUI() {
		if (!this.gameObject.activeSelf) {
			return;
		}

		if (!isChild) {
			GUI.depth = _depth;
			_pressed = GUI.Toggle(_position, _pressed, _content, _style);
			if (GUI.changed && _funcReturn != null) {
				_funcReturn();
			}
		}
	}

	
	public OnClickFunc funcReturn
	{
		get{ return _funcReturn;  }
		set{ _funcReturn = value; }
	}
}
