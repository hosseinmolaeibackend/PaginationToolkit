# PaginationToolkit

**PaginationToolkit** is a lightweight library for implementing pagination in **.NET** projects.  
It is designed to work seamlessly with both **Entity Framework Core** and **APIs**, making pagination simple and reusable.

---

## ✨ Features
- Full support for **Entity Framework Core**
- Both **Sync** and **Async** methods
- API-friendly responses with **metadata**
- Handy LINQ extensions (`Paginate` and `ToPaginatedListAsync`)
- Minimal, lightweight, and dependency-free

---

## 📦 Installation
### From source
```bash
git clone https://github.com/hosseinmolaeibackend/PaginationToolkit.git
cd PaginationToolkit
dotnet build
```
## 🚀 Usage
### Using in APIs (with metadata):
```
using PaginationToolkit;

[HttpGet]
public async Task<IActionResult> GetStudents(int pageNumber = 1, int pageSize = 10)
{
    var query = _context.Students.AsQueryable();

    var count = await query.CountAsync();
    var items = await query.Paginate(pageNumber, pageSize).ToListAsync();

    var result = new PaginationResult<Student>(items, count, pageNumber, pageSize);

    return Ok(result);
}
```
### Sample JSON Response:
```
{
  "data": [
    { "id": 1, "name": "Ali" },
    { "id": 2, "name": "Sara" }
  ],
  "metadata": {
    "totalCount": 50,
    "pageSize": 10,
    "currentPage": 1,
    "totalPages": 5
  }
}
```
### Using the Paginate Extension:
```
using PaginationToolkit;

var pagedData = await context.Products
    .Where(p => p.InStock)
    .OrderBy(p => p.Price)
    .Paginate(pageNumber: 3, pageSize: 20)
    .ToListAsync();
```
### Using with EF Core:
```
using PaginationToolkit;

var pageNumber = 2;
var pageSize = 10;

var students = await context.Students
    .OrderBy(s => s.Name)
    .ToPaginatedListAsync(pageNumber, pageSize);

Console.WriteLine($"Page {students.PageIndex} of {students.TotalPages}");
foreach (var student in students)
{
    Console.WriteLine(student.Name);
}
```
