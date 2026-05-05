using Sandbox;

/// <summary>
/// Simple top-down camera follow component.
/// Place this on a Camera GameObject and assign a target in the Inspector.
/// </summary>
public sealed class TopDownCamera : Component
{
	[Property] GameObject Target { get; set; }

	[Property] float SmoothSpeed { get; set; } = 8f;

	[Property] Vector3 Offset { get; set; } = new Vector3(-200f, 0f, 1000f);

	protected override void OnUpdate()
	{
		if (Target is null)
			return;

		// Keep camera above and behind the target with a slight tilt.
		var desiredPosition = Target.WorldPosition + Offset;
		WorldPosition = Vector3.Lerp(WorldPosition, desiredPosition, Time.Delta * SmoothSpeed);

		WorldRotation = Rotation.LookAt(Target.WorldPosition - WorldPosition);
	}
}
