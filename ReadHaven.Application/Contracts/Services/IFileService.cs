using Microsoft.AspNetCore.Http;

namespace ReadHaven.Application.Contracts.Services;

public interface IFileService
{
    Task<string> SaveFileAsync(IFormFile file, string folderName);
}
