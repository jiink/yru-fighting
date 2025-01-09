using Godot;
using System;

public partial class FlatscreenPlayer : CharacterBody3D
{
    public const float Speed = 5.0f;
    public const float JumpVelocity = 4.5f;
    public const float MouseSensitivity = 0.1f;
    private Camera3D cam;
    private Vector3 direction = Vector3.Zero;

    public override void _Ready()
    {
        cam = GetNode<Camera3D>("Camera3D");
        Input.MouseMode = Input.MouseModeEnum.Captured;
    }

    public override void _PhysicsProcess(double delta)
    {
        Vector3 velocity = Velocity;

        // Add the gravity.
        if (!IsOnFloor())
        {
            velocity += GetGravity() * (float)delta;
        }

        // Handle Jump.
        if (Input.IsActionJustPressed("fps_jump") && IsOnFloor())
        {
            velocity.Y = JumpVelocity;
        }

        // Get the input direction and handle the movement/deceleration.
        Vector2 inputDir = Input.GetVector("fps_left", "fps_right", "fps_up", "fps_down");
        direction = (Transform.Basis * new Vector3(inputDir.X, 0, inputDir.Y)).Normalized();
        if (direction != Vector3.Zero)
        {
            velocity.X = direction.X * Speed;
            velocity.Z = direction.Z * Speed;
        }
        else
        {
            velocity.X = Mathf.MoveToward(Velocity.X, 0, Speed);
            velocity.Z = Mathf.MoveToward(Velocity.Z, 0, Speed);
        }

        Velocity = velocity;
        MoveAndSlide();
    }

    public override void _Input(InputEvent @event)
    {
        if (@event is InputEventMouseMotion mouseMotion)
        {
            RotateY(Mathf.DegToRad(-mouseMotion.Relative.X * MouseSensitivity));
            cam.RotateX(Mathf.DegToRad(-mouseMotion.Relative.Y * MouseSensitivity));
            cam.Rotation = new Vector3(Mathf.Clamp(cam.Rotation.X, -Mathf.Pi / 2, Mathf.Pi / 2), cam.Rotation.Y, cam.Rotation.Z);
        }
    }
}