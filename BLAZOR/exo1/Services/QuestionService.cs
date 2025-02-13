using System.Net.Http.Json;
using exo1.entities;

namespace exo1.services;

public class QuestionService : IQuestionService
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

    public QuestionService(HttpClient http)
    {
        _=LoadQuestionsAsync(http);

    }

    static QuestionService (){
        LoadDefaultQuestions();
    }

    public static async Task LoadQuestionsAsync(HttpClient http)
    {
        try
        {
            var loadedQuestions = await http.GetFromJsonAsync<List<Question>>("questions.json");
            if (loadedQuestions != null)
            {
                Questions = loadedQuestions;
            }
            else
            {
                Console.WriteLine("Could not load Question Using default");
            }
        }
        catch (Exception)
        {
           Console.WriteLine("Could not load Question Using default");
        }
    }

    public QuestionService GetService(){
        return this;
    }

    private static void LoadDefaultQuestions()
    {
        Questions =
        [
            new Question { Statement = "The Great Wall of China is visible from space.", Answer = false },
            new Question {Statement = "Water boils at 100°C at sea level.", Answer= true },
            new Question {Statement = "Sharks are mammals.", Answer= false },
            new Question {Statement = "The capital of Australia is Sydney.", Answer= false },
            new Question {Statement = "Light travels faster than sound.", Answer= true },
            new Question {Statement = "Mount Everest is the tallest mountain in the world.", Answer= true },
            new Question {Statement = "Bananas grow on trees.", Answer= false },
            new Question {Statement = "The human body has 206 bones.", Answer= true },
            new Question {Statement = "Goldfish only have a 3-second memory.", Answer= false },
            new Question {Statement = "Octopuses have three hearts.", Answer= true }
        ];
    }
}