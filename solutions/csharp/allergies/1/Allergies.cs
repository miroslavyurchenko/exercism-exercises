public enum Allergen
{
    Eggs,
    Peanuts,
    Shellfish,
    Strawberries,
    Tomatoes,
    Chocolate,
    Pollen,
    Cats
}

public class Allergies
{
    private readonly int mask;

    public Allergies(int mask){
        this.mask = mask;
    }

    public bool IsAllergicTo(Allergen allergen){
        int value = 1 << (int)allergen;
        return (mask & value) != 0;
    }

    public Allergen[] List(){
        return Enum.GetValues<Allergen>()
            .Where(IsAllergicTo)
            .ToArray();
    }
}