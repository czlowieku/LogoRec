using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrameCopyier
{
    class Program
    {//"H:\klatki\Klatki Seweryn\CANALPLUSSPORT\2014-05-16\frames\CANALPLUSSPORT_2014-05-16_20-44-59.jpeg"
        static void Main(string[] args)
        {
            var fromPath = @"E:\MEDIA";
            var toPath = @"H:\klatki";
            
            var channelsToCopy = new[] {"CANALPLUS", "EUROSPORT", "CANALPLUSSPORT", "NSPORT", "POLSATSPORT", "TVPSPORT"};

            var fromDirInfo = new DirectoryInfo(fromPath);
            foreach (var mainDir in fromDirInfo.GetDirectories())
            {
                foreach (var klatkiDir in new DirectoryInfo(mainDir.FullName).GetDirectories())
                {
                    if (channelsToCopy.Contains(klatkiDir.Name))
                    {
                        var chanelDir = new DirectoryInfo(klatkiDir.FullName);
                        foreach (var dateDir in chanelDir.GetDirectories())
                        {

                            var pictdir = new DirectoryInfo(Path.Combine(dateDir.FullName, "frames"));
                            var copyToFolder = pictdir.FullName.Replace(fromPath, toPath);
                            Directory.CreateDirectory(copyToFolder);
                            foreach (var fileInfo in pictdir.GetFiles())
                            {
                                fileInfo.CopyTo(Path.Combine(copyToFolder, fileInfo.Name));
                            }

                        }

                    }
                }
            }

        }

      
    }
}
