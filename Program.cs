// See https://aka.ms/new-console-template for more information
using Route256.Easy;
using System.Runtime.CompilerServices;
using System.Text;

string text = "hEllo, wOrld!";
Console.WriteLine(text);
Console.WriteLine(TaskA(text));
Console.WriteLine(TaskB(text));
Console.WriteLine(TaskD(new[] { 2000, 1000, 1000, 5000, 2000, 2000, 1000 }));
Console.WriteLine(GetNumber("MMMDCXXV") + " = 3625");

Console.WriteLine(OrderSum.Calculate(new[] { 5, 1, 2, 3, 4, 5, 6, 6 ,6}));


static string TaskA(string text)
{
    if (!string.IsNullOrWhiteSpace(text))
    {
        bool isUpperCase = true;
        
        var array = text.ToCharArray();
        
        for (int i = 0; i < array.Length; i++)
        {
            if (char.IsWhiteSpace(array[i]))
            {
                isUpperCase = true;
            }
            else if (char.IsLetter(array[i]))
            {
                array[i] = isUpperCase
                    ? char.ToUpper(array[i])
                    : char.ToLower(array[i]);

                isUpperCase = false;
            }
        }

        text = string.Join("", array);
    }

    return text;
}

static string TaskB(string text)
{
    var result = new StringBuilder();
    if (!string.IsNullOrWhiteSpace(text))
    {
        var map = new Dictionary<char, int>();

        for(int i = 0; i < text.Length; i++)
        {
            char key = text[i];
            if (!map.ContainsKey(key))
            {
                map.Add(key, 0);
            }

            map[key]++;
            result.Append(map[key]);
        }
    }
    return result.ToString();
}

static int TaskC(string ip1, string ip2)
{
    int result = 0;

    // ip1 = 0.0.0.0
    // ip2 = 1.1.1.1

    int[] from = ConvertToIntArray(ip1);
    int[] to = ConvertToIntArray(ip2);

    if (to[0] > from[0])
    {
        result += (to[0] - from[0]) * to[1] * to[2] * to[3];
    }

    return result;
}

static int[] ConvertToIntArray(string ip)
{
    return ip
        .Split(".", StringSplitOptions.RemoveEmptyEntries)
        .Select(x => int.TryParse(x, out int value) ? value : throw new ArgumentException())
        .ToArray();
}

static bool TaskD(int[] cash)
{
    int _1000 = 0;
    int _2000 = 0;

    for(int i = 0; i < cash.Length; i++)
    {
        if (cash[i] == 1000)
        {
            _1000++;
        }
        else if(cash[i] == 2000) 
        { 
            if (_1000 <= 0)
                return false;

            _2000++;
            _1000--;
        }
        else if (cash[i] == 5000) 
        {
            if ((2000 * _2000 + 1000 * _1000) < 4000)
                return false;

            if (_2000 >= 2)
            {
                _2000 -= 2;
            }
            else if (_2000 >= 1 && _1000 >= 2)
            {
                _2000--;
                _1000 -= 2;
            }
            else if (_1000 >= 4)
            {
                _1000 -= 4;
            }
        }
    }

    return true;
}

static int TaskE(string num, string num2)
{
    if (string.Equals(num, num2, StringComparison.OrdinalIgnoreCase))
        return 0;

    var intNum1 = GetNumber(num);
    var intNum2 = GetNumber(num2);

    return intNum1 > intNum2 ? 1 : -1;
}

static int GetNumber(string romeNumber)
{
    var romeThousand = new KeyValuePair<int, char>(1000, 'M');

    var romeSystemMapping = new Dictionary<int, string>
    {
        { 900 ,"CM"     },
        { 800 ,"DCCC"   },
        { 700 ,"DCC"    },
        { 600 ,"DC"     },
        { 500 ,"D"      },
        { 400 ,"CD"     },
        { 300 ,"CCC"    },
        { 200 ,"CC"     },
        { 100 ,"C"      },
              
        { 90  ,"XC"     },
        { 80  ,"LXXX"   },
        { 70  ,"LXX"    },
        { 60  ,"LX"     },
        { 50  ,"L"      },
        { 40  ,"XL"     },
        { 30  ,"XXX"    },
        { 20  ,"XX"     },
        { 10  ,"X"      },
              
        { 9   ,"IX"     },
        { 8   ,"VIII"   },
        { 7   ,"VII"    },
        { 6   ,"VI"     },
        { 5   ,"V"      },
        { 4   ,"IV"     },
        { 3   ,"III"    },
        { 2   ,"II"     },
        { 1   ,"I"      },
    };

    int thousandCount = romeNumber.TakeWhile(x => x == romeThousand.Value).Count();
    var result = thousandCount * romeThousand.Key;

    var number = romeNumber.Substring(thousandCount);
    for(int i = 1; i < romeSystemMapping.Count; i++)
    {
        var pair = romeSystemMapping.ElementAt(i);
        
        if (number.StartsWith(pair.Value))
        {
            result += pair.Key;
            number = number.Substring(pair.Value.Length);
        }
    }

    return result;
}

