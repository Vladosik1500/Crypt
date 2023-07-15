using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace El_Gamal
{
    public class ElGamalLetterEncryption
    {
        private static readonly BigInteger P = BigInteger.Parse("FFFFFFFFFFFFFFFFC90FDAA22168C234C4C6628B80DC1CD129024E088A67CC74020BBEA63B139B22514A08798E3404DDEF9519B3CD3A431B302B0A6DF25F14374FE1356D6D51C245E485B576625E7EC6F44C42E9A637ED6B0BFF5CB6F406B7EDEE386BFB5A899FA5AE9F24117C4B1FE649286651ECE45B3DC2007CB8A163BF0598DA48361C55D39A69163FA8FD24CF5F83655D23DCA3AD961C62F356208552BB9ED529077096966D670C354E4ABC9804F1746C08CA18217C32905E462E36CE3BE39E772C180E86039B2783A2EC07A28FB5C55DF06F4C52C9DE2BCBF6955817183995497CEA956AE515D2261898FA051015728E5A8AAAC42DAD33170D04507A33A85521ABDF1CBA64ECFB850458DBEF0A8AEA71575D060C7DB3970F85A6E1E4C7ABF5AE8CDB0933D71E8C94E04A25619DCEE3D2261AD2EE6BF12FFA06D98A0864D87602733EC86A64521F2B18177B200CBBE117577A615D6C770988C0BAD946E208E24FA074E5AB3143DB5BFCE0FD108E4B82D120A93AD2CAFFFFFFFFFFFFFFFF", System.Globalization.NumberStyles.HexNumber);
        private static readonly BigInteger G = 2;

        private BigInteger privateKey;
        private BigInteger publicKey;

        public ElGamalLetterEncryption()
        {
            // Генерация ключей
            GenerateKeys();
        }

        public string Encrypt(string message)
        {
            // Преобразование сообщения в числовую форму
            BigInteger[] messageValues = ConvertToNumeric(message);

            // Шифрование числовых значений
            BigInteger[] encryptedValues = EncryptData(messageValues);

            // Кодирование шифрованных данных в шестнадцатеричную строку
            StringBuilder encryptedText = new StringBuilder();
            foreach (BigInteger encryptedValue in encryptedValues)
            {
                encryptedText.Append(encryptedValue.ToString("X") + " ");
            }

            return encryptedText.ToString();
        }

        public string Decrypt(string encryptedText)
        {
            // Декодирование шестнадцатеричной строки в шифрованные данные
            string[] tokens = encryptedText.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            BigInteger[] encryptedValues = new BigInteger[tokens.Length];
            for (int i = 0; i < tokens.Length; i++)
            {
                encryptedValues[i] = BigInteger.Parse(tokens[i], System.Globalization.NumberStyles.HexNumber);
            }

            // Расшифровка данных
            BigInteger[] decryptedValues = DecryptData(encryptedValues);

            // Преобразование числовых значений в текстовую форму
            string decryptedMessage = ConvertToString(decryptedValues);

            return decryptedMessage;
        }

        private void GenerateKeys()
        {
            // Генерация случайного числа для закрытого ключа
            privateKey = GenerateRandomNumber(2, P - 2);

            // Вычисление открытого ключа
            publicKey = BigInteger.ModPow(G, privateKey, P);
        }

        private BigInteger GenerateRandomNumber(BigInteger minValue, BigInteger maxValue)
        {
            Random random = new Random();
            byte[] bytes = new byte[maxValue.ToByteArray().LongLength];
            BigInteger randomValue;

            do
            {
                random.NextBytes(bytes);
                randomValue = new BigInteger(bytes);
            } while (randomValue < minValue || randomValue >= maxValue);

            return randomValue;
        }

        private BigInteger[] ConvertToNumeric(string message)
        {
            BigInteger[] numericValues = new BigInteger[message.Length];
            for (int i = 0; i < message.Length; i++)
            {
                char letter = message[i];

                // Преобразование символа в числовое значение
                numericValues[i] = new BigInteger(letter);
            }
            return numericValues;
        }

        private string ConvertToString(BigInteger[] values)
        {
            StringBuilder message = new StringBuilder();
            foreach (BigInteger value in values)
            {
                // Преобразование числового значения в символ
                char letter = (char)value;
                message.Append(letter);
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
                BigInteger k = GenerateRandomNumber(2, P - 1);

                // Вычисление шифрованного значения
                BigInteger c1 = BigInteger.ModPow(G, k, P);
                BigInteger c2 = (BigInteger.ModPow(publicKey, k, P) * m) % P;

                encryptedValues[i] = c2;
            }
            return encryptedValues;
        }

        private BigInteger[] DecryptData(BigInteger[] encryptedValues)
        {
            BigInteger[] decryptedValues = new BigInteger[encryptedValues.Length];
            for (int i = 0; i < encryptedValues.Length; i++)
            {
                BigInteger c1Inverse = BigInteger.ModPow(encryptedValues[i], P - 1 - privateKey, P);

                BigInteger m = (c1Inverse * encryptedValues[i]) % P;

                decryptedValues[i] = m;
            }
            return decryptedValues;
        }
    }
}
