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
        /// Creating this indexer for checking "Indexer Initializers" in "Side Object Initilizers"
        /// </summary>
        /// <param name="a"></param>
        /// <returns></returns>
        public int this[int a] { get { return a; } set { a = value; } }

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

            // "Indexers Initializers" in "Side Object Initializers" //
            Program pp = new Program {[0] = 1,[1] = 2, dumb = "Dummy" };
            // end of "Indexers Initializers" in "Side Object Initializers" //

            // The new "nameof" Operator in C# 6.0 //
            int nameOf = 0;
            // it is just basically used to out put name but comes in handy when you need to use it in a lot of places //
            // and then with just once change the string changes all over the code //
            Console.WriteLine(nameof(nameOf));
            // end of The new "nameof" Operator in C# 6.0 //

            // Calling the exceptionFiltersFunction //
            exceptionFiltersFunction();
            // end of Calling the exceptionFiltersFuntion //
        }

        static void nullCoalescingOperator()
        {
            // A thing from past that I might have missed. // Null coalescing operator // ?? operator //
            int x = 0;
            int? y = null; // and int? means null able int type //
            // if y is null then x is null, otherwise x is -1 //
            x = y ?? -1; // Note that ?? operator can only be applied to Null able types [int?] //
            Console.WriteLine(x);

            // Null Conditional Operator "?." new in C# 6.0 //
            /*
              Point p = new Point();
              if(p?.x==1){...} // so basically what you are doing here is checking if p is null 
              // if p is null the whole statement is null // and statement doesnt goes on to checking after that //
              // if(p.x?.ToString=="int"){ ... } // means if p.x is not equal to null and .ToString equals "int" //
              // if(p?.x?.ToString=="int"){ ... } // means check if p is null, if not then its x member, if not then its
                                       // ToString() method will be processed //
              // if(p?){ ... } // if body will only be executed if p is not null // otherwise the if statement is null //
              // you can also do this null-conditional operator on delegates too //
              // last but not the least you can also use p's indexers in this // try to do this //
            */
            Program p = new Program();
            if (p?.dumb == "World") { Console.WriteLine("Dumb World"); }
            // end of Null Conditional Operator "?." new in C# 6.0 //
        }

        /// <summary>
        /// // Now in C# you can filter the exceptions in the catch block too // previously in VB and F# //
        // For Example //
        // try {...} catch(Exception e) {...} finally {...}
        // now you can do this //
        // try {...}
        // catch (Exception e) if(e.Message == "Hello World!") {...}
        // finally {...}
        // Also now you have await in catch and finally blocks //
        /// </summary>
        public static void exceptionFiltersFunction()
        {
            try
            {
                Exception e = new Exception("Hello this is an Exception");
                throw e;
            }
            // Now you can't give catch block a body and neither else if statement nor else statement //
            catch (Exception e) if (e.Message == "Hello this is an Exception") { Console.WriteLine("Catch's if statement"); }
            finally
            {
                Console.WriteLine("Finally block executed");
            }
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