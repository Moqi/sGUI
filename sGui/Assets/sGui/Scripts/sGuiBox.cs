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

	private TextAnchor ChildLocation = TextAnchor.UpperLeft; // initial version only with UpperLeftLocation



	private Vector2 _scroll;


	public Texture2D _scrollerBg;
	public Texture2D _scrollerThumb;
	public float _scrollerBarSize;
	public RectOffset _scrollerBarPadding;
	public RectOffset _scrollerMargin;

	public GUIStyle _styleScroller;
	public GUIStyle _styleThumb;


	public Rect _view = new Rect();
	public Rect _boxPos;






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

		
		_styleScroller.padding = new RectOffset(_scrollerBarPadding.left,
												_scrollerBarPadding.right,
												_scrollerBarPadding.top,
												_scrollerBarPadding.bottom);




		_styleScroller.overflow = new RectOffset(-_scrollerBarPadding.left,
												 -_scrollerBarPadding.right,
												 -_scrollerBarPadding.top,
												 -_scrollerBarPadding.bottom);
		
		//_styleScroller.margin = _scrollerMargin;

		
		if (ScrollerOverflow == DirectionBox.Vertical) {
			_styleScroller.fixedWidth = _scrollerBarSize + _scrollerBarPadding.left + _scrollerBarPadding.right;
			_styleScroller.fixedHeight = 0;
		} else {
			_styleScroller.fixedHeight = _scrollerBarSize + _scrollerBarPadding.top + _scrollerBarPadding.bottom;
			_styleScroller.fixedWidth = 0;
		}
		
		_styleScroller.stretchHeight = true;
		_styleScroller.stretchWidth = true;
		

		_styleScroller.normal.background = _scrollerBg;
		_styleThumb.normal.background = _scrollerThumb;
		_styleThumb.overflow = _scrollerBarPadding;

		
		_boxPos = new Rect(_scrollerMargin.left,
							_scrollerMargin.top,
							this.Position.width - _scrollerMargin.left - _scrollerMargin.right,
							this.Position.height - _scrollerMargin.top - _scrollerMargin.bottom);
		


		foreach (Transform child in transform.Cast<Transform>().OrderBy(t => t.GetComponent<sGuiBase>().Depth.value)) {
			if (child.GetComponent<sGuiBase>() != null) {
				if (AlphaToChild) {
					child.GetComponent<sGuiBase>().Alpha = this.Alpha;
				}
				if (EnabledToChild) {
					child.GetComponent<sGuiBase>().isDisabled = this.isDisabled;
				}
				if(Scroller) {
					child.GetComponent<sGuiBase>().Location = ChildLocation;
				}
				
			}
		}
	}

	public void setGuiSkin() {
		if (ScrollerOverflow == DirectionBox.Vertical) {
			GUI.skin.verticalScrollbarThumb = _styleThumb;
			GUI.skin.verticalScrollbar = _styleScroller;
		} else {
			GUI.skin.horizontalScrollbarThumb = _styleThumb;
			GUI.skin.horizontalScrollbar = _styleScroller;
		}
	}

	public override void DrawGUI(Rect position, GUIStyle style) {

		
		GUI.BeginGroup(position, style);
		
		if (Scroller) {

			setGuiSkin();

			_scroll = GUI.BeginScrollView(_boxPos, _scroll, _view, ScrollerOverflow == DirectionBox.Horizontal, ScrollerOverflow == DirectionBox.Vertical);
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
			GUI.skin.horizontalScrollbarThumb = _styleThumb;

			GUI.skin.verticalScrollbar = _styleScroller;
			GUI.skin.horizontalScrollbar = _styleScroller;
			
			GUI.BeginGroup(position, style);
			_scroll = GUI.BeginScrollView(_boxPos, _scroll, _view, ScrollerOverflow == DirectionBox.Horizontal, ScrollerOverflow == DirectionBox.Vertical);
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
				_view.x = 0;
				_view.width = _boxPos.width - _scrollerBarSize - _scrollerBarPadding.left - _scrollerBarPadding.right;
				
			    _view.height = p.y;
				break;
			case DirectionBox.Horizontal:
				if (p.x < _boxPos.width) {
					p.x = _boxPos.width;
				}
				_view.y = 0;
				_view.height = _boxPos.height - _scrollerBarSize - _scrollerBarPadding.top - _scrollerBarPadding.bottom;
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
