using UnityEngine;
using System.Collections;



[System.Serializable]
public class AlphaSlider {
	public float value = 1;
}
[System.Serializable]
public class DepthSlider {
	public int value = 0;
}


[ExecuteInEditMode]
public class sGuiBase : MonoBehaviour {

	public AlphaSlider Alpha;
	public DepthSlider Depth;
	public bool isChild = false;
	public bool isEnabled = true;
	public TextAnchor Location;
	public Rect Position;


	public Texture2D BackgroundTexture;
	public RectOffset BackgroundBorder;
	public Color BackgroundColor = new Color(1,1,1,1);
	
	private GUIStyle _style = new GUIStyle();


	public OnGuiFunc onGuiFunc;
	public OnGuiFunc onChildGuiFunc;

	private Rect _relativePos;
	public delegate void OnGuiFunc(Rect position, GUIStyle style);
	public delegate void OnChildGuiFunc(Rect position, GUIStyle style);

	void Start () {
		
		updateStyles();
		
	}
	
	public void updateStyles() {
		if(_style == null) {
			_style = new GUIStyle();
		}
		
		if(BackgroundTexture != null) {
			BackgroundBorder.left = BackgroundBorder.right = (int)(BackgroundTexture.width * 0.5);
			BackgroundBorder.top = BackgroundBorder.bottom = (int)(BackgroundTexture.height * 0.5);
		}
		
		_style.normal.background = BackgroundTexture;
		_style.border = BackgroundBorder;
		



		CalculateRelativePos();
	}

	public void CalculateRelativePos() {

		switch(Location) {
		case TextAnchor.UpperLeft:
			_relativePos = Position;
			break;
		case TextAnchor.UpperRight:
			_relativePos = new Rect
				(Screen.width - Position.width - Position.x, 
				 Position.y, Position.width, Position.height);
			break;
		case TextAnchor.UpperCenter:
			_relativePos = new Rect
				((Screen.width - Position.width) * 0.5f + Position.x, 
				 Position.y, Position.width, Position.height);
			break;

		case TextAnchor.LowerLeft:
			_relativePos = new Rect
				(Position.x, 
				 Screen.height - Position.height - Position.y, 
				 Position.width, Position.height);
			break;
		case TextAnchor.LowerRight:
			_relativePos = new Rect
				(Screen.width - Position.width - Position.x, 
				 Screen.height - Position.height - Position.y, 
				 Position.width, Position.height);
			break;
		case TextAnchor.LowerCenter:
			_relativePos = new Rect
				((Screen.width - Position.width) * 0.5f + Position.x, 
				 Screen.height - Position.height - Position.y, 
				 Position.width, Position.height);
			break;
		
		case TextAnchor.MiddleLeft:
			_relativePos = new Rect
				(Position.x, 
				 (Screen.height - Position.height) * 0.5f + Position.y, 
				 Position.width, Position.height);
			break;
		case TextAnchor.MiddleRight:
			_relativePos = new Rect
				(Screen.width - Position.width - Position.x, 
				 (Screen.height - Position.height) * 0.5f + Position.y, 
				 Position.width, Position.height);
			break;
		case TextAnchor.MiddleCenter:
			_relativePos = new Rect
				((Screen.width - Position.width) * 0.5f + Position.x, 
				 (Screen.height - Position.height) * 0.5f + Position.y, 
				 Position.width, Position.height);
			break;
		}

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
		DrawGuiBase();
		_relativePos.y += pos;
		onChildGuiFunc(_relativePos, _style);

		return _relativePos.y + _relativePos.height + pos;
	}
	
	public void childGUI() {
		if (!this.gameObject.activeSelf) {
			return;
		}
		isChild = true;

		DrawGuiBase();
		CalculateRelativePos();
		onChildGuiFunc(_relativePos, _style);

	}

	void OnGUI() {

		if (!this.gameObject.activeSelf) {
			return;
		}

		if (!isChild) {
			
			DrawGuiBase();
			CalculateRelativePos();
			onGuiFunc(_relativePos, _style);
		}
	}

	public void DrawGuiBase() {
		GUI.enabled = isEnabled;
		GUI.depth = Depth.value;
		GUI.color = new Color( 1, 1, 1, Alpha.value);
		GUI.backgroundColor = BackgroundColor;
	}

	public GUIStyle Style {
		set { _style = value; }
		get { 
			if(_style == null) {
				return new GUIStyle();
			}
			return _style; 
		}
	}

}
