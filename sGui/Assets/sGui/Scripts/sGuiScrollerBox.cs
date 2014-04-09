using UnityEngine;
using System.Collections;



[ExecuteInEditMode]
public class sGuiScrollerBox : MonoBehaviour {

	public Vector2 _scroll;
	
	public RectOffset _boxPadding;

	public Texture2D _scrollerBg;
	public Texture2D _scrollerThumb;
	public float _scrollerSize;
	public int _scrollerMargin;
	public RectOffset _scrollerPadding;
	public RectOffset _scrollerThumbPadding;

	
	public GUIStyle _styleScroller;
	public GUIStyle _styleThumb;


	public Rect _view = new Rect();
	public Rect _boxPos;
	
	void Start () {

		updateStyles();
	}
	
	public void updateStyles() {

		

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
		
		


		//Debug.Log (this.transform.childCount);
		for(int i = 0; i < this.transform.childCount; i++) {
			//this.transform.GetChild(i).GetComponent<sGuiBox>().isChild = true;
		}
		
	}






	void onGuiWindow(int windowId) {

		//_scroll = GUILayout.BeginScrollView(_scroll, false, true );
		_scroll = GUI.BeginScrollView (_boxPos, _scroll, _view, false, true);

		float _pos = 0;
		for(int i = 0; i < this.transform.childCount; i++) {
			//_pos = this.transform.GetChild(i).GetComponent<sGuiBox>().childGUI(_pos);
		}
		if (_pos < _boxPos.height) {
			_pos = _boxPos.height;
		}
		_view.width = _boxPos.width - _scrollerSize - _scrollerMargin;
		_view.height = _pos;
		
		GUI.EndScrollView();
	}
	
	void OnGUI() {

		
		GUI.skin.verticalScrollbarThumb = _styleThumb;
		GUI.skin.verticalScrollbar = _styleScroller;
		
		//GUI.BeginGroup (_position, _style);

		_scroll = GUI.BeginScrollView (_boxPos, _scroll, _view, false, true);
		
		float _pos = 0;
		for(int i = 0; i < this.transform.childCount; i++) {
			//_pos = this.transform.GetChild(i).GetComponent<sGuiBox>().childGUI(_pos);
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
}
