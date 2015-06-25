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
				Handle = "Attack",
				Target = InputControlType.Action2,
				Source = new UnityKeyCodeSource(KeyCode.LeftShift)
			},
			new InputControlMapping()
			{
				Handle = "WeaponCycle",
				Target = InputControlType.Action4,
				Source = new UnityKeyCodeSource(KeyCode.Tab)
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
				Source = new UnityKeyCodeAxisSource(KeyCode.S, KeyCode.W)
			},
			new InputControlMapping()
			{
				Handle = "Right Stick X",
				Target = InputControlType.RightStickX,
				Source = new UnityKeyCodeAxisSource(KeyCode.LeftArrow, KeyCode.RightArrow)
			},
			new InputControlMapping()
			{
				Handle = "Right Stick Y",
				Target = InputControlType.RightStickY,
				Source = new UnityKeyCodeAxisSource(KeyCode.DownArrow, KeyCode.UpArrow)
			}
		};
	}
}
