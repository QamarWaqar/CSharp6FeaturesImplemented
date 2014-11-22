using System;
// You can use Static classes in using clause. //
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp_6_New_Features
{
    /// <summary>
    /// Remember it can also be defined inside Program but not as static.
    /// But when you are calling it, it is static to that Class
    /// </summary>
    /// <param name="s"></param>
    public delegate void Dell(string s);

    class Program
    {
        /// <summary>
        /// Just a refereshal on Properties
        /// </summary>
        public string dumb { get { return "World"; } set { value = "Hello"; } }

        /// <summary>
        /// Computed Properties, A completely new thing in C# 6.0 //
        /// Remember you cannot have body of "Computed Property"
        /// Which means that they will be getter only and cannot be setter and will return for sure
        /// </summary>
        public int number => 0;

        /// <summary>
        /// automatic implemented properties can now skip setter and can be getter only, 
        /// and can be assigned a value  with for example. public int x { get; } = 10;
        /// </summary>
        public static int autoImpProp { get; } = 10;

        static void Main(string[] args)
        {
            Console.WriteLine("Automatic Implemented Prperty with getter only value is: " + autoImpProp);
            nullCoalescingOperator();

            // String Interpolation //
            int x = 0; int y = 1;
            string sFormat = String.Format("x is: {0} and y is: {1}.", x, y);
            Console.WriteLine("String Format is: " + sFormat);
            Console.WriteLine("x is: \{x} and y is: \{y}");
            // end of String Interpolation //

            // Lambda Expressions //
            lambdaExpressionFunction("\{autoImpProp}");
            Program p = new Program();
            Dell d = Program.lambdaExpressionFunction;
            d("\{autoImpProp}");

            // strDel is a string returning delegate defined inside of Program Class //
            Program.strDel sD = () => "Hello";
            string str = sD(); Console.WriteLine("Qamar Waqar: " + str);
            // Good News Now you can have Lambda Expression Booty ;) //
            // Which in turn means you can use return inside of it //
            sD = () => { return "World"; };
            str = sD(); Console.WriteLine("Qamar Waqar: " + str);
            // end of Lambda Expressions //
        }

        static void nullCoalescingOperator()
        {
            // A thing from past that I might have missed. // Null coalescing operator // ?? operator //
            int x = 0;
            int? y = null; // and int? means null able int type //
            // if y is null then x is null, otherwise x is -1 //
            x = y ?? -1; // Note that ?? operator can only be applied to Null able types [int?] //
            Console.WriteLine(x);
        }

        /// <summary>
        /// you can now implement a method with just a Lambda Expression but 
        /// remember you cannot have a body of this lambda expression but
        /// you can now have lambda expression with body inside a function starting from C# 6.0
        /// check out the main fucntion for that
        /// </summary>
        public static void lambdaExpressionFunction(string s) => Console.WriteLine("From Lambda Expression funtion the string is: " + s);

        private delegate string strDel();
    }
}