using Godot;
using System;


public partial class ThrowableItem : Node3D
{
	[Export]
	public float BreakVelocity = 2.5f;
	private RigidBody3D _rigidBody;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		_rigidBody = GetNode<RigidBody3D>("XRToolsPickable");
		GD.Print("Hello, player!");

		_rigidBody.BodyEntered += _on_body_entered;
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{

	}
	
	public void _on_body_entered(Node body)
	{
		GD.Print($"HIT a {body.GetType()}!!!! Velocity: {_rigidBody.LinearVelocity.Length()}");
		// if (body is PhysicsBody3D)
		// {
			if (_rigidBody.LinearVelocity.Length() >= BreakVelocity)
			{
				GD.Print("sugma my my balls");
			}
		// }
	}
}
