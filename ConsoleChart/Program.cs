using System;
using System.Collections.Generic;
using System.Linq;

Dictionary<string, int> data = new Dictionary<string, int>();

string[] cols = Console.ReadLine().Split('\t');
int groupCol = Array.IndexOf(cols, args[0]);
int valueCol = Array.IndexOf(cols, args[1]);
int numberOfLines = int.Parse(args[2]);

string line;
while ((line = Console.ReadLine()) != null) {
    cols = line.Split('\t');
    string group = cols[groupCol];
    int value = int.Parse(cols[valueCol]);
    
    if (data.Keys.Contains(group))
        data[group] += value;
    else
        data.Add(group, value);
}

data = data.OrderByDescending(v => v.Value).ToDictionary(v => v.Key, v => v.Value);

int maxValue = data.Values.Max();
const int maxGroupLenght = 40;

int i = 0;
foreach (var v in data) {
    if (i == Math.Min(data.Count, numberOfLines))
        break;
    
    Console.Write($" {v.Key, maxGroupLenght} | ");
    ConsoleColor original = Console.BackgroundColor;
    Console.BackgroundColor = ConsoleColor.DarkMagenta;
    Console.WriteLine(new string(' ', (int) Math.Ceiling(v.Value * 100.0 / maxValue)));
    Console.BackgroundColor = original;
    
    i++;
}
