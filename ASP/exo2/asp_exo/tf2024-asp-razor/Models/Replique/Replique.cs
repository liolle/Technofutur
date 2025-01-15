
namespace tf2024_asp_razor.Models.Replique;
class Replique
{
    public string Film {get;set;}
    public string Phrase {get; set;}
}

 class Repliques(List<Replique> repliques) {
    public List<Replique> rep {get;set;} = repliques;
}