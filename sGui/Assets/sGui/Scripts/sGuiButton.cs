using UnityEngine;
using System.Collections;



[ExecuteInEditMode]
public class sGuiButton : sGuiBase {
	
	public bool _hasAudio = true;
	
	public Texture2D BackgroundHover;
	public Texture2D BackgroundPressed;
	
	
	public int FontSize = 10;

	public Color FontColor = Color.gray;
	public Color FontColorHover = Color.gray;
	public Color FontColorActive = Color.red;

	public TextAnchor TextAlign;
	
	public Vector2 ContentOffset;
	public ImagePosition ContentImagePosition;
	public RectOffset Margin;

	private Rect absPos;
	private Vector2 rpos;
	private bool _hover;
	private OnClickFunc _onClickButton;
	private OnClickFunc _onHoverButton;
	private OnClickFunc _onOutButton;
	
	public delegate void OnClickFunc(GameObject curr = null);
	
	
	
	public override void updateStyles() {

		base.updateStyles();
		
		Style.hover.background = BackgroundHover;
		Style.active.background = BackgroundPressed;

		Style.contentOffset = ContentOffset;
		Style.imagePosition = ContentImagePosition;

		Style.alignment = TextAlign;
		Style.fontSize = FontSize;
		Style.font = FontFamily;
		Style.richText = true;
		Style.wordWrap = true;
		Style.normal.textColor = FontColor;
		Style.hover.textColor = FontColorHover;
		Style.active.textColor = FontColorActive;

	}

	void Update() {

		if (absPos.Contains(new Vector2(Input.mousePosition.x, Screen.height - Input.mousePosition.y))) {
			if (_onHoverButton != null) {
				_onHoverButton(this.gameObject);
			}
			_hover = true;
		} else if (_hover) {
			if (_onOutButton != null) {
				_onOutButton(this.gameObject);
			}
			_hover = false;
		}

	}


	public override void DrawGUI(Rect position, GUIStyle style) {

		
		bool _clicked = GUI.Button(position, Content, style);
		
		rpos = GUIUtility.GUIToScreenPoint(new Vector2(position.x, position.y)); ;
		absPos = new Rect(rpos.x, rpos.y, position.width, position.height);
		
		if (_clicked) {
			
			if (_hasAudio && this.GetComponent<AudioSource>() != null) {
				this.GetComponent<AudioSource>().Play();
			}
			
			if(_onClickButton != null) {
				_onClickButton(this.gameObject);
			}
		}

	}

	public override void DrawChildGUI(Rect position, GUIStyle style) {

		bool _clicked = GUI.Button(position, Content, style);

		rpos = GUIUtility.GUIToScreenPoint(new Vector2(position.x, position.y)); ;
		absPos = new Rect(rpos.x, rpos.y, position.width, position.height);

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

	public OnClickFunc onHoverButton {
		get { return _onHoverButton; }
		set { _onHoverButton = value; }
	}

	public OnClickFunc onOutButton {
		get { return _onOutButton; }
		set { _onOutButton = value; }
	}
}