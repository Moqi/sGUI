sGUI
====

Unity3d GUI helper.
Current Version 1.0.1

[Download Package](https://github.com/sharbelfs/sGUI/raw/master/sGui-1.0.1.unitypackage)


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


## GuiBase

All the elements have the base script. Its the basic structure of the GUI.
Although its possible to extend and create others elements.

* Alpha: Transparency of the element.
* Depth: z-index of the element. Draw order is from the lower to the higher.
* Is Child: is marked automatic if the element is child from another one.
* is Enabled: set if you can interact with the gui element
* Location: Location base on the screen
* Position: position in pixels of the element in the screen
* Background Texture: The image is resized to fit the element.
* Background Color: Color RGBA of the background element



## GuiBox

GuiBox are elements that you can put child on it to make a box with content.


* Alpha to Child: if true the 'Alpha' of the child is the same of the parent. Its only valid for the first level child
* Enabled to Child: if true the 'isEnabled' of the child is the same of the parent. Its only valid for the first level child
* Scroller: Set the box to be scroller or not.


### Box

if the Scroller is disabled, the element is a simple box.
In the Box, the 'Location' of the child is works


### ScrollerBox

*TODO* - need some improvement, not tested

* Scroller Overflow
* Child Location
* Scroller Bg
* Scroller Thumb
* Scroller Size
* Scroller Margin
* Scroller Padding


## GuiButton

* Has Audio: if its enabled, you need to set the sound in the "Audio Source"
* Background Hover:
* Background Pressed:
* Font Family:
* Font Size:
* Font Color:
* Font Hover Color:
* Font Pressed Color:
* Text Align:
* Content:
* Content Offset:
* Content Image Position:
* Margin:

##### Script

* onClickButton: 

```
  onClickButton(GameObject current) {
    // do some action when button is clicked
  }
```


## GuiImage

* Image:
* Scale Mode:


## GuiLabel

* Font Family:
* Font Size:
* Font Color:
* Text Align:
* Content:
* Content Offset:
* Content Image Position:
* Margin:


## GuiSlider

* Direction: Vertical or Horizontal
* Slider Texture:
* Slider Thumb Texture:
* Slider Thumb Size:
* Min Value: float number
* Max Value: float number

##### Script

* Value: Return the current float value of the slider


## GuiTextarea

* Text: text typed in the area. You can set initial text and get in from script
* Max Length: set '0' to unlimited character
* Background Focus:
* Padding:
* Font Family:
* Font Size:
* Font Color:
* Font Focus Color:
* Text Align:
* Content Offset:
* Margin:

## GuiToggle

* Font Family
* Font Size
* Text Align
* Content
* Font Color
* Background Texture Pressed: Background of the element when its pressed
* Content Pressed: you need to set the content, even if its the same
* Font Color Pressed:
* Content Offset:
* Content Image Position: Image position is the same for normal and pressed state

##### Script

* Pressed: return true if its pressed



Changes
====

### 1.0.1

* Fixed folder systema
* Fixed package file
