using UnityEngine;
using UnityEngine.Events;

public interface IAgentInput
{
    UnityEvent OnFireButtonHeld { get; set; }
    UnityEvent OnFireButtonReleased { get; set; }
    UnityEvent<Vector2> OnMovmentKeyPressed { get; set; }
    UnityEvent<Vector3> OnPointerPositionChange { get; set; }
}