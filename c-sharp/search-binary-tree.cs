using System.Diagnostics;
using System.Linq;
using System.Collections.Generic;

public record TreeNode
{
  public int Value {get; init;}
  public TreeNode Left {get; init;}
  public TreeNode Right {get; init;}
}

TreeNode SearchBinaryTreeDepthFirstRecursive(TreeNode node, int value)
{
  if(node == null) return null;
  if(node.Value ==value) return node; 
  return value < node.Value ? SearchBinaryTreeDepthFirstRecursive(node.Left, value)
    : SearchBinaryTreeDepthFirstRecursive(node.Right, value);
}

TreeNode SearchBinaryTreeDepthFirstIterative(TreeNode node, int value)
{  
  var current = node;
  while(current != null)
  {
      if(current.Value == value) return node;
      else if(value < current.Value) current = current.Left;
      else if(value > current.Value) current = current.Right;
  }
  return null;
}

TreeNode BuildBinaryTreeFromSorted(IEnumerable<int> values)
{
  var count = values.Count();
  if(count == 0) return null;
  if(count == 1) return new TreeNode() { Value = values.ElementAt(0) };
  var mid = count / 2;
  return new TreeNode()
  {
    Value = values.ElementAt(mid), 
    Left = BuildBinaryTreeFromSorted(values.Take(mid)), 
    Right = BuildBinaryTreeFromSorted(values.Skip(mid + 1).Take(count - mid + 1)), 
  };  
}

var tree1 = BuildBinaryTreeFromSorted(new []{1,2,3,4,6,7,8,51,59});
var foundNodeDFS = SearchBinaryTreeDepthFirstRecursive(tree1, 51);
var foundNodeIterative = SearchBinaryTreeDepthFirstIterative(tree1, 6);

Console.WriteLine($"foundNodeDFS: {foundNodeDFS?.ToString()}");
Console.WriteLine($"foundNodeIterative: {foundNodeIterative?.ToString()}");

Console.WriteLine("");
Console.WriteLine(tree1.ToString());