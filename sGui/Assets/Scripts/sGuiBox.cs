using UnityEngine;
using System.Collections;
using System.Linq;
using System.Collections.Generic;


[ExecuteInEditMode]
public class sGuiBox : MonoBehaviour {
	
	public int _depth = 1;
	public bool _enabled = true;
	public Rect _position;
	public Font _font;
	public int _fontSize = 10;
	public Color _fontColor = Color.gray;
	public TextAnchor _textAlign;
	
	public Texture2D _background;
	public RectOffset _borderBackground;
	public Color _colorBackground = new Color(1,1,1,1);
	
	public GUIContent _content;
	public Vector2 _contentOffset;
	public ImagePosition _contentImagePosition;
	public RectOffset _margin;
	
	public GUIStyle _style = new GUIStyle();
	
	public bool isChild = false;
	
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
		_style.border = _borderBackground;
		
		_style.contentOffset = _contentOffset;
		_style.imagePosition = _contentImagePosition;
		_style.margin = _margin;
		
		_style.alignment = _textAlign;
		_style.fontSize = _fontSize;
		_style.font = _font;
		_style.richText = true;
		_style.normal.textColor = _fontColor;
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
	
	public float childGUI(float pos) {
		if (!this.gameObject.activeSelf) {
			return pos;
		}
		isChild = true;
		GUI.color = _colorBackground;
		GUILayout.BeginArea (new Rect(_position.x, _position.y+pos, _position.width, _position.height), _style);

		onGuiContent ();

		GUILayout.EndArea ();

		return _position.y + _position.height + pos;
	}

	public void childGUI(bool value) {
		if (!this.gameObject.activeSelf) {
			return;
		}
		isChild = true;
		GUI.color = _colorBackground;
		GUILayout.BeginArea (new Rect(_position.x, _position.y, _position.width, _position.height), _style);
		
		onGuiContent ();
		
		GUILayout.EndArea ();
	}

	void onGuiContent() {
		
		
		
		//foreach(Transform child in transform.Cast<Transform>().OrderBy(t=>t.name)) {
			
		//for(int i = 0; i < this.transform.childCount; i++) {
			/*
			if(child.GetComponent<sGuiSlider>() != null) {
				child.GetComponent<sGuiSlider>().childGUI(true);
			}
			if(child.GetComponent<sGuiToggle>() != null) {
				child.GetComponent<sGuiToggle>().childGUI(true);
			}
			if(child.GetComponent<sGuiBox>() != null) {
				child.GetComponent<sGuiBox>().childGUI(true);
			}
			*/
		//}
	}
	
	void OnGUI() {
		if (!this.gameObject.activeSelf) {
			return;
		}
		if (!isChild) {

			GUI.enabled = _enabled;
			GUI.depth = _depth;
			GUI.color = _colorBackground;
			GUI.BeginGroup(_position,_style);

			onGuiContent();

			GUI.EndGroup();

		}
	}
}
