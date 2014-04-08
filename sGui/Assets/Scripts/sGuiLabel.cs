using UnityEngine;
using System.Collections;


[ExecuteInEditMode]
public class sGuiLabel : MonoBehaviour {


	public Font FontFamily;
	public int FontSize = 10;
	public Color FontColor = Color.gray;
	public TextAnchor TextAlign;

	public GUIContent Content;
	public Vector2 ContentOffset;
	public ImagePosition ContentImagePosition;
	public RectOffset Margin;

	
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

		_style.contentOffset = ContentOffset;
		_style.imagePosition = ContentImagePosition;
		_style.margin = Margin;
		
		_style.alignment = TextAlign;
		_style.fontSize = FontSize;
		_style.font = FontFamily;
		_style.richText = true;
		_style.wordWrap = true;
		_style.normal.textColor = FontColor;

		this.GetComponent<sGuiBase>().Style = _style;
	}

	public void drawGui(Rect position, GUIStyle style) {
		GUI.Label (position, Content, style);
	}

	public void drawChildGui(Rect position, GUIStyle style) {
		GUI.Label(position, Content, style);
		//GUI.Label (Content, style, GUILayout.Width (position.width), GUILayout.Height (position.height));
	}


}
