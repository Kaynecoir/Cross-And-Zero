using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Cell : MonoBehaviour, IPointerClickHandler
{
	public int x, y;
	public Image val;

	private UGameManager GameManager;

	public void OnPointerClick(PointerEventData eventData)
	{
		GameManager.Add(this);
	}

	private void Start()
	{
		GameManager = GameObject.Find("GameManager").GetComponent<UGameManager>();
		val = gameObject.GetComponent<Image>();
		val.color = new Color(1, 1, 1, 0);
	}


}
