using BookLibrary.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Threading.Tasks;

namespace BookLibrary.Extensions
{
    public static class ZipArchiveExtensions
    {
        public static Stream Compress(this IEnumerable<FileModel> files)
        {
            if (files.Any())
            {
                var ms = new MemoryStream();
                using (var archive = new ZipArchive(
                    stream: ms,
                    mode: ZipArchiveMode.Create,
                    leaveOpen: true
                ))
                {
                    foreach (var file in files)
                    {
                        var entry = archive.Add(file);
                    }
                }
                ms.Position = 0;
                return ms;
            }
            return null;
        }

        private static ZipArchiveEntry Add(this ZipArchive archive, FileModel file)
        {
            var entry = archive.CreateEntry(file.FileName, CompressionLevel.Fastest);
            using (var stream = entry.Open())
            {
                stream.Write(file.FileContent, 0, file.FileContent.Length);
            }
            return entry;
        }
    }
}
