using Godot;
using System;

public partial class RigidBody3d : VehicleBody3D
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		EngineForce = 20.0f;
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
}
