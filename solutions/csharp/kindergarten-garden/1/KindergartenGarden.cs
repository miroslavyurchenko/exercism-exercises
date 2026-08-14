public enum Plant
{
    Violets,
    Radishes,
    Clover,
    Grass
}

public class KindergartenGarden
{    
    private string diagram;
    public KindergartenGarden(string diagram)
    {
        
        this.diagram = diagram;
    }

    public IEnumerable<Plant> Plants(string student)
    {
        string[] rows = diagram.Split('\n');

        string[] students = {
            "Alice",
            "Bob",
            "Charlie",
            "David",
            "Eve",
            "Fred",
            "Ginny",
            "Harriet",
            "Ileana",
            "Joseph",
            "Kincaid",
            "Larry"
        };

        int studentIndex = Array.IndexOf(students, student);
        int start = studentIndex * 2;

        for (int i = start; i < start + 2; i++){
            yield return ToPlant(rows[0][i]);
        }

        for (int i = start; i < start + 2; i++){
            yield return ToPlant(rows[1][i]);
        }
    }

    private Plant ToPlant(char plant){
        return plant switch{'V' => Plant.Violets, 'R' => Plant.Radishes, 'C' => Plant.Clover, 'G' => Plant.Grass,
            _ => throw new ArgumentException("Unknown plant")};
    }
}