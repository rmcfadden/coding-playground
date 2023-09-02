// Magic Index is an index in
// A[1...n-1] 
// where A[i] = i
// A is sorted distinct integers
// Followup: A is not distinct integers
using System.Collections;
using System.Diagnostics;

/* Example set with Distinct integers
|  0  |  1  |  2  |  3  |  4  |  5  |  6  |  7  |  8  |  9  |
| -15 | -13 | -9  | -6  |  0  |  1  |  2  |  7  |  10 |  11 | 
*/

/* Example set with non Distinct integers
|  0  |  1  |  2  |  3  |  4  |  5  |  6  |  7  |  8  |  9  | 10 |
| -10 | -5  |  2  |  2  |  2  |  3  |  4  |  7  |  9  | 12  | 13 |
*/


int? MagicIndexNaive(IEnumerable<int> a)
{
  var count = a.Count();
  for(var i=0; i < count; i++){
    if(a.ElementAt(i) == i) return i;
  }
  return null;
}

// BST
// if mid is less than a[mid], then search left
// if mid is greater than a[mid], then search right
int? MagicIndexBinarySearch(IEnumerable<int> a)
{
  var count = a.Count();
  var l = 0;
  var mid  = count  / 2;
  var r = count -1;
  while(l <= mid && r >= mid)
  {
    if(mid == a.ElementAt(mid)) return mid;
    else if(mid < a.ElementAt(mid))
    {
      r = mid - 1;
      mid = (l + r) / 2;
    }
    else
    {
      l = mid + 1;
      mid = (l + r) / 2;
    }
  }
  return null;
}



Console.WriteLine("magicIndexNaive:" + MagicIndexNaive(new []{-10,-5,-2,3,10 }));
Console.WriteLine("magicIndexBinarySearch:" + MagicIndexBinarySearch(new []{-15,-13,-9,-6,0,1,2,7,10,11}));