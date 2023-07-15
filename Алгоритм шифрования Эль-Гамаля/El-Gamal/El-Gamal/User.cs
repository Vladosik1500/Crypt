using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace El_Gamal
{
    public partial class User : MetroFramework.Forms.MetroForm
    {
        public User()
        {
            InitializeComponent();
        }

        private void number_p1_MouseMove(object sender, MouseEventArgs e)
        {
            tool.SetToolTip(number_p, "Введите простое число p");
        }
        private void number_g_MouseMove(object sender, MouseEventArgs e)
        {
            tool.SetToolTip(number_g, "Введите число g, такое, что p mod(g) = 1.");
        }
        public static int FindPrimitiveRoot(int p)
        {
            List<int> factors = GetPrimeFactors(p - 1); // Получаем простые множители p - 1

            for (int r = 2; r < p; r++)
            {
                bool isPrimitiveRoot = true;

                foreach (int factor in factors)
                {
                    if (ModularExponentiation(r, (p - 1) / factor, p) == 1)
                    {
                        isPrimitiveRoot = false;
                        break;
                    }
                }

                if (isPrimitiveRoot)
                {
                    return r;
                }
            }

            return -1; // Если первообразный корень не найден
        }

        public static int ModularExponentiation(int a, int b, int p)
        {
            if (b == 0)
            {
                return 1;
            }

            long result = 1;
            long baseValue = a % p;

            while (b > 0)
            {
                if (b % 2 == 1)
                {
                    result = (result * baseValue) % p;
                }

                baseValue = (baseValue * baseValue) % p;
                b /= 2;
            }

            return (int)result;
        }

        public static List<int> GetPrimeFactors(int n)
        {
            List<int> factors = new List<int>();

            while (n % 2 == 0)
            {
                factors.Add(2);
                n /= 2;
            }

            for (int i = 3; i <= Math.Sqrt(n); i += 2)
            {
                while (n % i == 0)
                {
                    factors.Add(i);
                    n /= i;
                }
            }

            if (n > 2)
            {
                factors.Add(n);
            }

            return factors;
        }
        private void gen_g_Click_1(object sender, EventArgs e)
        {
            int p = Convert.ToInt32(number_p.Text);
            number_g.Text = Convert.ToString(FindPrimitiveRoot(p));
        }

        private void number_g_KeyPress(object sender, KeyPressEventArgs e)
        {
            char g = e.KeyChar;
            if(!Char.IsDigit(g) && g != 8)
            {
                    e.Handled = true;             
            }
            
        }
        private void number_p_KeyPress(object sender, KeyPressEventArgs e)
        {
            char g = e.KeyChar;
            if (!Char.IsDigit(g) && g != 8)
            {
                e.Handled = true;
            }
        }
        private void secret_x_MouseMove(object sender, MouseEventArgs e)
        {
            tool.SetToolTip(secret_x, "Введите секр. число x в диапазоне 1 <= x <= (p - 1)");
        }

        private void secret_x_KeyPress(object sender, KeyPressEventArgs e)
        {
            char k = e.KeyChar;
            if (!Char.IsDigit(k) && k != 8)
            {
                e.Handled = true;
            }
        }
        private void gen_x_Click(object sender, EventArgs e)
        {
                int p = Convert.ToInt32(number_p.Text);
                Random rand = new Random();
                int g = Convert.ToInt32(number_g.Text);
                int x = rand.Next(1,100);
                if (1 <= x && x <= (p - 1))
                {
                    MetroFramework.MetroMessageBox.Show(this, $"Число сгенерировано = {x}", "Уведомление");
                }
                secret_x.Text = x.ToString();
        }

        private void cal_y_Click(object sender, EventArgs e)
        {
                int p = Convert.ToInt32(number_p.Text);
                int g = Convert.ToInt32(number_g.Text);
                int x = Convert.ToInt32(secret_x.Text);
                double y;
                if (number_p.Text != String.Empty && number_g.Text != String.Empty && secret_x.Text != String.Empty)
                {
                    y = Math.Pow(g, x) % p;
                    number_y.Text = y.ToString();
                    MetroFramework.MetroMessageBox.Show(this, $"Число y = {y}", "Уведомление");
                }
                else
                {
                    MetroFramework.MetroMessageBox.Show(this, "Не все параметры введены для вычисления ключа - y", "Уведомление");
                }   
            
        }

        private void number_k_KeyPress(object sender, KeyPressEventArgs e)
        {
            char k = e.KeyChar;
            if (!Char.IsDigit(k) && k != 8)
            {
                e.Handled = true;
            }
        }

        private void number_k_MouseMove(object sender, MouseEventArgs e)
        {
            tool.SetToolTip(number_k, "Введите ключ k в диапазоне 1 <= x <= (p - 1)");
        }

        private void gen_k_Click(object sender, EventArgs e)
        {
                if(number_p.Text != String.Empty)
                {
                    int p = Convert.ToInt32(number_p.Text);
                    Random rand = new Random();
                    int k = rand.Next(1, 100);
                    if (1 <= k && k <= (p - 1))
                    {
                        MetroFramework.MetroMessageBox.Show(this, $"Число сгенерировано = {k}", "Уведомление");
                    }
                    number_k.Text = k.ToString();
                }
                else
                {
                    MetroFramework.MetroMessageBox.Show(this, "Пропущен параметр p", "Уведомление");
                }
        }
        private BigInteger[] ConvertToNumeric(string message)
        {
            BigInteger[] numericValues = new BigInteger[message.Length];
            for (int i = 0; i < message.Length; i++)
            {
                char letter = char.ToLower(message[i]);
                if (letter >= 'а' && letter <= 'я')
                {
                    numericValues[i] = letter - 'а' + 1;
                }
                if(letter == 'ё')
                {
                    numericValues[i] = 7;
                }
                else if (letter >= 'a' && letter <= 'z')
                {
                    numericValues[i] = letter - 'a' + 1;
                }
            }
            return numericValues;
        }
        private string ConvertToString(BigInteger[] values)
        {
            StringBuilder message = new StringBuilder();
            
            foreach (BigInteger value in values)
            {
                // Преобразование числового значения в символ
                char letter = (char)('а' + (value - 1));
                message.Append(letter);
            }
            string zero = "0";
            string space = " ";
            if (message.ToString().Contains(zero))
            {
                message.Replace(zero, space);
            }
            return message.ToString();
        }
        private BigInteger[] EncryptData(BigInteger[] messageValues)
        {
            BigInteger[] encryptedValues = new BigInteger[messageValues.Length];
            for (int i = 0; i < messageValues.Length; i++)
            {
                BigInteger m = messageValues[i];

                // Генерация случайного числа k
                int k = Int32.Parse(number_k.Text);
                int g = Int32.Parse(number_g.Text);
                int p = Int32.Parse(number_p.Text);
                int y = Int32.Parse(number_y.Text);

                // Вычисление шифрованного значения
                BigInteger u = BigInteger.ModPow(g, k, p);
                BigInteger v = (BigInteger.ModPow(y, k, p) * m) % p;

                string locks1 = string.Join(" ", u);
                number_u.Text = locks1;
                string locks2 = string.Join(" ", v);
                encryptedValues[i] = Int32.Parse(locks2);
            }
            return encryptedValues;
        }
        private void gen_message_Click(object sender, EventArgs e)
        {
            string message = text.Text;
            if (message != String.Empty)
            {
                string withoutPunctuation = Regex.Replace(message, @"[\p{P}\p{S}]", "");
                string output = string.Join(" ", ConvertToNumeric(withoutPunctuation));
                number_text.Text = output;
            }
            else
                MetroFramework.MetroMessageBox.Show(this, "Строка пустая, введите сообщение для его шифрования", "Уведомление");

        }
        private void text_KeyUp(object sender, KeyEventArgs e)
        {
            if(text.Text == String.Empty)
            {
                number_text.Clear();
            }
        }
        private void gen_private_Click(object sender, EventArgs e)
        {
            string num = number_text.Text;
            string[] withoutSpaces = num.Split(' ');
            BigInteger[] number_let = withoutSpaces.Select(BigInteger.Parse).ToArray();
            string let = string.Join(" ", EncryptData(number_let));
            number_v.Text = let;
            string u = number_u.Text;
            number_u2.Text = u;
            number_v2.Text = number_v.Text;
        }

        
        private BigInteger[] DecryptData(BigInteger[] encryptedValues)
        {
            int p = Int32.Parse(number_p.Text);
            int x = Int32.Parse(secret_x.Text);
            int u = Int32.Parse(number_u.Text);
            BigInteger s = BigInteger.ModPow(u, x, p);
            BigInteger[] decryptedValues = new BigInteger[encryptedValues.Length];
            BigInteger sInv = BigInteger.ModPow(s, p - 2, p);
            for(int i = 0; i < encryptedValues.Length; i++)
            {
                BigInteger decryptMessage = (encryptedValues[i] * sInv) % p;
                decryptedValues[i] = decryptMessage;
            }
            
            //BigInteger[] decryptedValues = new BigInteger[encryptedValues.Length];
            //for (int i = 0; i < encryptedValues.Length; i++)
            //{
            //    BigInteger c1Inverse = BigInteger.ModPow(encryptedValues[i], p - 2, p);

            //    BigInteger m = (c1Inverse * encryptedValues[i]) % p;

            //    decryptedValues[i] = m;
            //}
            return decryptedValues;
        }
        //public string Decrypt(string encryptedText)
        //{
        //    // Декодирование шестнадцатеричной строки в шифрованные данные
        //    string[] tokens = encryptedText.Split(' ');
        //    BigInteger[] number_let = tokens.Select(BigInteger.Parse).ToArray();

        //    // Расшифровка данных
        //    //BigInteger[] decryptedValues = DecryptData(number_let);

        //    // Преобразование числовых значений в текстовую форму
        //    //string decryptedMessage = ConvertToString(decryptedValues);
        //    //dec_mes.Text = decryptedMessage;
        //    return decryptedMessage;

        //}
        private void decrypt_message_Click(object sender, EventArgs e)
        {
            string num_v = number_v.Text;
            string[] withoutSpaces = num_v.Split(' ');
            BigInteger[] number_let = withoutSpaces.Select(BigInteger.Parse).ToArray();
            string let = string.Join(" ", DecryptData(number_let));
            dec_mes.Text = let;
        }
        static bool IsPrime(int number)
        {
            if (number < 2)
                return false;

            for (int i = 2; i <= Math.Sqrt(number); i++)
            {
                if (number % i == 0)
                    return false;
            }

            return true;
        }
        private void gen_p_Click(object sender, EventArgs e)
        {
            Random random = new Random();
            int number;

            while (true)
            {
                number = random.Next(2, 100); // Генерируем случайное число от 2 до 100

                if (IsPrime(number))
                    break;
            }
            number_p.Text = number.ToString();
        }

        private void data_verification_Click(object sender, EventArgs e)
        {
            int p = int.Parse(number_p.Text);
            int g = int.Parse(number_g.Text);
            int x = int.Parse(secret_x.Text);
            if (p <= 1)
            {
                DialogResult result = MetroFramework.MetroMessageBox.Show(this,  $"Число {p} меньше либо равно 1", "Уведомление");
                if(result == DialogResult.OK)
                {
                    number_p.Clear();
                }
            }
            else if (p > 1)
            {
                for (int i = 2; i <= Math.Sqrt(p); i++)
                {
                    if (p % i == 0)
                    {
                        DialogResult result = MetroFramework.MetroMessageBox.Show(this, $"Число p = {p} четное, что не соответствует условию", "Уведомление");
                        if (result == DialogResult.OK)
                        {
                            number_p.Clear();
                        }
                    }
                }
            }
            if(number_p.Text != String.Empty)
            {
                List<int> factors = GetPrimeFactors(p - 1); // Получаем простые множители p - 1

                foreach (int factor in factors)
                {
                    if (ModularExponentiation(g, (p - 1) / factor, p) == 1)
                    {
                        MetroFramework.MetroMessageBox.Show(this, $"Число {g} не является первообразным корнем.", "Уведомление");
                        number_g.Clear();
                    }
                }
            }
            
            if (x < 1 || x > (p - 1))
            {
                DialogResult result = MetroFramework.MetroMessageBox.Show(this, $"Число {x} не соответствует данным условиям", "Уведомление");
                if (result == DialogResult.OK)
                {
                    secret_x.Clear();
                }
            }
            if(number_p.Text == String.Empty || number_g.Text == String.Empty || secret_x.Text == String.Empty)
            {
                number_y.Clear();
            }
        }

        private void conv_num_Click(object sender, EventArgs e)
        {
            string num_v = dec_mes.Text;
            string[] tokens = num_v.Split(' ');
            BigInteger[] number_let = tokens.Select(BigInteger.Parse).ToArray();
            string decryptedMessage = ConvertToString(number_let);
            encrypt_mes.Text = decryptedMessage;
            //string decryptedMessage = "";

            //while (decryptedNumber > 0)
            //{
            //    BigInteger asciiValue = decryptedNumber % 100; // Предполагается, что каждое двузначное число соответствует символу ASCII
            //    char character = (char)asciiValue;
            //    decryptedMessage = character + decryptedMessage;
            //    decryptedNumber = decryptedNumber / 100;
            //}
        }
    }
}
