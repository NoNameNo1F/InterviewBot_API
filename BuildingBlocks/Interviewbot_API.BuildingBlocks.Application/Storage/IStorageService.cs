using Interviewbot_API.BuildingBlocks.Application.Common.Files;

namespace Interviewbot_API.BuildingBlocks.Application.Storage;

public interface IStorageService
{
    Task<List<string>> UploadAsync(ICollection<FileData> files);
}