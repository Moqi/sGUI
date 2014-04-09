using UnityEngine;
using System.Collections;



[ExecuteInEditMode]
public class sGuiText : MonoBehaviour {



	public string Text;
	public int MaxLength = 50;

	public Texture2D BackgroundFocus;
	public RectOffset Padding = new RectOffset();


	public Font FontFamily;
	public int FontSize = 10;
	public Color FontColor = Color.gray;
	public Color FontFocusColor = Color.red;
	public TextAnchor TextAlign;
	public Vector2 ContentOffset;

	
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
		
		_style.focused.background = BackgroundFocus;
		_style.focused.textColor = FontFocusColor;

		_style.normal.textColor = FontColor;
		_style.padding = Padding;
		_style.contentOffset = ContentOffset;
		
		_style.alignment = TextAlign;
		_style.fontSize = FontSize;
		_style.font = FontFamily;
		_style.richText = true;
		_style.wordWrap = true;

		this.GetComponent<sGuiBase>().Style = _style;
	}

    void Update() {

        if (!this.gameObject.activeSelf) {
            return;
        }

        if (Input.inputString.Length > 0 && MaxLength > 0) {
            if (Text.Length > MaxLength) {
				Text = Text.Substring(0, MaxLength);
            }
        }
    }


	public void drawGui(Rect position, GUIStyle style) {
		Text = GUI.TextField(position, Text, MaxLength, style);
	}
	
	public void drawChildGui(Rect position, GUIStyle style) {
		Text = GUI.TextField(position, Text, MaxLength, style);
	}

}
