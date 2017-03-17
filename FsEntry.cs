using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bash
{
    public abstract class FsEntry
    {
        private LocalDirectory _parentDirectory;
        private string _name;

        protected FsEntry(string name)
        {
            Name = name;
        }

        protected FsEntry(string name, LocalDirectory parentDirectory) : this(name)
        {
            if (parentDirectory != null) _parentDirectory = parentDirectory;
        }

        public string Name
        {
            get
            {
                return _name;
            }

            set
            {
                if (value != null) _name = value;
            }
        }

        public LocalDirectory Parent
        {
            get
            {
                return _parentDirectory;
            }

            set
            {
                if (value != null) _parentDirectory = value;
            }
        }

        protected bool Equals(FsEntry other)
        {
            return Equals(_parentDirectory, other._parentDirectory) 
                && string.Equals(_name, other._name);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((FsEntry) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return ((_parentDirectory != null ? _parentDirectory.GetHashCode() : 0) * 397) 
                    ^ (_name != null ? _name.GetHashCode() : 0);
            }
        }
    }
}