using System;

public class SayaTubeVideo
{
    // Atribut
    private int id;
    private string title;
    private int playCount;

    // Constructor
    public SayaTubeVideo(string title)
    {
        // Mengatur id secara random sepanjang 5 digit
        Random rand = new Random();
        this.id = rand.Next(10000, 99999);
        this.title = title;
        this.playCount = 0; // Awalnya playCount diatur sebagai 0
    }

    // Method untuk menambah jumlah pemutaran
    public void IncreasePlayCount(int increment)
    {
        playCount += increment;
    }

    // Method untuk mencetak detail video
    public void PrintVideoDetails()
    {
        Console.WriteLine("Video ID: " + id);
        Console.WriteLine("Title: " + title);
        Console.WriteLine("Play Count: " + playCount);
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Membuat objek SayaTubeVideo baru dengan judul "Tutorial Design By Contract – [NAMA_PRAKTIKAN]"
        string namaPraktikan = "Alwin Fahrozi Marbun"; // Ganti dengan nama praktikan yang sesuai
        string judulVideo = "Tutorial Design By Contract – " + namaPraktikan;
        SayaTubeVideo video = new SayaTubeVideo(judulVideo);

        // Menambah jumlah pemutaran sebanyak 50
        video.IncreasePlayCount(50);

        // Mencetak detail video
        video.PrintVideoDetails();
    }
}