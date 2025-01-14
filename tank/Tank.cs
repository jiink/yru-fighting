using Godot;
using System;

public partial class Tank : VehicleBody3D
{
	[Export]
	public TankLever leverL;
	[Export]
	public TankLever leverR;

	public Tank() {}

	public override void _Ready()
	{
		leverL = GetNode<TankLever>("LeverLeft");// as TankLever;
		leverR = GetNode<TankLever>("LeverRight");// as TankLever;
		if (leverL is null || leverR is null)
		{
			throw new InvalidOperationException("WTF!!!!!!!!!!");
		}
		GD.Print($">>>>>>>>>{leverL.Name} {leverR.Name}!!!!!!!!!");
	}

	public override void _Process(double delta)
	{
	}

    public override void _PhysicsProcess(double delta)
    {
		const float steeringRange = (float)Math.PI / 3.0f;
		const float engineScale = 100.0f;
		Steering = (leverL.Value - leverR.Value) * steeringRange;
		EngineForce = Math.Max(leverL.Value, leverR.Value) * 0.5f * engineScale;
		// Steering = leverL.Value * 1.5f;
		// EngineForce = leverR.Value * 90.0f;
        base._PhysicsProcess(delta);
    }
}
