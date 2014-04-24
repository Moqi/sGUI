using UnityEngine;
using System.Collections;



[ExecuteInEditMode]
public class sGuiProgressBar : sGuiBase
{

	public DirectionBox Direction;
	public Texture2D SliderTexture;
	public Texture2D SliderThumbTexture;
	public Rect Border;

	private RectOffset SliderBorder = new RectOffset();
	private RectOffset SliderThumbBorder = new RectOffset();
	private GUIStyle SliderBarStyle = new GUIStyle();
	public GUIStyle SliderThumbStyle = new GUIStyle();


	public float _maxValue = 100.0f;
	public float _value = 0.0f;

	private float percent;

	public override void updateStyles() {

		base.updateStyles();

		if (SliderBarStyle == null) {
			SliderBarStyle = new GUIStyle();
			SliderThumbStyle = new GUIStyle();
		}
		//SliderBarStyle = Style;
		//SliderThumbStyle = Style;

		if (SliderTexture != null) {

			SliderBorder.left = SliderBorder.right = (int)(SliderTexture.width * 0.5f);
			SliderBorder.top = SliderBorder.bottom = (int)(SliderTexture.height * 0.5f);

		}
		if (SliderThumbTexture != null) {
			
			SliderThumbBorder.left = SliderThumbBorder.right = (int)(SliderThumbTexture.width * 0.5f);
			SliderThumbBorder.top = SliderThumbBorder.bottom = (int)(SliderThumbTexture.height * 0.5f);
		}

		SliderBarStyle.normal.background = SliderTexture;
		SliderBarStyle.border = SliderBorder;

		SliderThumbStyle.normal.background = SliderThumbTexture;
		SliderThumbStyle.border = SliderThumbBorder;

	}

	public void updatePercent(Rect size) {

		percent = value / _maxValue;
		if (percent > 1) {
			percent = 1;
			value = _maxValue;
		}
		if (percent <= 0) {
			value = 0;
		}
	}

	public override void DrawGUI(Rect position, GUIStyle style) {

		switch (Direction) {
			case DirectionBox.Horizontal:

				updatePercent(position);

				float wi = (position.width - Border.x - Border.width) * percent;
				if (wi * 0.5f < SliderThumbBorder.left) {
					SliderThumbBorder.left = SliderThumbBorder.right = (int)(wi * 0.5f);
					SliderThumbStyle.border = SliderThumbBorder;
				}

				GUI.Label(position, new GUIContent(), SliderBarStyle);
				GUI.Label(new Rect(position.x + Border.x, 
									position.y + Border.y,
									wi,
									position.height - Border.y - Border.height), 
					new GUIContent(), SliderThumbStyle);

				break;
			case DirectionBox.Vertical:
				
				break;
		}
	}

	public override void DrawChildGUI(Rect position, GUIStyle style) {
		switch (Direction) {
			case DirectionBox.Horizontal:
				
				break;
			case DirectionBox.Vertical:
				
				break;
		}
		// _value = GUILayout.HorizontalSlider(_value, _minValue, _maxValue, _sliderBarStyle, _sliderThumbStyle);
	}


	public float value {
		get { return _value; }
		set { _value = value; }
	}
}
