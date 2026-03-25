namespace SSY.Core;

public interface IOssService : ISingleton
{
    Task<string> UploadAsync(Stream stream, string objectName);
    Task<Stream> DownloadAsync(string objectName);
    Task DeleteAsync(string objectName);
}
