using app;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;

[MemoryDiagnoser]
public class SelectObjectComparison
{
    private readonly List<Animal> _data = Generate();

    public static List<Animal> Generate() //Will generate 2500 dogs, 10000 ducks and 5000 cats
    {
        var animals = new List<Animal>();

        animals.AddRange(CreateAnimals.Dogs(2500).ToList());
        animals.AddRange(CreateAnimals.Ducks(10000).ToList());
        animals.AddRange(CreateAnimals.Cats(5000).ToList());

        return animals;
    }

    [Benchmark]
    public List<Duck> SelectWithWhere() //Will retrieve only ducks from the list
    {
         return _data.Where(a => a is Duck)
                    .Select(a => (Duck)a).ToList();
    }

    [Benchmark]
    public List<Duck> SelectWithOfType() //Will retrieve only ducks from the list
    {
        return _data.OfType<Duck>().ToList();
    }


    // [MemoryDiagnoser]
    // public class SelectPrimitiveTypeComparison
    // {
    //     public static List<object> Generate()
    //     {
    //         var objects = new List<object>();
    //
    //         objects.AddRange(CreatePrimitives.Ints(2500).ToList());
    //         objects.AddRange(CreatePrimitives.Strings(10000).ToList());
    //         objects.AddRange(CreatePrimitives.Bools(5000).ToList());
    //
    //         return objects;
    //     }
    //
    //     [Benchmark]
    //     public List<object> SelectWithWhere()
    //     {
    //         var objects = Generate();
    //
    //         return objects.Where(a => a is string).ToList();
    //     }
    //
    //     [Benchmark]
    //     public List<string> SelectWithOfType()
    //     {
    //         var objects = Generate();
    //
    //         return objects.OfType<string>().ToList();
    //     }
    // }

    class Program
    {
        public static void Main(string[] args)
        {
            BenchmarkRunner.Run<SelectObjectComparison>();
        }
    }
}