public class RandomSeed
{
    private System.Random random;

    // Cria uma instância com uma seed
    public RandomSeed(int seed)
    {
        random = new System.Random(seed);
    }

    // Retorna um número inteiro entre min (inclusive) e max (exclusivo)
    public int RandomInt(int min, int max)
    {
        return random.Next(min, max);
    }

    // Retorna um número flutuante entre 0 e 1
    public float RandomFloat()
    {
        return (float)random.NextDouble();
    }
}
