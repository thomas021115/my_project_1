using Sandbox;

/// <summary>
/// Simple player movement component using WASD input.
/// Applies force to a Rigidbody so the ball can roll around.
/// </summary>
public sealed class BallController : Component
{
	[RequireComponent] Rigidbody rb { get; set; }
	[Property] public int moveForce { get; set; } = 100;
	protected override void OnUpdate()
	{
		if (Input.Down("forward"))
		{
			rb.ApplyForce(Vector3.Forward * moveForce);
		}
		if (Input.Down("backward"))
		{
			rb.ApplyForce(Vector3.Backward * moveForce);
		}
		if (Input.Down("left"))
		{
			rb.ApplyForce(Vector3.Left * moveForce);
		}
		if (Input.Down("right"))
		{
			rb.ApplyForce(Vector3.Right * moveForce);
		}
	}
}
