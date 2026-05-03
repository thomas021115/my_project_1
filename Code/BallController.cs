using Sandbox;

public sealed class BallController : Component
{
	[RequireComponent] Rigidbody rb { get; set; }
	[Property] public int velocity { get; set; } = 100;
	protected override void OnUpdate()
	{
		if (Input.Down("forward"))
		{
			rb.ApplyForce(Vector3.Forward * velocity);
		}
		if (Input.Down("backward"))
		{
			rb.ApplyForce(Vector3.Backward * velocity);
		}
		if (Input.Down("left"))
		{
			rb.ApplyForce(Vector3.Left * velocity);
		}
		if (Input.Down("right"))
		{
			rb.ApplyForce(Vector3.Right * velocity);
		}
	}
}
