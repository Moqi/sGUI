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



public enum DirectionBox
{
	Vertical, Horizontal
}

[ExecuteInEditMode]
public class sGuiBase : MonoBehaviour {

	public AlphaSlider Alpha;
	public DepthSlider Depth;
	public bool isChild = false;
	public bool isDisabled = false;
	public TextAnchor Location;
	public Rect Position;


	public Texture2D BackgroundTexture;
	public Color BackgroundColor = new Color(1,1,1,1);


	private RectOffset BackgroundBorder = new RectOffset();
	private Rect _relativePos;
	private GUIStyle _style = new GUIStyle();

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
	
	public virtual void updateStyles() {
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

	private void CalculateRelative(Rect rect) {
		switch (Location) {
			case TextAnchor.UpperLeft:
				_relativePos = Position;
				break;
			case TextAnchor.UpperRight:
				_relativePos = new Rect
					(rect.width - Position.width - Position.x,
					 Position.y, Position.width, Position.height);
				break;
			case TextAnchor.UpperCenter:
				_relativePos = new Rect
					((rect.width - Position.width) * 0.5f + Position.x,
					 Position.y, Position.width, Position.height);
				break;

			case TextAnchor.LowerLeft:
				_relativePos = new Rect
					(Position.x,
					 rect.height - Position.height - Position.y,
					 Position.width, Position.height);
				break;
			case TextAnchor.LowerRight:
				_relativePos = new Rect
					(rect.width - Position.width - Position.x,
					 rect.height - Position.height - Position.y,
					 Position.width, Position.height);
				break;
			case TextAnchor.LowerCenter:
				_relativePos = new Rect
					((rect.width - Position.width) * 0.5f + Position.x,
					 rect.height - Position.height - Position.y,
					 Position.width, Position.height);
				break;

			case TextAnchor.MiddleLeft:
				_relativePos = new Rect
					(Position.x,
					 (rect.height - Position.height) * 0.5f + Position.y,
					 Position.width, Position.height);
				break;
			case TextAnchor.MiddleRight:
				_relativePos = new Rect
					(rect.width - Position.width - Position.x,
					 (rect.height - Position.height) * 0.5f + Position.y,
					 Position.width, Position.height);
				break;
			case TextAnchor.MiddleCenter:
				_relativePos = new Rect
					((rect.width - Position.width) * 0.5f + Position.x,
					 (rect.height - Position.height) * 0.5f + Position.y,
					 Position.width, Position.height);
				break;
		}
	}

	public void CalculateRelativePos() {
		CalculateRelative(new Rect(0, 0, Screen.width, Screen.height));
	}
	public void CalculateRelativePos(Rect RectBase) {
		CalculateRelative(RectBase);
	}
	
	

	public Vector2 childGUI(Rect parent, Vector2 pos) {
		if (!this.gameObject.activeSelf) {
			return pos;
		}
		isChild = true;

		DrawGuiBase();
		CalculateRelativePos(parent);

		_relativePos.x += pos.x;
		_relativePos.y += pos.y;

		DrawChildGUI(_relativePos, _style);

		return new Vector2(_relativePos.x + _relativePos.width, _relativePos.y + _relativePos.height);
	}

	public void childGUI(Rect parent) {
		if (!this.gameObject.activeSelf) {
			return;
		}
		isChild = true;

		DrawGuiBase();
		CalculateRelativePos(parent);
		DrawGUI(_relativePos, _style);

	}

	void OnGUI() {

		if (!this.gameObject.activeSelf) {
			return;
		}

		if (!isChild) {
			DrawGuiBase();
			CalculateRelativePos();
			DrawGUI(_relativePos, _style);
		}
	}

	public virtual void DrawChildGUI(Rect position, GUIStyle style) {

	}
	public virtual void DrawGUI(Rect position, GUIStyle style) {

	}

	public void DrawGuiBase() {
		GUI.enabled = !isDisabled;
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

	public Rect relativePos {
		get {
			return _relativePos;
		}
	}
	

}
