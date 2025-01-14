using Godot;
using System;

public partial class Textboxparent : Node3D
{
    private TankLever _targetObject;
    private Label3D _label;

    public override void _Ready()
    {
        _targetObject = GetParent<TankLever>();
        _label = GetNode<Label3D>("rotationlabel");
//        if (TargetObject == null || string.IsNullOrEmpty(TargetVariableString))
//        {
//            GD.PrintErr($"Whoops. Nuh uh. No worky.");
//            QueueFree();
//        }
    }

    public override void _Process(double delta)
    {
        float v = _targetObject.Value;
        _label.Text = $"{Math.Round(v, 1)}";
    }
}
