using Sandbox;

/// <summary>
/// Simple top-down camera follow component.
/// Place this on a Camera GameObject and assign a target in the Inspector.
/// </summary>
public sealed class TopDownCamera : Component
{
	[Property] public GameObject Target { get; set; }
	[Property] public float Height { get; set; } = 350f;
	[Property] public float Distance { get; set; } = 220f;
	[Property] public float SmoothSpeed { get; set; } = 8f;

	protected override void OnUpdate()
	{
		if (Target is null)
			return;

		// Keep camera above and behind the target with a slight tilt.
		var desiredPosition = Target.WorldPosition + (Vector3.Up * Height) + (Vector3.Backward * Distance);
		WorldPosition = Vector3.Lerp(WorldPosition, desiredPosition, Time.Delta * SmoothSpeed);

		// Always look at the target so player stays centered in view.
		WorldRotation = Rotation.LookAt(Target.WorldPosition - WorldPosition);
	}
}
