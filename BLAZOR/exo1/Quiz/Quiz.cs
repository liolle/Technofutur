using System.Text.Json;

namespace exo1.QZ;


public class QuizGame
{
    public static List<Question> Questions { get; private set; } = [];

    public Question this[int index]
    {
        get
        {
            if (Questions == null || Questions.Count == 0)
                throw new InvalidOperationException("No questions available.");

            index--;
            return Questions[Math.Clamp(index, 0, Questions.Count - 1)];
        }
    }

    public int Len {
        get {
            return Questions.Count();
        }
    }

    static QuizGame()
    {
        LoadQuestionsAsync().Wait();
    }

    public static async Task LoadQuestionsAsync()
    {
        try
        {
            string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "questions.json");

            if (File.Exists(filePath))
            {
                string json = await File.ReadAllTextAsync(filePath);
                Questions = JsonSerializer.Deserialize<List<Question>>(json) ?? [];
            }
            else
            {
                Console.WriteLine("Questions file not found. Using default questions.");
                LoadDefaultQuestions();
            }
        }
        catch (Exception)
        {
            LoadDefaultQuestions();
        }
    }

    private static void LoadDefaultQuestions()
    {
        Questions =
        [
            new Question { Statement = "The Great Wall of China is visible from space.", Answer = false },
        ];
    }
}

public class Question
{
    public required string Statement { get; set; } 
    public bool Answer { get; set; } 
}

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