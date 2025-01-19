using Godot;
using System;

public partial class SyringeBody : Area3D
{
	public bool press_to_hold = true;
	bool _isPickedUp = false;
	Vector3 _startGrabPos;
	float _startSlidePos;
	Node3D _grabber;
	Label3D debugLabel;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		debugLabel = GetNode<Label3D>("Label3D");
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		if (_isPickedUp)
		{
			var currentGrabPos = _grabber.GlobalPosition;
			var grabDiff = currentGrabPos - _startGrabPos;
			Position = new Vector3(Position.X, _startSlidePos + grabDiff.Y, Position.Z);
			debugLabel.Text = $"{_grabber.Name}: {currentGrabPos}\n{grabDiff.Y}";
		}
		else
		{
			debugLabel.Text = "N/A";
		}
	}

	public void pick_up(Node3D by)
	{
		_isPickedUp = true;
		GD.Print($"{Name} GRABBED BY {by.Name}.");
		_startGrabPos = by.GlobalPosition;
		_startSlidePos = Position.Y;
		_grabber = by;
	}

	public void let_go(Node3D by,
		Vector3 p_linear_velocity,
		Vector3 p_angular_velocity)
	{
		_isPickedUp = false;
		GD.Print($"{Name} RELEASED BY {by.Name}.");
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
