using System;
using System.Collections.Generic;

namespace _3_2_字典
{
    class Program
    {
        static void PrintDict(Dictionary<string, int> dict)
        {
            // for (int i = 0; i < 10; i++)    // 字典没有下标，不能用for循环
            //foreach (KeyValuePair<string,int> pair in dict)
            //{
            //    Console.WriteLine(pair.Key + " " + pair.Value);
            //}

            // 变量类型可以用var代替，省略写法
            foreach(var pair in dict)
            {
                Console.WriteLine(pair.Key + " " + pair.Value);
            }
        }
        static void TestForeach()
        {
            int[] array = new int[] { 3, 4, 5, 6 };

            foreach (int n in array)    // 注意n不是下标，而是元素的值
            {
                Console.WriteLine(n);    // 打印： 3 4 5 6 
            }

            List<string> list = new List<string> { "a","bbb","ccd"};
            foreach (string s in list)
            {
                Console.WriteLine(s);
            }
        }
        static void TestRemove(Dictionary<string,int> dict)
        {
            Console.WriteLine("测试删除");
            // 在遍历字典时，删除Key或者修改字典，都可能导致异常（新版本的C#没有此问题）
            foreach(var pair in dict)
            {
                if(pair.Value <= 80)
                { dict.Remove(pair.Key); }
            }
            PrintDict(dict);
            Console.WriteLine("删除完了");

            // 传统的正确做法
            List<string> list = new List<string>();
            foreach(var pair in dict)
            {
                if(pair.Value <= 80)
                {
                    list.Add(pair.Key);
                }
            }
            foreach(string name in list)
            {
                dict.Remove(name); 
            }
        }
        static void Main(string[] args)
        {
            // var可以用于变量定义，只要编译器可以推断出实际类型
            var n = 3;
            var f = 3.0f;
            var d = 3.0;
            var b = false;
            var list = new List<int>();
            List<int> list2 = new List<int>();

            Dictionary<string, int> dict = new Dictionary<string, int>();

            // 添加元素   Key键 : Value值
            dict.Add("小明", 80);
            dict.Add("小红", 90);
            dict.Add("小军", 85);
            dict.Add("小王", 75);
            dict.Add("小刘", 80);

            // 通过索引 Key(键)快速查找
            Console.WriteLine(dict["小红"]);

            // Console.WriteLine(dict["小花"]);    // 不存在小花，导致报异常，KeyNotFound
    
            if(dict.ContainsKey("小花"))
            { Console.WriteLine(dict["小花"]); }
            else
            { Console.WriteLine("小花不存在"); }


            // 通过Key,修改值
            dict["小红"] = 95;     // 修改小红的分数
            // ★ set
            dict["小花"] = 88;     // 小花不存在，添加小花=88

            // 删除Key，Key和Value一起删除
            dict.Remove("小明");

            // 遍历字典,打印内容
            PrintDict(dict);

            TestRemove(dict);

            Console.ReadKey();
        }
    }
}
