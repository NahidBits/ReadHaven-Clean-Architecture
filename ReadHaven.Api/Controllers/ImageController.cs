using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("[controller]")]
public class ImageController : ControllerBase
{
    private readonly IWebHostEnvironment _env;

    public ImageController(IWebHostEnvironment env)
    {
        _env = env;
    }

    [HttpGet("File/{*filePath}")]
    public IActionResult GetFile(string filePath)
    {
        if (string.IsNullOrWhiteSpace(filePath))
            return BadRequest("File path is required.");

        var decodedPath = Uri.UnescapeDataString(filePath);

        var uploadsRoot = Path.Combine(_env.WebRootPath); 

        var fullPath = Path.GetFullPath(Path.Combine(uploadsRoot, decodedPath));

        // Security check
        if (!fullPath.StartsWith(uploadsRoot))
            return BadRequest("Invalid file path.");

        if (!System.IO.File.Exists(fullPath))
            return NotFound("File not found.");

        var fileStream = System.IO.File.OpenRead(fullPath);
        var contentType = GetContentType(fullPath);

        return File(fileStream, contentType);
    }

    private string GetContentType(string path)
    {
        var provider = new Microsoft.AspNetCore.StaticFiles.FileExtensionContentTypeProvider();
        if (!provider.TryGetContentType(path, out var contentType))
        {
            contentType = "application/octet-stream";
        }
        return contentType;
    }
}
