﻿using System;
using System.Collections.Generic;

namespace ADO_TASK_5;

public partial class Author
{
    public int Id { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public virtual ICollection<Book> Books { get; set; } = new List<Book>();

    public override string ToString()
    {
        return $"{Id}\t{FirstName}\t{LastName}";
    }
}