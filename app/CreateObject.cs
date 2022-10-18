namespace app;

public class CreateAnimals
{
    public static IEnumerable<Animal> Dogs(int range)
    {
        foreach (int i in Enumerable.Range(1, range))
        {
            yield return new Dog($"Dog {i}");
        };
    }
    
    public static IEnumerable<Animal> Ducks(int range)
    {
        foreach (int i in Enumerable.Range(1, range))
        {
            yield return new Duck($"Duck {i}");
        };
    }

    public static IEnumerable<Animal> Cats(int range)
    {
        foreach (int i in Enumerable.Range(1, range))
        {
            yield return new Cat($"Cat {i}");
        };
    }
}

public class CreatePrimitives
{
    public static IEnumerable<object> Ints(int range)
    {
        foreach (int i in Enumerable.Range(1, range))
        {
            yield return i;
        };
    }
    
    public static IEnumerable<object> Strings(int range)
    {
        foreach (int i in Enumerable.Range(1, range))
        {
            yield return ($"string {i}");
        };
    }
    
    public static IEnumerable<object> Bools(int range)
    {
        foreach (int i in Enumerable.Range(1, range))
        {
            if (i%2 == 0)
                yield return true;
            
            yield return false;
        };
    }
}