# Dev Notes


/Assets/GILES/Settings/pb_Config.cs  
contains a list of components to be ignored. These components don't have their editor's displayed.
If they have an editor defined they will be hidden behinf the Inspectors "Show Full Inspector" button.

/Assets/GILES/Code/Classes/GUI/pb_ComponentEditorResolver.cs
To add new custom inspectors create the component type editor (eg, pb_HumanoidEditor ), and then add in to the resolver, { typeof(Humanoid), typeof(pb_HumanoidEditor) }

