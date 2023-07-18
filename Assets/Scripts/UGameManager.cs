using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UGameManager : MonoBehaviour
{
	public UGameData GameData;
	public UPlayerData player1, player2;
	public GameObject PauseBox, LoseBox, WinBox;

	private bool isPause;
	private ItemType[,] itemArea = new ItemType[3, 3];
	private UPlayerData currentPlayer;

	private void Start()
	{
		//itemArea = new ItemType[GameData.WidthTable, GameData.HeightTable];
		currentPlayer = player1;
		isPause = true;
	}
	public void Add(Cell c)
	{
		if (itemArea[c.x, c.y] != ItemType.None) return;
		itemArea[c.x, c.y] = currentPlayer.PlayerType;
		c.val.sprite = currentPlayer.PlayerIcon;
		c.val.color = currentPlayer.PlayerColor;
		if (Win(currentPlayer.PlayerType)) WinBox.SetActive(true);
		else if (Lose()) LoseBox.SetActive(true);


		currentPlayer = currentPlayer == player1 ? player2 : player1;
	}

	private bool Win(ItemType it)
	{
		// Проверка по горизонтали
		for(int i = 0; i < GameData.WidthTable; i++)
		{
			for (int j = 0; j < GameData.HeightTable - GameData.CountToWin + 1; j++)
			{
				int c = 0;
				for(int k = 0; k < GameData.CountToWin; k++)
				{
					if (itemArea[i, j + k] == it) c++;
					else break;
				}
				if (c == GameData.CountToWin) return true;
			}
		}
		// Проверка по вертикали
		for (int j = 0; j < GameData.HeightTable; j++)
		{
			for (int i = 0; i < GameData.WidthTable - GameData.CountToWin + 1; i++)
			{
				int c = 0;
				for (int k = 0; k < GameData.CountToWin; k++)
				{
					if (itemArea[i + k, j] == it) c++;
					else break;
				}
				if (c == GameData.CountToWin) return true;
			}
		}
		// Проверка по диагонали
		for (int i = 0; i < GameData.WidthTable - GameData.CountToWin + 1; i++)
		{
			for (int j = 0; j < GameData.HeightTable - GameData.CountToWin + 1; j++)
			{
				int c = 0;
				for (int k = 0; k < GameData.CountToWin; k++)
				{
					if (itemArea[i + k, j + k] == it) c++;
					else break;
				}
				if (c == GameData.CountToWin) return true;
			}
		}
		// Проверка по обратной диагонали
		for (int i = GameData.WidthTable - 1; i > GameData.CountToWin - 1; i--)
		{
			for (int j = 0; j < GameData.HeightTable - GameData.CountToWin + 1; j++)
			{
				int c = 0;
				for (int k = 0; k < GameData.CountToWin; k++)
				{
					if (itemArea[i + GameData.WidthTable - k, j + k] == it) c++;
					else break;
				}
				if (c == GameData.CountToWin) return true;
			}
		}

		return false;
	}

	private bool Lose()
	{
		for (int i = 0; i < GameData.WidthTable; i++)
		{
			for (int j = 0; j < GameData.HeightTable; j++)
			{
				if (itemArea[i, j] == ItemType.None)
				{
					return false;
				}
			}
		}

		return true;
	}

	public void SetPause(bool value)
	{
		isPause = value;
		PauseBox.SetActive(isPause);
	}
	public void SetPlay()
	{
		isPause = false;
		WinBox.SetActive(false);
		LoseBox.SetActive(false);
	}

	public void ResetTable()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
		isPause = false;
		//WinBox.SetActive(false);
		//LoseBox.SetActive(false);
		currentPlayer = player1;
	}

	public void QuitGame()
	{
		Debug.Log("Quit");
		Application.Quit();
	}
}
