# Dictionary

C# Dictionary class is a generic collection of keys and values pair of data.

Defined in the System.Collections.Generic namespace is a generic class and can store any data types in a form of keys and values. Each key must be unique in the collection.

```C#
using System.Collections.Generic;
```

## 1 Add elements to a C# Dictionary

```C#
Dictionary<string,string> EmployeeList=new Dictionary<string,stirng>();
//Add items to the dictionary both keys and values are string types
EmployeeList.Add("Mahesh Chand", "Programmer");    
EmployeeList.Add("Praveen Kumar", "Project Manager");    
EmployeeList.Add("Raj Kumar", "Architect");    
EmployeeList.Add("Nipun Tomar", "Asst. Project Manager");    
EmployeeList.Add("Dinesh Beniwal", "Manager");  


Dictionary<string,Int16> AuthorList=new Dictionary<string,Int16>();
//Add items to the dictionary where the key type is string and value type is short integer
AuthorList.Add("Mahesh Chand", 35);    
AuthorList.Add("Mike Gold", 25);    
AuthorList.Add("Praveen Kumar", 29);    
AuthorList.Add("Raj Beniwal", 21);    
AuthorList.Add("Dinesh Beniwal", 84); 

//We can also limit the size of a dictionary.The following code shows the limit is 3.
Dictionary<string, float> PriceList = new Dictionary<string, float>(3);
```

## 2  Retrieve elements from a C# Dictionary

```C#
foreach(KeyValuePair<string,Int16> author in AuthorList)
{
    Console.WriteLine("Key:{0}, Value{1}",author.Key,author.Value);
}
```

## 3 C# Dictionary Properties

Count, Keys and Values.

## 4 Get number of elements in a C# Dictionary

The Count property gets the number of key/value pairs in a Dictionary.

```C#
Console.WriteLine("Count: {0}", AuthorList.Count);
```

## 5 Get a Dictionary item 

The Item property gets and sets the value associated with the specified key.

```C#
// Set Item value    
AuthorList["Mahesh Chand"] = 20;    
// Get Item value    
Int16 age = Convert.ToInt16(AuthorList["Mahesh Chand"]); 
```

## 6 Get the collection of keys of C# Dictionary

```C#
// Get and display keys    
Dictionary<string, Int16>.KeyCollection keys = AuthorList.Keys;    
foreach (string key in keys)    
{    
    Console.WriteLine("Key: {0}", key);    
}
```

## 7 Get the collection of values of a C# Dictionary

```C#
// Get and display values    
Dictionary<string, Int16>.ValueCollection values = AuthorList.Values;    
foreach (Int16 val in values)    
{    
    Console.WriteLine("Value: {0}", val);
}
```

## 8 C# Dictionary Methods

The Dictionary class is a generic collection and provides all common methods to **add, remove, find and replace items** in the collection. 

## 9 Add Items

```C#
Dictionary<string, Int16> AuthorList = new Dictionary<string, Int16>();    
AuthorList.Add("Mahesh Chand", 35);
```

## 10 Remove elements from a C# dictionary

```C#
// Remove item with key = 'Mahesh Chand'    
AuthorList.Remove("Mahesh Chand");
// Remove all items    
AuthorList.Clear();
```

## 11 Find a key in a Dictionary

The ContainsKey method checks if a key is already exists in the dictionary. 

```C#
if (!AuthorList.ContainsKey("Mahesh Chand"))    
{    
    AuthorList["Mahesh Chand"] = 20;    
}
```

## 12 Find a Value in a Dictionary

The ContainsValue method checks if a value is already exists in the dictionary. 

```C#
if (!AuthorList.ContainsValue(9))    
{    
    Console.WriteLine("Item found");    
}
```

# Queue

 Queue represents a first-in, first-out (FIFO) collection of objects.

## 1 Queue Constructors

```C#
//Queue<T> Constructor
Queue<string> queue = newQueue<string>();

//Queue<T> Constructor (IEnumerable<T>)
string[] courses = { "MCA","MBA", "BCA","BBA", "BTech","MTech" };  
Queue<string> queue = newQueue<string>(courses); 

//Queue<T> Constructor (Int32) 
Queue<string> queue = newQueue<string>(4); 
```

## 2 Queue.Count Property

The Count property gets the number of elements of Queue\<T>.

```C#
namespace Queue {  
    classProgram {  
        staticvoid Main(string[] args) {  
            string[] courses = {  
                "MCA",  
                "MBA",  
                "BCA",  
                "BBA",  
                "BTech",  
                "MTech"  
            };  
            Queue < string > queue1 = newQueue < string > ();  
            Queue < string > queue2 = newQueue < string > (courses);  
            Queue < string > queue3 = newQueue < string > (4);  
            Console.WriteLine("Number of elements in queue1:" + queue1.Count());  
            Console.WriteLine("Number of elements in queue2:" + queue2.Count());  
            Console.WriteLine("Number of elements in queue3:" + queue3.Count());  
        }
    }
}

//output: 0 6 0
```

## 3 Queue.Enqueue()

The Queue.Enqueue method adds an object to the end of the Queue<T>.

```C#
namespace Queue {  
    classProgram {  
        staticvoid Main(string[] args) {  
            Queue < string > queue1 = newQueue < string > ();  
            queue1.Enqueue("MCA");  
            queue1.Enqueue("MBA");  
            queue1.Enqueue("BCA");  
            queue1.Enqueue("BBA");  
            Console.WriteLine("The elements in the queue are:");  
            foreach(string s in queue1) {  
                Console.WriteLine(s);  
            }  
        }  
    }  
} 
```

## 4 Queue.Dequeue()

Removes and returns the object at the beginning of the Queue<T>.

```C#
namespace Queue {  
    classProgram {  
        staticvoid Main(string[] args) {  
            Queue < string > queue1 = newQueue < string > ();  
            queue1.Enqueue("MCA");  
            queue1.Enqueue("MBA");  
            queue1.Enqueue("BCA");  
            queue1.Enqueue("BBA");  
            Console.WriteLine("The elements in the queue are:");  
            foreach(string s in queue1) {  
                Console.WriteLine(s);  
            }  
            queue1.Dequeue(); //Removes the first element that enter in the queue here the first element is MCA  
            queue1.Dequeue(); //Removes MBA  
            Console.WriteLine("After removal the elements in the queue are:");  
            foreach(string s in queue1) {  
                Console.WriteLine(s);  
            }  
        }  
    }  
}  
```

## 5 Queue.contain()

Determines whether an element is in the Queue<T>.

```C#
namespace Queue {  
    classProgram {  
        staticvoid Main(string[] args) {  
            Queue < string > queue1 = newQueue < string > ();  
            queue1.Enqueue("MCA");  
            queue1.Enqueue("MBA");  
            queue1.Enqueue("BCA");  
            queue1.Enqueue("BBA");  
            Console.WriteLine("The elements in the queue are:");  
            foreach(string s in queue1) {  
                Console.WriteLine(s);  
            }  
            Console.WriteLine("The element MCA is contain in the queue:" + queue1.Contains("MCA"));  
            Console.WriteLine("The element BCA is contain in the queue:" + queue1.Contains("BCA"));  
            Console.WriteLine("The element MTech is contain in the queue:" + queue1.Contains("MTech"));  
        }  
    }  
} 
```

## 6 Queue.Clear()

Removes all objects from the Queue<T>.

## 7 Queue.Peek()

Returns the object at the beginning of the Queue<T> without removing it.

## 8 Queue.ToArray()

Copies the Queue<T> elements to a new array.

```C#
namespace Queue {  
    classProgram {  
        static void Main(string[] args) {  
            Queue < string > queue1 = newQueue < string > ();  
            queue1.Enqueue("MCA");  
            queue1.Enqueue("MBA");  
            queue1.Enqueue("BCA");  
            queue1.Enqueue("BBA");  
            Console.WriteLine("The queue elements are:");  
            foreach(string s in queue1) {  
                Console.WriteLine(s);  
            }  
            Queue < string > queue2 = newQueue < string > (queue1.ToArray());  
            Console.WriteLine("\nContents of the copy");  
            foreach(string n in queue2) {  
                Console.WriteLine(n);  
            }  
        }  
    }  
} 
```

# Stack

A stack is a LIFO (last in first out) data structure.

## 1 Stack Constructors

Stack<T>() Constructor

Stack<T>(IEnumerable<T>)

Stack<T>(Int32)

## 2 Stack.Count Property

he Count property of the Stack class returns the number of elements in a stack. 

## 3 Stack.Push()

The Push() method is used to add a (push) element to the stack.

## 4 Stack.Pop()

The Pop() method is used to remove elements from a stack. The Pop() method removes the top most item from the stack.

## 5 Stack.Peek()

The Peek() method returns the topmost element of a Stack<T> without removing it. 

## 6 Stack.Clear()

The Clear() method of Stack<T> removes all elements from a stack. 

# List

The C# List<T> class in .NET represents a collection of strongly typed objects that can be accessed by index. 

```C#
using System.Collections.Generic; 
```

## 1 List Constructors

```C#
// List with default capacity  
List<Int16> list = new List<Int16>();  
// List with capacity = 5  
List<string> authors = new List<string>(5);  
string[] animals = { "Cow", "Camel", "Elephant" };  
List<string> animalsList = new List<string>(animals);  
```

## 2 List.Add()

The Add method adds an element to a List.

## 3 List Properties

- Capacity – Number of elements List<T> can contain. The default capacity of a List<T> is 0.
- Count – Number of elements in List<T>.

## 4 List.Insert()

The Insert method of List class inserts an object at a given position. The first parameter of the method is the 0th based index in the List.

The InsertRange method can insert a collection at the given position. 

```C#
authors.Insert(3, "Bill Author");  
// Collection of new authors  
string[] newAuthors = { "New Author1", "New Author2", "New Author3" };  
// Insert array at position 2  
authors.InsertRange(2, newAuthors);  
```

## 5 List.Remove()

```C#
//he Remove method removes the first occurrence of the given item in the List.
// Remove an item  
authors.Remove("New Author1");



// Remove 3rd item  
authors.RemoveAt(3);


//The RemoveRange method removes a list of items from the starting index to the number of items. 
// Remove a range  
authors.RemoveRange(3, 2);  

// Remove all items  
authors.Clear(); 
```

## 6 List.IndexOf()

The IndexOf method finds an item in a List. The IndexOf method returns -1 if there are no items found in the List. 

```C#
int idx = authors.IndexOf("Naveen Sharma");  
if (idx > 0)  
Console.WriteLine($"Item index in List is: {idx}");  
else  
Console.WriteLine("Item not found");  
```

## 7 List.Sort()

The Sort method of List<T> sorts all items of the List using the QuickSort algorithm. 

## 8 List.Reverse()

The Reverse method of List<T> reverses the order all items in in the List. 

## 9 List.BinarySearch()

The BinarySearch method of List<T> searches a sorted list and returns the zero-based index of the found item. The List<T> must be sorted before this method can be used. 

```C#
int bs = authors.BinarySearch("Mahesh Chand");  
```

