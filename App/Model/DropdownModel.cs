using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App.Model
{
  public class DropdownModel<T>
  {
    public T Value { get; set; }
    public string Text { get; set; }
  }
}