using UnityEngine;
using System.Collections;



[ExecuteInEditMode]
public class sGuiButton : sGuiBase {
	
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


	public override void DrawGUI(Rect position, GUIStyle style) {

		
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

	public override void DrawChildGUI(Rect position, GUIStyle style) {

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