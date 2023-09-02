using System.Linq;
using System.Collections;
using System.Diagnostics;

/*
Powerset of:
{a,b,c}
  {} ->
  {a}, {b}, {c}
  {a,b}, {b,c},{b,a},
  {a,b,c}
*/

IEnumerable<IEnumerable<int>> PowerSetIterative(IEnumerable<int> items)
{
  return null;
}
IEnumerable<IEnumerable<int>> PowerSetRecursive(IEnumerable<int> items)
{
  return null;
}
IEnumerable<IEnumerable<int>> PowerSetBinary(IEnumerable<int> items) 
{
  var powerSets = new List<List<int>>();
  var count = items.Count();
  var setCount = Math.Pow(2, count);
  for(var i=0; i < setCount; i++) {
    var b = i;
    var newSet = new List<int>();
    for(var j = 0; j < count; j++) {
      var d = b & (1 << j);
      if(d > 0) newSet.Add(items.ElementAt(j));      
    }
    powerSets.Add(newSet);
  }
  return powerSets;
}

string PrintSet(IEnumerable<IEnumerable<int>> items) => string.Join(",", items.Select(subs => $"[{string.Join(",",subs)}]"));

Console.WriteLine("Powers Binary: " + PrintSet(PowerSetBinary(new []{1,2,3})));