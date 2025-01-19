using Godot;
using System;

/* 
Extend from this class when you want something (an area3d) to have
a method run when a player grabs it.
This is a sort of wrapper that turns the gdscript functions and variables
that all xr-tools "pickable" things need into C# methods and variables
with better terminology. 
This way you just implement everything this class insists upon
instead of seeing godot crash because a certain function or variable
wasn't found in your node.*/
namespace YRUFighting;

// Disable naming style warnings because the method names
// must exactly match the GDScript style that xr-tools expects.
#pragma warning disable IDE1006 // Naming Styles
public abstract partial class GrabbableThing : Area3D
{
    // Override this propert with a getter 
    // to define when this thing should not be 
    // grabbable.
    virtual public bool IsGrabbable => true;
    public bool IsGrabbed => _isPickedUp;
    private bool _isPickedUp = true;

    // Runs when this object is grabbed.
    public abstract void OnGrab(Node3D grabber);
    // Runs when this object is ungrabbed (released).
    public abstract void OnUngrab(Node3D grabber);

    // --- Vars and methods that xr-tools needs: -------
    public bool press_to_hold = true;
    public bool can_pick_up(Node3D by)
    {
		return IsGrabbable;
	}

    public void pick_up(Node3D by)
	{
		_isPickedUp = true;
		//GD.Print($"{Name} GRABBED BY {by.Name}.");
        OnGrab(by);
	}

    public void let_go(Node3D by,
		Vector3 p_linear_velocity,
		Vector3 p_angular_velocity)
	{
		_isPickedUp = false;
		//GD.Print($"{Name} RELEASED BY {by.Name}.");
        OnUngrab(by);
	}

    public bool is_picked_up()
    {
		return _isPickedUp;
	}

    public void request_highlight(Node from, bool on = true)
	{
		//GD.Print($"{Name} highlight requested by {from.Name}.");
	}
}
#pragma warning restore IDE1006 // Naming Styles
