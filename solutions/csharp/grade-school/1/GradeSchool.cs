public class GradeSchool
{
    private Dictionary<int, List<string>> students = new Dictionary<int, List<string>>();

    public bool Add(string student, int grade)
    {
        if (students.Values.Any(list => list.Contains(student))){
            return false;
        }
    
        if (!students.ContainsKey(grade)){
            students[grade] = new List<string>();
        }
    
        students[grade].Add(student);
        return true;
    }

    public IEnumerable<string> Roster()
    {
        return students
            .OrderBy(x => x.Key)
            .SelectMany(x => x.Value.OrderBy(name => name));
    }

    public IEnumerable<string> Grade(int grade)
    {
        if (!students.ContainsKey(grade)){
            return new List<string>();
        }

        return students[grade].OrderBy(name => name);
    }
}