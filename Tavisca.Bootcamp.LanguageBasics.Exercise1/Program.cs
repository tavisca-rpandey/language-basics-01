using System;

namespace Tavisca.Bootcamp.LanguageBasics.Exercise1
{
    class Program
    {
        static void Main(string[] args)
        {
            Test("42*47=1?74", 9);
            Test("4?*47=1974", 2);
            Test("42*?7=1974", 4);
            Test("42*?47=1974", -1);
            Test("2*12?=247", -1);
            Console.ReadKey(true);
        }

        private static void Test(string args, int expected)
        { 
            var ans= FindDigit(args);
            var result = ans.Equals(expected) ? "PASS" : "FAIL";
            Console.WriteLine($"{args} : {result}");
        }

        public static int FindDigit(string equation)
        {
            string[] hlfs= new string[2];
            string[] nums = new string[3];
            string q="";
            int ans =0, flag=0;
            string sans ="";

            hlfs = equation.Split("=");         //breaking the equation into lhs and rhs
            nums[0] = hlfs[0].Split('*')[0];    // breaking the LHS into 2 nums, and Rhs into third number
            nums[1] = hlfs[0].Split('*')[1];
            nums[2] = hlfs[1];
            
            // Checking which part has the "?" mark

            if(nums[0].IndexOf('?')!=-1)        
            {
                if(Convert.ToInt32(nums[2])%Convert.ToInt32(nums[1])==0)
                {
                    ans = Convert.ToInt32(nums[2])/Convert.ToInt32(nums[1]);
                    q=nums[0];
                }
                else
                    flag=1;
            }
            
            else if(nums[1].IndexOf('?')!=-1)
            {

                if(Convert.ToInt32(nums[2])%Convert.ToInt32(nums[0])==0)
                {
                    ans = Convert.ToInt32(nums[2])/Convert.ToInt32(nums[0]);
                    q=nums[1];
                }
                else
                    flag=1;
            }
            
            else if(nums[2].IndexOf('?')!=-1)
            {
                 ans = Convert.ToInt32(nums[0]) * Convert.ToInt32(nums[1]);
                 q= nums[2];
            }


// The comparision part to find if the ? can be replaced
            if(flag==0)
            {
                sans = ans.ToString();
                if(sans.Length==q.Length)
                {
                    for(int i=0; i<sans.Length;i++)
                    {
                        if(q[i]!='?')
                        {
                            if(q[i]!=sans[i])
                            {
                                flag=1;
                            }
                        }
                    }
                } 
                else
                    flag=1;
            }
            if (flag==1)
                return(-1);

            else
            {
                int fan = sans[q.IndexOf('?')]-'0';
                return(fan);
            }
                 
        }
    }
}