# Stable SegMap

This is a 3d application geared towards generating control net maps. Eventually depth maps and possibly normal maps if anyone want to add that in!

This is a modified fork of [Giles](https://github.com/Unity-Technologies/giles) with the aim of publishing a web runtime editor for building 3d segmentations for controlnet. 
Authored using Unity 2022 LTS
 
![segmentation-colors-for-controlnet](notes/color150-segmentation-colors-for-controlnet-v0.webp)




# Original README

### A Runtime Level Editor for Unity3D

![giles](giles.png)


## What is it?

GILES is a runtime level editor for Unity games.  It is designed to be completely functional on it's own, but open to extensibility at every opportunity.

Out of the box here's what GILES provides:

- Selection manager
- Grid snapping
- Translate, rotate, and scale handles
- Scene save / load
	- Levels written to human-readable JSON.
	- Saves all objects in scene via reflection, no additional code required.
	- Writes only state deltas if prefabs are used.
	- Serialization process is customizable with both simple attributes or complete overloading.
- Undo/redo.

## Quick Start

- Install **Unity 2022.3.5** or greater.
- In Player Settings, set "API Compatibility Level" to ".NET 4.0"
- Open **GILES** project.
- Open *GILES/Example/Level Editor*

## Contributing

Bug reports should be submitted to the Issues queue on Github.  Feature requests should be either posted on the [forums](http://www.protoolsforunity3d.com/forum/) or contributed via pull request.


## Documentation
https://github.com/FAL2009/giles/wiki

## This Fork is not dead but slow in development because of missing time
