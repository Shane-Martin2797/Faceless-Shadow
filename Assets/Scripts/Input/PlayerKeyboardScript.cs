using UnityEngine;
using System.Collections;
using InControl;

public class PlayerKeyboardScript : UnityInputDeviceProfile {

	public PlayerKeyboardScript()
	{
		Name = "Keyboard";
		
		ButtonMappings = new[]
		{
			new InputControlMapping()
			{
				Handle = "Jump",
				Target = InputControlType.Action1,
				Source = new UnityKeyCodeSource(KeyCode.Space)
			},
			new InputControlMapping()
			{
				Handle = "GravityKnuckles",
				Target = InputControlType.Action2,
				Source = new UnityKeyCodeSource(KeyCode.LeftShift)
			},
			new InputControlMapping()
			{
				Handle = "PlasmaSword",
				Target = InputControlType.Action3,
				Source = new UnityKeyCodeSource(KeyCode.F)
			}
		};
		
		AnalogMappings = new[]
		{
			new InputControlMapping()
			{
				Handle = "Left Stick X",
				Target = InputControlType.LeftStickX,
				Source = new UnityKeyCodeAxisSource(KeyCode.A, KeyCode.D)
			},
			new InputControlMapping()
			{
				Handle = "HeightControl",
				Target = InputControlType.LeftStickY,
				Source = new UnityKeyCodeAxisSource(KeyCode.W, KeyCode.S)
			},
			new InputControlMapping()
			{
				Handle = "Right Stick Y",
				Target = InputControlType.RightStickY,
				Source = new UnityKeyCodeAxisSource(KeyCode.Q, KeyCode.E)
			}
		};
	}
}
