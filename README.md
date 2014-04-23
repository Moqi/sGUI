sGUI
====

Unity3d GUI helper.
Current Version 1.2.1 [See changes](#changes)

[Download Package](https://github.com/sharbelfs/sGUI/raw/master/sGui-1.2.1.unitypackage)

Assets thanks to [Kenney](http://www.kenney.nl)

Features
====

Drag the prefab into the scene and configure as you like.

* [GuiBase](#guibase)
* [GuiBox](#guibox)
* [GuiButton](#guibutton)
* [GuiImage](#guiimage)
* [GuiLabel](#guilabel)
* [GuiSlider](#guislider)
* [GuiTextarea](#guitextarea)
* [GuiToggle](#guitoggle)

* [Create Custom](#create-custom)

## GuiBase

All the elements have the base script. Its the basic structure of the GUI.
Although its possible to extend and create others elements.

* Alpha: Transparency of the element.
* Depth: z-index of the element. Draw order is from the lower to the higher.
* Is Child: is marked automatic if the element is child from another one.
* is Enabled: set if you can interact with the gui element
* Location: Location base on the screen
* Position: position in pixels of the element in the screen


## GuiBox

GuiBox are elements that you can put child on it to make a box with content.


* Alpha to Child: if true the 'Alpha' of the child is the same of the parent. Its only valid for the first level child
* Enabled to Child: if true the 'isEnabled' of the child is the same of the parent. Its only valid for the first level child
* Scroller: Set the box to be scroller or not.


### Box

if the Scroller is disabled, the element is a simple box.
In the Box, the 'Location' of the child is works


### ScrollerBox


* Scroller Overflow
* Child Location
* Scroller Bg
* Scroller Thumb
* Scroller Size
* Scroller Margin
* Scroller Box Padding


## GuiButton

* Has Audio: if its enabled, you need to set the sound in the "Audio Source"

##### Script

* onClickButton: 
```
  onClickButton(GameObject current) {
    // do some action when button is clicked
  }
```

* onHoverButton: 
```
  onHoverButton(GameObject current) {
    // do some action when button is hover
  }
```

* onOutButton: 
```
  onOutButton(GameObject current) {
    // do some action when button is leave the hover state
  }
```

## GuiImage

Simple Image. Can be used to resize gui Images.


## GuiLabel

Simple Label text. Can be used as label, multiline text and/or with a texture


## GuiSlider

A Value slider. You need to set the Min and Max values. You can set and get the current value of the slider by script

* Direction: Vertical or Horizontal
* Slider Texture:
* Slider Thumb Texture:
* Slider Thumb Size:
* Min Value: float number
* Max Value: float number

##### Script

* Value: Return the current float value of the slider


## GuiTextarea

its a input text area

* Text: text typed in the area. You can set initial text and get in from script
* Max Length: set '0' to unlimited character
* Is Password: mark to set the textfield to act like password. (thanks to @diegocbarboza)

## GuiToggle

Toggle Element, it changes its state 'pressed' to true or false

##### Script

* Pressed: return true if its pressed



## Create Custom

This is the base to create a custom GuiElement. Extending the base class, it will work with all others elements.

```
using UnityEngine;
using System.Collections;


[ExecuteInEditMode]
public class CustomGuiItem : sGuiBase {

  // used to update the styles in EditMode when changes
	public override void updateStyles() {

		base.updateStyles();
		
		// custom style
		Style.richText = true;

	}
  
  // in the current version both function do the same thing, just replicate the content of both
	public override void DrawGUI(Rect position, GUIStyle style) {
		
	}

	public override void DrawChildGUI(Rect position, GUIStyle style) {
		
	}
}

```


Changes
====

### 1.2.1
* Script for MouserOver and MouseOut events

### 1.2
* Scroller Box Vertical / Horizontal
* Password

### 1.1
* Base redone
* assets formatted


### 1.0.1

* Fixed folder systema
* Fixed package file
