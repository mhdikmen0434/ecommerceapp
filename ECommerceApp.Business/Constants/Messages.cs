using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceApp.Business.Constants
{
    public static class Messages
    {
        public static string ProductNotFound = "Ürün bulunamadı";


        public static string CartProductNotExists = "Sepette ürün bulunmamaktadır";
        public static string CartProductAdded = "Ürün sepete eklendi";
        public static string CartProductDeleted = "Ürün sepetten silindi";
        public static string CartProductNotAddedMore = "Sepete stoktan fazla ürün eklenemez";
        public static string CartProductQuantityCannotBeNegative = "Ürün miktarı sıfırdan küçük olamaz";
        public static string CartProductUpdated = "Sepet güncellendi";
    }
}
