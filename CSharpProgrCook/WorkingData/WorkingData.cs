using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Text;

namespace CSharpProgrCook
{
    public class ManipulateString
    {
        private static void Main(string[] args)
        {
            string normalString = "EDUARDO ISAAC BALLESTEROS";
            string reverseString = ReverseString(normalString);
            System.Console.WriteLine(string.Concat("NORMAL: ", normalString));
            System.Console.WriteLine(string.Concat("REVERSE: ", reverseString));
            System.Console.Read();
            
        }

        public static string ReverseString(string str)
        {
            if (str == null || str.Length == 1)
            {
                return str;
            }

            System.Text.StringBuilder revString = new System.Text.StringBuilder(str.Length);

            for (int count = str.Length - 1; count > -1; count--)
            {
                revString.Append(str[count]);
            }

            return revString.ToString();
        }
    }
    public class CharacterEncodingExample
    {
        public static void Main(string[] args)
        {
            CharacterEncoding();
        }

        public static void CharacterEncoding()
        {
            using (System.IO.StreamWriter streamWriter = new System.IO.StreamWriter("output.txt"))
            {
                //Create and write a string containing the Pi math symbol
                string srcString = "Area = \u03A0r^2";
                streamWriter.WriteLine("Source Text: " + srcString);

                //Write the UTF-16 encoded bytes of the source string
                byte[] utf16String = System.Text.Encoding.Unicode.GetBytes(srcString);
                streamWriter.WriteLine("UTF-16: {0}", System.BitConverter.ToString(utf16String));

                //Convert the UTF-16 encoded source string to UTF-8 and ASCII
                byte[] utf8String = System.Text.Encoding.UTF8.GetBytes(srcString);
                byte[] asciiString = System.Text.Encoding.ASCII.GetBytes(srcString);

                //Write the UTF-8 and and ASCII encoded byte arrays
                streamWriter.WriteLine("UTF-8: {0}", System.BitConverter.ToString(utf8String));
                streamWriter.WriteLine("ASCII: {0}", System.BitConverter.ToString(asciiString));

                //Convert UTF-8 and ASCII encoded bytes back to UTF-16
                streamWriter.WriteLine("UTF-8: {0}", System.Text.Encoding.UTF8.GetString(utf8String));
                streamWriter.WriteLine("ASCII: {0}", System.Text.Encoding.ASCII.GetString(asciiString));

                //Flush and close the output file
                streamWriter.Flush();
                streamWriter.Close();
            }
        }
    }

    public class BasicValueTypesToByteArrays
    {
        public static void Main(string[] args)
        {
            ConvertBasicValueTypesToByteArray();
            System.Console.Read();
        }

        public static void ConvertBasicValueTypesToByteArray()
        {
            byte[] b = null;

            //Convert a bool to a byte array and display
            b = System.BitConverter.GetBytes(true);
            System.Console.WriteLine(System.BitConverter.ToString(b));

            //Convert a byte array to a bool and display
            System.Console.WriteLine(System.BitConverter.ToBoolean(b, 0));

            //Convert a bool to a byte array and display
            b = System.BitConverter.GetBytes(false);
            System.Console.WriteLine(System.BitConverter.ToString(b));

            //Convert a byte array to a bool and display
            System.Console.WriteLine(System.BitConverter.ToBoolean(b, 0));

            //Convert an int to a byte array and display
            b = System.BitConverter.GetBytes(123456789);
            System.Console.WriteLine(System.BitConverter.ToString(b));

            //Convert a byte array to a bool and display
            System.Console.WriteLine(System.BitConverter.ToInt32(b, 0));

            //Convert an int to a byte array and display
            b = System.BitConverter.GetBytes(1);
            System.Console.WriteLine(System.BitConverter.ToString(b));

            //Convert a byte array to a bool and display
            System.Console.WriteLine(System.BitConverter.ToInt32(b, 0));

            //Convert an int to a byte array and display
            b = System.BitConverter.GetBytes(2);
            System.Console.WriteLine(System.BitConverter.ToString(b));

            //Convert a byte array to a bool and display
            System.Console.WriteLine(System.BitConverter.ToInt32(b, 0));
        }
    }


    public class EncodeBinaryDataAsText
    {
        public static void Main(string[] args)
        {
            string normalText = "EDUARDO ISAAC BALLESTEROS MUÑOZ";
            System.Console.WriteLine(normalText);
            string base64String = StringToBase64(normalText);
            System.Console.WriteLine(base64String);
            System.Console.WriteLine(Base64ToString(base64String));

            System.Console.WriteLine("*********************");

            int normalInt = System.Int32.MaxValue;
            System.Console.WriteLine(normalInt);
            string base64Int = IntToBase64(normalInt);
            System.Console.WriteLine(base64Int);
            System.Console.WriteLine(Base64ToInt(base64Int));

            System.Console.Read();
        }

        //Base64 encode a Unicode string
        public static string StringToBase64(string src)
        {
            //Get a byte representation of the source string
            byte[] b = System.Text.Encoding.Unicode.GetBytes(src);

            //Return the Base 64 encoded string
            return System.Convert.ToBase64String(b);
        }

        //Decode a Base64 encoded Unicode string
        public static string Base64ToString(string src)
        {
            //Decode the base 64 encoded string to a byte array
            byte[] b = System.Convert.FromBase64String(src);

            //Return the decoded Unicode string
            return System.Text.Encoding.Unicode.GetString(b);
        }

        //Base64 encode an int
        public static string IntToBase64(int src)
        {
            //Get a byte representation of the int
            byte[] b = System.BitConverter.GetBytes(src);

            //Return the Base 64 encoded int
            return System.Convert.ToBase64String(b);
        }

        //Decode a Base64 encoded int
        public static int Base64ToInt(string src)
        {
            //Decode the base 64 encoded int to a byte array
            byte[] b = System.Convert.FromBase64String(src);

            //Return the decoded int
            return System.BitConverter.ToInt32(b, 0);
        }
    }

    public class ValidateInputUsingRegularExpressions
    {
        public static void Main(string[] args)
        {
            string validEmail = "eduballesteros@gmail.com";
            System.Console.WriteLine(validEmail);
            System.Console.WriteLine("IsValid:" + ValidateInput(@"^[\w-]+@([\w-]+\.)+[\w-]+$", validEmail));
            System.Console.WriteLine("-------------------");

            string invalidEmail = "eduballesteros@gmail";
            System.Console.WriteLine(invalidEmail);
            System.Console.WriteLine("IsValid:" + ValidateInput(@"^[\w-]+@([\w-]+\.)+[\w-]+$", invalidEmail));
            System.Console.WriteLine("-------------------");

            int validNumericInput = int.MaxValue;
            System.Console.WriteLine(validNumericInput);
            System.Console.WriteLine("IsValid:" + ValidateInput(@"^\d+$", validNumericInput.ToString()));
            System.Console.WriteLine("-------------------");

            string invalidNumericInputl = string.Concat(int.MaxValue, "BALLESTEROS");
            System.Console.WriteLine(invalidNumericInputl);
            System.Console.WriteLine("IsValid:" + ValidateInput(@"^\d+$", invalidEmail));
            System.Console.WriteLine("-------------------");

            //System.Console.Read();
        }

        /// <summary>
        /// Test any input string to see if it matches a specific regular expression
        /// </summary>
        /// <param name="regularExpression"></param>
        /// <param name="input"></param>
        /// <returns></returns>
        public static bool ValidateInput(string regularExpression, string input)
        {
            //Create a new Regex based on the specified regular expression
            System.Text.RegularExpressions.Regex regex = new System.Text.RegularExpressions.Regex((string)regularExpression);

            //Test if the specified input matches the regular expression
            return regex.IsMatch(input);
        }
    }

    public class CreatesDatesAndTimeFromStrings
    {
        public static void Main(string[] args)
        {
            // 01/09/2013 00:00:00
            System.DateTime dt1 = System.DateTime.Parse("Sep 2013");
            System.Console.WriteLine(dt1);

            // 05/09/2013 14:15:33
            System.DateTime dt2 = System.DateTime.Parse("Thu 5 September 2013 14:15:33");
            System.Console.WriteLine(dt2);

            // 05/09/2013 14:15:33
            System.DateTime dt3 = System.DateTime.Parse("Thursday 5 September 2013 14:15:33");
            System.Console.WriteLine(dt3);

            // 05/09/2013 14:15:33
            System.Globalization.CultureInfo providerES = System.Globalization.CultureInfo.GetCultureInfo("ES-CO");
            System.DateTime dt3spanish = System.DateTime.Parse("Jueves 5 Septiembre 2013 14:15:33", providerES);
            System.Console.WriteLine(dt3spanish);

            // 05/09/2013 00:00:00
            System.DateTime dt4 = System.DateTime.Parse("5,9,13");
            System.Console.WriteLine(dt4);

            // 05/09/2013 14:15:33
            System.DateTime dt5 = System.DateTime.Parse("5/9/2013 14:15:33");
            System.Console.WriteLine(dt5);

            // DateTime Now with 14:15:33
            System.DateTime dt6 = System.DateTime.Parse("14:15:33");
            System.Console.WriteLine(dt6);

            //Parse only strings containing LongTimePattern
            System.Globalization.CultureInfo provider = System.Globalization.CultureInfo.InvariantCulture;
            System.DateTime dt7 = System.DateTime.ParseExact("2:13:30 PM", "h:mm:ss tt", provider);
            System.Console.WriteLine(dt7);

            //Parse only strings containing MonthDayPattern
            System.DateTime dt8 = System.DateTime.ParseExact("September 03", "MMMM dd", provider);
            System.Console.WriteLine(dt8);
        }
    }

    public class ShortUrl
    {
        public static void Main(string[] args)
        {
            var payload = new
            {
                destination = "https://www.youtube.com/channel/UCHK4HD0ltu1-I212icLPt3g",
                domain = new
                {
                    fullName = "rebrand.ly"
                }
                //, slashtag = "A_NEW_SLASHTAG"
                //, title = "Rebrandly YouTube channel"
            };

            using (var httpClient = new HttpClient { BaseAddress = new Uri("https://api.rebrandly.com") })
            {
                httpClient.DefaultRequestHeaders.Add("apikey", "298fcb9f5c994ee09751487c9fd4c3a8");
                httpClient.DefaultRequestHeaders.Add("workspace", "5cf8d4fbae97433eae81b39d593b0e41");

                var body = new StringContent(
                    JsonConvert.SerializeObject(payload), UnicodeEncoding.UTF8, "application/json");

                using (var response = httpClient.PostAsync("/v1/links", body))
                {
                    var link = JsonConvert.DeserializeObject<dynamic>(response.ToString());

                    Console.WriteLine($"Long URL was {payload.destination}, short URL is {link.shortUrl}");
                }
            }
        }
    }

}
