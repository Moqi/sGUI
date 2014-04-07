using UnityEngine;
using System.Collections;



[ExecuteInEditMode]
public class sGuiScrollerBox : MonoBehaviour {

	public int _depth = 1;
	public bool _enabled = true;
	public Rect _position;
	
	public Vector2 _scroll;
	
	public Texture2D _box;
	private RectOffset _borderBackground;
	public RectOffset _boxPadding;

	public Texture2D _scrollerBg;
	public Texture2D _scrollerThumb;
	public float _scrollerSize;
	public int _scrollerMargin;
	public RectOffset _scrollerPadding;
	public RectOffset _scrollerThumbPadding;
	
	public GUIStyle _style;
	
	public GUIStyle _styleScroller;
	public GUIStyle _styleThumb;

	public delegate void OnGuiItem();
	private OnGuiItem _guiItem;
	
	void Start () {

		updateStyles();
	}
	
	public void updateStyles() {

		if(_style == null) {
			_style = new GUIStyle();
		}

		if(_box != null) {
			_borderBackground = new RectOffset(0,0,0,0);
			_borderBackground.left = _borderBackground.right = (int)(_box.width * 0.5);
			_borderBackground.top = _borderBackground.bottom = (int)(_box.height * 0.5);
		}

		if(_scrollerBg != null) {
			_styleScroller.border.left = _styleScroller.border.right = (int)(_scrollerBg.width * 0.5);
			_styleScroller.border.top = _styleScroller.border.bottom = (int)(_scrollerBg.height * 0.5);
		}
		if(_scrollerThumb != null) {
			_styleThumb.border.left = _styleThumb.border.right = (int)(_scrollerThumb.width * 0.5);
			_styleThumb.border.top = _styleThumb.border.bottom = (int)(_scrollerThumb.height * 0.5);
		}

		_styleScroller.padding = new RectOffset(_scrollerPadding.left, _scrollerPadding.right, _scrollerPadding.top, _scrollerPadding.bottom);

		_styleScroller.overflow = new RectOffset(-_scrollerPadding.left, -_scrollerPadding.right, -_scrollerPadding.top, -_scrollerPadding.bottom);

		_styleScroller.margin = new RectOffset(_scrollerMargin,0,0,0);

		_styleScroller.fixedWidth = _scrollerSize;
		_styleScroller.normal.background = _scrollerBg;
		_styleThumb.normal.background = _scrollerThumb;
		_styleThumb.overflow = _scrollerThumbPadding;
		
		_style.normal.background = _box;
		if (_borderBackground != null) {
			_style.border = _borderBackground;
		}

		_style.padding = _boxPadding;


		//Debug.Log (this.transform.childCount);
		for(int i = 0; i < this.transform.childCount; i++) {
			//this.transform.GetChild(i).GetComponent<sGuiBox>().isChild = true;
		}
		
	}
	
	
	void OnValidate() {
		updateStyles();
    }

	public Rect _view = new Rect(0,0,200,600);
	public Rect _boxPos;

	void onGuiWindow(int windowId) {

		//_scroll = GUILayout.BeginScrollView(_scroll, false, true );
		_scroll = GUI.BeginScrollView (_boxPos, _scroll, _view, false, true);

		float _pos = 0;
		for(int i = 0; i < this.transform.childCount; i++) {
			_pos = this.transform.GetChild(i).GetComponent<sGuiBox>().childGUI(_pos);
		}
		if (_pos < _boxPos.height) {
			_pos = _boxPos.height;
		}
		_view.width = _boxPos.width - _scrollerSize - _scrollerMargin;
		_view.height = _pos;
		
		GUI.EndScrollView();
	}
	
	void OnGUI() {

		GUI.enabled = _enabled;
		GUI.depth = _depth;

		GUI.skin.verticalScrollbarThumb = _styleThumb;
		GUI.skin.verticalScrollbar = _styleScroller;
		//GUILayout.BeginArea(_position, _style);
		GUI.BeginGroup (_position, _style);
		//GUI.Window (2, _position, onGuiWindow, "", _style);


		_scroll = GUI.BeginScrollView (_boxPos, _scroll, _view, false, true);
		
		float _pos = 0;
		for(int i = 0; i < this.transform.childCount; i++) {
			_pos = this.transform.GetChild(i).GetComponent<sGuiBox>().childGUI(_pos);
		}
		if (_pos < _boxPos.height) {
			_pos = _boxPos.height;
		}
		_view.width = _boxPos.width - _scrollerSize - _scrollerMargin;
		_view.height = _pos;

		GUI.EndScrollView();




		GUI.EndGroup ();
		//GUILayout.EndArea();
	}

	public OnGuiItem guiItem {
		set { _guiItem = value; }
		get { return _guiItem; }
	}

}
