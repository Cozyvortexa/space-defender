using UnityEngine;

public class ScoreCalculator : MonoBehaviour
{
    public int BaseScore { get; private set; } = 1;
    public float Multiplier {  get; private set; } = 1.0f;


    public int Calculate(int kills, int time)
    {
        float value = kills * BaseScore * Multiplier;
        return (int)value;
    }
    public void ApplyCombo(int comboCount)
    {
        if (comboCount <= 1) 
            Multiplier = 1.0f;
        else 
            Multiplier = comboCount;
    }

    public void ResetMultiplier()
    {
        Multiplier = 1.0f;
    }
}
