using System;
using System.Collections.Generic;
using System.Globalization;
using System.Reflection.PortableExecutable;

class Programm
{
    static void Main()
    {
        Console.WriteLine("---1: ShowName---");
        ShowName("Abu");
        ShowName("b");
        ShowName("");
        ShowName("   ");

        Console.WriteLine();
        Console.WriteLine("---2: ShowGrades---");
        ShowGrades(new int[] {80, 90, 100});
        ShowGrades(new int[] {80, 81});
        ShowGrades(new int[] {});

        Console.WriteLine();
        Console.WriteLine("---3: ShowSpecialGrades---");
        int[] grades = { 80, 90, 100};
        SpecialSelectedGrades( grades, 1);
        SpecialSelectedGrades( grades, 3);
        SpecialSelectedGrades( grades, 0);
        SpecialSelectedGrades( grades, -1);
        SpecialSelectedGrades( grades, 4);
        SpecialSelectedGrades(new int[] { }, 1);

        Console.WriteLine();
        Console.WriteLine("---4: Adding students and changing---");
        StudentsDemo();

        Console.WriteLine();
        Console.WriteLine("---5: Find suitable students---");
        FindStudent(new List<string> { "Ali", "Vali", "Malika"});
        FindStudent(new List<string> { "Ali", "Vali"});
        FindStudent(new List<string>());

        Console.WriteLine();
        Console.WriteLine("---6: Safely removing students from list---");
        RemoveDemo(new List<string> { "Ali", "Vali", "Malika"}, 2);
        RemoveDemo(new List<string> { "Ali", "Vali", "Malika"}, 0);
        RemoveDemo(new List<string> { "Ali", "Vali", "Malika"}, 4);
        RemoveDemo(new List<string> { "Ali"}, 1);
        RemoveDemo(new List<string>(),1);

        Console.WriteLine();
        Console.WriteLine("---7: Dictionary---");
        DictionaryDemo();


        Console.WriteLine("---8: Unusual emails---");

        // 1
        HashSet<string> emails = new HashSet<string>();
        AddEmail(emails, "  ALI@example.com  ");
        AddEmail(emails, "ali@example.com");
        AddEmail(emails, "vali@example.com");
        Console.WriteLine("Count " + emails.Count);

        // 2(bo'sh natija)
        HashSet<string> emptyEmails = new HashSet<string>();
        AddEmail(emptyEmails, "");
        AddEmail(emptyEmails, "   ");
        Console.WriteLine("Count " + emptyEmails.Count);

        //1-narsani qaytarish, keyin Contains va Remove
        HashSet<string> newEmails = new HashSet<string>();
        AddEmail(newEmails, "  ALI@example.com  ");
        AddEmail(newEmails, "ali@example.com");
        AddEmail(newEmails, "vali@example.com");

        Console.WriteLine(newEmails.Contains("ali@example.com")); // True
        Console.WriteLine(newEmails.Remove("ali@example.com"));  // True
        Console.WriteLine(newEmails.Contains("ali@example.com")); // False

                
    }

    // _______Task 1______
    static void ShowName(string FriendName)
    {
      string name = (FriendName?? ""). Trim();
      if (name.Length == 0)
        {
            Console.WriteLine(" No name ");
            return;
        }
      Console.WriteLine($"Name: {name}; Length: {name.Length}; First: {name[0]}");
        
    }

// _______Task 2______
    static void ShowGrades(int[] grades)
    {
    if (grades.Length == 0)
    {
        Console.WriteLine("Overall 0 ; No grades ");
        return;
    }
// for bn raqamlash 
    for (int i = 0; i < grades.Length; i++)
    {
        Console.WriteLine($"Grade {i + 1}: {grades[i]}");
    }
// foreach bn obshiy 
    int sum = 0;
    foreach (int grade in grades)
    {
        sum += grade;
    }
// double sifatida o'rtacha (butun bo'lish emas)
    double average = (double)sum / grades.Length;

// InvariantCulture: har doim nuqta 324.34)
    Console.WriteLine($"Jami {sum}; o'rtacha {average.ToString(CultureInfo.InvariantCulture)}");
    }

// _______Task 3______
    static void SpecialSelectedGrades(int[] grades, int gradeNumber)
    {
// Tekshirvolamiza >>>
        if (gradeNumber < 1 || gradeNumber > grades.Length)
        {
        Console.WriteLine(" Wrong grade number");
        return;
        }
// indeksga chiqarvolamiza >>>>
        int index = gradeNumber - 1;
        Console.WriteLine( grades[index]);
    }
    
//______Task 4______
    static void StudentsDemo()
    {
        List<string> students = new List<string>{" Abu", "Ali"};
        students.Add("ibn Abdulloh"); // Abu Ali ibn abdulloh
        students.AddRange(new[] {"ibn Sino al-Balxiy"}); // Abu Ali ibn abdulloh ibn Sino al-Balxiy
        students[1] = " Ali al-Husayni " ; // Abu Ali al-Husayni ibn abdulloh
        Console.WriteLine($"Count: {students.Count}");
        Console.WriteLine($" Capacity >=  Count: {students.Capacity >= students.Count}");
        Console.WriteLine( string.Join(", ", students));
    }
// _____Task 5______
    static bool StartsWithMa(string name)
    {
        return name.StartsWith("Ma");
    }
         private static void FindStudent(List<string> list)
    {
        string found = list.Find(StartsWithMa);
        if (found == null)
        {
            Console.WriteLine("No suitable student found");
        }
        else
        {
            Console.WriteLine($"Found: {found}");
        }
    }

// _____Task 6______
    static bool TryRemoveStudent(List<string> students, int studentNumber)
        {
            if (studentNumber < 1 || studentNumber > students.Count)
            {
                return false;
            }
            students.RemoveAt(studentNumber - 1);
            return true;
        }
    static void RemoveDemo(List<string> students, int studentNumber)
        {
            bool removed = TryRemoveStudent(students, studentNumber);
            string result = removed ? "True" : "False; Wrong student number";
            string names = students.Count > 0 ? "; " + string.Join(", ", students) : "";
            Console.WriteLine($"{result}; Count {students.Count}{names}");
        }

//_____Task 7______
// Dictionary int string ishlatamiza

    static void DictionaryDemo()
    {
       Dictionary<int, string> students = new Dictionary<int, string>
       {
        [101] = "Abu",
        [102] = "Vali"
     };
        FindStudent(students, 101);
        FindStudent(students, 999);

        students[101] = "Abusher";
        Console.WriteLine($"101: {students[101]}; Count: {students.Count}");
        bool removed = students.Remove(102);

        Console.WriteLine($"{removed}; Count: {students.Count}");
        removed = students.Remove(999);
        
        Console.WriteLine($"{removed}; Count {students.Count}");

        static void FindStudent(Dictionary<int, string> students, int id)
    {
        if (students.TryGetValue(id, out string name))
        {
            Console.WriteLine(name);
        }
        else
        {
            Console.WriteLine("Talaba topilmadi.");
        }

    }
    }

//____Task 8___

         static void AddEmail(HashSet<string> emails, string email)
    {
        string clean = email.Trim().ToLowerInvariant();

        if (clean == "")
        {
            Console.WriteLine("Email bo'sh.");
            return;
        }

        Console.WriteLine(emails.Add(clean));
    }
}
