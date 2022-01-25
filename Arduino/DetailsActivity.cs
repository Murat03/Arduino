using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Arduino
{
    [Activity(Label = "Details")]
    public class DetailsActivity : Activity
    {
        TextView detailText;
        TextView titleText;
        TextView linkText;
        TextView linkText2;
        TextView linkText3;
        TextView linkText4;
        TextView linkText5;
        TextView linkText6;
        TextView linkText7;
        TextView linkText8;
        TextView linkText9;
        TextView questionTitleText;
        TextView questionText;
        TextView answerText;
        RadioGroup radioGroup;
        RadioButton radioButton1;
        RadioButton radioButton2;
        RadioButton radioButton3;
        CheckBox checkBox1;
        CheckBox checkBox2;
        CheckBox checkBox3;
        Button answerButton;
        Button newQuestionButton;

        string buttonName;
        int random;

        Intent intent;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.activity_details);

            detailText = FindViewById<TextView>(Resource.Id.detailText);
            titleText = FindViewById<TextView>(Resource.Id.titleText);
            linkText = FindViewById<TextView>(Resource.Id.linkText);
            linkText2 = FindViewById<TextView>(Resource.Id.linkText2);
            linkText3 = FindViewById<TextView>(Resource.Id.linkText3);
            linkText4 = FindViewById<TextView>(Resource.Id.linkText4);
            linkText5 = FindViewById<TextView>(Resource.Id.linkText5);
            linkText6 = FindViewById<TextView>(Resource.Id.linkText6);
            linkText7 = FindViewById<TextView>(Resource.Id.linkText7);
            linkText8 = FindViewById<TextView>(Resource.Id.linkText8);
            linkText9 = FindViewById<TextView>(Resource.Id.linkText9);
            questionTitleText = FindViewById<TextView>(Resource.Id.questionTitleText);
            questionText = FindViewById<TextView>(Resource.Id.questionText);
            radioGroup = FindViewById<RadioGroup>(Resource.Id.radioGroup1);
            radioButton1 = FindViewById<RadioButton>(Resource.Id.radioButton1);
            radioButton2 = FindViewById<RadioButton>(Resource.Id.radioButton2);
            radioButton3 = FindViewById<RadioButton>(Resource.Id.radioButton3);
            checkBox1 = FindViewById<CheckBox>(Resource.Id.checkBox1);
            checkBox2 = FindViewById<CheckBox>(Resource.Id.checkBox2);
            checkBox3 = FindViewById<CheckBox>(Resource.Id.checkBox3);
            answerButton = FindViewById<Button>(Resource.Id.answerButton);
            answerText = FindViewById<TextView>(Resource.Id.answerText);
            newQuestionButton = FindViewById<Button>(Resource.Id.newQuestionButton);


            buttonName = Intent.GetStringExtra("button");
            write(buttonName);

            linkText.Click += LinkText_Click;
            linkText2.Click += LinkText2_Click;
            linkText3.Click += LinkText3_Click;
            linkText4.Click += LinkText4_Click;
            linkText5.Click += LinkText5_Click;
            linkText6.Click += LinkText6_Click;
            linkText7.Click += LinkText7_Click;
            linkText8.Click += LinkText8_Click;
            linkText9.Click += LinkText9_Click;

            answerButton.Click += AnswerButton_Click;
            newQuestionButton.Click += NewQuestionButton_Click;
        }

        private void NewQuestionButton_Click(object sender, EventArgs e)
        {
            Random generator = new Random();
            random = generator.Next(0, 5);

            answerButton.Visibility = ViewStates.Visible;
            newQuestionButton.Visibility = ViewStates.Gone;

            radioGroup.ClearCheck();
            checkBox1.Checked = false;
            checkBox2.Checked = false;
            checkBox3.Checked = false;

            answerText.Visibility = ViewStates.Gone;
            titleText.Visibility = ViewStates.Gone;
            detailText.Visibility = ViewStates.Gone;
            linkText.Visibility = ViewStates.Gone;
            questionTitleText.Visibility = ViewStates.Visible;
            questionText.Visibility = ViewStates.Visible;
            if (random == 4)
            {
                checkBox1.Visibility = ViewStates.Visible;
                checkBox2.Visibility = ViewStates.Visible;
                checkBox3.Visibility = ViewStates.Visible;
                radioGroup.Visibility = ViewStates.Gone;
            }
            else
            {
                checkBox1.Visibility = ViewStates.Gone;
                checkBox2.Visibility = ViewStates.Gone;
                checkBox3.Visibility = ViewStates.Gone;
                radioGroup.Visibility = ViewStates.Visible;
                radioButton3.Visibility = ViewStates.Visible;
            }
            randomQuestion();
        }
        private void randomQuestion()
        {
            if (random == 0)
            {
                questionText.Text = "Konu Anlaşıldı Mı?";
                radioButton1.Text = "Evet";
                radioButton2.Text = "Hayır";
                radioButton3.Visibility = ViewStates.Gone;
            }
            else if (random == 1)
            {
                questionText.Text = "Arduino Uno'nun Hedef Alanı Nedir?";
                radioButton1.Text = "Başlangıç Seviyesi";
                radioButton2.Text = "Gelişmiş Özellikli";
                radioButton3.Text = "Nesnelerin İnterneti";
            }
            else if (random == 2)
            {
                questionText.Text = "Hangisi Arduino'nun Özelliklerindendir?";
                radioButton1.Text = "Sadece giriş verisi alır.";
                radioButton2.Text = "Sadece dışarıya çıktı verir.";
                radioButton3.Text = "Hem giriş verisi alır hem çıktı verir.";
            }
            else if (random == 3)
            {
                questionText.Text = "Hangisi Arduino Kartlarda En Az Bir Tane Bulunan Özelliktir?";
                radioButton1.Text = "5 voltluk regüle entegresi.";
                radioButton2.Text = "16 MHz osilator veya rezonatör.";
                radioButton3.Text = "İkisi de";
            }
            else if (random == 4)
            {
                questionText.Text = "Arduino IDE için Hangileri Doğrudur?";
                checkBox1.Text = "Kod editörüdür.";
                checkBox2.Text = "Derleyicidir.";
                checkBox3.Text = "Derlenen programı karta yükler.";
            }
        }

        private void AnswerButton_Click(object sender, EventArgs e)
        {
            answerButton.Visibility = ViewStates.Gone;
            newQuestionButton.Visibility = ViewStates.Visible;

            answerText.Visibility = ViewStates.Visible;
            if (random == 0)
            {
                if (radioButton1.Checked || radioButton2.Checked)
                {
                    answerText.SetTextColor(Resources.GetColor(Resource.Color.colorPrimaryDark));
                    radioGroup.Visibility = ViewStates.Gone;
                    answerText.Text = "Geri Dönüşünüz İçin Teşekkürler.";
                }
                else
                {
                    answerText.SetTextColor(Resources.GetColor(Resource.Color.colorPrimaryDark));
                    answerText.Text = "Lütfen Şıklardan Birini Seçin.";
                    answerButton.Visibility = ViewStates.Visible;
                    newQuestionButton.Visibility = ViewStates.Gone;
                }
            }else if(random == 1)
            {
                if (radioButton1.Checked)
                {
                    answerText.SetTextColor(Resources.GetColor(Resource.Color.colorGreen));
                    answerText.Text = "Cevabınız Doğru!";
                }else if (radioButton2.Checked)
                {
                    answerText.SetTextColor(Resources.GetColor(Resource.Color.colorRed));
                    radioGroup.Visibility = ViewStates.Gone;
                    answerText.Text = "Cevabınız Yanlış!";
                }
                else if (radioButton3.Checked)
                {
                    answerText.SetTextColor(Resources.GetColor(Resource.Color.colorRed));
                    radioGroup.Visibility = ViewStates.Gone;
                    answerText.Text = "Cevabınız Yanlış!";
                }
                else
                {
                    answerText.SetTextColor(Resources.GetColor(Resource.Color.colorPrimaryDark));
                    answerText.Text = "Lütfen Şıklardan Birini Seçin.";
                    answerButton.Visibility = ViewStates.Visible;
                    newQuestionButton.Visibility = ViewStates.Gone;
                }
            }else if(random == 2)
            {
                if (radioButton1.Checked)
                {
                    answerText.SetTextColor(Resources.GetColor(Resource.Color.colorRed));
                    radioGroup.Visibility = ViewStates.Gone;
                    answerText.Text = "Cevabınız Yanlış!";
                }
                else if (radioButton2.Checked)
                {
                    answerText.SetTextColor(Resources.GetColor(Resource.Color.colorRed));
                    radioGroup.Visibility = ViewStates.Gone;
                    answerText.Text = "Cevabınız Yanlış!";
                }
                else if (radioButton3.Checked)
                {
                    answerText.SetTextColor(Resources.GetColor(Resource.Color.colorGreen));
                    answerText.Text = "Cevabınız Doğru!";
                }
                else
                {
                    answerText.SetTextColor(Resources.GetColor(Resource.Color.colorPrimaryDark));
                    answerText.Text = "Lütfen Şıklardan Birini Seçin.";
                    answerButton.Visibility = ViewStates.Visible;
                    newQuestionButton.Visibility = ViewStates.Gone;
                }
            }
            else if(random == 3)
            {
                if (radioButton1.Checked)
                {
                    answerText.SetTextColor(Resources.GetColor(Resource.Color.colorRed));
                    radioGroup.Visibility = ViewStates.Gone;
                    answerText.Text = "Cevabınız Yanlış!";
                }
                else if (radioButton2.Checked)
                {
                    answerText.SetTextColor(Resources.GetColor(Resource.Color.colorRed));
                    radioGroup.Visibility = ViewStates.Gone;
                    answerText.Text = "Cevabınız Yanlış!";
                }
                else if (radioButton3.Checked)
                {
                    answerText.SetTextColor(Resources.GetColor(Resource.Color.colorGreen));
                    answerText.Text = "Cevabınız Doğru!";
                }
                else
                {
                    answerText.SetTextColor(Resources.GetColor(Resource.Color.colorPrimaryDark));
                    answerText.Text = "Lütfen Şıklardan Birini Seçin.";
                    answerButton.Visibility = ViewStates.Visible;
                    newQuestionButton.Visibility = ViewStates.Gone;
                }
            }
            else if(random == 4)
            {
                if (checkBox1.Checked && checkBox2.Checked && checkBox3.Checked)
                {
                    answerText.SetTextColor(Resources.GetColor(Resource.Color.colorGreen));
                    answerText.Text = "Cevabınız Doğru!";
                }
                else if (checkBox1.Checked || checkBox2.Checked || checkBox3.Checked)
                {
                    answerText.SetTextColor(Resources.GetColor(Resource.Color.colorRed));
                    checkBox1.Visibility = ViewStates.Gone;
                    checkBox2.Visibility = ViewStates.Gone;
                    checkBox3.Visibility = ViewStates.Gone;
                    answerText.Text = "Cevabınız Yanlış!";
                }
                else
                {
                    answerText.SetTextColor(Resources.GetColor(Resource.Color.colorPrimaryDark));
                    answerText.Text = "Lütfen Şıklardan Birini Seçin.";
                    answerButton.Visibility = ViewStates.Visible;
                    newQuestionButton.Visibility = ViewStates.Gone;
                }
            }
        }

        private void LinkText_Click(object sender, EventArgs e)
        {
            StartActivity(intent);
        }
        private void LinkText2_Click(object sender, EventArgs e)
        {
            intent = new Intent(this, typeof(ImageActivity));
            intent.PutExtra("image", "uno");
            StartActivity(intent);
        }
        private void LinkText3_Click(object sender, EventArgs e)
        {
            intent = new Intent(this, typeof(ImageActivity));
            intent.PutExtra("image", "mega");
            StartActivity(intent);
        }
        private void LinkText4_Click(object sender, EventArgs e)
        {
            intent = new Intent(this, typeof(ImageActivity));
            intent.PutExtra("image", "mini");
            StartActivity(intent);
        }
        private void LinkText5_Click(object sender, EventArgs e)
        {
            intent = new Intent(this, typeof(ImageActivity));
            intent.PutExtra("image", "nano");
            StartActivity(intent);
        }

        private void LinkText6_Click(object sender, EventArgs e)
        {
            intent = new Intent(this, typeof(ImageActivity));
            intent.PutExtra("image", "zero");
            StartActivity(intent);
        }

        private void LinkText7_Click(object sender, EventArgs e)
        {
            intent = new Intent(this, typeof(ImageActivity));
            intent.PutExtra("image", "gemma");
            StartActivity(intent);
        }

        private void LinkText8_Click(object sender, EventArgs e)
        {
            intent = new Intent(this, typeof(ImageActivity));
            intent.PutExtra("image", "lilypad");
            StartActivity(intent);
        }

        private void LinkText9_Click(object sender, EventArgs e)
        {
            intent = new Intent(this, typeof(ImageActivity));
            intent.PutExtra("image", "yun");
            StartActivity(intent);
        }
        private void write(string button)
        {
            if (button == "button1")
            {
                titleText.Text = "Arduino Nedir?";
                detailText.Text = "Arduino bir G/Ç kartı ve Processing/Wiring dilinin bir uygulamasını içeren geliştirme ortamından " +
                    "oluşan bir fiziksel programlama platformudur. Arduino tek başına çalışan interaktif nesneler geliştirmek için " +
                    "kullanılabileceği gibi bilgisayar üzerinde çalışan yazılımlara da bağlanabilir.";
                intent = new Intent(Intent.ActionView, Android.Net.Uri.Parse("https://tr.wikipedia.org/wiki/Arduino"));
            }
            else if (button == "button2")
            {
                titleText.Text = "Arduino'nun Donanım Özellikleri";
                detailText.Text = "Arduino kartları bir Atmel AVR mikrodenetleyici (Eski kartlarda ATmega8 veya ATmega168, yenilerinde" +
                    " ATmega328 ya da ATmega4809[1]) ve programlama ve diğer devrelere bağlantı için gerekli yan elemanlardan oluşur." +
                    " Her kartta en azından bir 5 voltluk regüle entegresi ve bir 16 MHz kristal osilator (bazılarında seramik " +
                    "rezonatör) bulunur. Mikrodenetleyiciye önceden bir bootloader programı yazılı olduğundan programlama için " +
                    "harici bir programlayıcıya ihtiyaç duyulmaz.";
                intent = new Intent(Intent.ActionView, Android.Net.Uri.Parse("https://tr.wikipedia.org/wiki/Arduino"));
            }
            else if (button == "button3")
            {
                titleText.Text = "Arduino Çeşitleri";
                detailText.Text = "Arduino kartları yetenek ve bağlantı sayılarına göre farklı modeller olarak sunuluyor. Bu çeşitliliğin " +
                    "ardında ise Arduino'nun açık ve özgür bir platform olması yatıyor. Arduino tabanlı donanım kartlarını özellikleri ve " +
                    "hedef alanları bağlamında aşağıdaki gibi bir sınıflandırmaya ayırmak mümkün";
                intent = new Intent(this, typeof(ImageActivity));
                intent.PutExtra("image", "model");
                linkText.Text = "Konuyla Alakalı Görsel İçin Tıkla";
            }
            else if (button == "button4")
            {
                titleText.Text = "Arduino Yazılımı";
                detailText.Text = "Arduino IDE, kod editörü ve derleyici olarak görev yapan, aynı zamanda derlenen programı karta yükleme " +
                    "işlemini de yapabilen, platform bağımsız çalışabilen Java programlama dilinde yazılmış bir geliştirme çatısıdır. Geliştirme " +
                    "ortamı, sanatçıları programlamayla tanıştırmak için geliştirilmiş Processing yazılımından yola çıkılarak geliştirilmiştir.";
                intent = new Intent(Intent.ActionView, Android.Net.Uri.Parse("https://teslaakademi.com/arduino-programlama"));
            }
            else if (button == "button5")
            {
                titleText.Text = "Arduino İle Yapılabilecek Projeler";
                detailText.Text = "En temel ve eğlenceli bir proje olan çeşitli tasarımlarda kumandalı arabalar yapılabilir. " +
                    "FM radyo yapılıp istenilen frekans dinlenebilir. Bluetooth modülleri ile kablosuz gamepad yapılabilir." +
                    "Müziğin ritmine göre hareket eden ledler yapılabilir. Sese duyarlı lamba yapılabilir. Küçük robot, robot kol," +
                    " nabız ölçer, engellere çarpmayan robot ve doğal gaz kaçak sensörü gibi birçok eğlenceli ve faydalı ürünler arduino " +
                    "ile yapılabilir.";
                intent = new Intent(Intent.ActionView, Android.Net.Uri.Parse("https://maker.robotistan.com/kategori/arduino/arduino-projeleri/"));
                linkText.Text = "Daha Fazla Proje ve Yapılışları İçin Tıklayın";
            }
            else if (button == "button6")
            {
                titleText.Text = "Yeni Başlayanlara Öneriler";
                detailText.Text = "Arduino kullanmak istiyor ve bu konuda bir şey bilmiyorsanız doğru yerdesiniz. Öncelikle yapmanız gereken bir " +
                    "proje seçmek. Daha sonra da bir Arduino seçmek. Kullanılabilecek en basit ve güçlü kartlardan birisi Arduino Uno'dur. Fakat " +
                    "projeniz için yeterli olup olmadığını da araştırmanız gerekmektedir. Daha sonra projeniz için gerekli diğer elemanları da " +
                    "tamamlayarak projenizi yapabilirsiniz. Bir proje yapabilmeniz için gerekli tüm bilgiler ve proje örnekleri uygulamamızda bulunmaktadır.";
                intent = new Intent(Intent.ActionView, Android.Net.Uri.Parse("http://www.netber.com/yeni-baslayanlar-icin-arduino-tavsiyeleri"));
                linkText.Text = "Daha Fazla Öneri İçin Tıklayın";
            }
            else if (button == "button7")
            {
                titleText.Text = "Görselini Görmek İstediğiniz Arduino'yu Seçin";
                newQuestionButton.Visibility = ViewStates.Gone;
                detailText.Visibility = ViewStates.Gone;
                linkText.Visibility = ViewStates.Gone;
                linkText2.Visibility = ViewStates.Visible;
                linkText3.Visibility = ViewStates.Visible;
                linkText4.Visibility = ViewStates.Visible;
                linkText5.Visibility = ViewStates.Visible;
                linkText6.Visibility = ViewStates.Visible;
                linkText7.Visibility = ViewStates.Visible;
                linkText8.Visibility = ViewStates.Visible;
                linkText9.Visibility = ViewStates.Visible;
                linkText2.Text = "Arduino Uno";
                linkText3.Text = "Arduino Mega";
                linkText4.Text = "Arduino Mini";
                linkText5.Text = "Arduino Nano";
                linkText6.Text = "Arduino Zero";
                linkText7.Text = "Arduino Gemma";
                linkText8.Text = "Arduino Lilypad";
                linkText9.Text = "Arduino Yun";
            }
        }
    }
}