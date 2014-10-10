using System.IO;

namespace MyTunes
{
    public interface IStreamLoader
    {
        Stream GetStreamForFilename(string filename);
    }
}