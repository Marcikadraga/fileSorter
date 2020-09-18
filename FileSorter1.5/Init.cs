using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace FileSorter
{
    public class Init
    {
        public string DestDirPath { get; set; }
        public string StartDiryPath { get; set; }
        public string[] Files { get; set; }
        public Init()
        {
            //     C:\\Users\\Balogh Márton\\Desktop\\folder2\\
            Console.WriteLine("Type the path of your folder what you want to sort:");
            StartDiryPath = Console.ReadLine();
            Console.WriteLine("Type the path of your destination folder:");
            DestDirPath = Console.ReadLine();
            Files = Directory.GetFileSystemEntries(StartDiryPath);
        }
        public void SortTheFolder()
        {
            foreach (var file in Files)
            {
                string ext = Path.GetExtension(file);
                if (Directory.Exists(file))
                {
                    SuperMoveToNewDirectory(startPath: file, destinationPath: DestDirPath, filesDateOfCreation: "", extension: "", foldersName: "folders", item: file);
                }
                else if (File.Exists(file))
                {
                    if (ext == ".avi" || ext == ".mp4")
                    {
                        SuperMoveToNewDirectory(startPath: file, destinationPath: DestDirPath, filesDateOfCreation: File.GetCreationTime(file).ToString().Replace(":", " "), extension: "", foldersName: "Movies", item: file);
                    }
                    else
                    {
                        SuperMoveToNewDirectory(startPath: file, destinationPath: DestDirPath, filesDateOfCreation: "", extension: ext, foldersName: "", item: file);
                    }
                }
            }
        }
        public void SuperMoveToNewDirectory(string startPath, string destinationPath, string extension, string foldersName, string filesDateOfCreation, string item)
        {
            Directory.CreateDirectory($"{destinationPath}{extension}{foldersName}");
            if (Directory.Exists(item))
            {
                Directory.Move(item, $@"{DestDirPath}{foldersName}\{new DirectoryInfo(item).Name}");
            }
            if (File.Exists(item))
            {
                File.Move(startPath, $@"{destinationPath}{foldersName}\{filesDateOfCreation}{extension}\{extension}");
            }
        }
    }
}
