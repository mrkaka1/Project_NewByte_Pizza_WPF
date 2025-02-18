﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project_pizzaria_newbyte.Interface
{
    interface IDAO<T>
    {
        public bool Create(T value);
        public List<T> Read();
        public T ReadById(int id);

        public void Update(T value);
        public void Delete(T value);
    }
}
