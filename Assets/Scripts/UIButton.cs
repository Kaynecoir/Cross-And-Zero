using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class UIButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
	[SerializeField] private Sprite down, up;
	Image image;
	private void Awake()
	{
		image = gameObject.GetComponent<Image>();
	}
	public void OnPointerDown(PointerEventData eventData)
	{
		image.sprite = down;
	}

	public void OnPointerUp(PointerEventData eventData)
	{
		image.sprite = up;
	}
}
