using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Models.File
{
    public class FileModel
    {
        public int Id { get; set; }

        public string FileName { get; set; }

        public byte[] FileData { get; set; }
    }
}
