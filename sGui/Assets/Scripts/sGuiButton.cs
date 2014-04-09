using UnityEngine;
using System.Collections;



[ExecuteInEditMode]
public class sGuiButton : MonoBehaviour {
	
	public bool _hasAudio = true;
	
	public Texture2D BackgroundHover;
	public Texture2D BackgroundPressed;
	
	
	public Font FontFamily;
	public int FontSize = 10;

	public Color FontColor = Color.gray;
	public Color FontColorHover = Color.gray;
	public Color FontColorActive = Color.red;

	public TextAnchor TextAlign;
	
	public GUIContent Content;
	public Vector2 ContentOffset;
	public ImagePosition ContentImagePosition;
	public RectOffset Margin;


	private OnClickFunc _onClickButton;
	
	public delegate void OnClickFunc(GameObject curr = null);
	
	void Start () {
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

		if(this.GetComponent<sGuiBase>() != null) {
			this.GetComponent<sGuiBase>().onGuiFunc = drawGui;
			this.GetComponent<sGuiBase>().onChildGuiFunc = drawChildGui;
		}

		if(this.GetComponent<sGuiBase>() == null) {
			return;
		}
		GUIStyle _style = this.GetComponent<sGuiBase>().Style;

		_style.hover.background = BackgroundHover;
		_style.active.background = BackgroundPressed;
		
		_style.contentOffset = ContentOffset;
		_style.imagePosition = ContentImagePosition;
		
		_style.alignment = TextAlign;
		_style.fontSize = FontSize;
		_style.font = FontFamily;
		_style.richText = true;
		_style.wordWrap = true;
		_style.normal.textColor = FontColor;
		_style.hover.textColor = FontColorHover;
		_style.active.textColor = FontColorActive;

		this.GetComponent<sGuiBase>().Style = _style;
	}


	public void drawGui(Rect position, GUIStyle style) {

		
		bool _clicked = GUI.Button(position, Content, style);
		
		if (_clicked) {
			
			if (_hasAudio && this.GetComponent<AudioSource>() != null) {
				this.GetComponent<AudioSource>().Play();
			}
			
			if(_onClickButton != null) {
				_onClickButton(this.gameObject);
			}
		}

	}
	
	public void drawChildGui(Rect position, GUIStyle style) {

		//bool _clicked = GUILayout.Button(Content, style, GUILayout.Width(position.width), GUILayout.Height(position.height));
		bool _clicked = GUI.Button(position, Content, style);
		
		if (_clicked) {
			
			if (_hasAudio && this.GetComponent<AudioSource>() != null) {
				this.GetComponent<AudioSource>().Play();
			}
			
			if(_onClickButton != null) {
				_onClickButton(this.gameObject);
			}
		}

	}
	

	public OnClickFunc onClickButton
    {
          get{ return _onClickButton;  }
		set{ _onClickButton = value; }
    }
}