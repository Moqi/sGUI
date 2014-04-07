using UnityEngine;
using System.Collections;



[ExecuteInEditMode]
public class sGuiSlider : MonoBehaviour {

	public int _depth = 1;
	public Rect _position;
	
	
	public Texture2D _slider;
	private RectOffset _sliderBorder = new RectOffset();
	public RectOffset _sliderSize = new RectOffset();
	
	
	public Texture2D _sliderThumb;
	public RectOffset _sliderThumbSize = new RectOffset();
	private RectOffset _sliderThumbBorder = new RectOffset();
	private RectOffset _sliderThumbPadding = new RectOffset();
	
	public Vector2 _contentOffset;
	public ImagePosition _contentImagePosition;
	
	public GUIStyle _sliderBarStyle = new GUIStyle();
	public GUIStyle _sliderThumbStyle = new GUIStyle();
	
	
	public float _minValue = 0.0f;
	public float _maxValue = 100.0f;
	private float _value = 0.0f;

	public bool isChild = false;
	
	
	void Start () {
		
		updateStyles();
		
	}
	
	public void updateStyles() {
		if(_sliderBarStyle == null) {
			_sliderBarStyle = new GUIStyle();
			_sliderThumbStyle = new GUIStyle();
		}
		
		if(_slider != null) {
			_sliderBorder.left = _sliderBorder.right = (int)(_slider.width * 0.5);
			_sliderBorder.top = _sliderBorder.bottom = (int)(_slider.height * 0.5);
		}
		if(_sliderThumb != null) {
			_sliderThumbPadding.left = _sliderThumbPadding.right = _sliderThumbBorder.left = _sliderThumbBorder.right = (int)(_sliderThumb.width * 0.5);
			
			_sliderThumbBorder.top = _sliderThumbBorder.bottom = (int)(_sliderThumb.height * 0.5);
		}
		
		_sliderBarStyle.normal.background = _slider;
		_sliderBarStyle.border = _sliderBorder;
		_sliderThumbStyle.overflow = _sliderSize;
		
		
		_sliderThumbStyle.normal.background = _sliderThumb;
		_sliderThumbStyle.border = _sliderThumbBorder;
		_sliderThumbStyle.padding = _sliderThumbPadding;
		_sliderThumbStyle.overflow = _sliderThumbSize;
		
	}
	
	
	void OnValidate() {
		updateStyles();
    }


	public void childGUI(bool isModal) {
		isChild = true;
		//Rect _pos = new Rect (_position.x + _boxPos.x, _position.y + _boxPos.y, _position.width, _position.height);
		_value = GUI.HorizontalSlider(_position, _value, _minValue, _maxValue, _sliderBarStyle, _sliderThumbStyle);
		
	}
	
	public void childGUI() {
		isChild = true;
		_value = GUILayout.HorizontalSlider(_value, _minValue, _maxValue, _sliderBarStyle, _sliderThumbStyle);
	}
	
	void OnGUI() {
		if (!isChild) {
			GUI.depth = _depth;
			_value = GUI.HorizontalSlider (_position, _value, _minValue, _maxValue, _sliderBarStyle, _sliderThumbStyle);
		}
		
	}
	
	public float value
    {
          get{ return _value;  }
          set{ _value = value; }
    }
}
