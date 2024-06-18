﻿using System.ComponentModel.DataAnnotations.Schema;

namespace languageInstitute.Domain.ValueObjects;

[NotMapped]
public class QueryCriteria
{
    public List<Filter> Filters { get; set; }
    public List<Sort> Sorts { get; set; }
    public int Skip { get; set; }
    public int Take { get; set; }
}

