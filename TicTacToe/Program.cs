namespace TicTacToe
{
    internal class Program
    {



       static char currentPlayer = 'X';//şu anki oyuncu
       static char[] tahta = {'1','2','3', '4', '5', '6', '7', '8', '9' };
       static bool kazanma = false;


        static void Main(string[] args)
        {
            TahtaOlustur();
            int turn = 0;//sıra 

            while (!kazanma && turn<9)//kazanan yok ve daha 9 tur olmadığı müddetçe bu blok çalışacak
            {
                currentPlayer = (turn % 2 == 0) ? 'X' : 'O';//eğer sıra no çift ise X tek ise 0 olsun
                int choice = OyuncuSecimi();

                
                
                    tahta[choice - 1] = currentPlayer;//kullanıcının seçtiği konuma o an ki oyuncunun sembolünü ver
                    TahtaOlustur();//oyun tahtasını güncelleyerek tekrar oluştur
                    kazanma = kazanmaDurumu();
                    if (!kazanma)//kazanan yoksa turu arttır
                        turn++;
                
            
            }
            if (kazanma)
            {
                Console.WriteLine($"tebrikler {currentPlayer} kazandı.");
            }
            else { Console.WriteLine("Berabere kaldınız");}//bu durumlar olmazsa beraber



        }

        static void TahtaOlustur()
        {

            for(int i=0; i<9; i += 3)//tahta düzenini oluşturan döngü
            {
                Console.WriteLine($"|{tahta[i]}  {tahta[i+1]}  {tahta[i+2]}|");
                if (i < 6) { Console.WriteLine("--|--|--"); }
            }
        }


        static int OyuncuSecimi() {
            int choice;
            
            while (true)
            {
                Console.WriteLine($"{currentPlayer}lütfen 1-9 arasında bir sayı giriniz:");

                string input = Console.ReadLine(); 
                if (int.TryParse(input, out choice))//eğer input olarak gelen değer int tipine dönüştürülebilirse choice değişkenine ata
                    if (choice >= 1 && choice <= 9)//girilen değer 1 veya 9 arasında ise burası çalışşsın
                {
                    if (tahta[choice - 1] != 'X' && tahta[choice - 1] != 'O')
                        break;
                    else
                        Console.WriteLine("Bu alan zaten dolu, başka bir alan seçin.");//aynı yeri seçemesin
                }
                else
                    Console.WriteLine("Geçersiz seçim! Lütfen 1-9 arasında bir sayı girin.");
            }
            return choice;
        }


        static bool kazanmaDurumu()
        {
            if (tahta[0] == tahta[1] && tahta[1] == tahta[2] ||
                tahta[3] == tahta[4] && tahta[4] == tahta[5] ||
                tahta[6] == tahta[7] && tahta[7] == tahta[8] ||//satırlar eşit mi
                tahta[0] == tahta[3] && tahta[3] == tahta[6] ||
                tahta[1] == tahta[4] && tahta[4] == tahta[7] ||
                tahta[2] == tahta[5] && tahta[5] == tahta[8] ||//sütunlar eşit mi
                tahta[0] == tahta[4] && tahta[4] == tahta[8] ||
                tahta[2] == tahta[4] && tahta[4] == tahta[6])//çapraz değerler eşit mi
            {
                return true;
            }
            else 
            return false;
            
        }

    }

    }

