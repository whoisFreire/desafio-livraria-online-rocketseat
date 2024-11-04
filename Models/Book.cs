namespace DesafioLivrariaOnline.Models;


public class Book
{
    public string Id { get; set; } = Guid.NewGuid().ToString();
    public string Title { get; set; }
    public string Author { get; set; }
    public string Gender { get; set; }
    public double Price { get; set; }
    public int stock { get; set; } = 0;
}


