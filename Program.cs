using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cichelli2
{
    class Program
    {
        
       
        static void Main(string[] args)
        {
            Program a = new Program();
            string[] lines = System.IO.File.ReadAllLines(@"C:\Users\hhk19\Documents\Visual Studio 2017\Projects\Cichelli2\words.txt");
            List<String> anahtarlar = new List<String>();
            List<String> uzunluklar = new List<String>();
            List<String> fkarakterler = new List<String>();
            List<String> lkarakterler = new List<String>();


            foreach (string line in lines)
            {
                // Use a tab to indent each line of the file.
                anahtarlar.Add(line);
                    
                    
            }
            a.hashle(anahtarlar);

            

        }
        

        public void hashle(List<String> a) {
            /* int size;
             char firstcharacter;
             char lastcharacter;*/
            int fkaraktersayisi = 0;
            int lkaraktersayisi = 0;
            int toplamsıklık = 0;
            List<anahtar> anah = new List<anahtar>();
            Hashtable tablo = new Hashtable();
            

            foreach (string key in a) {
                anahtar b = new anahtar();
                b.Word = key;
                b.Size = key.Length;
                b.Fkarakter = key[0];
                b.Lkarakter = key[key.Length-1];
                fkaraktersayisi = fkaraktersay(key[0]);                
                lkaraktersayisi = lkaraktersay(key[key.Length-1]);
                toplamsıklık = fkaraktersayisi + lkaraktersayisi;                
                b.Sıklık = toplamsıklık;
                anah.Add(b);
                anah.OrderBy(x=>x.Sıklık);
                
                
            }
            e:
            tablo.Clear();
            int i = 0;
            foreach (anahtar key in anah) {
                int hashdeg = hashhesapla(key);
                i++;
                /*key.Fkarakterdeg = 0;
                key.Lkarakterdeg = 0;*/
                a:
                hashdeg = hashhesapla(key);
                //TODO Sıklıklar hesaplamada yok! Çakışma kontrolünde neden 1 sefer artırılıyor onu da çöz!
                
                if(tablo.ContainsValue(hashdeg) && !tablo.ContainsKey(key.Word))
                {
                    
                        Console.WriteLine("Cakisma oldu!");
                    //gvalueupdate(key, tablo, anah);
                    
                        key.Fkarakterdeg++;
                        goto e;
                        if (key.Fkarakterdeg == 4 || key.Fkarakterdeg>4)
                        {//buraya girince hep sonsuz döngü oluyor. Collision resolution bir türlü yapamadım. Bir türlü olmuyor.
                        key.Lkarakterdeg++;
                        //anahtar  k=anah.Find(anah.FindIndex(x => x.Word==key.Word));
                        //goto e;
                        /* Console.WriteLine("girdi2");
                         //c:*/
                           /* key.Deger = hashhesapla(key);
                            tablo.Keys.ToString();
                        anahtar k = anah[i];
                        k.Fkarakterdeg++;
                            Console.WriteLine("kword {0}, keyword {1}", k.Word, key.Word);*/
                                               
                            //goto e;
                            
                        }
                    //i++;
                    //goto e;
                        
                    
                    //Console.WriteLine("gecti");



                    /*key.Fkarakterdeg++;
                    if (key.Fkarakterdeg == 4) {
                        /*key.Fkarakterdeg = 0;
                        anahtar k1=anah.FindLast(x => x.Deger == hashdeg);
                        k1.Fkarakterdeg++;                
                    }*/

                    //key.Fkarakterdeg++;
                    //hashdeg = hashhesapla(key);


                }
                
               else
                {
                    key.Deger = hashdeg;
                    tablo.Add(key.Word, key.Deger);
                    Console.WriteLine("Key = {0}, Value = {1}", key.Word, key.Deger, key.Fkarakterdeg);
                }
               
               
            }

            Console.WriteLine("Hash tablosu dolduruldu!");
            foreach (DictionaryEntry de in tablo)
            {
                Console.WriteLine("Key = {0}, Value = {1}", de.Key, de.Value);
            }

            Console.ReadKey();






        }

        public void gvalueupdate(anahtar key, Hashtable tablo, List<anahtar> anah)
        {
            int say = 0;
            anahtar k;
            
                //key.Deger = hashdeg;
                key.Fkarakterdeg++;
                key.Deger = hashhesapla(key);
                /*tablo.Add(key.Word, key.Deger);
                Console.WriteLine("Key = {0}, Value = {1}", key.Word, key.Deger);*/
                if (key.Fkarakterdeg == 4)
                {
                    Console.WriteLine("G_value maxed");
                    key.Fkarakterdeg = 0;
                    Console.WriteLine("Geriye don!");
                    //tablo.Remove(key);
                    say = tablo.Count;
                    Console.WriteLine(say);
                    //anah.FindIndex(x => x.Word == key.Word);
                    k = anah.FindLast(x => x.Deger == key.Deger);
                    gvalueupdate(k, tablo, anah);
                    gvalueupdate(key, tablo, anah);


                }
                
                    if (tablo.ContainsKey(key.Word)) tablo.Remove(key.Word);
                    tablo.Add(key.Word, hashhesapla(key));
                    Console.WriteLine("yeniden eklendi!");
                
            




        
            /*key.Fkarakterdeg++;            
            if (key.Fkarakterdeg == 4)
            {
                Console.WriteLine("G_value maxed");
                key.Fkarakterdeg = 0;
                Console.WriteLine("Geriye don!");
                //tablo.Remove(key);
                say = tablo.Count;
                Console.WriteLine(say);
                //anah.FindIndex(x => x.Word == key.Word);
                k = anah.FindLast(x => x.Deger == key.Deger);
                gvalueupdate(k, tablo, anah);


            }*/
               
            
           
        }

        

        public int hashhesapla(anahtar key) {
            return (key.Size + key.Fkarakterdeg + key.Lkarakterdeg) % 20 ;
            
        }



        public int fkaraktersay(char c) {
            int ilksayi=0;
            int sonsayi = 0;
            int toplam = 0;
            string[] lines = System.IO.File.ReadAllLines(@"C:\Users\hhk19\Documents\Visual Studio 2017\Projects\Cichelli2\words.txt");
            foreach (string line in lines)
            {
                
                if (c == line[0]) {
                    ilksayi++;
                }
                if (c == line[line.Length-1]) {
                    sonsayi++;
                }

            }
            toplam = ilksayi + sonsayi;
            return ilksayi;
        }

        public int lkaraktersay(char c) {
            int ilksayi = 0;
            int sonsayi = 0;
            int toplam = 0;
            string[] lines = System.IO.File.ReadAllLines(@"C:\Users\hhk19\Documents\Visual Studio 2017\Projects\Cichelli2\words.txt");
            foreach (string line in lines)
            {
                
                if (c == line[line.Length-1])
                {
                    sonsayi++;
                }
                if (c == line[0])
                {
                    ilksayi++;
                }

            }
            toplam = sonsayi + ilksayi;
            return sonsayi;
        }

        
    }
}
