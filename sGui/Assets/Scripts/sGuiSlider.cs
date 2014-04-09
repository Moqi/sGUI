using UnityEngine;
using System.Collections;



[ExecuteInEditMode]
public class sGuiSlider : MonoBehaviour {

	public DirectionBox Direction;
	public Texture2D SliderTexture;

	private RectOffset SliderBorder = new RectOffset();
	//private RectOffset SliderSize = new RectOffset();
	
	
	public Texture2D SliderThumbTexture;
	public RectOffset SliderThumbSize = new RectOffset();

	private RectOffset SliderThumbBorder = new RectOffset();
	//private RectOffset SliderThumbPadding = new RectOffset();
	private GUIStyle SliderBarStyle = new GUIStyle();
	private GUIStyle SliderThumbStyle = new GUIStyle();
	
	
	public float _minValue = 0.0f;
	public float _maxValue = 100.0f;
	private float _value = 0.0f;


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


		if (SliderBarStyle == null) {
			SliderBarStyle = new GUIStyle();
			SliderThumbStyle = new GUIStyle();
		}


		if (SliderTexture != null) {
			SliderBorder.left = SliderBorder.right = (int)(SliderTexture.width * 0.5f);
			SliderBorder.top = SliderBorder.bottom = (int)(SliderTexture.height * 0.5f);
		}
		if (SliderThumbTexture != null) {
			// SliderThumbPadding.left = SliderThumbPadding.right = SliderThumbBorder.left = SliderThumbBorder.right = (int)(SliderThumbTexture.width * 0.5f);
			SliderThumbBorder.left = SliderThumbBorder.right = (int)(SliderThumbTexture.width * 0.5f);
			SliderThumbBorder.top = SliderThumbBorder.bottom = (int)(SliderThumbTexture.height * 0.5f);
		}

		SliderBarStyle.normal.background = SliderTexture;
		SliderBarStyle.border = SliderBorder;


		SliderThumbStyle.normal.background = SliderThumbTexture;
		SliderThumbStyle.overflow = SliderThumbSize;
		
	}




	public void drawGui(Rect position, GUIStyle style) {
		switch(Direction) {
			case DirectionBox.Horizontal:
				_value = GUI.HorizontalSlider(position, _value, _minValue, _maxValue, SliderBarStyle, SliderThumbStyle);
				break;
			case DirectionBox.Vertical:
				_value = GUI.VerticalSlider(position, _value, _minValue, _maxValue, SliderBarStyle, SliderThumbStyle);
				break;
		}
	}

	public void drawChildGui(Rect position, GUIStyle style) {
		switch (Direction) {
			case DirectionBox.Horizontal:
				_value = GUI.HorizontalSlider(position, _value, _minValue, _maxValue, SliderBarStyle, SliderThumbStyle);
				break;
			case DirectionBox.Vertical:
				_value = GUI.VerticalSlider(position, _value, _minValue, _maxValue, SliderBarStyle, SliderThumbStyle);
				break;
		}
		// _value = GUILayout.HorizontalSlider(_value, _minValue, _maxValue, _sliderBarStyle, _sliderThumbStyle);
	}

	
	public float value
    {
          get{ return _value;  }
          set{ _value = value; }
    }
}
