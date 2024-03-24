using System;

namespace FirstNamespace
{
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
}

namespace SecondNamespace
{
    public class SayaTubeVideo
    {
        // Atribut
        private int id;
        private string title;
        private int playCount;

        // Constructor
        public SayaTubeVideo(string title)
        {
            // Prekondisi: Judul video tidak null dan memiliki panjang maksimal 100 karakter
            if (title == null || title.Length > 100)
            {
                throw new ArgumentException("Judul video tidak valid");
            }

            // Mengatur id secara random sepanjang 5 digit
            Random rand = new Random();
            this.id = rand.Next(10000, 99999);
            this.title = title;
            this.playCount = 0; // Awalnya playCount diatur sebagai 0
        }

        // Method untuk menambah jumlah pemutaran
        public void IncreasePlayCount(int increment)
        {
            // Prekondisi: Input penambahan play count maksimal 10.000.000
            if (increment < 0 || increment > 10000000)
            {
                throw new ArgumentException("Penambahan play count tidak valid");
            }

            // Exception handling untuk overflow
            try
            {
                checked
                {
                    playCount += increment;
                }
            }
            catch (OverflowException ex)
            {
                Console.WriteLine("Overflow terjadi: " + ex.Message);
            }
        }

        // Method untuk mencetak detail video
        public void PrintVideoDetails()
        {
            Console.WriteLine("Video ID: " + id);
            Console.WriteLine("Title: " + title);
            Console.WriteLine("Play Count: " + playCount);
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Membuat objek SayaTubeVideo baru dengan judul "Tutorial Design By Contract – [NAMA_PRAKTIKAN]"
        string namaPraktikan = "Alwin Fahrozi Maarbun"; // Ganti dengan nama praktikan yang sesuai
        string judulVideo = "Tutorial Design By Contract – " + namaPraktikan;

        // Objek dari kelas pertama
        FirstNamespace.SayaTubeVideo video1 = new FirstNamespace.SayaTubeVideo(judulVideo);
        video1.IncreasePlayCount(50);
        video1.PrintVideoDetails();

        // Objek dari kelas kedua
        SecondNamespace.SayaTubeVideo video2;

        // Menguji prekondisi
        try
        {
            // Judul video melebihi panjang maksimal
            video2 = new SecondNamespace.SayaTubeVideo(new string('a', 101));
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }

        // Menguji exception handling
        video2 = new SecondNamespace.SayaTubeVideo("Tutorial Design By Contract");

        // Loop untuk menambah play count dengan increment yang besar
        for (int i = 0; i < 100; i++)
        {
            try
            {
                video2.IncreasePlayCount(1000000); // Menambah 1.000.000 play count per panggilan
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }

        // Mencetak detail video
        video2.PrintVideoDetails();
    }
}