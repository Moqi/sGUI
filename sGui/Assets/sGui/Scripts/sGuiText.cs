using UnityEngine;
using System.Collections;



[ExecuteInEditMode]
public class sGuiText : sGuiBase {



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

	
	public override void updateStyles() {

		base.updateStyles();
		
		Style.focused.background = BackgroundFocus;
		Style.focused.textColor = FontFocusColor;

		Style.normal.textColor = FontColor;
		Style.padding = Padding;
		Style.contentOffset = ContentOffset;

		Style.alignment = TextAlign;
		Style.fontSize = FontSize;
		Style.font = FontFamily;
		Style.richText = true;
		Style.wordWrap = true;

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


	public override void DrawGUI(Rect position, GUIStyle style) {
		Text = GUI.TextField(position, Text, MaxLength, style);
	}

	public override void DrawChildGUI(Rect position, GUIStyle style) {
		Text = GUI.TextField(position, Text, MaxLength, style);
	}

}
