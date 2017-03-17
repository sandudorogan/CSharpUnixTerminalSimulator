using System.Collections.Generic;

namespace Bash
{
    public class LocalDirectory : FsEntry
    {
        public List<FsEntry> Children;

        public LocalDirectory(string name) 
            : base(name)
        {
            Children = new List<FsEntry>();
        }

        public LocalDirectory(string name, LocalDirectory parentDirectory) 
            : base(name, parentDirectory)
        {
            Children = new List<FsEntry>();
        }

        public bool HasChild(FsEntry entry)
        {
            return Children.Contains(entry);
        }

        public bool HasChild(string entry)
        {
            foreach (var fsEntry in Children)
            {
                if (fsEntry.Name.Equals(entry))
                {
                    return true;
                }
            }

            return false;
        }

        public void AddChild(FsEntry child)
        {
            Children.Add(child);
        }

        public void RemoveChild(FsEntry child)
        {
            Children.Remove(child);
        }

        public FsEntry GetChild(string name)
        {
            foreach (var fsEntry in Children)
            {
                if (fsEntry.Name.Equals(name)) 
                {
                    return fsEntry;
                }
            }

            return null;
        }
    }
}