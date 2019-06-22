using System.Web.Mvc;
using System.Web.Routing;

namespace ASPNET_MVC
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.IgnoreRoute("robots.txt");

            routes.MapRoute(
                name: "Yeni Haber",
                url: "Yeni_haber",
                defaults: new { controller = "Detaylar", action = "Create"}
                );

            routes.MapRoute(
                name: "Haber Detayları",
                url: "Haber/{baslik}",
                defaults: new { controller = "Detaylar", action = "Oku", baslik = "" }
                );

            routes.MapRoute(
                name: "Haberler",
                url: "Haberler",
                defaults: new { controller = "Detaylar", action = "Index" }
                );
            //
            routes.MapRoute(
                name: "Şifremi Unuttum",
                url: "Sifremi_unuttum",
                defaults: new { controller = "Security", action = "Sifre_unuttum" }
                );

            routes.MapRoute(
                name: "Yeni Kayıt",
                url: "Kayit",
                defaults: new { controller = "Security", action = "Kayit" }
                );

            routes.MapRoute(
                name: "Oturumu Aç",
                url: "Oturumu_ac",
                defaults: new { controller = "Security", action = "Oturum_ac" }
                );

            routes.MapRoute(
                name: "Oturumu Kapat",
                url: "Oturumu_kapat",
                defaults: new { controller = "Home", action = "Logout" }
                );

            routes.MapRoute(
                name: "Çerez",
                url: "Cerez",
                defaults: new { controller = "Komut", action = "CerezK" }
                );

            routes.MapRoute(
                name: "Hamburger",
                url: "Hamburger/{id}",
                defaults: new { controller = "Komut", action = "Hamburger", id = "" }
                );

            routes.MapRoute(
                name: "Tema",
                url: "Tema/{id}",
                defaults: new { controller = "Komut", action = "Tema", id = "" }
                );

            routes.MapRoute(
                name: "Yenile",
                url: "Yenile",
                defaults: new { controller = "Komut", action = "Yenile" }
                );

            //
            routes.MapRoute(
                name: "Tanıtım",
                url: "Tanitim",
                defaults: new { controller = "Home", action = "Tanitim" }
                );

            routes.MapRoute(
                name: "Html Css",
                url: "HtmlCss",
                defaults: new { controller = "Home", action = "HtmlCss" }
                );

            routes.MapRoute(
                name: "JavaScript",
                url: "JavaScript",
                defaults: new { controller = "Komut", action = "JavaScript" }
                );

            routes.MapRoute(
                name: "İletişim",
                url: "Iletisim",
                defaults: new { controller = "Home", action = "Iletisim" }
                );

            routes.MapRoute(
                name: "Hakkında",
                url: "Hakkimizda",
                defaults: new { controller = "Home", action = "Hakkinda" }
                );

            routes.MapRoute(
                name: "İstatistik",
                url: "Istatistik",
                defaults: new { controller = "Istatistik", action = "Istatistik" }
                );

            routes.MapRoute(
                name: "Sohbet",
                url: "Sohbet",
                defaults: new { controller = "Sohbet", action = "Sohbet" }
                );
            //
            routes.MapRoute(
                name: "Kullanıcı Sil",
                url: "Kullanici_sil/{id}",
                defaults: new { controller = "Kullanici", action = "Sil", id = "" }
                );

            routes.MapRoute(
                name: "Kullanıcı Düzenle",
                url: "Kullanici_duzenle/{id}",
                defaults: new { controller = "Kullanici", action = "Duzenle", id = "" }
                );

            routes.MapRoute(
                name: "Kullanıcı Detay",
                url: "Kullanici_detaylari/{id}",
                defaults: new { controller = "Kullanici", action = "Detaylar", id = "" }
                );

            routes.MapRoute(
                name: "Kullanıcı Ekleme",
                url: "Yeni_kullanici",
                defaults: new { controller = "Kullanici", action = "Olustur" }
                );

            routes.MapRoute(
                name: "Kullanicilar Anasayfa",
                url: "Kullanicilar",
                defaults: new { controller = "Kullanici", action = "Kullanicilar" }
                );
            //
            routes.MapRoute(
                name: "Personel Listeleme",
                url: "Personelleri_listele/{id}",
                defaults: new { controller = "Personel", action = "PersonelleriListele", id = "" }
                );

            routes.MapRoute(
                name: "Personel Güncelleme",
                url: "Personel_guncelleme/{id}",
                defaults: new { controller = "Personel", action = "Guncelle", id = "" }
                );

            routes.MapRoute(
                name: "Personel Ekleme",
                url: "Yeni_personel",
                defaults: new { controller = "Personel", action = "Yeni" }
                );

            routes.MapRoute(
                name: "Personel Anasayfa",
                url: "Personeller",
                defaults: new { controller = "Personel", action = "Personel" }
                );
            //
            routes.MapRoute(
                name: "Departman Güncelleme",
                url: "Departman_guncelleme/{id}",
                defaults: new { controller = "Departman", action = "Guncelle", id = "" }
                );

            routes.MapRoute(
                name: "Departman Ekleme",
                url: "Yeni_departman",
                defaults: new { controller = "Departman", action = "Yeni" }
                );

            routes.MapRoute(
                name: "Departman Anasayfa",
                url: "Departmanlar",
                defaults: new { controller = "Departman", action = "Departman" }
                );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Anasayfa", id = UrlParameter.Optional }
            );
        }
    }
}
