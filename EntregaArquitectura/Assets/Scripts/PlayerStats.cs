using System;
using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class PlayerStats : MonoBehaviour {

	public static int Money;
	public int startMoney = 400;
	public Text textoMoney;
	public Text textoVidas;

	public static int Lives;
	public int startLives = 20;

	public static int Rounds;

	void Start ()
	{
		Money = startMoney;
		Lives = startLives;

		Rounds = 0;
	}

	public void Update()
	{
		textoMoney.text =  PlayerStats.Money.ToString()+"$";
		textoVidas.text = PlayerStats.Lives.ToString() + " VIDAS";
		
	}
}
