using UnityEngine;
using System.Collections;
using System.Linq;
using System.Collections.Generic;



[ExecuteInEditMode]
public class sGuiBox : sGuiBase {

	// TODO

	public bool AlphaToChild;
	public bool EnabledToChild;

	public bool Scroller;
	public DirectionBox ScrollerOverflow;
	public TextAnchor ChildLocation;



	private Vector2 _scroll;


	public Texture2D _scrollerBg;
	public Texture2D _scrollerThumb;
	public float _scrollerSize;
	public int _scrollerMargin;
	public RectOffset _scrollerPadding;


	private GUIStyle _styleScroller;
	private GUIStyle _styleThumb;


	private Rect _view = new Rect();
	private Rect _boxPos;






	public override void updateStyles() {

		base.updateStyles();

		if (_styleScroller == null) {
			_styleScroller = new GUIStyle();
			_styleThumb = new GUIStyle();
		}


		if (_scrollerBg != null) {
			_styleScroller.border.left = _styleScroller.border.right = (int)(_scrollerBg.width * 0.5);
			_styleScroller.border.top = _styleScroller.border.bottom = (int)(_scrollerBg.height * 0.5);
		}
		if (_scrollerThumb != null) {
			_styleThumb.border.left = _styleThumb.border.right = (int)(_scrollerThumb.width * 0.5);
			_styleThumb.border.top = _styleThumb.border.bottom = (int)(_scrollerThumb.height * 0.5);
		}

		_styleScroller.padding = _scrollerPadding;

		_styleScroller.overflow = new RectOffset(-_scrollerPadding.left, -_scrollerPadding.right, -_scrollerPadding.top, -_scrollerPadding.bottom);

		_styleScroller.margin = new RectOffset(_scrollerMargin, 0, 0, 0);

		_styleScroller.fixedWidth = _scrollerSize + _scrollerPadding.left + _scrollerPadding.right;
		_styleScroller.normal.background = _scrollerBg;
		_styleThumb.normal.background = _scrollerThumb;
		_styleThumb.overflow = _scrollerPadding;


		_boxPos = new Rect(0, 0, this.GetComponent<sGuiBase>().Position.width, this.GetComponent<sGuiBase>().Position.height);
		
		foreach (Transform child in transform.Cast<Transform>().OrderBy(t => t.GetComponent<sGuiBase>().Depth.value)) {
			if (child.GetComponent<sGuiBase>() != null) {
				if (AlphaToChild) {
					child.GetComponent<sGuiBase>().Alpha = this.GetComponent<sGuiBase>().Alpha;
				}
				if (EnabledToChild) {
					child.GetComponent<sGuiBase>().isDisabled = this.GetComponent<sGuiBase>().isDisabled;
				}
				
			}
		}
	}

	public override void DrawGUI(Rect position, GUIStyle style) {

		
		GUI.BeginGroup(position, style);
		
		if (Scroller) {

			GUI.skin.verticalScrollbarThumb = _styleThumb;
			GUI.skin.verticalScrollbar = _styleScroller;

			_scroll = GUI.BeginScrollView(_boxPos, _scroll, _view, false, true);
			onGuiContentScroller();
			GUI.EndScrollView();
		} else {
			onGuiContent();
		}

		GUI.EndGroup();

	}

	public override void DrawChildGUI(Rect position, GUIStyle style) {

		
		if (Scroller) {
			GUI.skin.verticalScrollbarThumb = _styleThumb;
			GUI.skin.verticalScrollbar = _styleScroller;
			
			GUI.BeginGroup(position, style);
			_scroll = GUI.BeginScrollView(_boxPos, _scroll, _view, false, true);
			onGuiContentScroller();
			GUI.EndScrollView();
			GUI.EndGroup();

		} else {
			
			GUILayout.BeginArea(position, style);
			onGuiContent();
			GUILayout.EndArea();

		}
		
		

	}

	private void onGuiContentScroller() {
		Vector2 p = new Vector2();

		foreach (Transform child in transform.Cast<Transform>().OrderBy(t => t.GetComponent<sGuiBase>().Depth.value)) {

			if (child.GetComponent<sGuiBase>() != null) {

				switch (ScrollerOverflow) {
					case DirectionBox.Vertical:
						p.x = 0;
						break;
					case DirectionBox.Horizontal:
						p.y = 0;
						break;
				}

				p = child.GetComponent<sGuiBase>().childGUI(this.GetComponent<sGuiBase>().Position, p);
			}
		}

		switch (ScrollerOverflow) {
			case DirectionBox.Vertical:
				if (p.y < _boxPos.height) {
					p.y = _boxPos.height;
				}
				_view.width = _boxPos.width - _scrollerSize - _scrollerPadding.left - _scrollerPadding.right - _scrollerMargin;
				_view.height = p.y;
				break;
			case DirectionBox.Horizontal:
				if (p.x < _boxPos.width) {
					p.x = _boxPos.width;
				}
				_view.height = _boxPos.height - _scrollerSize - _scrollerPadding.left - _scrollerPadding.right - _scrollerMargin;
				_view.width = p.x;
				break;
		}
		

	}

	private void onGuiContent() {
		
		foreach(Transform child in transform.Cast<Transform>().OrderBy(t=>t.GetComponent<sGuiBase>().Depth.value)) {
			if(child.GetComponent<sGuiBase>() != null) {
				child.GetComponent<sGuiBase>().childGUI(this.GetComponent<sGuiBase>().Position);
			}
		}
	}
}
