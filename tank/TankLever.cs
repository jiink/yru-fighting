using Godot;
using System;

public partial class TankLever : Node3D
{
	[Export]
	public float Value
	{
		get {
			if (XrLever is null)
			{
				GD.PrintErr("osidoasdkoasikd");
				return 0.1f;
			}
			float f = (float)XrLever.Get("hinge_position");
			float upperLim = (float)XrLever.Get("hinge_limit_max");
			float lowerLim = (float)XrLever.Get("hinge_limit_min");
			float normalizedValue = 2f * (f - lowerLim) / (upperLim - lowerLim) - 1f;
			return normalizedValue;
		}
		set {}
	}

	private Node3D _xrLever;
	private Node3D XrLever
	{
		get {
			if (_xrLever is null)
			{
				_xrLever = GetNode<Node3D>("XRToolsInteractableHinge");
				if (_xrLever is null) 
				{
					throw new InvalidOperationException("No xr lever found!");
				}
			}
			return _xrLever;
		}
	}
	public TankLever() {}
	public override void _Ready()
	{
		
	}

	public override void _Process(double delta)
	{
	}
}
