using System.Linq;
using LinqPractices;
using LinqPractices.DbOperations;


DataGenerator.Initialize();
LinqDbContext _context = new LinqDbContext();
var students = _context.Students.ToList<Student>();

//Find();

Console.WriteLine("***Find***");

var student = _context.Students.Where(s => s.StudentId ==1).FirstOrDefault();
student = _context.Students.Find(2) ;
Console.WriteLine(student.Name);


//FirstOrDefault();
Console.WriteLine();
Console.WriteLine("***FirstOrDefault***");
var student2 = _context.Students.Where(s => s.Surname == "Arda").FirstOrDefault();

Console.WriteLine(student2.Name);

student2 = _context.Students.FirstOrDefault(s => s.Surname == "Arda");

Console.WriteLine(student2.Name);

//SingleOrDefault();
Console.WriteLine();
Console.WriteLine("***SingleOrDefault***");

var student3 = _context.Students.SingleOrDefault(s => s.Name == "Deniz");
Console.WriteLine(student3.Surname);

//ToList();
Console.WriteLine();
Console.WriteLine("***ToList***");

var studentList = _context.Students.Where(s=> s.ClassId == 2).ToList();
Console.WriteLine(studentList.Count);// Eleman sayısını döner

//OrderBy();
Console.WriteLine();
Console.WriteLine("***OrderBy***");

students = _context.Students.OrderBy(s => s.StudentId).ToList();

foreach (var st in students)
{
    Console.WriteLine(st.StudentId + "-" + st.Name + "-" + st.Surname);
}

//OrderByDescanding();
Console.WriteLine();
Console.WriteLine("***OrderByDescanding**");

students = _context.Students.OrderByDescending(s => s.StudentId).ToList();

foreach (var st in students)
{
    Console.WriteLine(st.StudentId + "-" + st.Name + "-" + st.Surname);
}

//Anonymus Object Result 
Console.WriteLine();
Console.WriteLine("***Anonymus Object Result**");

var anonymousObject = _context.Students.Where(x => x.ClassId == 2).Select(x => new {
    Id = x.StudentId,
    Fullname = x.Name + " " + x.Surname
});
foreach (var obj in anonymousObject){
  Console.WriteLine(obj.Id + "-" + obj.Fullname );
}