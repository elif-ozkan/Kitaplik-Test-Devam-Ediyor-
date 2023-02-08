using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;

namespace Kitaplık_Listele
{
    //Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\elifo\Desktop\Kitaplık.accdb

    public class KitapVT
    {
        OleDbConnection baglantı = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\elifo\Desktop\Kitaplık.accdb");

        public List<Kitap>Listele()
        {
            
            List<Kitap> ktp = new List<Kitap>();
            baglantı.Open();    
            
            OleDbCommand komut=new OleDbCommand("Select*From Kitaplar",baglantı); // Kayıtlı tüm kitaplar listelenir.
            OleDbDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                Kitap k = new Kitap();
                k.ID=Convert.ToInt32(dr[0]); //dr den gelen değerin alınması sağlanır.
                k.Ad = dr[1].ToString();
                k.Yazar = dr[2].ToString();

                ktp.Add(k);

            }
            baglantı.Close();
            return ktp;





        }
        public void KitapEkle(Kitap kt) //Değişkenin türü belli olmadığından sınıftan parametre türettik
        {
            baglantı.Open();
            OleDbCommand komut = new OleDbCommand("insert into Kitaplar(KitapAd,Yazar) values(@p1,@p2)", baglantı);
            komut.Parameters.AddWithValue("@p1", kt.Ad);
            komut.Parameters.AddWithValue("@p2", kt.Yazar);
            komut.ExecuteNonQuery();

            baglantı.Close();
        }
    }
}
