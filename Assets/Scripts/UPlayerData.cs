using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New PlayerData", menuName = "UserData/Player Data", order = 2)]
public class UPlayerData : ScriptableObject
{
	[SerializeField] private Sprite playerIcon;
	[SerializeField] private ItemType playerType;
	[SerializeField] private Color playerColor;

	public Sprite PlayerIcon { get => playerIcon; set => playerIcon = value; }
	public ItemType PlayerType { get => playerType; set => playerType = value; }
	public Color PlayerColor { get => playerColor; set => playerColor = value; }

}
