using Microsoft.AspNetCore.Http;
using ReadHaven.Application.Contracts.Services;
using Microsoft.AspNetCore.Hosting;


namespace ReadHaven.Infrastructure.Services;

public class FileService : IFileService
{
    private readonly IWebHostEnvironment _env;

    public FileService(IWebHostEnvironment env)
    {
        _env = env;
    }

    public async Task<string> SaveFileAsync(IFormFile file, string folderName)
    {
        var uploadDir = Path.Combine(_env.WebRootPath, folderName);
        if (!Directory.Exists(uploadDir))
            Directory.CreateDirectory(uploadDir);

        var uniqueFileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
        var filePath = Path.Combine(uploadDir, uniqueFileName);

        using (var fileStream = new FileStream(filePath, FileMode.Create))
        {
            await file.CopyToAsync(fileStream);
        }

        // Return relative path to store in DB
        return Path.Combine(folderName, uniqueFileName).Replace("\\", "/");
    }
}
