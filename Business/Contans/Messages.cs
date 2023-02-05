namespace Business.Contans
{
    public static class Messages
    {

        //User
        public static string AuthorizationDenied = "Yetkiniz Yoktur";
        public static string UserAdded = "Kullanıcı Başarıyla Kayıt Edilmiştir";
        public static string UserDeleted = "Kullanıcı Başarıyla Silinmiştir";
        public static string UserUpdated = "Kullanıcı Başarıyla Güncellendi";
        public static string UserPasswordUpdated = "Kullanıcı Şifresi Başarıyla Sıfırlandı";
        public static string UserListed = "Kullanıcılar Başarıyla Listelendi";
        public static string UserActiveListed = "Aktif Kullanıcılar Başarıyla Listelendi";
        public static string UserPassiveListed = "Pasif Kullanıcılar Başarıyla Listelendi";
        public static string UserNotFound = "Kullanıcı Bulunamadı";
        public static string PasswordError = "Hatalı Parola Girdiniz";
        public static string SuccessfulLogin = "Giriş Başarılı";
        public static string AccessTokenCreated = "Token Oluşturuldu";
        public static string UserPassive = "Kullanıcı Aktif Değil";
        public static string UserEmailAlreadyExists = "Aynı E-Posta Zaten Kayıtlı";

        public static string UserOperationListed = "Kullanıcı Yetkileri Başarıyla Listelendi";
        public static string UserOperationAdded = "Kullanıcı Yetkisi Başarıyla Kayıt Edilmiştir";
        public static string UserOperationDeleted = "Kullanıcı Yetkisi Başarıyla Silinmiştir";
        public static string UserOperationUpdated = "Kullanıcı Yetkisi Başarıyla Güncellendi";
        public static string UserOperationError = "Bu Kayıtta Kullanıcı Yetkisi Yoktur";

        public static string UserMenuListed = "Kullanıcı Menü Yetkileri Başarıyla Listelendi";
        public static string UserMenuAdded = "Kullanıcı Menü Yetkisi Başarıyla Kayıt Edilmiştir";
        public static string UserMenuDeleted = "Kullanıcı Menü Yetkisi Başarıyla Silinmiştir";
        public static string UserMenuUpdated = "Kullanıcı Menü Yetkisi Başarıyla Güncellendi";
        public static string UserMenuError = "Bu Kayıtta Menü Yetkisi Yoktur";

        //Bank
        public static string BankAdded = "Banka Başarıyla Kayıt Edilmiştir";
        public static string BankDeleted = "Banka Başarıyla Silinmiştir";
        public static string BankUpdated = "Banka Başarıyla Güncellendi";
        public static string BankListed = "Bankalarınız Başarıyla Listelendi";
        public static string BankNameAlreadyExists = "Aynı Banka Zaten Kayıtlı";

        //Cancellation
        public static string CancellationAdded = "İptal İşlemi Başarıyla Kayıt Edilmiştir";
        public static string CancellationDeleted = "İptal İşlemi Başarıyla Silinmiştir";
        public static string CancellationUpdated = "İptal İşlemi Başarıyla Güncellendi";
        public static string CancellationListed = "İptal İşlemleri Başarıyla Listelendi";
        public static string CancellationTotal = "Toplam İptal Tutarı";

        //CardPayment
        public static string CardPaymentAdded = "Kart Ödemesi Başarıyla Kayıt Edilmiştir";
        public static string CardPaymentDeleted = "Kart Ödemesi Başarıyla Silinmiştir";
        public static string CardPaymentUpdated = "Kart Ödemesi Başarıyla Güncellendi";
        public static string CardPaymentListed = "Kart Ödemeleriniz Başarıyla Listelendi";
        public static string CardPaymentCount = "Kartlı Ödeme İşlem Sayısı";
        public static string CardPaymentTotal = "Toplam Kartlı Ödeme Tutarı";

        //CentralPay
        public static string CentralPayAdded = "Merkez Ödemesi Başarıyla Kayıt Edilmiştir";
        public static string CentralPayDeleted = "Merkez Ödemesi Başarıyla Silinmiştir";
        public static string CentralPayUpdated = "Merkez Ödemesi Başarıyla Güncellendi";
        public static string CentralPayListed = "Merkez Ödemeleriniz Başarıyla Listelendi";

        //CustomerPay
        public static string CustomerPayAdded = "Firma Ödemesi Başarıyla Kayıt Edilmiştir";
        public static string CustomerPayDeleted = "Firma Ödemesi Başarıyla Silinmiştir";
        public static string CustomerPayUpdated = "Firma Ödemesi Başarıyla Güncellendi";
        public static string CustomerPayListed = "Firma Ödemeleriniz Başarıyla Listelendi";

        //Expenditure
        public static string ExpenditureAdded = "Masraf Çıkışınız Başarıyla Yapılmıştır";
        public static string ExpenditureDeleted = "Masraf Çıkışınız Başarıyla Silinmiştir";
        public static string ExpenditureUpdated = "Masraf Çıkışınız Başarıyla Güncellendi";
        public static string ExpenditureListed = "Masraf Çıkışlarınız Başarıyla Listelendi";
        public static string ExpenditureTotal = "Toplam Masraf Tutarı";


        //FutureMoney
        public static string FutureMoneyAdded = "Elden Gelecek Başarıyla Kayıt Edilmiştir";
        public static string FutureMoneyDeleted = "Elden Gelecek Başarıyla Silinmiştir";
        public static string FutureMoneyUpdated = "Elden Gelecek Başarıyla Güncellendi";
        public static string FutureMoneyUpdatedError = "Müşterinin Elden Gelen Ödemeleri Var";
        public static string FutureMoneyListed = "Elden Gelecekler Başarıyla Listelendi";
        public static string FutureMoneyActiveListed = "Aktif Elden Gelecekler Başarıyla Listelendi";
        public static string FutureMoneyPassiveListed = "Pasif Elden Gelecekler Başarıyla Listelendi";
        public static string FutureMoney = "Elden Gelecek Listelendi";
        public static string TransactionAmountAndAmountPaidSame = "İşlem Tutarı İle Ödenen Tutar Aynı Olamaz";
        public static string AmountPaidCannotGreaterTransactionAmount = "Ödenen Tutar İşlem Tutarından Büyük Olamaz";
        public static string CheckIfIncomingMoneyExists = "Müşterinin Elden Gelen Ödemeleri Var Gelecek Tutar Müşterinin Elden Gelen Ödemesinden Küçük Olamaz";
        public static string PromissoryNumberAlreadyExists = "Aynı Senet Numarası Zaten Kayıtlı";
        public static string FutureMoneyTotal = "Toplam Elden Gelecek Tutarı";

        //FutureMoneyCancellation
        public static string FutureMoneyCancellationAdded = "Elden Gelecek İptal İşlemi Başarıyla Kayıt Edilmiştir";
        public static string FutureMoneyCancellationDeleted = "Elden Gelecek İptal İşlemi Başarıyla Silinmiştir";
        public static string FutureMoneyCancellationUpdated = "Elden Gelecek İptal İşlemi Başarıyla Güncellendi";
        public static string FutureMoneyCancellationListed = "Elden Gelecek İptalleri Başarıyla Listelendi";

        //IncomingMoney
        public static string IncomingMoneyAdded = "Elden Gelen Başarıyla Kayıt Edilmiştir";
        public static string IncomingMoneyDeleted = "Elden Gelen Başarıyla Silinmiştir";
        public static string IncomingMoneyUpdated = "Elden Gelen Başarıyla Güncellendi";
        public static string IncomingMoneyListed = "Elden Gelenler Başarıyla Listelendi";
        public static string IncomingAmountCannotGreaterFutureAmount = "Gelen Tutar Gelecek Tutardan Büyük Olamaz";
        public static string IncomingAmountAndFutureAmountSame = "Ödemenin Tamamını Kapatmak İçin Lütfen Ödeme Kapat Butonunu Kullanın Sadece Kısmi Ödemeleri Buradan Yapabilirsiniz";

        //Operation Claim
        public static string MenuListed = "Menu Yetkileri Başarıyla Listelendi";

        //MonetaryDeficit
        public static string MonetaryDeficitAdded = "Kasa Açığı Başarıyla Kayıt Edilmiştir";
        public static string MonetaryDeficitDeleted = "Kasa Açığı Başarıyla Silinmiştir";
        public static string MonetaryDeficitUpdated = "Kasa Açığı Başarıyla Güncellendi";
        public static string MonetaryDeficitListed = "Kasa Açıklarınız Başarıyla Listelendi";

        //MoneyDeposited
        public static string MoneyDepositedAdded = "Para Yatırma Başarıyla Kayıt Edilmiştir";
        public static string MoneyDepositedDeleted = "Para Yatırma Başarıyla Silinmiştir";
        public static string MoneyDepositedUpdated = "Para Yatırma Başarıyla Güncellendi";
        public static string MoneyDepositedListed = "Para Yatırma İşlemleri Başarıyla Listelendi";

        //MoneyOutput
        public static string MoneyOutputAdded = "Kasa Çıkışınız Kayıt Edilmiştir";
        public static string MoneyOutputDeleted = "Kasa Çıkışınız Başarıyla Silinmiştir";
        public static string MoneyOutputUpdated = "Kasa Çıkışınız Başarıyla Güncellendi";
        public static string MoneyOutputListed = "Kasa Çıkışlarınız Başarıyla Listelendi";
        public static string MoneyOutputAlreadyExists = "Aynı Tarihli Kasa Çıkışı Zaten Kayıtlı";

        //Note
        public static string NoteAdded = "Notunuz Başarıyla Kayıt Edilmiştir";
        public static string NoteDeleted = "Notunuz Başarıyla Silinmiştir";
        public static string NoteUpdated = "Notunuz Başarıyla Güncellendi";
        public static string NoteListed = "Notunuz Başarıyla Listelendi";

        //Operation Claim
        public static string OperationListed = "Yetkiler Başarıyla Listelendi";

        //SafeBox
        public static string SafeBoxAdded = "Günlük Kasa Başarıyla Kayıt Edilmiştir";
        public static string SafeBoxDeleted = "Günlük Kasa Başarıyla Silinmiştir";
        public static string SafeBoxUpdated = "Günlük Kasa Başarıyla Güncellendi";
        public static string SafeBoxListed = "Günlük Kasa Başarıyla Listelendi";
        public static string TransactionTotalByDate = "İşlem Toplamları Listelendi";
        public static string DateAlreadyExists = "Aynı Tarih Zaten Kayıtlı";
        public static string SafeBoxCount = "Günlük Kasa İşlem Sayısı";

        //ShipmentList
        public static string ShipmentListAdded = "Kayıt Edilmiştir";
        public static string ShipmentListDeleted = "Silinmiştir";
        public static string ShipmentListUpdated = "Güncellendi";
        public static string ShipmentListListed = "Sevkiyat Listesi Başarıyla Listelendi";
        public static string ResearchListListed = "Sor Listesi Başarıyla Listelendi";
        public static string ShipmentNumberAlreadyExists = "Aynı Sıra Numarası Zaten Kayıtlı";
        public static string ShipmentListCount = "Toplam Sevkiyat Sayısı";
        public static string ResearchListCount = "Toplam Sor Sayısı";

        //Satisfaction
        public static string SatisfactionAdded = "Müşteri Memnuniyeti Başarıyla Kayıt Edilmiştir";
        public static string SatisfactionDeleted = "Müşteri Memnuniyeti Başarıyla Silinmiştir";
        public static string SatisfactionUpdated = "Müşteri Memnuniyeti Başarıyla Güncellendi";
        public static string SatisfactionListed = "Müşteri Memnuniyetleri Başarıyla Listelendi";

        //Staff
        public static string StaffAdded = "Personel Başarıyla Kayıt Edilmiştir";
        public static string StaffDeleted = "Personel Başarıyla Silinmiştir";
        public static string StaffUpdated = "Personel Başarıyla Güncellendi";
        public static string StafsActiveListed = "Aktif Personeller Başarıyla Listelendi";
        public static string StaffPassiveListed = "Pasif Personeller Başarıyla Listelendi";
        public static string StaffIdentityNumberExists = "Aynı T.C. Kimlik Numarasında Personel Zaten Kayıtlı";

        //StaffEpisode
        public static string StaffEpisodeAdded = "Personel Bölümü Başarıyla Kayıt Edilmiştir";
        public static string StaffEpisodeDeleted = "Personel Bölümü Başarıyla Silinmiştir";
        public static string StaffEpisodeUpdated = "Personel Bölümü Başarıyla Güncellendi";
        public static string StaffEpisodeListed = "Personel Bölümleri Başarıyla Listelendi";
        public static string StaffEpisodeNameAlreadyExists = "Aynı Bölüm Zaten Kayıtlı";

        //StaffTask
        public static string StaffTaskAdded = "Personel Görevi Başarıyla Kayıt Edilmiştir";
        public static string StaffTaskDeleted = "Personel Görevi Başarıyla Silinmiştir";
        public static string StaffTaskUpdated = "Personel Görevi Başarıyla Güncellendi";
        public static string StaffTaskListed = "Personel Görevleri Başarıyla Listelendi";
        public static string StaffTaskAlreadyExists = "Aynı Görev Zaten Kayıtlı";

    }

}
