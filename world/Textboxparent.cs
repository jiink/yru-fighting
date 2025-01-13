using Godot;
using System;

public partial class Textboxparent : Node3D
{
    private Node3D _targetObject;
    private float _targetVariable;
    private Label3D _label;

    public override void _Ready()
    {
        _targetObject = GetParent().GetNode<Node3D>("XRToolsInteractableHinge");
        _label = GetNode<Label3D>("rotationlabel");
//        if (TargetObject == null || string.IsNullOrEmpty(TargetVariableString))
//        {
//            GD.PrintErr($"Whoops. Nuh uh. No worky.");
//            QueueFree();
//        }
    }

    public override void _Process(double delta)
    {
        _targetVariable = (float)_targetObject.Get("hinge_position");
        GD.Print($"My Variable: {_targetVariable}");
        _label.Text = $"{Math.Round(_targetVariable, 1)}";
    }
}
