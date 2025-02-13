namespace exo1.entities;

public class Guess
{
    public required Question Question { get; set; } 
    public bool GS { get; set; } 

    public bool IsValid {
        get {
            if (Question is null){return false;}
            return Question.Answer == GS;
        }
    }
}