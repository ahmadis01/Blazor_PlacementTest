using System.IO;

namespace PlacementTestMangement.Server.Helper;

public static class HelperMethods
{
	public async static Task<string> UploadFile(IFormFile file, IWebHostEnvironment hostingEnvironment)
	{
		var extension = Path.GetExtension(file.FileName);
		var fileName = Guid.NewGuid();
		var folderPath = Path.Combine(hostingEnvironment.ContentRootPath, "wwwroot/images");
		if (!Directory.Exists(folderPath))
			Directory.CreateDirectory(folderPath);
		var fullPath = Path.Combine(folderPath, fileName + extension);
		string returnedPath = Path.Combine("images", fileName + extension);
		using (FileStream stream = new FileStream(fullPath, FileMode.Create))
		{
			await file.CopyToAsync(stream);
			stream.Close();
		}
		return returnedPath;
	}
}
