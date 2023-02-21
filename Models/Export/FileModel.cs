using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookLibrary.Models
{
    public class FileModel
    {
        public string FileName { get; set; }
        public byte[] FileContent { get; set; }
    }
}
