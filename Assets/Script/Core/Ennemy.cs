namespace SpaceDefender.Core
{
    public class Ennemy
    {
        public int MaxHealth { get; private set; } = 100;
        public int Health { get; private set; } = 100;
        public bool IsAlive => Health > 0;

        public bool giveReward = true;
        public int scoreGive { get; private set; } = 10;
        public void TakeDamage(int amount)
        {
            if (amount < 0) return;
            Health -= amount;
            if (Health <= 0)
            {
                Health = 0;
            }
        }

        public void Heal(int amount)
        {
            Health += amount;
            if (Health > MaxHealth) Health = MaxHealth;

        }

        public int GetReward()
        {
            if (giveReward)
            {
                giveReward = false;
                return scoreGive;
            }
            return 0;
        }

    }
}
