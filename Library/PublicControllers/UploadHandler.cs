namespace Library.PublicControllers
{
    public class UploadHandler
    {

        public string Upload(IFormFile file)
        {
            // // extention
            //List<string> validExtentions = new List<string>() { ".pdf", ".jpg" }; // file types allowed
            string extention = Path.GetExtension(file.FileName);
            //if (!validExtentions.Contains(extention))
            //{
            //return "Extention is not valid";
            //}

            // // file size
            //long size = file.Length;
            //if (size > 5 * 1024 * 1024)
            //{
            //return "Mazimim file size can only be 5 mb";
            //}

            // file changing
            string fileName = Guid.NewGuid().ToString() + extention;
            string path = Path.Combine(Directory.GetCurrentDirectory(), "Uploads");
            using FileStream stream = new FileStream(Path.Combine(path,fileName), FileMode.Create);
            file.CopyTo(stream);

            return fileName;
        }
    }
}
