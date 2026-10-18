using System;
using System.Collections.Generic;

namespace SistemPerpustakaan
{
    // Kelas Induk Item
    public class Item
    {
        public string judul { get; set; }
        public int tahun { get; set; }

        public virtual void Deskripsi()
        {
            Console.WriteLine("Ini adalah sebuah item di perpustakaan.");
        }

        public void InfoItem()
        {
            Console.WriteLine($"Judul: {judul}, Tahun: {tahun}");
        }
    }

    // Kelas Buku mewarisi Item
    public class Buku : Item
    {
        public string penulis { get; set; }

        public void CekPenulis()
        {
            Console.WriteLine($"Penulis: {penulis}");
        }

        public override void Deskripsi()
        {
            Console.WriteLine($"Buku berjudul '{judul}' ditulis oleh {penulis}.");
        }
    }

    // Kelas Majalah mewarisi Item
    public class Majalah : Item
    {
        public int edisi { get; set; }

        public void InfoEdisi()
        {
            Console.WriteLine($"Edisi: {edisi}");
        }

        public override void Deskripsi()
        {
            Console.WriteLine($"Majalah '{judul}' edisi ke-{edisi}.");
        }
    }

    // Kelas Novel mewarisi Buku
    public class Novel : Buku
    {
        public void BacaSinopsis()
        {
            Console.WriteLine("Membaca sinopsis novel...");
        }

        public override void Deskripsi()
        {
            Console.WriteLine($"Novel fiksi berjudul '{judul}' karya {penulis}.");
        }
    }

    // Kelas Komik mewarisi Buku
    public class Komik : Buku
    {
        public void TampilkanIlustrasi()
        {
            Console.WriteLine("Menampilkan ilustrasi gambar komik...");
        }

        public override void Deskripsi()
        {
            Console.WriteLine($"Buku Komik berjudul '{judul}' karya {penulis}.");
        }
    }

    // Kelas MajalahAnak mewarisi Majalah
    public class MajalahAnak : Majalah
    {
        public void KategoriAnak()
        {
            Console.WriteLine("Kategori: Anak-anak (Usia 5-12 Tahun)");
        }

        public override void Deskripsi()
        {
            Console.WriteLine($"Majalah Anak '{judul}' edisi {edisi}. Ramah anak.");
        }
    }

    // Kelas MajalahTeknologi mewarisi Majalah
    public class MajalahTeknologi : Majalah
    {
        public void TopikTeknologi()
        {
            Console.WriteLine("Topik: Gadget, AI, dan Inovasi Teknologi");
        }

        public override void Deskripsi()
        {
            Console.WriteLine($"Majalah Teknologi '{judul}' edisi {edisi}. Membahas tren IT terbaru.");
        }
    }

    // Kelas Perpustakaan
    public class Perpustakaan
    {
        private List<Item> daftarItem = new List<Item>();

        public void TambahItem(Item item)
        {
            daftarItem.Add(item);
            Console.WriteLine($"Item '{item.judul}' berhasil ditambahkan ke perpustakaan.");
        }

        public void DaftarItem()
        {
            Console.WriteLine("\n--- Daftar Item Perpustakaan ---");
            foreach (var item in daftarItem)
            {
                item.Deskripsi();
            }
            Console.WriteLine("--------------------------------\n");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // 1. Buat objek perpustakaan
            Perpustakaan perpus = new Perpustakaan();

            // 2. Buat beberapa objek item
            Novel novel1 = new Novel { judul = "MADILOG", tahun = 1951, penulis = "Tan Malaka" };
            Komik komik1 = new Komik { judul = "Naruto Vol 1", tahun = 1999, penulis = "Masashi Kishimoto" };
            MajalahTeknologi majalah1 = new MajalahTeknologi { judul = "CHIP", tahun = 2023, edisi = 10 };

            // 3. Tambahkan ke perpustakaan
            perpus.TambahItem(novel1);
            perpus.TambahItem(komik1);
            perpus.TambahItem(majalah1);

            // 4. Tampilkan semua data
            perpus.DaftarItem();

            // 5. Demonstrasikan polymorphism & panggil method khusus
            Console.WriteLine("--- Demonstrasi Method Khusus ---");
            novel1.InfoItem();
            novel1.CekPenulis();
            novel1.BacaSinopsis();
            majalah1.TopikTeknologi();

            // Demonstrasi Soal 5:
            Console.WriteLine("\n--- Demonstrasi Soal 5 ---");
            Item itemKomik = new Komik { judul = "One Piece", tahun = 1997, penulis = "Eiichiro Oda" };
            itemKomik.Deskripsi(); 
        }
    }
}