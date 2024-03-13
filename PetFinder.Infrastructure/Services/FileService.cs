﻿using PetFinder.Infrastructure.Operations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetFinder.Infrastructure.Services
{
    public class FileService
    {

        private async Task<string> FileRenameAsync(string path, string fileName, int num = 1)
        {
            {
                // Get file extension
                string extension = Path.GetExtension(fileName);

                // Create new file name with -num suffix
                string oldName = $"{Path.GetFileNameWithoutExtension(fileName)}-{num}";
                string newFileName = $"{NameOperation.CharacterRegulatory(oldName)}{extension}";

                // Check if new file name already exists
                if (File.Exists($"{path}\\{newFileName}"))
                {
                    // If it does, increment num and try again
                    return await FileRenameAsync(path, $"{newFileName.Split($"-{num}")[0]}{extension}", ++num);
                }

                // If it doesn't, return new file name
                return newFileName;
            };
        }

    }
}
