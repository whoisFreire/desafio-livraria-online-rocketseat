using DesafioLivrariaOnline.Models;

namespace DesafioLivrariaOnline.Requests.Book;

public class CreateBookRequestJSON
{
    public string Title { get; set; }
    public string Author { get; set; }
    public string Gender { get; set; }
    public double Price { get; set; }
}