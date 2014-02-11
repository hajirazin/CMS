using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ramesoft.Cms.Common.Models.Contract
{
    public interface ISelectable
    {
        string Text { get; }
        
        string Value { get; }
    }
}
