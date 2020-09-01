using System;

namespace MovieLibrary
{
    class Program
    {
        static void Main ( string[] args )
        {
            FunWithTypes();
            

        }
        //Function defination- declaration + implemation
        //[modifiers] T id([parameter) {s*}
        //Function signature - [return-type] name, parameter types
        static void FunWithTypes ()
        {

            //Body

            //primitive - type implicitly known by the language

            //Intergral -Whole numbers
            //Signed
            //sbyte - 1byte -128 to 127
            //short - 2bytes + -32k
            //int  - 4bytes, + -2 billion - DEFAULT
            // long -8bytes, really big - large size
            //Unsigned
            //bytes -1byte 0 to 255
            //usshort - 2bytes 0 to 64k
            //uint - 4bytes, 0 to 4 billion
            //ulong -8bytes, 0 to really big
            //Literals
            //10,20,30  int
            //150L =long
            // 0xFFUL = ulong or 0xFFU = uint
            //decimal = 0-9, hex = 0-9A-F, binary = 0-1 (0b101010)
            //32 _766, 3__2_7_6_6, 0b1011_1010

            // variable declaration -T id [ =E ];
            int hours = 10;
            int code = 0xFF;
            int ration = hours*40;

            //Floating point types - real numbers IEEE
            // float - 4 bytes, +-E38, 7 to 9 precision 123.456789
            // double -8 bytes, +-E308, 15 to 17 precision -DEFAULT
            //decimal -16 bytes, precision  currency
            //Literals
            // 123.45F;  float
            // 123.54M   decimal
            double payRate = 123.456789;
            payRate = 123E12;
            decimal price = 456.746M;


            //boolean
            //bool -1bytes, true or false(0)
            bool isPassing = true;
            //bool success = 1; //Error
            //int isPassing =1; //BAD

            //Textural
            // char -2 bytes, '\0 to '\uFFF'
            //string -0
            char letterA = 'A';
            char digit0 = '1'; // not equal to 1
            char hex = '\x0A'; // CR

            string name = "Bob";
            string empty = "";


        }  

    }
   
}



