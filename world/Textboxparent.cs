using Godot;
using System;

public partial class Textboxparent : Node3D
{
    [Export] public Node3D TargetObject { get; set; }
    [Export] public float TargetVariable { get; set; }
    private Label3D _label;
    public string TargetVariableString;

    public override void _Ready()
    {
        TargetObject = GetParent().GetNode<XrToolsInteractableHinge>("XRToolsInteractableHinge");
        TargetVariable = (float)TargetObject.Get("hinge_position");
        TargetVariableString = $"{Math.Round(TargetVariable, 1)}";
        GD.Print($"My Variable: {TargetVariable}");
        _label = GetNode<Label3D>("rotationlabel");
//        if (TargetObject == null || string.IsNullOrEmpty(TargetVariableString))
//        {
//            GD.PrintErr($"Whoops. Nuh uh. No worky.");
//            QueueFree();
//        }
    }

    public override void _Process(double delta)
    {
        _label.Text = TargetVariableString;
    }
}
