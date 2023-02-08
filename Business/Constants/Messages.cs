using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Constants
{
    // Burası sabit ve basit bir mesaj olduğu için her seferinde new'lememek için class'ı 'static' yaptık.
    public static class Messages
    {
        public static string ProductAdded = "Ürün eklendi";
        public static string ProductNameInvalid = "Ürün adı geçersiz";
        public static string MaintenanceTime = "Sistem bakımda";
        public static string ProductsListed = "Ürünler listelendi";
    }
}
