using Godot;
using System;

namespace YRUFighting;
public partial class SyringeBody : GrabbableThing
{
	// Player hand location when they start grabbing this.
	Vector3 _startGrabPos; 
	// The slider's position along its axis when it's started
	// to be grabbed. Used so slider doesn't start at 0 every time it's
	// grabbed.
	float _startSlidePos;
	// The thing grabbing this (Usually, a FunctionPickup node which is a child
	// of the player's hand)
	Node3D _grabber; 
	Label3D _debugLabel;

	// Runs when this object is grabbed.
	public override void OnGrab(Node3D grabber)
	{
		GD.Print($"{Name} GRABBED BY {grabber.Name}.");
		_startGrabPos = grabber.GlobalPosition;
		_startSlidePos = Position.Y;
		// Need to get position from player hand in process loop.
		_grabber = grabber;
	}

	// Runs when this object is ungrabbed (released).
	public override void OnUngrab(Node3D grabber)
	{
		GD.Print($"{Name} RELEASED BY {grabber.Name}.");
	}
	
	public override void _Ready()
	{
		_debugLabel = GetNode<Label3D>("Label3D");
	}

	public override void _Process(double delta)
	{
		if (IsGrabbed)
		{
			// This will break if tank goes up or down vertically. To fix that,
			// convert global coordinates to tank-relative coordinates.
			var currentGrabPos = _grabber.GlobalPosition;
			var grabDiff = currentGrabPos - _startGrabPos;
			Position = new Vector3(
				Position.X,
				_startSlidePos + grabDiff.Y,
				Position.Z
				);
			_debugLabel.Text = $"{_grabber.Name}\n{grabDiff.Y:F2}";
		}
		else
		{
			_debugLabel.Text = "N/A";
		}
	}
}
