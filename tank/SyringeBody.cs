using Godot;
using System;

public partial class SyringeBody : Area3D
{
	public bool press_to_hold = true;
	bool _isPickedUp = false;


	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	public void pick_up(Node3D by)
	{
		GD.Print("]]] Hello world");
	}

	public void let_go(Node3D by,
		Vector3 p_linear_velocity,
		Vector3 p_angular_velocity)
	{
		_isPickedUp = false;
	}

	public bool can_pick_up(Node3D by)
	{
		return true;
	}

	public bool is_picked_up() {
		return _isPickedUp;
	}

	public void request_highlight(Node from, bool on = true)
	{
		GD.Print("[syringebody] highlight requested");
	}
}
