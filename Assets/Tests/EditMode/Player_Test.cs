using NUnit.Framework;
using UnityEngine;
using SpaceDefender.Core;

[TestFixture]
public class Player_Test
{
    private Player _player;
    private Ennemy _ennemy;
    private ScoreCalculator _scoreCalculator;


    [SetUp]
    public void SetUp()
    {
        _player = new Player();   // Arrange — initialisation
        _ennemy = new Ennemy(); 
        _scoreCalculator = new ScoreCalculator();
    }

    [Test]
    public void TakeDamage_Normal_ReducesHealth()
    {
        int damage = 20;

        _player.TakeDamage(damage);

        Assert.AreEqual(80, _player.Health);
    }

    [Test]// T1
    public void TakeDamage_WithFatalDamage_SetsHealthToZero()
    {
        int damage = _player.Health + 1;

        _player.TakeDamage(damage);

        Assert.AreEqual(0, _player.Health);
    }

    [Test]// T2
    public void TakeDamage_WithNegativeAmount_DoesNotChangeHealth()
    {
        int damage = -10;

        _player.TakeDamage(damage);

        Assert.AreEqual(100, _player.Health);
    }
    [Test]// T3
    public void Heal_WhenHealthBelow100_IncreasesHealth()
    {
        int heal = 10;
        _player.TakeDamage(20);
        _player.Heal(heal);

        Assert.AreEqual(90, _player.Health);
    }
    [Test]// T4
    public void Heal_WhenAlreadyFullHealth_DoesNotExceed100()
    {
        int heal = 999999;
        _player.Heal(heal);

        Assert.AreEqual(100, _player.Health);
    }
    [Test]// T5
    public void IsAlive_WhenHealthIsZero_ReturnsFalse()
    {

        _player.TakeDamage(_player.Health);

        Assert.AreEqual(false, _player.IsAlive);
    }
    [Test]// T6
    public void LoseLife_WhenLastLife_IsAliveReturnsFalse()
    {
        _player.LoseLife();
        _player.LoseLife();
        _player.LoseLife();

        Assert.AreEqual(false, _player.IsAlive);
    }
    [Test]// T7
    public void TakeDamage_WhenKilled_SetsIsAliveToFalse()
    {
        _ennemy.TakeDamage(_player.Health);


        Assert.AreEqual(false, _ennemy.IsAlive);
    }
    [Test]// T8
    public void GetReward_WhenAlreadyDead_ReturnsZero()
    {
        _ennemy.TakeDamage(_ennemy.Health);
        _ennemy.GetReward();

        Assert.AreEqual(0, _ennemy.GetReward());
    }
    [Test]// T9
    public void Calculate_WithZeroKills_ReturnsZero()
    {
        Assert.AreEqual(0, _scoreCalculator.Calculate(0, 0));
    }
    [Test]// T10
    public void ApplyCombo_With3Kills_IncreasesMultiplier()
    {
        _scoreCalculator.ApplyCombo(3);
        Assert.AreEqual(3, (int)_scoreCalculator.Multiplier);
    }
    [Test]// T11
    public void ResetMultiplier_AfterCombo_SetsMultiplierToOne()
    {
        _scoreCalculator.ApplyCombo(3);
        _scoreCalculator.ResetMultiplier();
        Assert.AreEqual(1.0f, (int)_scoreCalculator.Multiplier);
    }
    [Test]// T12
    public void Calculate_AfterComboAndReset_UsesBaseMultiplier()
    {
        _scoreCalculator.ApplyCombo(3);
        _scoreCalculator.ResetMultiplier();
        _scoreCalculator.ApplyCombo(1);

        Assert.AreEqual(1, _scoreCalculator.Calculate(1, 1));
    }

}
