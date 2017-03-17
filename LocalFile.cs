using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bash
{
    internal class LocalFile : FsEntry
    {
        public string Content { get; set; }

        public LocalFile(string name) : base(name)
        {
        }

        public LocalFile(string name, LocalDirectory parentDirectory) : base(name, parentDirectory)
        {
        }
    }
}