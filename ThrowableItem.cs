using Godot;
using System;


public partial class ThrowableItem : Node3D
{
	[Export]
	public float BreakVelocity = 15.0f;
	private RigidBody3D _rigidBody;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		_rigidBody = GetNode<RigidBody3D>("XRToolsPickable");
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{

	}
	private void _on_body_entered(Node body)
	{
		if (body is PhysicsBody3D)
		{
			if (_rigidBody.LinearVelocity.Length() >= BreakVelocity)
			{
				GD.Print("sugma my my balls");
			}
		}
	}
}
