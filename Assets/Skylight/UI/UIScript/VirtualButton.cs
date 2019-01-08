
using UnityEngine;
using UnityEngine.EventSystems;
using Skylight;
public class VirtualButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{

	public HandheldButtonInput input;

	public void OnPointerDown (PointerEventData eventData)
	{
		input.Value = true;
	}

	public void OnPointerUp (PointerEventData eventData)
	{
		input.Value = false;
	}
}
