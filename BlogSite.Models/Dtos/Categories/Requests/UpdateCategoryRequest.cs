﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogSite.Models.Dtos.Categories.Requests;

public sealed record UpdateCategoryRequest(int Id, string Name);
