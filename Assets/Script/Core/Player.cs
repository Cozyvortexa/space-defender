namespace SpaceDefender.Core
{
    public class Player
    {
        public int MaxHealth { get; private set; } = 100;
        public int Health { get; private set; } = 100;
        public int Lives { get; private set; } = 3;
        public int Score { get; private set; } = 0;
        public bool IsAlive => Health > 0 && Lives > 0;

        public void TakeDamage(int amount)
        {
            if (amount < 0) return;
            Health -= amount;
            if (Health <= 0)
            {
                Health = 0;
                LoseLife();
            }
            // TODO : implementer la logique
            // RAPPEL : Health ne peut pas etre negatif
        }

        public void Heal(int amount) {
            Health += amount;
            if (Health > MaxHealth) Health = MaxHealth;

        }
        public void AddScore(int points) { /* TODO */ }
        public void LoseLife() {
            Lives--;
            if (Lives < 0)
            {
                Lives = 0;
            }
        }

    }

}
