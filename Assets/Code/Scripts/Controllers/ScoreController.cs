using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreController : SingletonBehaviour<ScoreController>
{
	private double score;

	public event Action OnScoreChange;

	public double GetScore()
	{
		return score;
	}

	public void SetScore(double newScore)
	{
		score = newScore;
		if (OnScoreChange != null) OnScoreChange.Invoke();
	}

	public void AddScore(double value)
	{
		score += value;
		if (OnScoreChange != null) OnScoreChange.Invoke();
	}

	public void SubtractScore(double value)
	{
		score -= value;
		if (OnScoreChange != null) OnScoreChange.Invoke();
	}
}
