﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contatos
{
    public interface IFileHelper
    {
        string GetLocalFilePath(string fileName);
    }
}
